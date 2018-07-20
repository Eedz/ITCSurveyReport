using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace ITCSurveyReportLib
{
    public enum HScheme { Sequential = 1, AcrossCountry = 2 }
    public enum HStyle { Classic = 1, TrackedChanges = 2 }
    /// <summary>
    /// This class compares two Survey objects. One survey is considered the 'primary' survey against which the other survey will be compared.
    /// 
    /// TODO test with the primary and Qnum survey being the same survey
    /// </summary>
    public class Comparison
    {
        Survey _primarySurvey;
        Survey _otherSurvey;     // this survey's raw table will be altered


        // data tables
        public DataTable changes;

        // general comparison options
        bool selfCompare;

        //
        bool hidePrimary;
        bool showDeletedFields;
        bool showDeletedQuestions;
        bool reInsertDeletions;
        bool hideIdenticalWordings;
        bool hideIdenticalQuestions;    // TODO
        bool showOrderChanges;          // TODO
        bool beforeAfterReport;         // TODO
        bool ignoreSimilarWords;        
        bool convertTrackedChanges;     // TODO
        bool matchOnRename;             // TODO

        // ordercomparisons
        bool includeWordings;           // TODO
        bool bySection;                 // TODO

        // highlight options
        
        bool highlight;                 // TODO
        HStyle highlightStyle;
        HScheme highlightScheme;
        bool highlightNR;
        bool hybridHighlight;

        public Comparison()
        {
            _primarySurvey = null;
            _otherSurvey = null;

            selfCompare = false;

            hidePrimary = false;
            showDeletedFields = true;
            showDeletedQuestions = true;
            reInsertDeletions = true;
            hideIdenticalWordings = false;
            hideIdenticalQuestions = false;
            showOrderChanges = false;
            beforeAfterReport = false;
            ignoreSimilarWords = false;
            convertTrackedChanges = false;
            matchOnRename = false;

            includeWordings = false;
            bySection = false;

            highlight = true;
            highlightStyle = HStyle.Classic;
            highlightScheme = HScheme.Sequential;
            highlightNR = true;
            hybridHighlight = false;
        }

        public Comparison(Survey p, Survey o)
        {
            _primarySurvey = p;
            _otherSurvey = o;

            selfCompare = false;

            hidePrimary = false;
            showDeletedFields = true;
            showDeletedQuestions = true;
            reInsertDeletions = true;
            hideIdenticalWordings = false;
            hideIdenticalQuestions = false;
            showOrderChanges = false;
            beforeAfterReport = false;
            ignoreSimilarWords = false;
            convertTrackedChanges = false;
            matchOnRename = false;

            includeWordings = false;
            bySection = false;

            highlight = true;
            highlightStyle = HStyle.Classic;
            highlightScheme = HScheme.Sequential;
            highlightNR = true;
            hybridHighlight = false;
        }

        // Use VarName as the basis for comparison (actually refVarName)
        public void CompareByVarName()
        {
            // Compare the English survey content
            CompareSurveyTables();

            // Compare translation records if at least one language was selected for each survey
            if (highlight)
                if (_primarySurvey.TransFields.Count >= 1 && _otherSurvey.TransFields.Count >= 1)
                    CompareTranslationTables();


        }


        /// <summary>
        /// For each translation in the non-primary survey, compare it to the same language in the primary survey.
        /// </summary>
        private void CompareTranslationTables()
        {
            DataRow[] foundRows;
            foreach (string t in _otherSurvey.TransFields)
            {
                // primary also contains this language
                if (!_primarySurvey.TransFields.Contains(t))
                    continue;
                
                foreach (DataRow rOther in _otherSurvey.translationTable.Rows)
                {
                    foundRows = _primarySurvey.translationTable.Select("refVarName = '" + rOther["refVarName"].ToString() + "'");
                    if (foundRows.Length == 0)
                    {
                        // if no matching rows are found in primary, this row is unique to other
                        if (highlightScheme == HScheme.Sequential)
                        {

                            if (!rOther["VarName"].Equals("")) { rOther["VarName"] = "[yellow]" + rOther["VarName"] + "[/yellow]"; }
                            if (!rOther[t].Equals("")) { rOther[t] = "[yellow]" + rOther[t] + "[/yellow]"; }

                        }
                        else if (highlightScheme == HScheme.AcrossCountry)
                        {
                            if (!rOther["VarName"].Equals("")) { rOther["VarName"] = "[yellow]" + rOther["VarName"] + "[/yellow]"; }
                        }
                    }
                    else
                    {
                        // if matching rows are found in dt1 (primary), compare the wording fields
                        foreach (DataRow r in foundRows)
                        {
                            CompareWordings(r, rOther, t);
                               
                        }
                    }
                       
                }
                
            }
            //other.translationTable.AcceptChanges();
        }

        //TODO accept a list of fields that should be compared, this would generalize the comparison so any 2 tables can be compared
        
        /// <summary>
        /// Compares rows in this Surveys' DataTable objects. The non-primary data table will contain highlighting tags where it differs from the primary data table.
        /// For rows that exist in only one of the tables, either color the whole question (Sequential), or just the VarName field (Across Country).
        /// </summary>
        private void CompareSurveyTables()
        {
            
            // Highlight questions in the 'other' survey
            if (highlight)
                ProcessNonPrimaryRows();

            // If we want to include those questions that are only in the primary survey, process them now
            // They will either be included at the end of the report, or inserted into their proper places
            if (showDeletedQuestions)
            {
                ProcessPrimaryOnlyRows();

                // if we are not re-inserting them, add heading for unmatched questions
                if (!reInsertDeletions)
                    AddUnmatchedQuestionsHeading();
            }

        }

        /// <summary>
        /// For any row that only appears in the primary survey, we need to either move it to the end of the survey, or re-insert it into its original position.
        /// </summary>
        private void ProcessPrimaryOnlyRows()
        {
            DataTable deletedQs; // holds the rows that only appear in the primary survey
            DataRow[] foundRows;

            DataRow toAdd;
            deletedQs = _primarySurvey.rawTable.Clone();

            // for each row that only exists in the primary table, add it to the non-primary table
            foreach (DataRow rPrime in _primarySurvey.rawTable.Rows)
            {

                foundRows = _otherSurvey.rawTable.Select("refVarName = '" + rPrime["refVarName"].ToString() + "'");
                if (foundRows.Length == 0)
                {
                    // row not found in non-primary table
                    // add it and colour it blue if we are re-inserting them 
                    // highlight the whole question if the surveys are part of the same country by differ by wave
                    // highlight the VarName only if the surveys are from different countries or differ by cohort/group
                    if (reInsertDeletions)
                    {
                        if (highlightScheme == HScheme.Sequential)
                        {
                            if (!rPrime["VarName"].Equals("")) { rPrime["VarName"] = "[s][t]" + rPrime["VarName"] + "[/t][/s]"; }
                            if (!rPrime["PreP"].Equals("")) { rPrime["PreP"] = "[s][t]" + rPrime["PreP"] + "[/t][/s]"; }
                            if (!rPrime["PreI"].Equals("")) { rPrime["PreI"] = "[s][t]" + rPrime["PreI"] + "[/t][/s]"; }
                            if (!rPrime["PreA"].Equals("")) { rPrime["PreA"] = "[s][t]" + rPrime["PreA"] + "[/t][/s]"; }
                            if (!rPrime["LitQ"].Equals("")) { rPrime["LitQ"] = "[s][t]" + rPrime["LitQ"] + "[/t][/s]"; }
                            if (!rPrime["PstI"].Equals("")) { rPrime["PstI"] = "[s][t]" + rPrime["PstI"] + "[/t][/s]"; }
                            if (!rPrime["PstP"].Equals("")) { rPrime["PstP"] = "[s][t]" + rPrime["PstP"] + "[/t][/s]"; }
                            if (!rPrime["RespOptions"].Equals("")) { rPrime["RespOptions"] = "[s][t]" + rPrime["RespOptions"] + "[/t][/s]"; }
                            if (!rPrime["NRCodes"].Equals("")) { rPrime["NRCodes"] = "[s][t]" + rPrime["NRCodes"] + "[/t][/s]"; }
                        }
                        else if (highlightScheme == HScheme.AcrossCountry)
                        {
                            if (!rPrime["VarName"].Equals("")) { rPrime["VarName"] = "[s][t]" + rPrime["VarName"] + "[/t][/s]"; }
                        }
                    }
                    // if we are including the deleted questions, copy the row, add it to the deletedQs table
                    toAdd = deletedQs.NewRow();
                    toAdd.ItemArray = rPrime.ItemArray;
 
                    toAdd["SortBy"] = "z" + toAdd["SortBy"];

                    deletedQs.Rows.Add(toAdd);
                    deletedQs.AcceptChanges();
                    // reject the changes to the original row in the primary table (blue highlighting)
                    rPrime.RejectChanges();
                    // but change the Qnum to add a 'z'
                    rPrime["SortBy"] = "z" + rPrime["SortBy"];
                    rPrime.AcceptChanges();
                }
            }

            // if we are re-inserting the deleted questions, they need to be renumbered with their location in the primary survey
            if (reInsertDeletions)
            {
                RenumberDeletions(deletedQs);

                // now merge the deleted questions table with the non-primary table 
                // change the primary key to the refVarName column, since there may be duplicate ID numbers (in the case of renames)
                _otherSurvey.rawTable.PrimaryKey = new DataColumn[] { _otherSurvey.rawTable.Columns["refVarName"] };
                _otherSurvey.rawTable.Merge(deletedQs);
            }
            
        }

        /// <summary>
        /// Add a row in both survey tables that acts as a heading for the unmatched questions. This heading will appear at the end of the list of matched questions, before the
        /// list of unmatched questions.
        /// </summary>
        private void AddUnmatchedQuestionsHeading()
        {
            DataRow toAdd;
            
            toAdd = _otherSurvey.rawTable.NewRow();
            toAdd["ID"] = "-1";
            toAdd["refVarName"] = "ZZ999";
            toAdd["VarName"] = "ZZ999";
            toAdd["Qnum"] = "z000";
            toAdd["SortBy"] = "z000";
            toAdd["PreP"] = "Unmatched Questions";
            toAdd["TableFormat"] = false;
            toAdd["CorrectedFlag"] = false;

            _otherSurvey.rawTable.Rows.Add(toAdd);
            _otherSurvey.rawTable.AcceptChanges();

            toAdd = _primarySurvey.rawTable.NewRow();
            toAdd["ID"] = "-1";
            toAdd["refVarName"] = "ZZ999";
            toAdd["VarName"] = "ZZ999";
            toAdd["Qnum"] = "z000";
            toAdd["SortBy"] = "z000";
            toAdd["PreP"] = "Unmatched Questions";
            toAdd["TableFormat"] = false;
            toAdd["CorrectedFlag"] = false;

            _primarySurvey.rawTable.Rows.Add(toAdd);
            _primarySurvey.rawTable.AcceptChanges();
            
        }

        /// <summary>
        /// Add highlighting to the non-primary survey.
        /// For any row not in the primary survey, color it yellow.
        /// For any common rows, compare the wordings and color them if they are different or missing.
        /// </summary>
        private void ProcessNonPrimaryRows()
        {
            DataRow[] foundRows;

            foreach (DataRow rOther in _otherSurvey.rawTable.Rows)
            {
                foundRows = _primarySurvey.rawTable.Select("refVarName = '" + rOther["refVarName"].ToString() + "'");

                if (foundRows.Length == 0)
                {
                    // if no matching rows are found in primary, this row is unique to other
                    // highlight the whole question if the surveys are part of the same country by differ by wave
                    // highlight the VarName only if the surveys are from different countries or differ by cohort/group
                    if (highlightScheme == HScheme.Sequential)
                    {
                        if (!rOther["VarName"].Equals("")) { rOther["VarName"] = "[yellow]" + rOther["VarName"] + "[/yellow]"; }
                        if (!rOther["PreP"].Equals("")) { rOther["PreP"] = "[yellow]" + rOther["PreP"] + "[/yellow]"; }
                        if (!rOther["PreI"].Equals("")) { rOther["PreI"] = "[yellow]" + rOther["PreI"] + "[/yellow]"; }
                        if (!rOther["PreA"].Equals("")) { rOther["PreA"] = "[yellow]" + rOther["PreA"] + "[/yellow]"; }
                        if (!rOther["LitQ"].Equals("")) { rOther["LitQ"] = "[yellow]" + rOther["LitQ"] + "[/yellow]"; }
                        if (!rOther["PstI"].Equals("")) { rOther["PstI"] = "[yellow]" + rOther["PstI"] + "[/yellow]"; }
                        if (!rOther["PstP"].Equals("")) { rOther["PstP"] = "[yellow]" + rOther["PstP"] + "[/yellow]"; }
                        if (!rOther["RespOptions"].Equals("")) { rOther["RespOptions"] = "[yellow]" + rOther["RespOptions"] + "[/yellow]"; }
                        if (!rOther["NRCodes"].Equals("")) { rOther["NRCodes"] = "[yellow]" + rOther["NRCodes"] + "[/yellow]"; }
                    }
                    else if (highlightScheme == HScheme.AcrossCountry)
                    {
                        if (!rOther["VarName"].Equals("")) { rOther["VarName"] = "[yellow]" + rOther["VarName"] + "[/yellow]"; }
                    }
                    rOther.AcceptChanges();
                }
                else
                {
                    // if matching rows are found in primary, compare the wording fields
                    foreach (DataRow r in foundRows)
                    {
                        CompareWordings(r, rOther, "PreP");
                        CompareWordings(r, rOther, "PreI");
                        CompareWordings(r, rOther, "PreA");
                        CompareWordings(r, rOther, "LitQ");
                        CompareWordings(r, rOther, "PstI");
                        CompareWordings(r, rOther, "PstP");
                        CompareWordings(r, rOther, "RespOptions");
                        if (highlightNR) { CompareWordings(r, rOther, "NRCodes"); }
                    }
                }
            }
           
        }

        public void RenumberDeletions (DataTable deletedQs)
        {
            // for each row in deletedQs where the qnum starts with z, 
            // we need to find the last common varname between the 2 tables, set the qnum of the row to that common row's qnum + the z-qnum
            var foundRows = deletedQs.Select("SortBy Like 'z%'");
            string varname;
            string previousvar;
            string previousqnum = "";
            foreach (DataRow r in foundRows)
            {
                varname = (string) r["VarName"];
                varname = varname.Replace("[s][t]", "");
                varname = varname.Replace("[/t][/s]", "");

                for (int i = 0; i < _primarySurvey.rawTable.Rows.Count; i ++)
                {
                    if (_primarySurvey.rawTable.Rows[i]["VarName"].Equals(varname))
                    {
                        if (i == 0)
                        {
                            previousqnum = "000";
                        }
                        else
                        {
                            previousvar = (string)_primarySurvey.rawTable.Rows[i - 1]["VarName"];
                            previousqnum = GetPreviousCommonVar(varname);
                        }
                        break;
                    }
                }
                r["SortBy"] = previousqnum + r["SortBy"];
                r.AcceptChanges();
            }
        }

        /// <summary>
        /// Returns the VarName of the last common VarName between 2 datatables, starting from a specified VarName.
        /// </summary>
        /// <param name="varname">The starting point from which we will look back to find the first common VarName.</param>
        /// <returns>Returns the Qnum of the first common VarName that occurs before the specified VarName. If there are no common VarNmaes before this VarName, returns '000'.</returns>
        private string GetPreviousCommonVar (string varname)
        {
            string previousQnum = "";
            string prev = "";
            string curr = "";
            DataView dt1 = _primarySurvey.rawTable.DefaultView;
            dt1.Sort = "SortBy ASC";
            DataView dt2 = _otherSurvey.rawTable.DefaultView;
            dt2.Sort = "SortBy ASC";

            DataTable sorted1 = dt1.ToTable();
            DataTable sorted2 = dt2.ToTable();

            for (int i = dt1.ToTable().Rows.Count-1; i >= 0; i--)
            {
                curr = (string)sorted1.Rows[i]["VarName"];
                curr = curr.Replace("[s][t]", "");
                curr = curr.Replace("[/t][/s]", "");

                if (curr.Equals(varname))
                {
                    // get the previous var in dt1
                    if (i == 0)
                    {
                        prev = "";
                        break;
                    }
                    else
                    {
                        prev = (string)sorted1.Rows[i - 1]["VarName"];
                        prev = prev.Replace("[s][t]", "");
                        prev = prev.Replace("[/t][/s]", "");
                        // check if it exists in dt2
                        var foundRow = sorted2.Select("VarName = '" + prev + "'");

                        if (foundRow.Length != 0)
                        {
                            previousQnum = (string)foundRow[0]["Qnum"];
                            break;
                        }
                        else
                        {
                            varname = (string)sorted1.Rows[i - 1]["VarName"];
                        }
                    }
                }
            }

            if (prev.Equals(""))
                previousQnum = "000";
           
       
            return previousQnum;
        }

        public void CompareVars(DataRow rPrime, DataRow rOther)
        {
            if (rPrime == null) // if rPrime is null, yellow
            {
                if (!rOther["PreP"].Equals("")) {rOther["PreP"] = "[yellow]" + rOther["PreP"] + "[/yellow]"; }
                if (!rOther["PreI"].Equals("")) { rOther["PreI"] = "[yellow]" + rOther["PreI"] + "[/yellow]"; }
                if (!rOther["PreA"].Equals("")) { rOther["PreA"] = "[yellow]" + rOther["PreA"] + "[/yellow]"; }
                if (!rOther["LitQ"].Equals("")) { rOther["LitQ"] = "[yellow]" + rOther["LitQ"] + "[/yellow]"; }
                if (!rOther["PstI"].Equals("")) { rOther["PstI"] = "[yellow]" + rOther["PstI"] + "[/yellow]"; }
                if (!rOther["PstP"].Equals("")) { rOther["PstP"] = "[yellow]" + rOther["PstP"] + "[/yellow]"; }
                if (!rOther["RespOptions"].Equals("")) { rOther["RespOptions"] = "[yellow]" + rOther["RespOptions"] + "[/yellow]"; }
                if (!rOther["NRCodes"].Equals("")) { rOther["NRCodes"] = "[yellow]" + rOther["NRCodes"] + "[/yellow]"; }
                rOther.AcceptChanges();
            }else if (rOther == null) // if rOther is null, blue
            {
                if (!rPrime["PreP"].Equals("")) { rPrime["PreP"] = "[t][s]" + rPrime["PreP"] + "[/s][/t]"; }
                if (!rPrime["PreI"].Equals("")) { rPrime["PreI"] = "[t][s]" + rPrime["PreI"] + "[/s][/t]"; }
                if (!rPrime["PreA"].Equals("")) { rPrime["PreA"] = "[t][s]" + rPrime["PreA"] + "[/s][/t]"; }
                if (!rPrime["LitQ"].Equals("")) { rPrime["LitQ"] = "[t][s]" + rPrime["LitQ"] + "[/s][/t]"; }
                if (!rPrime["PstI"].Equals("")) { rPrime["PstI"] = "[t][s]" + rPrime["PstI"] + "[/s][/t]"; }
                if (!rPrime["PstP"].Equals("")) { rPrime["PstP"] = "[t][s]" + rPrime["PstP"] + "[/s][/t]"; }
                if (!rPrime["RespOptions"].Equals("")) { rPrime["RespOptions"] = "[t][s]" + rPrime["RespOptions"] + "[/s][/t]"; }
                if (!rPrime["NRCodes"].Equals("")) { rPrime["NRCodes"] = "[t][s]" + rPrime["NRCodes"] + "[/s][/t]"; }
                rPrime.AcceptChanges();
            }
            

        }

        
        public void CompareWordings (DataRow rPrime, DataRow rOther, String fieldname)
        {
            //String highlightStartNew;
            //String highlightEndNew;
            //String highlightStartDiff;
            //String highlightEndDiff;
            //String highlightStartMiss;
            //String highlightEndMiss;

            //bool highlightVar;
            //bool highlightWord;

            string primaryWording = (string)rPrime[fieldname];
            string otherWording = (string)rOther[fieldname];

            //switch (highlightStyle) {
            //    case HStyle.Classic:

            //        if (highlightScheme == HScheme.Sequential)
            //        {
            //            highlightVar = true;
            //            highlightWord = true;
            //        } else if (highlightScheme == HScheme.AcrossCountry)
            //        {
            //            highlightVar = true;
            //            highlightWord = false;
            //        }
            //        highlightStartNew = "[yellow]";
            //        highlightEndNew = "[/yellow]";

            //        highlightStartDiff = "[brightgreen]";
            //        highlightEndDiff = "[/brightgreen]";

            //        highlightStartMiss = "[t][s]";
            //        highlightEndMiss = "[/s][/t]";
            //        break;
            //    case HStyle.TrackedChanges:

            //        break;

            //}



            //if (primaryWording.Equals(otherWording)){
            if (IsWordingEqual(primaryWording,otherWording))
            {
                if (hideIdenticalWordings) { rOther[fieldname] = "";}
            }
            else
            {
                if (otherWording.Equals("") && showDeletedFields)
                {
                    rOther[fieldname] = "[t][s]" + rPrime[fieldname] + "[/t][/s]";
                }else if (primaryWording.Equals(""))
                {
                    rOther[fieldname] = "[yellow]" + rOther[fieldname] + "[/yellow]";
                }
                else
                {
                    if (hybridHighlight)
                    {
                        // tracked changes  and brightgreen
                        rOther[fieldname] = "[brightgreen]" + rOther[fieldname] + "[/brightgreen]";
                    }
                    else
                    {
                        rOther[fieldname] = "[brightgreen]" + rOther[fieldname] + "[/brightgreen]";
                    }
                }
            }
            rOther.AcceptChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="ignorePunctuation"></param>
        /// <param name="ignoreSimilarWords"></param>
        /// <returns></returns>
        private bool IsWordingEqual (string str1, string str2, bool ignorePunctuation = true, bool ignoreSimilarWords = true)
        {
            DataTable similarWords;
            string[] words;
            if (str1.Equals("") && str2.Equals(""))
                return true;

            // ignore similar words
            if (ignoreSimilarWords)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString))
                {
                    using (SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM qryAlternateSpelling", conn))
                    {
                        similarWords = new DataTable();
                        sql.Fill(similarWords);

                        foreach (DataRow r in similarWords.Rows)
                        {
                            words = r["word"].ToString().Split(',');

                            for (int i = 0; i < words.Length; i++)
                            {
                                words[i] = words[i].Trim(' ');

                                str1 = str1.Replace(words[i], words[0]);
                                str2 = str2.Replace(words[i], words[0]);
                            }
                        }
                    }
                }
            }

            // remove tags
            str1 = Utilities.RemoveTags(str1);
            str2 = Utilities.RemoveTags(str2);

            // ignore punctuation
            if (ignorePunctuation)
            {
                str1 = str1.Replace("&lt;", "<");
                str2 = str2.Replace("&lt;", "<");

                str1 = str1.Replace("&gt;", ">");
                str2 = str2.Replace("&gt;", ">");

                str1 = Utilities.StripChars(str1, "0123456789 abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ <>=");
                str2 = Utilities.StripChars(str2, "0123456789 abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ <>=");
            }

            // remove line breaks
            str1 = str1.Replace("\r", string.Empty);
            str1 = str1.Replace("\n", string.Empty);

            str2 = str2.Replace("\r", string.Empty);
            str2 = str2.Replace("\n", string.Empty);


            // remove spaces
            while (str1.IndexOf(' ') > 0)
                str1 = str1.Replace(" ", string.Empty);

            while (str2.IndexOf(' ') > 0)
                str2 = str2.Replace(" ", string.Empty);

            if (!str1.Equals(str2))
                return false;
            else
                return true;
            
        }




        #region Topic/Label Comparison
        // TODO consider making this another class
        // TODO create method for getting question text
        // TODO create method for getting SortBy (even for Qnum survey)


        /// <summary>
        /// Returns a DataTable containing all combinations of Topic and Content labels found in the survey list. Each question that appears under these 
        /// combinations is displayed under it's own survey heading. The table is sorted by the Qnum from the first survey and any labels not found in that 
        /// survey are collected at the bottom of the table.
        /// </summary>
        public DataTable CreateTCReport(List<Survey> surveyList) {
            DataTable report = new DataTable();
            DataRow newrow;            
            string currentT;
            string currentC;
            string qs = "";
            string firstQnum = "";
            string otherFirstQnum = "";
            DataRow[] foundRows;
            Survey qnumSurvey = null;

            // start with a table containing all Topic/Content combinations present in the surveys
            report = CreateTCBaseTable(surveyList);

            foreach (Survey s in surveyList)
            {
                if (s.Qnum) qnumSurvey = s;
            }

            // for each T/C combination, add each survey's questions that match 
            // there should be one row for each T/C combo, so we need to concatenate all questions with that combo
            foreach (DataRow tc in report.Rows)
            {
                currentC = (string)tc["Info"];
                currentC = currentC.Substring(currentC.IndexOf("<em>") + 4, currentC.IndexOf("</em>") - currentC.IndexOf("<em>")-4);
                currentC = currentC.Replace("'", "''");

                currentT = (string)tc["Info"];
                currentT = currentT.Substring(8, currentT.IndexOf("</strong>") - 8);
                currentT = currentT.Replace("'", "''");

                // now for each survey, add the questions that match the topic content pair
                foreach (Survey s in surveyList)
                {
                    foundRows = s.finalTable.Select("Topic = '" + currentT + "' AND Content = '" + currentC + "'");
                    foreach (DataRow r in foundRows)
                    {
                        if (firstQnum.Equals(""))
                            firstQnum = (string)r["Qnum"];

                        qs += r[s.SurveyCode] + "\r\n\r\n";
                    }

                    qs = Utilities.TrimString(qs, "\r\n\r\n");
                    tc[s.SurveyCode] = qs;
                    if (s.Qnum)
                    {
                        tc["SortBy"] = firstQnum;
                        tc["Qnum"] = firstQnum;
                    }
                    else
                    {

                        if (tc["SortBy"] == DBNull.Value || tc["SortBy"].Equals(""))
                        {
                            otherFirstQnum = GetFirstQnum(currentT, currentC, qnumSurvey);

                            if (otherFirstQnum.Equals("z"))
                                firstQnum = otherFirstQnum + firstQnum;
                            else
                                firstQnum = otherFirstQnum;

                            tc["SortBy"] = firstQnum;
                        }
                    }
                    qs = "";
                    firstQnum = "";
                }
                tc.AcceptChanges();
            }
            // add a row to start the section for unmatched labels (labels that do not exist in the Qnum survey)
            newrow = report.NewRow();
            newrow["Info"] = "<strong>Unmatches Labels</strong>";
            newrow["SortBy"] = "z000";
            report.Rows.Add(newrow);
            report.AcceptChanges();

            return report;
        }


        /// <summary>
        /// Get sortby by looking for the topic label and content label in the qnum survey and using that qnum
        /// if the content label isnt there, use the qnum for the last instance of the topic label, adding !00 to it
        /// if neither are there, use z
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="content"></param>
        /// <param name="qnumSurvey"></param>
        /// <returns>string. The first Qnum that contains the provided Topic and Content labels</returns>
        private string GetFirstQnum(string topic, string content, Survey qnumSurvey)
        {
            string firstQnum;
            DataRow[] foundRows;
            foundRows = qnumSurvey.finalTable.Select("Topic = '" + topic + "' AND Content = '" + content + "'");
            
            if (foundRows.Count() != 0)
            {
                firstQnum = (string)foundRows[0]["Qnum"];
            }
            else
            {
                foundRows = qnumSurvey.finalTable.Select("Topic = '" + topic + "'");
                if (foundRows.Count() != 0)
                {
                    firstQnum = (string)foundRows[0]["Qnum"] + "!00";
                }
                else
                {
                    firstQnum = "z";
                }
            }

            return firstQnum;
        }

        /// <summary>
        /// Create a DataTable that contains the all the Topic/Content combinations found in the list of surveys. A column for each survey is also created.
        /// </summary>
        private DataTable CreateTCBaseTable(List<Survey> surveyList)
        {
            DataTable report = new DataTable();
            List<string> topicContent = new List<string>();
            string currentTC;
            DataRow newrow;
            report.Columns.Add(new DataColumn("Info", System.Type.GetType("System.String")));
            report.Columns.Add(new DataColumn("Qnum", System.Type.GetType("System.String")));
            report.Columns.Add(new DataColumn("SortBy", System.Type.GetType("System.String")));

            foreach (Survey s in surveyList)
            {
                report.Columns.Add(new DataColumn(s.SurveyCode, System.Type.GetType("System.String")));
                
                foreach (DataRow r in s.finalTable.Rows)
                {
                    currentTC = "<strong>" + r["Topic"] + "</strong>\r\n<em>" + r["Content"] + "</em>";
                    if (!topicContent.Contains(currentTC))
                        topicContent.Add(currentTC);

                }
            }

            // now add each topic content pair to the table
            for (int i = 0; i < topicContent.Count; i++)
            {
                newrow = report.NewRow();
                newrow["Info"] = topicContent[i];
                report.Rows.Add(newrow);
                report.AcceptChanges();
            }

            return report;
        }
        #endregion

        #region Order Comparison
        private void CompareSurveyOrder()
        {

        }
        #endregion

        #region LINQ attempts
        // Marks differences between 2 tables in the specified field
        // Get all rows that differ in the specified field. Then, insert [brightgreen] tags around the entire field.
        public void CompareField<T>(DataTable dt1, DataTable dt2, String fieldname)
        {
            var results = from table2 in dt2.AsEnumerable()
                          join table1 in dt1.AsEnumerable() on table2.Field<string>("refVarName") equals table1.Field<string>("refVarName")
                          where !table2.Field<T>(fieldname).Equals(table1.Field<T>(fieldname))
                          select table2;

            foreach (DataRow r in results)
            {
                if (r[fieldname].Equals(""))
                {
                    // blue?
                    r[fieldname] = "[yellow]" + r[fieldname] + "[/yellow]";
                }
                else
                {
                    r[fieldname] = "[brightgreen]" + r[fieldname] + "[/brightgreen]";
                }

                r.AcceptChanges();

            }
        }

        // Marks unique variables 
        public void CompareVars(DataTable dt1, DataTable dt2)
        {
            var results = from table2 in dt2.AsEnumerable()
                          join table1 in dt1.AsEnumerable() on table2.Field<string>("refVarName") equals table1.Field<string>("refVarName") into a
                          from table1 in a.DefaultIfEmpty()
                          where table1 == null
                          select table2;

            foreach (DataRow r in results)
            {
                r["PreP"] = "[yellow]" + r["PreP"] + "[/yellow]";
                r["PreI"] = "[yellow]" + r["PreI"] + "[/yellow]";
                r["PreA"] = "[yellow]" + r["PreA"] + "[/yellow]";
                r["LitQ"] = "[yellow]" + r["LitQ"] + "[/yellow]";
                r["PstI"] = "[yellow]" + r["PstI"] + "[/yellow]";
                r["PstP"] = "[yellow]" + r["PstP"] + "[/yellow]";
                r["RespOptions"] = "[yellow]" + r["RespOptions"] + "[/yellow]";
                r["NRCodes"] = "[yellow]" + r["NRCodes"] + "[/yellow]";
                r.AcceptChanges();

            }
        }
        #endregion

        public override string ToString()
        {
            PropertyInfo[] _PropertyInfos = null;
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

        public bool SelfCompare { get => selfCompare; set => selfCompare = value; }

        [CategoryAttribute("Layout Options"), DescriptionAttribute("Hide the primary survey.")]
        public bool HidePrimary { get => hidePrimary; set => hidePrimary = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Show deleted fields in blue.")]
        public bool ShowDeletedFields { get => showDeletedFields; set => showDeletedFields = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Show deleted questions (depends on Scheme).")]
        public bool ShowDeletedQuestions { get => showDeletedQuestions; set => showDeletedQuestions = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Re-insert deleted questions after the last common question.")]
        public bool ReInsertDeletions { get => reInsertDeletions; set => reInsertDeletions = value; }
        [CategoryAttribute("Layout Options"), DescriptionAttribute("Hide identical wording fields.")]
        public bool HideIdenticalWordings { get => hideIdenticalWordings; set => hideIdenticalWordings = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight changes to the order or questions.")]
        public bool ShowOrderChanges { get => showOrderChanges; set => showOrderChanges = value; }
        [CategoryAttribute("Layout Options"), DescriptionAttribute("Create a 3-column report in old-marked-new order.")]
        public bool BeforeAfterReport { get => beforeAfterReport; set => beforeAfterReport = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Ignore words with alternate spellings (honor/honour).")]
        public bool IgnoreSimilarWords { get => ignoreSimilarWords; set => ignoreSimilarWords = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Convert tracked changes highlighting to actual tracked changes.")]
        public bool ConvertTrackedChanges { get => convertTrackedChanges; set => convertTrackedChanges = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Try to match questions based on previous names.")]
        public bool MatchOnRename { get => matchOnRename; set => matchOnRename = value; }

        

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight differences between surveys."), DefaultValueAttribute(true)]
        public bool Highlight { get => highlight; set => highlight = value; }

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Classic (Green, Yellow, Blue) or Tracked Changes."), DisplayNameAttribute("Style"), DefaultValueAttribute(1)]
        public HStyle HighlightStyle { get => highlightStyle; set => highlightStyle = value; }

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Determines how deleted questions are shown."), DisplayNameAttribute("Scheme"),DefaultValueAttribute(1)]
        public HScheme HighlightScheme { get => highlightScheme; set => highlightScheme = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight changes in the Non-response field."), DefaultValueAttribute(true)]
        public bool HighlightNR { get => highlightNR; set => highlightNR = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("For wording differences, use both Green and Tracked Changes."), DefaultValueAttribute(false)]
        public bool HybridHighlight { get => hybridHighlight; set => hybridHighlight = value; }

        [CategoryAttribute("Order Comparisons"), DescriptionAttribute("Include a column for the wordings."), DefaultValueAttribute(false)]
        public bool IncludeWordings { get => includeWordings; set => includeWordings = value; }
        [CategoryAttribute("Order Comparisons"), DescriptionAttribute("Display the report by section."), DefaultValueAttribute(false)]
        public bool BySection { get => bySection; set => bySection = value; }
        public Survey PrimarySurvey { get => _primarySurvey; set => _primarySurvey = value; }
        public Survey OtherSurvey { get => _otherSurvey; set => _otherSurvey = value; }
        public bool HideIdenticalQuestions { get => hideIdenticalQuestions; set => hideIdenticalQuestions = value; }
    }
}
