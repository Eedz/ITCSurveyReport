using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace ITCSurveyReport
{
    public class Comparison
    {
        // data tables
        public DataTable changes;

        // general comparison options
        bool selfCompare;
        bool doCompare; // 

        //
        bool hidePrimary;
        bool showDeletedFields;
        bool showDeletedQuestions;
        bool reInsertDeletions;
        bool hideIdenticalWordings;
        bool showOrderChanges;
        bool beforeAfterReport;
        bool ignoreSimilarWords;
        bool convertTrackedChanges;
        bool matchOnRename;

        // ordercomparisons
        bool includeWordings;
        bool bySection;

        // highlight options
        public enum HScheme { Sequential = 1, AcrossCountry = 2 }
        public enum HStyle { Classic = 1, TrackedChanges = 2 }
        bool highlight;
        HStyle highlightStyle;
        HScheme highlightScheme;
        bool highlightNR;
        bool hybridHighlight;

        public Comparison()
        {
            selfCompare = false;
            doCompare = false;

            hidePrimary = false;
            showDeletedFields = true;
            showDeletedQuestions = true;
            reInsertDeletions = true;
            hideIdenticalWordings = false;
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


        public void CompareByMerge(List<Survey> SurveyList)
        {
            DataTable primary = new DataTable();
            DataTable other = new DataTable();

            foreach (Survey s in SurveyList)
            {
                if (s.Primary)
                {
                    primary = s.rawTable;
                    break;
                }
            }

            foreach (Survey s in SurveyList)
            {

            }
        }

        public void CompareByVarName(List<Survey> SurveyList) {
            DataTable primary = new DataTable();
            DataTable other = new DataTable();

            foreach (Survey s in SurveyList)
            {
                if (s.Primary) {
                    primary = s.rawTable;
                    break;
                }
            }

            foreach (Survey s in SurveyList)
            {
                if (!s.Primary) {
                    other = s.rawTable;
                    CompareSurveyTables(primary, other);
                }   
            }
        }

        /// <summary>
        /// Compares rows in 2 DataTable objects.
        /// </summary>
        public void CompareSurveyTables(DataTable dt1, DataTable dt2)
        {
            DataTable deletedQs;
            DataRow[] foundRows;
            foreach (DataRow rOther in dt2.Rows)
            {
                foundRows = dt1.Select("refVarName = '" + rOther["refVarName"].ToString() + "'");

                
                if (foundRows.Length == 0)
                {
                    // if no matching rows are found in dt1 (primary), this row is unique to dt2 (other)
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
                    
                    
                }
                else
                {
                    // if matching rows are found in dt1 (primary), compare the wording fields
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
            DataRow toAdd;
            deletedQs = dt1.Clone();
            // now get all rows that are unique to dt1 (primary)
            foreach (DataRow rPrime in dt1.Rows)
            {
                
                foundRows = dt2.Select("refVarName = '" + rPrime["refVarName"].ToString() + "'");
                if (foundRows.Length == 0)
                {
                    // row not found in dt2 (other) so add it to dt2 and colour it blue
                    if (highlightScheme == HScheme.Sequential)
                    {
                        // if the extra dt1 rows are to be re-inserted, colour them blue
                        if (reInsertDeletions)
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
                        
                    }
                    else if (highlightScheme == HScheme.AcrossCountry)
                    {
                        if (!rPrime["VarName"].Equals("")) { rPrime["VarName"] = "[yellow]" + rPrime["VarName"] + "[/yellow]"; }

                    }
                    if (showDeletedQuestions)
                    {

                        if (reInsertDeletions)
                        {
                            toAdd = deletedQs.NewRow();
                            toAdd.ItemArray = rPrime.ItemArray;
                            toAdd["SortBy"] = "z" + toAdd["SortBy"];
                            
                            deletedQs.Rows.Add(toAdd);
                            deletedQs.AcceptChanges();
                        }
                        rPrime.RejectChanges();
                    }
                    
                    

                }

                
            }
            // if we are not re-inserting deletions, add a heading for the deleted questions, which will apear at the end of the table.
            if (showDeletedQuestions && !reInsertDeletions)
            {
                toAdd = dt2.NewRow();
                toAdd["ID"] = "-1";
                toAdd["refVarName"] = "ZZ999";
                toAdd["VarName"] = "ZZ999";
                toAdd["Qnum"] = "z999";
                toAdd["SortBy"] = "z999";
                toAdd["PreP"] = "Unmatched Questions";
                toAdd["TableFormat"] = false;
                toAdd["CorrectedFlag"] = false;

                dt2.Rows.Add(toAdd);
                
                dt2.AcceptChanges();

                toAdd = dt1.NewRow();
                toAdd["ID"] = "-1";
                toAdd["refVarName"] = "ZZ999";
                toAdd["VarName"] = "ZZ999";
                toAdd["Qnum"] = "z999";
                toAdd["SortBy"] = "z999";
                toAdd["PreP"] = "Unmatched Questions";
                toAdd["TableFormat"] = false;
                toAdd["CorrectedFlag"] = false;

                dt1.Rows.Add(toAdd);
                dt1.AcceptChanges();
            }

            if (reInsertDeletions)
            {
                RenumberDeletions(dt1, dt2, deletedQs);
            }
            dt2.Merge(deletedQs);
        }

        public void RenumberDeletions (DataTable dt1, DataTable dt2, DataTable deletedQs)
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

                for (int i = 0; i < dt1.Rows.Count; i ++)
                {
                    if (dt1.Rows[i]["VarName"].Equals(varname))
                    {
                        if (i == 0)
                        {
                            previousqnum = "000";
                        }
                        else
                        {
                            previousvar = (string)dt1.Rows[i - 1]["VarName"];
                            previousqnum = GetPreviousCommonVar(dt1, dt2, varname);
                            
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
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="varname"></param>
        /// <returns></returns>
        private string GetPreviousCommonVar (DataTable dt1, DataTable dt2, string varname)
        {
            string previousQnum = "";
            string prev = "";
            string curr = "";
            for (int i = dt1.Rows.Count-1; i >= 0; i--)
            {
                curr = (string)dt1.Rows[i]["VarName"];
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
                        prev = (string)dt1.Rows[i - 1]["VarName"];
                        prev = prev.Replace("[s][t]", "");
                        prev = prev.Replace("[/t][/s]", "");
                        // check if it exists in dt2
                        var foundRow = dt2.Select("VarName = '" + prev + "'");

                        if (foundRow.Length != 0)
                        {
                            previousQnum = (string)foundRow[0]["Qnum"];
                            break;
                        }
                        else
                        {
                            varname = (string)dt1.Rows[i - 1]["VarName"];
                        }
                    }
                }
            }

            if (prev.Equals(""))
                previousQnum = "000";
           
            


            // if it does, return the var, if not, try again
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

        // TODO ignore punctuation and spacing
        public void CompareWordings (DataRow rPrime, DataRow rOther, String fieldname)
        {
            String highlightStartNew;
            String highlightEndNew;
            String highlightStartDiff;
            String highlightEndDiff;
            String highlightStartMiss;
            String highlightEndMiss;

            bool highlightVar;
            bool highlightWord;

            switch (highlightStyle) {
                case HStyle.Classic:

                    if (highlightScheme == HScheme.Sequential)
                    {
                        highlightVar = true;
                        highlightWord = true;
                    } else if (highlightScheme == HScheme.AcrossCountry)
                    {
                        highlightVar = true;
                        highlightWord = false;
                    }
                    highlightStartNew = "[yellow]";
                    highlightEndNew = "[/yellow]";

                    highlightStartDiff = "[brightgreen]";
                    highlightEndDiff = "[/brightgreen]";

                    highlightStartMiss = "[t][s]";
                    highlightEndMiss = "[/s][/t]";
                    break;
                case HStyle.TrackedChanges:
                    
                    break;

            }
            
            if (rPrime[fieldname].Equals(rOther[fieldname])){
                if (hideIdenticalWordings) { rOther[fieldname] = "";}
            }
            else
            {
                if (rOther[fieldname].Equals("") && showDeletedFields)
                {
                    rOther[fieldname] = "[t][s]" + rPrime[fieldname] + "[/t][/s]";
                }else if (rPrime[fieldname].Equals(""))
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

        #region Topic/Label Comparison
        public void CreateTCReport() { }
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

        public bool DoCompare { get => doCompare; set => doCompare = value; }
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


    }
}
