using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Word = Microsoft.Office.Interop.Word;
using System.ComponentModel;

namespace ITCSurveyReport
{
    class SurveyReport
    {
        #region Survey Report Properties
        // the dataset containing all the tables needed for the report
        DataSet SurveyReportData;
        SqlDataAdapter sql;

        // the surveys appearing in the report
        List<Survey> surveys;

        // formatting and layout options
        ReportFormatting formatting;
        ReportLayout layoutoptions;

        // comparison class
        Comparison surveycompare;

        // report source and type
        int mainSource;
        int reportType;

        // filters applying to all surveys in the report
        //String qRange;
        //List<String> prefixes;
        //String[] headings;
        //String[] varnames;

        // comparison options
        bool compare;

        // formatting and layout options
        String[] repeatedFields;
        bool inlineRouting;
        bool showLongLists;
        bool qnInsertion;
        bool aqnInsertion;
        bool ccInsertion;
        bool semiTel;
        bool singleField;
        bool tables;
        bool tablesTranslation;
        String colOrder;
        bool repeatedHeadings;
        int nrFormat;
        bool colorSubs;
        bool web;
        String fileName;

        // other details
        int enumeration;
        bool survNotes;
        bool varChangesApp;
        bool varChangesCol;
        bool excludeTempChanges;
        bool showAllQnums;
        String details;

        // other options
        bool combine;
        bool checkOrder;
        bool checkTables;
        bool batch;

        #endregion

        #region Constructors
        public SurveyReport() {

            SurveyReportData = new DataSet("Survey Report");
            sql = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

            layoutoptions = new ReportLayout();
            formatting = new ReportFormatting();
            surveycompare = new Comparison();
            surveys = new List<Survey>();
        }
        #endregion
        // TODO method for setting highlight options?
        #region Methods and Functions

        public void GenerateSurveyReport()
        {
            foreach (Survey s in surveys)
            {
                s.GenerateSourceTable();
                // TODO figure out datasets
                //SurveyReportData.Tables.Add(s.rawTable);
            }

            // check each table to make sure there is at least one record to show

            // perform comparisons

            // create final tables

            // compile final tables into report
            foreach (Survey s in surveys)
            {
                s.MakeReportTable();
                // TODO figure out datasets
                //SurveyReportData.Tables.Add(s.rawTable);
            }
            // output report
            //OutputReportTable();
            
        }

        public override string ToString()
        {
            String output = "";
            foreach (Survey s in Surveys)
            {
                output += s.SurveyCode + " from " + s.Backend + "\r\n" +
                    "VarLabel?: " + s.VarLabelCol + "\r\n" +
                    "Filters?: " + s.FilterCol + "\r\n";
                    

            }
            output += "General Options: \r\n" + "QN insertion: " + qnInsertion;
            output += "Compare Options: \r\n" + "Do Compare? " + SurveyCompare.DoCompare;
            output += "Layout Options: \r\n" + "Blank Column: " + LayoutOptions.BlankColumn;
            return output;
        }


        // Add a Survey object to the list of surveys and set it's ID to the next available number starting with 1
        public void AddSurvey(Survey s) {
            int newID=1;
            surveys.Add(s);

            while (GetSurvey(newID) != null) {
                newID++;
            }            
            
            s.ID = newID;
        }

        // Returns the first survey object matching the specified code.
        public Survey GetSurvey(String code)
        {
            Survey s = null;
            for (int i = 0; i < surveys.Count;i++)
            {
                if (surveys[i].SurveyCode == code) { s = surveys[i]; break; }
            }
            return s;
        }

        // Returns the first survey object matching the specified id.
        public Survey GetSurvey(int id)
        {
            Survey s = null;
            for (int i = 0; i < surveys.Count; i++)
            {
                if (surveys[i].ID == id) { s = surveys[i]; break; }
            }
            return s;

        }

        // Returns the survey object that has been designated primary
        public Survey GetPrimarySurvey() {
            Survey s = null;
            for (int i = 0; i < surveys.Count; i++)
            {
                if (surveys[i].Primary) { s = surveys[i]; break; }
            }
            return s;
        }

        public Survey QnumSurvey() {
            Survey s = null;
            for (int i = 0; i < surveys.Count; i++)
            {
                if (surveys[i].Qnum) { s = surveys[i]; break; }
            }
            return s;
        }

        public String[] SurveyCodes() { return null; }


        public void CompareSurveys() { }

        public void OutputReportTable() {


            Word.Application appWord;
            Word.Document docReport;
            appWord = new Word.Application();

            docReport = appWord.Documents.Add();

            docReport.Tables.Add(docReport.Range(0, 0), Surveys[0].finalTable.Rows.Count + 1, Surveys[0].finalTable.Columns.Count + 1);
            docReport.Tables[1].Cell(1, 1).Range.Text = Surveys[0].finalTable.Columns[0].Caption;
            docReport.Tables[1].Cell(1, 2).Range.Text = Surveys[0].finalTable.Columns[1].Caption;
            docReport.Tables[1].Cell(1, 3).Range.Text = Surveys[0].finalTable.Columns[2].Caption;

            for (int r = 1; r < Surveys[0].finalTable.Rows.Count; r++)
            {
                for (int c = 1; c < Surveys[0].finalTable.Columns.Count; c++)
                {
                    docReport.Tables[1].Cell(r, c).Range.Text = Surveys[0].finalTable.Rows[r][c].ToString();
                }
            }
            appWord.Visible = true;

        }

        public void FormatColumns() { }

        public void MergeSurveyTables() { }

        public void IncludeOrderChanges() { }

        public void IncludeDeletedQuestions() { }

        public void MarkOrderChanges() { }

        public String GetReInsertedComments() { return ""; }

        public void MakeTitlePage() { }

        public void MakeToC() { }

        public void MakeSurveyNotesAppendix() { }

        public void MakeVarChangesAppendix() { }

        public String FilterLegend() {
            String strFilter = "";
            //if (Prefixes.Length >= 0) {
            //    strFilter = "Section filters: " + String.Join(",", Prefixes);
            //}
            //if (QRange != "") {
            //    strFilter = strFilter + "\r\n" + "Questions " + QRange;
            //}
            
            return strFilter.TrimEnd('\r','\n');

        }

        // getSurveyTitle
        public String ReportTitle() { return ""; }

        // getSurveyFileName
        public String ReportFileName() { return ""; }
        // getHighlightingKey
        public String HighlightingKey () { return ""; }

        public void SetColumnOrder() { }

        public void RemoveDuplicateColums() { }

        public void StatusUpdate() { }

        public bool IsCompleteTF() { return true; }

        public bool IsCompleteSurvey() { return true; }

        // may be unneeded after a server function returns comments
        public void RemoveRepeatedComments() { }

        #endregion  

        #region Gets and Sets
        // add verification logic for some of these sets

        
       
        public List<Survey> Surveys
        {
            get {return surveys;}
            set {surveys = value;}   
        }

        

        public int MainSource
        {
            get {return mainSource; }
            set
            {
                // if a value other than 1 or 2 is provided, use default of 1
                if (value == 1 || value == 2) {
                    mainSource = value;
                }
                else
                {
                    mainSource = 1;
                }
            }
        }

        public int ReportType { get { return reportType; } set { reportType = value; } }

        
        //public String QRange { get => qRange; set => qRange = value; }
        //public String[] Prefixes { get => prefixes; set => prefixes = value; }
        //public String[] Headings { get => headings; set => headings = value; }
        //public String[] Varnames { get => varnames; set => varnames = value; }
        
        public bool Compare { get => compare; set => compare = value; }
        
        public String[] RepeatedFields { get => repeatedFields; set => repeatedFields = value; }
        public bool InlineRouting { get => inlineRouting; set => inlineRouting = value; }
        public bool ShowLongLists { get => showLongLists; set => showLongLists = value; }
        public bool QNInsertion { get => qnInsertion; set => qnInsertion = value; }
        public bool AQNInsertion { get => aqnInsertion; set => aqnInsertion = value; }
        public bool CCInsertion { get => ccInsertion; set => ccInsertion = value; }
        public bool SemiTel { get => semiTel; set => semiTel = value; }
        public bool SingleField { get => singleField; set => singleField = value; }
        public bool Tables { get => tables; set => tables = value; }
        public bool TablesTranslation { get => tablesTranslation; set => tablesTranslation = value; }
        public String ColOrder { get => colOrder; set => colOrder = value; }
        public bool RepeatedHeadings { get => repeatedHeadings; set => repeatedHeadings = value; }
        public int NrFormat { get => nrFormat; set => nrFormat = value; }
        public bool ColorSubs { get => colorSubs; set => colorSubs = value; }
        public bool Web { get => web; set => web = value; }
        public String FileName { get => fileName; set => fileName = value; }
        public int Enumeration { get => enumeration; set => enumeration = value; }
        public bool SurvNotes { get => survNotes; set => survNotes = value; }
        public bool VarChangesApp { get => varChangesApp; set => varChangesApp = value; }
        public bool VarChangesCol { get => varChangesCol; set => varChangesCol = value; }
        public bool ExcludeTempChanges { get => excludeTempChanges; set => excludeTempChanges = value; }
        public bool ShowAllQnums { get => showAllQnums; set => showAllQnums = value; }
        public String Details { get => details; set => details = value; }
        public bool Combine { get => combine; set => combine = value; }
        public bool CheckOrder { get => checkOrder; set => checkOrder = value; }
        public bool CheckTables { get => checkTables; set => checkTables = value; }
        public bool Batch { get => batch; set => batch = value; }
        public Comparison SurveyCompare { get => surveycompare; set => surveycompare = value; }
        public ReportLayout LayoutOptions { get => layoutoptions; set => layoutoptions = value; }


        #endregion

    }

        
}
