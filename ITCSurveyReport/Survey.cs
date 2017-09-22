using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
//using System.Runtime.CompilerServices;

namespace ITCSurveyReport
{
    class Survey //: INotifyPropertyChanged
    {
        #region Survey Properties
        
        SqlDataAdapter sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

        DataSet SurveyDataSet;
        // data tables for this survey 
        public DataTable rawTable;              // raw survey content, separated into fields
        public DataTable commentTable;          // table holding comments
        public DataTable[] translationTable;    // tables holding translation data
        public DataTable filterTable;           // table holding filters
        //public DataTable corrTable;
        public DataTable finalTable;            // table holding the final output
        
        //Dictionary<int, Variable> questions;  // Variable object not yet implemented

        int id;                                 // unique id
        String surveyCode;
        DateTime backend;                         // file name of backup

        // filters are currently report-level but that may change
        int qRangeLow;
        int qRangeHigh;
        String qRange;
        List<String> prefixes;
        String[] headings;
        List<String> varnames;

        // comment filters
        DateTime? commentDate;
        List<int> commentAuthors; // make a class of names?
        List<int> commentSources;

        // fields
        String[] extraFields;
        List<String> commentFields;
        List<String> transFields;
        List<String> stdFields;
        bool varlabelCol;
        bool filterCol;
        bool commentCol;

        String essentialList; // comma-separated list of essential varnames (and their Qnums) in this survey

        //attributes
        bool primary;   // true if this is the primary survey
        bool qnum;      // true if this is the qnum-defining survey
        bool corrected; // true if this uses corrected wordings
        bool marked;    // true if the survey contains tracked changes (for 3-way report)

        // errors and results
        // qnu list

        #endregion

        //public event PropertyChangedEventHandler PropertyChanged;

        //// This method is called by the Set accessor of each property.
        //// The CallerMemberName attribute that is applied to the optional propertyName
        //// parameter causes the property name of the caller to be substituted as an argument.
        //private void NotifyPropertyChanged(String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        #region Constructors
        // blank constructor
        public Survey() {

            id = 1;
            surveyCode = "";
            backend = DateTime.Today;

            SurveyDataSet = new DataSet("Survey" + id);
            sql = new SqlDataAdapter();
            rawTable = new DataTable();

            qRangeLow = 0;
            qRangeHigh = 0;
            qRange = "";
            prefixes = new List<String>();
            varnames = new List<String>();
            headings = null;

            commentDate = null;
            commentAuthors = new List<int>();
            commentSources = new List<int>();

            extraFields = null; // probably not needed
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
            filterCol = false;
            commentCol = false;

            essentialList = "";

            primary = false;  
            qnum = false ;     
            corrected = false ;
            marked  =false;   

        }
        #endregion 

        #region Methods and Functions

        // source tables
        // create rawTable, commentTable, translationTables
        
        public void GenerateSourceTable() {
            bool useBackup = false ;
            if (backend != DateTime.Today) { useBackup = true; }
                // create survey table (from backup or current)

            if (useBackup)
            {
                //GetBackupTable();
                GetSurveyTable();
            }
            else
            {
                GetSurveyTable();
            }

            // get corrected wordings
            if (corrected) { GetCorrectedWordings(); }

            // delete correctedflag column (or leave it in until the end?)
            //rawTable.Columns.Remove("CorrectedFlag");

            // insert comments into raw table
            if (commentCol) {
                MakeCommentTable();
                rawTable.Merge(commentTable, false, MissingSchemaAction.Add);
            }
            if (filterCol) { MakeFilterTable(); }

            if (transFields != null && transFields.Count != 0)
            {
                //if !(useSingleField) 
                if (useBackup)
                {
                    MakeTranslationTableBackup();
                }
                else
                {
                    MakeTranslationTable();
                }
            }

            
            
            // insert filters into raw table


            // deallocate comment table
            //commentTable.Dispose();
            // deallocate filter table
            //filterTable.Dispose();
        }

        public void GetBackupTable() { }

        // Create the raw survey table (TODO:)
        public void GetSurveyTable() {
            String query = "";
            String where = "";
            String strQFilter;
            
            // form the query
            // standard fields
            query = "SELECT ID, Qnum AS SortBy, Survey, VarName, refVarName, Qnum, AltQnum, CorrectedFlag, TableFormat ";

            // wording fields, replace &gt; &lt; and &nbsp; right away
            for (int i = 0; i < stdFields.Count; i++)
            {
                query = query + ", Replace(Replace(Replace(" + stdFields[i] + ", '&gt;','>'), '&lt;', '<'), '&nbsp;', ' ') AS " + stdFields[i];
            }
            
            query = query.TrimEnd(',', ' ');
            // other fields
            if (varlabelCol) { query = query + ", VarLabel"; }

            // FROM and WHERE
            query = query + " FROM qrySurveyQuestions WHERE Survey ='" + surveyCode + "'";

            // additional WHERE
            strQFilter = GetQRangeFilter();
            if (strQFilter != "") { where = strQFilter; }
            if (prefixes != null && prefixes.Count != 0) { where = where + " AND Left(VarName,2) IN ('" + String.Join("','", prefixes) + "')"; }
            if (varnames != null && varnames.Count != 0) { where = where + " AND VarName IN ('" + String.Join("','", varnames) + "')"; }
            //if (headings != null && headings.Length != 0) { where = where + " AND (" + GetHeadingFilter() + ")"; }

            query = query + where + " ORDER BY Qnum ASC";

            // run the query and fill the data table
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.Fill(rawTable);
            
            conn.Close();
            rawTable.PrimaryKey = new DataColumn[] { rawTable.Columns["ID"] };
            // TODO clear varlabel from heading rows
            if (varlabelCol)
            {
                String refVar;
                foreach (DataRow row in rawTable.Rows)
                {
                    refVar = row["refVarName"].ToString();
                    if (refVar.StartsWith ("Z")) { row["VarLabel"] = ""; }
                }
            }

        }

        // Look up and apply corrected wordings to the raw table
        public void GetCorrectedWordings() {
            DataTable corrTable;
            
            corrTable = new DataTable();
            sql.SelectCommand = new SqlCommand("SELECT C.QID AS ID, SN.VarName, C.PreP, C.PreI, C.PreA, C.LitQ, C.PstI, C.PstP, C.RespOptions," +
                "C.NRCodes FROM qryCorrectedSurveyNumbers AS C INNER JOIN qrySurveyQuestions AS SN ON C.QID = SN.ID " +
                "WHERE SN.Survey ='" + surveyCode + "'", conn);

            conn.Open();
            sql.Fill(corrTable);
            conn.Close();
            corrTable.PrimaryKey = new DataColumn[] { corrTable.Columns["ID"] };
            rawTable.Merge(corrTable);

            corrTable.Dispose();
        }

        public void MakeTranslationTable() { }

        public void MakeTranslationTableBackup() { }

        public void MakeTranslationTableFromFields() { }

        // Fills the commentTable DataTable with comments for this survey
        // TODO: make comment table local 
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

        public void MakeFilterTable() { }

        // final table
        public void MakeReportTable() {
            

            rawTable.Columns.Remove("SortBy");
            rawTable.Columns.Remove("Survey");
            rawTable.Columns.Remove("AltQnum");
            rawTable.Columns.Remove("CorrectedFlag");
            rawTable.Columns.Remove("TableFormat");
            
            List<String> columnNames = new List<String>();
            List<String> columnTypes = new List<String>();


            for (int i = 0; i < rawTable.Columns.Count; i++)
            {
                switch (rawTable.Columns[i].Caption)
                {
                    case "ID":
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
            columnNames.Add(surveyCode);
            columnTypes.Add("string");
            finalTable = Utilities.CreateDataTable(surveyCode + ID + "_Final", columnNames.ToArray(), columnTypes.ToArray());
            DataRow newrow;
            String qText;
            foreach (DataRow row in rawTable.Rows)
            {
                newrow = finalTable.NewRow();

                foreach (DataColumn col in rawTable.Columns)
                {
                    switch (col.Caption)
                    {
                        case "ID":
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
                            newrow[col.Caption] = row[col.Caption];
                            break;
                    }
                }

                    
                
                // TODO replace this with a getQuestion type function that accepts a row
                qText = row["PreP"] + Environment.NewLine + row["PreI"] + "\r\n" + row["PreA"] + "\r\n" + row["LitQ"] + "\r\n" + row["RespOptions"] + "\r\n" +
                    row["NRCodes"] + "\r\n" + row["PstI"] + "\r\n" + row["PstP"];
                newrow[surveyCode] = qText.TrimEnd('\r','\n');
                finalTable.Rows.Add(newrow);
            }

        }

        // functions
        public String GetQRangeFilter() {

            return "";
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
        public void GetEssentialQuestions() { this.EssentialList = ""; }

        public void RemoveRepeats() { }

        public int TranslationCount() { return TransFields.Count; }

        public void ReplaceQN() { }

        public String InsertRoutingQnum() { return ""; }

        public void ReplaceQN2() { }

        public void InsertCC() { }

        // possible unneeded once comments are retrieved with server function
        public void RemoveRepeatedComments() { }
        #endregion

        #region Gets and Sets

        public int ID { get => id; set => id = value; }
        public String SurveyCode { get => surveyCode; set => surveyCode = value; }
        public DateTime Backend { get => backend; set => backend = value; }
        public String QRange { get => qRange; set => qRange = value; }
        public List<String> Prefixes { get => prefixes; set => prefixes = value; }
        public String[] Headings { get => headings; set => headings = value; }
        public List<String> Varnames { get => varnames; set => varnames = value; }
        public DateTime? CommentDate { get => commentDate; set => commentDate = value; }
        public List<int> CommentAuthors { get => commentAuthors; set => commentAuthors = value; }
        public List<int> CommentSources { get => commentSources; set => commentSources = value; }
        public String[] ExtraFields { get => extraFields; set => extraFields = value; }
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
        public bool VarLabelCol { get => varlabelCol; set
            {
                varlabelCol = value;
                //NotifyPropertyChanged();
            }
        }
        public bool FilterCol { get => filterCol; set => filterCol = value; }
        public bool CommentCol { get => commentCol; set => commentCol = value; }
        public String EssentialList { get => essentialList; set => essentialList = value; }
        public bool Primary { get => primary; set => primary = value; }
        public bool Qnum { get => qnum; set => qnum = value; }
        public bool Corrected { get => corrected; set => corrected = value; }
        public bool Marked { get => marked; set => marked = value; }
        public int QRangeLow { get => qRangeLow; set => qRangeLow = value; }
        public int QRangeHigh { get => qRangeHigh; set => qRangeHigh = value; }

        #endregion



    }
}
