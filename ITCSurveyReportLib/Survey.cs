﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Text.RegularExpressions;

//using System.Runtime.CompilerServices;

namespace ITCSurveyReport
{
    // TODO make a base class called Survey, and another called SurveyDataTable which extends DataTable and make it a member of Survey 
    // SurveyDataTable will have all the methods that act on the rawTable 
    // Survey will have the methods that act on the final table and other auxilliary tables
    public class Survey 
    {
        #region Survey Properties
        // properties for the base class
        // TODO fill in these values during creation of object
        string languages;
        string title;
        string groups;
        string mode;
        int cc;
        bool hasQID;    // this flag is true if the survey records have an ID field at the chosen date TODO implement in GetSurveyTable/GetBackupTable

        SqlDataAdapter sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

        SurveyDataTable rawTable2;
        
        DataSet SurveyDataSet;
        // data tables for this survey 
        public DataTable rawTable;              // raw survey content, separated into fields
        public DataTable commentTable;          // table holding comments
        public DataTable translationTable;      // table holding all translations
        public DataTable filterTable;           // table holding filters
        // table holding the final output, this would be a combination of fields from rawTable, merged with commentTable, translationTable, and filterTable
        public DataTable finalTable;            

        public DataTable qnumTable;             // table holding the complete list of Qnums, AltQnums for each VarName (used if the rawTable is filtered)

        //Dictionary<int, Variable> questions;  // Variable object not yet implemented

        int id;                                 // unique id, NOT the database ID
        String surveyCode;
        
        DateTime backend;                         // file name of backup
        String webName;                         // the long name of this survey

        // filters are currently report-level but that may change
        int qRangeLow;
        int qRangeHigh;
        List<String> prefixes;
        String[] headings;
        List<String> varnames;

        // comment filters
        DateTime? commentDate;
        List<int> commentAuthors; // make a class of names?
        List<int> commentSources;

        // fields
        List<String> repeatedFields;
        List<String> commentFields;
        List<String> transFields;
        List<String> stdFields;
        List<String> stdFieldsChosen;
        bool varlabelCol;
        bool domainLabelCol;
        bool topicLabelCol;
        bool contentLabelCol;
        bool productLabelCol;
        bool filterCol;
        bool commentCol;

        String essentialList; // comma-separated list of essential varnames (and their Qnums) in this survey

        //attributes
        bool primary;   // true if this is the primary survey
        bool qnum;      // true if this is the qnum-defining survey
        bool corrected; // true if this uses corrected wordings
        bool marked;    // true if the survey contains tracked changes (for 3-way report)

        // report level options
        bool includePrevNames;
        bool excludeTempNames;
        bool qnInsertion;
        bool aqnInsertion;
        bool ccInsertion;
        bool inlineRouting;
        Enumeration numbering;
        ReadOutOptions nrFormat;
        bool showAllQnums;
        bool subsetTables;
        bool subsetTablesTranslation;
        bool showLongLists;

        // errors and results
        // qnu list

        #endregion

        #region Constructors
        // blank constructor
        // TODO create constructors for quick reports + auto surveys
        public Survey() {
            

            surveyCode = "";
            backend = DateTime.Today;
            webName = "";

            SurveyDataSet = new DataSet("Survey" + id);
            sql = new SqlDataAdapter();
            rawTable = new DataTable();

            qRangeLow = 0;
            qRangeHigh = 0;
            prefixes = new List<String>();
            varnames = new List<String>();
            headings = null;

            commentDate = null;
            commentAuthors = new List<int>();
            commentSources = new List<int>();

            repeatedFields = new List<String>();
            commentFields = new List<String>();
            transFields = new List<String>();

            stdFields = new List<String>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };
            
            varlabelCol = false;
            domainLabelCol = false;
            topicLabelCol = false;
            contentLabelCol = false;
            filterCol = false;
            commentCol = false;

            essentialList = "";

            primary = false;  
            qnum = false ;     
            corrected = false ;
            marked  =false;

            includePrevNames = false;
            excludeTempNames = true;
            numbering = Enumeration.Qnum;
            nrFormat = ReadOutOptions.Neither;
            showAllQnums = false;
            subsetTables = false;
            subsetTablesTranslation = false;
            showLongLists = false;
        }

        public Survey(string code)
        {
            sql = new SqlDataAdapter();
            String query = "SELECT * FROM qrySurveyInfo WHERE Survey = @survey";
            SqlParameter param = new SqlParameter("@survey", SqlDbType.VarChar, 50);
            param.Value = code;
            
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.Add(param);
            SqlDataReader rdr = sql.SelectCommand.ExecuteReader();
            rdr.Read();
            surveyCode = (string) rdr["Survey"];
            if (!rdr.IsDBNull(rdr.GetOrdinal("Languages"))) { languages = (string)rdr["Languages"]; }
            title = (string) rdr["SurveyTitle"];
            if (!rdr.IsDBNull(rdr.GetOrdinal("Group"))) { groups = (string)rdr["Group"]; }
            mode = (string) rdr["ModeLong"];
            cc = Int32.Parse((string) rdr ["CountryCode"]);

            rdr.Close();
            conn.Close();

            
            backend = DateTime.Today;
            webName = "";

            SurveyDataSet = new DataSet("Survey" + id);
            
            rawTable = new DataTable();

            qRangeLow = 0;
            qRangeHigh = 0;
            prefixes = new List<String>();
            varnames = new List<String>();
            headings = null;

            commentDate = null;
            commentAuthors = new List<int>();
            commentSources = new List<int>();

            repeatedFields = new List<String>();
            commentFields = new List<String>();
            transFields = new List<String>();

            stdFields = new List<String>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };

            varlabelCol = false;
            domainLabelCol = false;
            topicLabelCol = false;
            contentLabelCol = false;
            filterCol = false;
            commentCol = false;

            essentialList = "";

            primary = false;
            qnum = false;
            corrected = false;
            marked = false;

            includePrevNames = false;
            excludeTempNames = true;

            numbering = Enumeration.Qnum;
            nrFormat = ReadOutOptions.Neither;
            showAllQnums = false;
            subsetTables = false;
            subsetTablesTranslation = false;
            showLongLists = false;

        }

        public Survey (ReportTemplate repTemplate)
        {

        }
        #endregion 

        #region Methods and Functions

        /// <summary>
        /// Fills the rawTable object with all the questions for this particular survey. Corrected wordings are applied if necessary. 
        /// DataTables are created for comments, translations and filters if requested. Essential questions are also collected.
        /// </summary>
        public void GenerateSourceTable() {
        
            // create survey table (from backup or current)
            if (backend != DateTime.Today)
            {
                //GetBackupTable();
                GetSurveyTable();
            }
            else
            {
                hasQID = true;
                GetSurveyTable();
            }

            // get corrected wordings
            if (corrected)
                GetCorrectedWordings(); 

            // create comment table
            if (commentCol) 
                MakeCommentTable();
                
            // create filter table
            if (filterCol) 
                MakeFilterTable();

            // create translation table
            if (transFields != null && transFields.Count != 0)
            {
                //if !(useSingleField) 
                if (backend != DateTime.Today)
                {
                    MakeTranslationTableBackup();
                }
                else
                {
                    MakeTranslationTable();
                }
            }

            // get essential question list
            GetEssentialQuestions();

        }

        /// <summary>
        /// Fills the raw survey table with wordings, labels, corrected and table flags from a backup database.
        /// </summary>
        /// <remarks>
        /// This could be achieved by changing the FROM clause in GetSurveyTable but often there are columns that don't exist in the backups, due to 
        /// their age and all the changes that have happened to the database over the years. 
        /// </remarks>
        public void GetBackupTable() { }

        /// <summary>
        /// Fills the raw survey table with wordings, labels, corrected and table flags.
        /// </summary>
        public void GetSurveyTable() {
            String query = "";
            
            // form the query
            // standard fields
            query = "SELECT ID, Qnum AS SortBy, Survey, VarName, refVarName, Qnum, AltQnum, CorrectedFlag, TableFormat, Domain, Topic, Content, VarLabel, Product ";

            // wording fields, replace &gt; &lt; and &nbsp; right away
            for (int i = 0; i < stdFields.Count; i++)
            {
                query = query + ", Replace(Replace(Replace(" + stdFields[i] + ", '&gt;','>'), '&lt;', '<'), '&nbsp;', ' ') AS " + stdFields[i];
            }
            
            query = query.TrimEnd(',', ' ');

            // FROM and WHERE
            query = query + " FROM qrySurveyQuestions WHERE Survey ='" + surveyCode + "'";
            // ORDER BY
            query = query + " ORDER BY Qnum ASC";

            // run the query and fill the data table
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.Fill(rawTable);
            
            conn.Close();
            rawTable.PrimaryKey = new DataColumn[] { rawTable.Columns["ID"] };

            // clear varlabel from heading rows
            
            foreach (DataRow row in rawTable.Rows)
            {
                if (row["refVarName"].ToString().StartsWith ("Z"))
                    row["VarLabel"] = ""; 
            }
        }

        /// <summary>
        /// Look up and apply corrected wordings to the raw table. 
        /// </summary>        
        public void GetCorrectedWordings() {
            DataTable corrTable;
            
            corrTable = new DataTable();
            sql.SelectCommand = new SqlCommand("SELECT C.QID AS ID, SN.VarName, C.PreP, C.PreI, C.PreA, C.LitQ, C.PstI, C.PstP, C.RespOptions," +
                "C.NRCodes FROM qrySurveyQuestionsCorrected AS C INNER JOIN qrySurveyQuestions AS SN ON C.QID = SN.ID " +
                "WHERE SN.Survey ='" + surveyCode + "'", conn);

            conn.Open();
            sql.Fill(corrTable);
            conn.Close();
            corrTable.PrimaryKey = new DataColumn[] { corrTable.Columns["ID"] };
            rawTable.Merge(corrTable);

            corrTable.Dispose();
        }

        /// <summary>
        /// Creates a DataTable for each translation language. TODO convert line breaks. 
        /// </summary>
        public void MakeTranslationTable() {
            String query = "";
            String where = "";
            String whereLang = "";
            String strQFilter;

            // instantiate the data tables list
            List<DataTable> translationTables = new List<DataTable>();
            
            // create the filter for the query
            where = "WHERE Survey = '" + surveyCode + "'";
            strQFilter = GetQuestionFilter();
            if (strQFilter != "") { where += " AND " + strQFilter; }

            // create a data table for each language, set its primary key, add it to the list of translation tables
            for (int i = 0; i < transFields.Count; i++)
            {
                DataTable t;
                t = new DataTable();
                whereLang = " AND Lang ='" + transFields[i] + "'";

                query = "SELECT QID AS ID, VarName, refVarName, " + 
                    "Replace(Replace(Replace(Translation, '&gt;', '>'), '&lt;', '<'), '&nbsp;', ' ') AS [" + transFields[i] + "] " + 
                    "FROM qrySurveyQuestionsTranslations " + where + whereLang;

                
                // run the query and fill the data table
                conn.Open();
                sql.SelectCommand = new SqlCommand(query, conn);
                sql.Fill(t);

                conn.Close();

                t.PrimaryKey = new DataColumn[] { t.Columns["ID"] };

                // TODO get corrected wordings (see GetCorrectedWordings)
                // TODO get headings

                translationTables.Add(t);
            }
            // merge all translations into one table
            translationTable = new DataTable();
            foreach (DataTable t in translationTables)
                translationTable.Merge(t);

            
        }

        public void MakeTranslationTableBackup() { }

        public void MakeTranslationTableFromFields() { }

        /// <summary>
        /// Fills the commentTable DataTable with comments for this survey       
        /// </summary>
        public void MakeCommentTable() {
            commentTable = new DataTable();
            String cmdText = "SELECT ID, VarName, Comments FROM tvf_surveyVarComments(@survey";


            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@survey", SqlDbType.VarChar, 50);
            cmd.Parameters["@survey"].Value = surveyCode;
            // TODO: look at condensing this
            if (commentFields != null && commentFields.Count != 0)
            {
                cmd.Parameters.Add("@commentTypes", SqlDbType.VarChar);
                cmd.Parameters["@commentTypes"].Value = String.Join(",", commentFields);
                cmdText += ",@commentTypes";
            }
            else { cmdText += ",null"; }

            if (commentDate != null)
            {
                cmd.Parameters.Add("@commentDate", SqlDbType.DateTime);
                cmd.Parameters["@commentDate"].Value = commentDate;
                cmdText += ",@commentDate";
            }else { cmdText += ",null"; }

            if (commentAuthors != null && commentAuthors.Count != 0)
            {
                cmd.Parameters.Add("@commentAuthors", SqlDbType.VarChar);
                cmd.Parameters["@commentAuthors"].Value = String.Join(",",commentAuthors);
                cmdText += ",@commentAuthors";
            } else { cmdText += ",null"; }

            if (commentSources != null && commentSources.Count != 0)
            {
                cmd.Parameters.Add("@commentSources", SqlDbType.VarChar);
                cmd.Parameters["@commentSources"].Value = String.Join(",", commentSources);
                cmdText += ",@commentSources";
            }
            else { cmdText += ",null"; }
            cmdText += ")";
            // set the command text and connection
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            // set the sql adapter's command to the cmd object
            sql.SelectCommand = cmd;
            // open connection and fill the table with results
            conn.Open();
            sql.Fill(commentTable);
            conn.Close();
            commentTable.PrimaryKey = new DataColumn[] { commentTable.Columns["ID"] };

            
        }

        // TODO
        // TODO also need to get non-standard vars
        // TODO check for response codes mentioned in filter and only show those
        /// <summary>
        /// Creates a data table which contains each question who's filter references a variable.
        /// </summary>
        public void MakeFilterTable() {
            filterTable = new DataTable("FilterTable" + ID);
            string filterList = "";
            string filterVar;
            string filterRO;
            string filterNR;
            string filterLabel;
            DataRow toInsert;
            Regex rx1 = new Regex("[A-Z][A-Z][0-9][0-9][0-9]");

            // get any rows that contain a variable
            var refVars =  from r in rawTable.AsEnumerable()
                        where r.Field<string>("PreP") != null && rx1.IsMatch(r.Field<string>("PreP"))
                        select r;

            if (!refVars.Any())
                return;

            // now that we know there are some rows with filters, add columns to the filter table            
            filterTable.Columns.Add("refVarName", typeof(string));
            filterTable.PrimaryKey = new DataColumn[] { filterTable.Columns["refVarName"] };
            filterTable.Columns.Add("VarName", typeof(string));
            filterTable.Columns.Add("Filters", typeof(string));

            foreach (var item in refVars)
            {
                QuestionFilter qf = new QuestionFilter(item["PreP"].ToString());

                for (int i = 0; i < qf.FilterVars.Count; i++)
                {
                    filterVar = qf.FilterVars[i].Varname;
                    filterRO = Utilities.DTLookup(rawTable, "RespOptions", "refVarName ='" + filterVar + "'");
                    filterNR = Utilities.DTLookup(rawTable, "NRCodes", "refVarName ='" + filterVar + "'");
                    filterLabel = Utilities.DTLookup(rawTable, "VarLabel", "refVarName ='" + filterVar + "'");

                    filterList += "<strong>" + filterVar.Substring(0,2) + "." + filterVar.Substring(2) + "</strong>\r\n<em>" + 
                        filterLabel + "</em>\r\n" + filterRO + "\r\n" + filterNR + "\r\n";
                }
                // create a new row object that will be filled with the VarName and filter list of each row in the refVars table
                toInsert = filterTable.NewRow();
                toInsert["Filters"] = filterList;
                toInsert["VarName"] = item["VarName"];
                toInsert["refVarName"] = item["refVarName"];
                filterTable.Rows.Add(toInsert);
                filterList = "";
            }

        }

        // TODO
        /// <summary>
        /// Combines fields from rawTable into a single question field. Merges auxilliary tables with finalTable. Filters finalTable so it contains
        /// only the requested variables.
        /// </summary>
        public void MakeReportTable() {

            RemoveRepeats();
            // TODO remove repeats for translation (split only)

      
      
            
            
            List<String> columnNames = new List<String>();
            List<String> columnTypes = new List<String>();
            String questionColumnName = "";
            String colName = "";

            // construct finalTable
            // determine the fields that will appear in finalTable
            // eliminate Survey, SortBy, and wording fields right away
            for (int i = 0; i < rawTable.Columns.Count; i++)
            {
                switch (rawTable.Columns[i].Caption)
                {
                    case "ID":
                        columnNames.Add(rawTable.Columns[i].Caption);
                        columnTypes.Add("int");
                        break;
                    case "SortBy":
                    case "Survey":
                    case "PreP":
                    case "PreI":
                    case "PreA":
                    case "LitQ":
                    case "PstI":
                    case "PstP":
                    case "RespOptions":
                    case "NRCodes":
                        break;
                    default:
                        columnNames.Add(rawTable.Columns[i].Caption);
                        columnTypes.Add("string");
                        break;
                }
                
            }
            // add a column for the question text
            questionColumnName = GetQuestionColumnName();
            columnNames.Add(questionColumnName);
            columnTypes.Add("string");
            finalTable = Utilities.CreateDataTable(surveyCode + ID + "_Final", columnNames.ToArray(), columnTypes.ToArray());
            DataRow newrow;

            // TODO use DataRow[] dr = rawTable.Select to get all records for each operation
            

            // insert rows into finalTable from rawTable
            foreach (DataRow row in rawTable.Rows)
            {
                
                // insert Qnums before variable names
                if (qnInsertion)
                {
                    row["PreP"] = InsertQnums((string)row["PreP"]);
                    row["PreI"] = InsertQnums((string)row["PreI"]);
                    row["PreA"] = InsertQnums((string)row["PreA"]);
                    row["LitQ"] = InsertQnums((string)row["LitQ"]);
                    row["PstI"] = InsertQnums((string)row["PstI"]);
                    row["PstP"] = InsertQnums((string)row["PstP"]);
                    row["RespOptions"] = InsertQnums((string)row["RespOptions"]);
                    row["NRCodes"] = InsertQnums((string)row["NRCodes"]);
                    row.AcceptChanges();
                }
                // TODO insert Qnums before non-standard variable names

                // insert Country codes into variable names
                if (ccInsertion)
                {
                    row["PreP"] = InsertCountryCodes((string)row["PreP"]);
                    row["PreI"] = InsertCountryCodes((string)row["PreI"]);
                    row["PreA"] = InsertCountryCodes((string)row["PreA"]);
                    row["LitQ"] = InsertCountryCodes((string)row["LitQ"]);
                    row["PstI"] = InsertCountryCodes((string)row["PstI"]);
                    row["PstP"] = InsertCountryCodes((string)row["PstP"]);
                    row["RespOptions"] = InsertCountryCodes((string)row["RespOptions"]);
                    row["NRCodes"] = InsertCountryCodes((string)row["NRCodes"]);
                    row.AcceptChanges();
                }

                // remove long lists in response option column
                if (!showLongLists && !row.IsNull("RespOptions"))
                {
                    
                    if (Utilities.CountLines((String)row["RespOptions"].ToString()) >= 25)
                    {
                        row["RespOptions"] = "[center](Response options omitted)[/center]";
                        row.AcceptChanges();
                    }
                }

                // NRFormat
                if (nrFormat != ReadOutOptions.Neither && !row.IsNull("NRCodes"))
                {
                    row["NRCodes"] = FormatNR((string)row["NRCodes"]);
                    row.AcceptChanges();
                }

                // semi tel

                // in-line routing
                if (InlineRouting && row["PstP"] != null)
                {
                    FormatRouting(row);
                }

                // subset tables
                if (subsetTables)
                {
                    if (subsetTablesTranslation)
                    {
                        // TODO translation subset tables
                    }
                    else
                    {
                        if ((bool)row["TableFormat"] && row["Qnum"].ToString().EndsWith("a"))
                        {
                            row["RespOptions"] = "[TBLROS]" + row["RespOptions"];
                            row["NRCodes"] = row["NRCodes"] + "[TBLROE]";
                            row["LitQ"] = "[LitQ]" + row["LitQ"] + "[/LitQ]";
                            row.AcceptChanges();
                        }

                    }
                }

                newrow = finalTable.NewRow();
                foreach (DataColumn col in row.Table.Columns)
                {
                    colName = col.Caption;
                    col.AllowDBNull = true;
                    var currentValue = row[colName];

                    switch (colName)
                    {
                        case "SortBy":
                        //    row[colName] = (string)row[colName].ToString().Replace("!", "z");
                        //    row.AcceptChanges();
                        //    break;
                        case "Survey":
                        case "PreP":
                        case "PreI":
                        case "PreA":
                        case "LitQ":
                        case "PstI":
                        case "PstP":
                        case "RespOptions":
                        case "NRCodes":
                            break;
                        case "Qnum":
                            newrow[colName] = row[colName];
                            break;
                        case "AltQnum":
                            newrow[colName] = row[colName];
                            break;
                        case "VarName":
                            // headings
                            //if (currentValue.ToString().StartsWith("Z") && !currentValue.ToString().EndsWith("s") && !showAllQnums)
                            //{
                            //    row["Qnum"] = "reghead";
                            //    row["AltQnum"] = "reghead";
                            //    row.AcceptChanges();
                            //}

                            //if (currentValue.ToString().StartsWith("Z") && currentValue.ToString().EndsWith("s") && !showAllQnums)
                            //{
                            //    row["Qnum"] = "subhead";
                            //    row["AltQnum"] = "subhead";
                            //    row.AcceptChanges();
                            //}



                            // varname changes
                            if (includePrevNames && !row.IsNull(colName) && !currentValue.ToString().StartsWith("Z") ) {
                                row[colName] = currentValue + " " + GetPreviousNames((String)currentValue);
                                row.AcceptChanges();
                            }
                            // corrected 
                            if ((bool)row["CorrectedFlag"])
                            {
                                if (corrected) {row[colName] = row[colName] + "\r\n" + "[C]"; }
                                else { row[col] = row[colName] + "\r\n" + "[A]"; }

                            }
                            newrow[colName] = row[colName];
                            break;
                        default:
                            newrow[colName] = row[colName];
                            break;
                    }


                }

                // concatenate the question fields, and if this is varname BI104, attach the essential questions list
                if (row["refVarName"].Equals("BI104"))
                {
                    newrow[questionColumnName] = GetQuestionText(row) + "\r\n<strong>" + essentialList + "</strong>";
                }
                else
                {
                    newrow[questionColumnName] = GetQuestionText(row);
                }

                // now add a new row to the finalTable DataTable
                // the new row will be a susbet of columns in the rawTable, after the above modifications have been applied
                finalTable.Rows.Add(newrow);
            }

            // merge auxilliary tables based on ID (or varname if ID not present)



            // TODO merge with comment table, untested
            if (commentFields.Count > 0)
                finalTable.Merge(commentTable, false, MissingSchemaAction.Add);
            
            // merge with translation table
            if (transFields.Count > 0)
                finalTable.Merge(translationTable, false, MissingSchemaAction.Add);
            
            // merge with filter table
            if (filterCol)
                finalTable.Merge(filterTable, false, MissingSchemaAction.Add);

            // TODO apply question filters

            // change the primary key to be the VarName column
            finalTable.PrimaryKey = new DataColumn[] { finalTable.Columns["VarName"] };

            // remove unneeded fields
            // check enumeration and delete AltQnum
            if (numbering == Enumeration.Qnum)
                finalTable.Columns.Remove("AltQnum");

            if (numbering == Enumeration.AltQnum)
                finalTable.Columns.Remove("Qnum");

            if (!domainLabelCol)
                finalTable.Columns.Remove("Domain");

            if (!topicLabelCol)
                finalTable.Columns.Remove("Topic");

            if (!contentLabelCol)
                finalTable.Columns.Remove("Content");

            if (!varlabelCol)
                finalTable.Columns.Remove("VarLabel");

            if (!productLabelCol)
                finalTable.Columns.Remove("Product");



            finalTable.Columns.Remove("CorrectedFlag");
            finalTable.Columns.Remove("TableFormat");
            finalTable.Columns.Remove("refVarName");
            finalTable.Columns.Remove("ID");

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        private void FormatRouting(DataRow row)
        {
            QuestionRouting qr;

            qr = new QuestionRouting((string)row["PstP"], row["RespOptions"] + "\r\n" + row["NRCodes"]);

            row["PstP"] = string.Join("\r\n", qr.RoutingText);
            row["RespOptions"] = qr.ToString();
            row.AcceptChanges();
        }

        


        // TODO remove whitespace around each option before adding read out instruction
        // TODO check for tags before adding readOut string
        private string FormatNR (string wording)
        {
            string[] options;
            string result = wording;
            string readOut = new string (' ',3);

            options = wording.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            switch (nrFormat)
            {
                case ReadOutOptions.DontRead:
                    readOut += "(Don't read)";
                    break;
                case ReadOutOptions.DontReadOut:
                    readOut += "(Don't read out)";
                    break;
                case ReadOutOptions.Neither:
                    break;
            }

            for (int i=0; i < options.Length; i++)
            {
                options[i] += readOut;
            }

            result = string.Join("\n\r", options);

            return result;
        }

        /// <summary>
        /// Searches a string for a VarName pattern and, if found, looks up and inserts the Qnum right before the VarName. If a Qnum can not be found,
        /// "QNU" (Qnum Unknown) is used instead.
        /// TODO: Could be optimized - exit if no match is found in the whole string, before looking at each word in the string.
        /// </summary>
        /// <remarks> Each word in the string is compared to the VarName pattern.</remarks>
        /// <param name="wording"></param>
        /// <returns></returns>
        private string InsertQnums (string wording)
        {
            string newwording = wording;
            string[] words;
            string qnum;
            string varname;
            MatchCollection m;
            Regex rx = new Regex("[A-Z]{2}\\d{3}");
            // split the wording into words            
            words = newwording.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                // if words[i] contains a variable name, look up the qnum and place it before the variable
                if (rx.Match(words[i]).Success)
                {
                    m = rx.Matches(words[i]);
                    varname = m[0].Groups[0].Value;
                    switch (numbering)
                    {
                        case Enumeration.Both:
                        case Enumeration.Qnum:
                            qnum = Utilities.DTLookup(rawTable, "Qnum", "refVarName = '" + varname + "'");
                            break;
                        case Enumeration.AltQnum:
                            qnum = Utilities.DTLookup(rawTable, "AltQnum", "refVarName = '" + varname + "'");
                            break;
                        default:
                            qnum = Utilities.DTLookup(rawTable, "Qnum", "refVarName = '" + varname + "'");
                            break;
                    }

                    if (qnum.Equals(""))
                        qnum = "QNU";
                    
                    words[i] = rx.Replace(words[i], qnum + "/" + varname); 
                }
            }
            newwording = string.Join(" ", words);
            return newwording;
        }

        
        private string InsertCountryCodes(string wording)
        {
            string newwording = wording;
            string[] words;
            string qnum;
            string varname;
            MatchCollection m;
            Regex rx = new Regex("[A-Z]{2}\\d{3}");
            // split the wording into words            
            words = newwording.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                // if words[i] contains a variable name, replace the variable with the country coded version
                if (rx.Match(words[i]).Success)
                {
                    m = rx.Matches(words[i]);
                    varname = m[0].Groups[0].Value;
                    varname = Utilities.ChangeCC(varname, cc);

                    words[i] = rx.Replace(words[i], varname);
                }
            }
            newwording = string.Join(" ", words);
            return newwording;
        }

        private String GetPreviousNames(String varname)
        {
            
            String varlist = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);
            DataTable surveyListTable = new DataTable("ChangedSurveys");
            String query = "SELECT dbo.FN_VarNamePreviousNames(@varname, @survey, @excludeTemp)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@varname", SqlDbType.VarChar);
            cmd.Parameters["@varname"].Value = varname;
            cmd.Parameters.Add("@survey", SqlDbType.VarChar);
            cmd.Parameters["@survey"].Value = SurveyCode;
            cmd.Parameters.Add("@excludeTemp", SqlDbType.Bit);
            cmd.Parameters["@excludeTemp"].Value = excludeTempNames;

            conn.Open();
            try {
                varlist = (String)cmd.ExecuteScalar();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
#if DEBUG 
                Console.WriteLine(ex.ToString());
#endif
                return "Error";
            }
            conn.Close();
            if (!varlist.Equals(varname)) { varlist = "(Prev. " + varlist.Substring(varname.Length +1) + ")"; } else { varlist = ""; }
            return varlist;
        }

        private String GetQuestionText(DataRow row, String newline = "\r\n")
        {
            String questionText = "";
            if (row.Table.Columns.Contains("PreP") && !row.IsNull("PreP") && !row["PreP"].Equals("")) { questionText += "<strong>" + row["PreP"] + "</strong>" + newline; }
            if (row.Table.Columns.Contains("PreI") && !row.IsNull("PreI") && !row["PreI"].Equals("")) { questionText += "<em>" + row["PreI"] + "</em>" + newline; }
            if (row.Table.Columns.Contains("PreA") && !row.IsNull("PreA") && !row["PreA"].Equals("")) { questionText += row["PreA"] + newline; }
            if (row.Table.Columns.Contains("LitQ") && !row.IsNull("LitQ") && !row["LitQ"].Equals("")) { questionText += "[indent]" + row["LitQ"] + "[/indent]" + newline; }
            if (row.Table.Columns.Contains("RespOptions") && !row.IsNull("RespOptions") && !row["RespOptions"].Equals("")) { questionText += "[indent3]" + row["RespOptions"] + "[/indent3]" + newline; }
            if (row.Table.Columns.Contains("NRCodes") && !row.IsNull("NRCodes") && !row["NRCodes"].Equals("")) { questionText += "[indent3]" +  row["NRCodes"] + "[/indent3]" + newline; }
            if (row.Table.Columns.Contains("PstI") && !row.IsNull("PstI") && !row["PstI"].Equals("")) { questionText += "<em>" + row["PstI"] + "</em>" + newline; }
            if (row.Table.Columns.Contains("PstP") && !row.IsNull("PstP") && !row["PstP"].Equals("")) { questionText += "<strong>" + row["PstP"] + "</strong>"; }

            // replace all "<br>" tags with newline characters
            questionText = questionText.Replace("<br>", newline);
            questionText = Utilities.TrimString(questionText, newline);

            return questionText;
        }

        /// <summary>
        /// Returns the name of the column, in the final survey table, containing the question text.
        /// </summary>
        /// <returns>Returns: string.</returns>
        private String GetQuestionColumnName()
        {
            String column = "";
            column = surveyCode.Replace(".", "");
            if (!backend.Equals(DateTime.Today)) { column += "_" + backend.ToString("d"); }
            if (corrected) { column += "_Corrected"; }
            if (marked) { column += "_Marked"; }
            return column;
        }

        // functions
        public String GetQRangeFilter() {
            String filter = "";
            if (qRangeLow == 0 && qRangeHigh == 0) { return ""; }
            if (qRangeLow <= qRangeHigh)
            {
                filter = "Qnum BETWEEN '" + qRangeLow.ToString().PadLeft(3, '0') + "' AND '" + qRangeHigh.ToString().PadLeft(3, '0') + "'";
            }
            return filter;
        }

        // Returns a WHERE clause using the properties qRange, prefixes, and varnames (and headings if it is decided to use them again)
        public String GetQuestionFilter()
        {
            String filter = "";

            filter = GetQRangeFilter();
            
            if (prefixes != null && prefixes.Count != 0) { filter += " AND Left(VarName,2) IN ('" + String.Join("','", prefixes) + "')"; }
            if (varnames != null && varnames.Count != 0) { filter += " AND VarName IN ('" + String.Join("','", varnames) + "')"; }
            //if (headings != null && headings.Count != 0) { filter += " AND (" + GetHeadingFilter() + ")"; }
            // TODO trim AND from the edges 
            //filter.Trim();
            return filter;
        }

        public String GetTranslation(int index)
        {
            return "";
            //return TransFields(index);
        }

               

        // heading filters not supported at this time
        public String GetHeadingFilter() { return "1=1"; }

        public override String ToString() { return "ID: " + ID + "\r\n" + "Survey: " + SurveyCode + "\r\n" + "Backend: " + Backend; }

        // sets the essentialList property
        /// <summary>
        /// Sets the 'essentialList' property by compiling a list of VarNames that contain the special routing instruction that only essential 
        /// questions have.
        /// </summary>
        public void GetEssentialQuestions() {
            String varlist = "";
            Regex rx = new Regex("go to [A-Z][A-Z][0-9][0-9][0-9], then BI9");

            var query = from r in rawTable.AsEnumerable()
                        where r.Field<string>("PstP") != null && rx.IsMatch(r.Field<string>("PstP"))
                        select r;

            // if there are any variables with the special PstP instruction, create a list of them
            if (query.Any()) { 
                foreach (var item in query)
                {
                    varlist += item["VarName"] + " (" + item["Qnum"] + "), ";
                }

                varlist = varlist.Substring(0, varlist.Length - 2);
            }
            essentialList = varlist;
        }

        /// <summary>
        /// Remove repeated values from the wording fields (PreP, PreI, PreA, LitQ, PstI, Pstp, RespOptions, NRCodes) unless they are requested. 
        /// </summary>
        public void RemoveRepeats() {
            int mainQnum = 0;
            String currQnum = "";
            String currField = "";
            int currQnumInt = 0;
            bool firstRow = true;
            Object[] refRow = null; // this array will hold the 'a' question's fields
            // only try to remove repeats if there are more than 0 rows
            if (rawTable.Rows.Count == 0) return;
            // sort table by SortBy
            rawTable.DefaultView.Sort = "SortBy ASC";
            //
            foreach (DataRow r in rawTable.Rows)
            {
                currQnum = (String)r["Qnum"];
                if (currQnum.Length != 4) { continue; }

                // get the integer value of the current qnum
                int.TryParse(currQnum.Substring(0,3), out currQnumInt);

                // if this row is in table format, we need to remove all repeats, regardless of repeated designations
                if ((bool)r["TableFormat"]) {
                    // TODO set repeated fields to none (or all?)

                }
                
                // if this is a non-series row, the first member of a series, the first row in the report, or a new Qnum, make this row the reference row
                if (currQnum.Length == 3 || (currQnum.Length == 4 && currQnum.EndsWith("a")) || firstRow || currQnumInt != mainQnum)
                {
                    mainQnum = currQnumInt;
                    // copy the row's contents into an array
                    refRow = (Object[]) r.ItemArray.Clone();
                }
                else
                {
                    // if we are inside a series, compare the wording fields to the reference row
                    for (int i = 0; i < r.Table.Columns.Count;i++)
                    {
                        currField = r.Table.Columns[i].Caption; // field name
                        // if the current column is a standard wording column and has not been designated as a repeated field, compare wordings
                        if (stdFields.Contains(currField) && !repeatedFields.Contains(currField))
                        {
                            // if the current row's wording field matches the reference row, clear it. 
                            // otherwise, set the reference row's field to the current row's field
                            // this will cause a new reference point for that particular field, but not the fields that were identical to the original reference row
                            if (r[i].Equals(refRow[i])) // field is identical to reference row's field, clear it
                            {
                                r[i] = "";
                                r.AcceptChanges();
                            }
                            else // field is different from reference row's field, use this value as the new reference for this field
                            {
                                refRow[i] = r[i];
                            }
                        }
                    }
                }

                firstRow = false; // after once through the loop, we are no longer on the first row
            }
        }

        public int TranslationCount() { return TransFields.Count; }

        public void ReplaceQN2() { }

        // possible unneeded once comments are retrieved with server function
        public void RemoveRepeatedComments() { }
        #endregion

        #region Gets and Sets

        public int ID { get => id; set => id = value; }
        public String SurveyCode { get => surveyCode; set => surveyCode = value; }
        public DateTime Backend { get => backend; set => backend = value; }
        public List<String> Prefixes { get => prefixes; set => prefixes = value; }
        public String[] Headings { get => headings; set => headings = value; }
        public List<String> Varnames { get => varnames; set => varnames = value; }
        public DateTime? CommentDate { get => commentDate; set => commentDate = value; }
        public List<int> CommentAuthors { get => commentAuthors; set => commentAuthors = value; }
        public List<int> CommentSources { get => commentSources; set => commentSources = value; }
        public List<String> CommentFields
        {
            get => commentFields;
            set
            {
                commentFields = value;
                if (commentFields != null && commentFields.Count!= 0) { commentCol = true; }
            }
        }
        public List<String> TransFields { get => transFields; set => transFields = value; }
        public List<String> StdFields { get => stdFields; set => stdFields = value; }
        public bool VarLabelCol { get => varlabelCol; set => varlabelCol = value; }
        public bool FilterCol { get => filterCol; set => filterCol = value; }
        public bool CommentCol { get => commentCol; set => commentCol = value; }
        public String EssentialList { get => essentialList; set => essentialList = value; }
        public bool Primary { get => primary; set => primary = value; }
        public bool Qnum { get => qnum; set => qnum = value; }
        public bool Corrected { get => corrected; set => corrected = value; }
        public bool Marked { get => marked; set => marked = value; }
        public int QRangeLow { get => qRangeLow; set => qRangeLow = value; }
        public int QRangeHigh { get => qRangeHigh; set => qRangeHigh = value; }
        public string WebName { get => webName; set => webName = value; }
        public bool IncludePrevNames { get => includePrevNames; set => includePrevNames = value; }
        public bool ExcludeTempNames { get => excludeTempNames; set => excludeTempNames = value; }
        public bool QNInsertion { get => qnInsertion; set => qnInsertion = value; }
        public bool AQNInsertion { get => aqnInsertion; set => aqnInsertion = value; }
        public bool CCInsertion { get => ccInsertion; set => ccInsertion = value; }
        public Enumeration Numbering { get => numbering; set => numbering = value; }
        public ReadOutOptions NrFormat { get => nrFormat; set => nrFormat = value; }
        public string Title { get => title; set => title = value; }
        public string Languages { get => languages; set => languages = value; }
        public string Groups { get => groups; set => groups = value; }
        public string Mode { get => mode; set => mode = value; }
        public int Cc { get => cc; set => cc = value; }
        public bool InlineRouting { get => inlineRouting; set => inlineRouting = value; }
        public bool ShowAllQnums { get => showAllQnums; set => showAllQnums = value; }
        public bool SubsetTables { get => subsetTables; set => subsetTables = value; }
        public bool SubsetTablesTranslation { get => subsetTablesTranslation; set => subsetTablesTranslation = value; }
        public bool ShowLongLists { get => showLongLists; set => showLongLists = value; }
        #endregion



    }
}
