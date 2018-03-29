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
    public enum ReportTemplate { Standard, Comparison, Automatic }
    public enum Enumeration { Qnum, AltQnum, Both }
    public enum ReadOutOptions { DontRead, DontReadOut, Neither }
    public class SurveyReport
    {
        #region Survey Report Properties

        // the dataset containing all the tables needed for the report
        //DataSet SurveyReportData;
        public DataTable reportTable;
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
        ReadOutOptions nrFormat;
        bool colorSubs;
        bool web;
        String fileName; // this value will initially contain the path up to the file name, which will be added in the Output step

        // other details
        Enumeration numbering;
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

            //SurveyReportData = new DataSet("Survey Report");
            sql = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

            layoutoptions = new ReportLayout();
            formatting = new ReportFormatting();
            surveycompare = new Comparison();
            surveys = new List<Survey>();

            // default settings

            reportType = 1;

            // comparison options
            compare = false;

            // formatting and layout options
            repeatedHeadings = true;
            colorSubs = true;
            showLongLists = false;
            qnInsertion = false;
            aqnInsertion = false;
            ccInsertion = false;
            tables = false;
            tablesTranslation = false;
            inlineRouting = false;
            semiTel = false;
            repeatedFields = new string[] { "PreP", "PreI", "PreA", "LitQ", "PstI", "PstP", "RespOptions", "NRCodes" };
            
            numbering = Enumeration.Qnum;
            survNotes = false;
            varChangesApp = false ;
            varChangesCol = false;
            excludeTempChanges = true;
            showAllQnums = false;
 
            nrFormat = ReadOutOptions.Neither;
            web = false;
            fileName = "";
            details = "";

            // TODO review the need for these options
            mainSource = 1;
            singleField = true;

            
        }
        #endregion
        // TODO method for setting highlight options?
        #region Methods and Functions

        public int GenerateSurveyReport()
        {
            foreach (Survey s in surveys)
            {
                s.GenerateSourceTable();
                // TODO figure out datasets
                    // create a relationship between main survey and other surveys on refVarName

                if (s.rawTable.Rows.Count== 0)
                {
                    return 1;
                }
                //SurveyReportData.Tables.Add(s.rawTable);
            }

            // perform comparisons
            if (surveys.Count > 1)
            {
                SurveyCompare.CompareByVarName(surveys);
            }

            // create final tables
            foreach (Survey s in surveys)
            {

                s.MakeReportTable();
                
                //SurveyReportData.Tables.Add(s.finalTable);
            }
            // TODO
            // compile final tables into report
            // merge tables into one
            
            reportTable = surveys[0].finalTable.Copy();
            if (surveys.Count > 1)
            {
                reportTable.Merge(surveys[1].finalTable, false, MissingSchemaAction.Add);
            }

            // for now, just set the reportTable to the first survey's final table
            // this way the SurveyReport object is only set up to generate a single survey, the first one defined in the surveys list.
            // this could also be where we remove the primary survey if hidePrimary is true
            // this is also where we would sort the report
            //reportTable = surveys[0].finalTable;

            // remove refVarName column before outputting 
            DataColumn[] pk = new DataColumn[1];
            pk[0] = reportTable.Columns["VarName"];
            reportTable.PrimaryKey = pk;
            reportTable.Columns.Remove("refVarName");

            // output report
            // at this point the reportTable should be exactly how we want it to appear, minus interpreting tags
            //#if DEBUG
            //#else     


            OutputReportTable();
//#endif
            return 0;
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

        /// <summary>
        ///  Automatically sets the primary survey to be the 2nd survey if there are 2 surveys, otherwise, the 1st survey.
        /// </summary>
        public void AutoSetPrimary()
        {
            if (surveys.Count == 0) return;
            for (int i = 0; i < surveys.Count; i++) {surveys[i].Primary = false; }
            if (surveys.Count ==2)
            {
                surveys[1].Primary = true;
            }else
            {
                surveys[0].Primary = true;
            }
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

        // Returns the survey object that defines the Qnum order
        public Survey QnumSurvey() {
            Survey s = null;
            for (int i = 0; i < surveys.Count; i++)
            {
                if (surveys[i].Qnum) { s = surveys[i]; break; }
            }
            return s;
        }

        public String[] SurveyCodes() { return null; }


        ///<summary>
        ///Exports the final report DataTable to Word. The table is formatted in Word, including headings, colors, formatting tags like bold, italics, etc.
        ///
        ///</summary>
        public void OutputReportTable() {

            Word.Application appWord;
            Word.Document docReport;

            int rowCount = reportTable.Rows.Count;
            int columnCount = reportTable.Columns.Count;

            // ensure that the columns are in the right order
            reportTable.Columns["Qnum"].SetOrdinal(0);
            reportTable.Columns["VarName"].SetOrdinal(1);

            // create an instance of Word
            appWord = new Word.Application();

            // create the document
            docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLandLet.dotx");

            // add a table
            docReport.Tables.Add(docReport.Range(0, 0), rowCount + 1, columnCount );

            // fill header row
            docReport.Tables[1].Cell(1, 1).Range.Text = reportTable.Columns[0].Caption;
            docReport.Tables[1].Cell(1, 2).Range.Text = reportTable.Columns[1].Caption;
            docReport.Tables[1].Cell(1, 3).Range.Text = reportTable.Columns[2].Caption;

            // fill the rest of the rows
            for (int r = 0; r < rowCount ; r++)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    docReport.Tables[1].Cell(r+2, c+1).Range.Text = reportTable.Rows[r][c].ToString();
                }
            }

            // table style
            docReport.Tables[1].Rows.AllowBreakAcrossPages = -1;
            docReport.Tables[1].Rows.Alignment = 0;
            docReport.Tables[1].AutoFitBehavior (Word.WdAutoFitBehavior.wdAutoFitContent);
            docReport.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            docReport.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            docReport.Tables[1].Borders.OutsideColor = Word.WdColor.wdColorGray25;
            docReport.Tables[1].Borders.InsideColor = Word.WdColor.wdColorGray25;
            docReport.Tables[1].Select();
            docReport.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;

            //header row style
            docReport.Tables[1].Rows[1].Range.Bold = 1;
            docReport.Tables[1].Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorRose;
            docReport.Tables[1].Rows[1].Borders.OutsideColor = Word.WdColor.wdColorBlack;
            docReport.Tables[1].Rows[1].Borders.InsideColor = Word.WdColor.wdColorBlack;
            docReport.Tables[1].Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
            docReport.Tables[1].Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            // repeat heading row
            if (repeatedHeadings)
                docReport.Tables[1].Rows[1].HeadingFormat = -1;
            else
                docReport.Tables[1].Rows[1].HeadingFormat = 0;

            //header text
            docReport.Range(0, 0).Select();
            docReport.Application.Selection.Range.ParagraphFormat.SpaceAfter = 0;
            docReport.Application.Selection.SplitTable();
            docReport.Application.Selection.TypeParagraph();
            docReport.Application.Selection.Font.Bold = 0;
            docReport.Application.Selection.Font.Size = 12;
            docReport.Application.Selection.Font.Name = "Arial";
            docReport.Application.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            docReport.Application.Selection.Text = ReportTitle();
            // add highlighting key if more than 1 survey (ie a comparison)
            if (surveys.Count > 1) {
                docReport.Application.Selection.Text = docReport.Application.Selection.Text + HighlightingKey();
            }
            docReport.Application.Selection.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            // if there are filters, add a description of the filter
            docReport.Application.Selection.Text = "\r\n" + FilterLegend();
            docReport.Application.Selection.Font.Size = 12;

            // footer text
            docReport.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InsertAfter ("\t" + ReportTitle() +
                "\t\t" + "Generated on " + DateTime.Today.ToString("d"));

            //
            docReport.Paragraphs.SpaceAfter = 0;

            // format column names and widths
            FormatColumns(docReport);

            // format subset tables
            if (tables && numbering == Enumeration.Qnum && reportType == 1) { }

            // create TOC
            if (layoutoptions.ToC != 1) { }

            // create title page
            if (layoutoptions.CoverPage) { MakeTitlePage(docReport); }

            // format section headings
            if (reportType == 1)
            {
                // process headings TODO use enumeration for 2nd arg
                formatting.FormatHeadings(docReport, 2, colorSubs);
            }

            // update TOC due to formatting changes (see if the section headings can be done first, then the TOC could update itself)
            if (layoutoptions.ToC == 3 && docReport.TablesOfContents.Count > 0 ) { docReport.TablesOfContents[1].Update(); }

            // add survey notes appendix
            if (survNotes) { MakeSurveyNotesAppendix(); }

            // add varname changes as appendix
            if (varChangesApp) { MakeVarChangesAppendix(); }

            // interpret formatting tags
            formatting.FormatTags(appWord, docReport, surveycompare.Highlight);
            
            // convert TC tags into real tracked changes
            if (surveycompare.ConvertTrackedChanges) { formatting.ConvertTC(docReport); }

            // format shading for order comparisons
            if (reportType == 3) { formatting.FormatShading(docReport); }

            fileName += ReportFileName() + ", " + DateTime.Today.ToString("d").Replace("-", "") ;
            fileName += ".doc";

            //save the file
            docReport.SaveAs2(fileName);
            appWord.Visible = true;
            // close the document and word if this is an automatic survey
            if (batch) {
                docReport.Close();
                appWord.Quit();
            }
            
        }

        public void FormatColumns() { }

        public void MergeSurveyTables() { }

        public void IncludeOrderChanges() { }

        public void IncludeDeletedQuestions() { }

        public void MarkOrderChanges() { }

        public String GetReInsertedComments() { return ""; }

        public void MakeTitlePage(Word.Document doc) {
            Word.Table t;
            Survey s = GetPrimarySurvey();
            // create new section
            doc.Range(0, 0).InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);

            doc.Sections[2].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false;

            doc.Sections[1].PageSetup.VerticalAlignment = Word.WdVerticalAlignment.wdAlignVerticalCenter;
            doc.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "";

            // create a table
            t = doc.Tables.Add(doc.Range(0, 0), 6, 1, Word.WdDefaultTableBehavior.wdWord8TableBehavior, Word.WdAutoFitBehavior.wdAutoFitContent);

            t.Range.Font.Name = "Verdana";
            t.Range.Font.Size = 18;
            t.Rows.VerticalPosition = 1.8f;
            // add info to table
            t.Rows[1].Cells[1].Range.InlineShapes.AddPicture(@"\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\logo.JPG", false, true);
            t.Rows[2].Cells[1].Range.Text = s.Title;
            t.Rows[3].Cells[1].Range.Text = "Survey Code: " + s.SurveyCode;
            t.Rows[4].Cells[1].Range.Text = "Languages: " +  s.Languages;
            t.Rows[5].Cells[1].Range.Text = "Mode: " + s.Mode;
            t.Rows[6].Cells[1].Range.Text = s.Groups.Equals("") ? "(" + s.Groups + ")" : "";
            // format table
            t.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleNone;
            t.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone;
            t.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

        }

        public void MakeToC(Word.Document doc) {



        }

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
        public String ReportTitle(bool addDate = false) {
            String title = "";
            String surveyCodes = "";

            if (surveys.Count == 1) {
                title = surveys[0].WebName;
                if (surveys[0].Backend != DateTime.Today) { surveyCodes += " on " + surveys[0].Backend.ToString(); }
                return title;
            }

            for (int i = 0; i < surveys.Count; i++)
            {
                surveyCodes += surveys[i].SurveyCode;
                if (surveys[i].Backend != DateTime.Today) { surveyCodes += " on " + surveys[i].Backend.ToString(); }
                surveyCodes += " vs. ";
            }
            // trim off " vs. "
            if (surveyCodes.EndsWith(" vs. ")) { surveyCodes = surveyCodes.Substring(0, surveyCodes.Length - 5); }
            title += surveyCodes; 
            if (addDate) { title += ", Generated on " + DateTime.Today.ToString("d").Replace("-", ""); }

            return title;
        }

        // getSurveyFileName
        public String ReportFileName() {
            String finalfilename = "";
            String surveyCodes = "";
            if (web)
            {
                return surveys[0].WebName;
            }

            for (int i = 0; i <surveys.Count; i++)
            {
                surveyCodes += surveys[i].SurveyCode;
                if (surveys[i].Backend != DateTime.Today) {surveyCodes += " on " + surveys[i].Backend.ToString();}
                surveyCodes += " vs. ";
            }
            // trim off " vs. "
            if (surveyCodes.EndsWith(" vs. ")) { surveyCodes = surveyCodes.Substring(0, surveyCodes.Length - 5); }
            finalfilename = surveyCodes;
            if (details != "") { finalfilename += ", " + details; }
            if (!batch) { finalfilename += " generated"; }

            return finalfilename;
        }

        // getHighlightingKey
        public String HighlightingKey () { return ""; }

        public void SetColumnOrder() { }

        public void RemoveDuplicateColums() { }

        public void StatusUpdate() { }

        public bool IsCompleteTF() { return true; }

        public bool IsCompleteSurvey() { return true; }

        // Format the header row so with the appropriate widths and titles
        public void FormatColumns(Word.Document doc)
        {
            double widthLeft;
            float qnumWidth = 0.51f;
            float altqnumWidth = 0.86f;
            float varWidth = 0.9f;
            float tcWidth = 1.2f;
            float respWidth = 0.86f;
            float commentWidth = 1f;
            int qCol;
            int otherCols;
            int numCols;
            String header;
            switch (layoutoptions.PaperSize)
            {
                case 1: widthLeft = 10.5; break;
                case 2: widthLeft = 13.5; break;
                case 3: widthLeft = 16.5; break; 
                case 4: widthLeft = 11.7; break;
                default: widthLeft = 10.5; break;
            }
            // Qnum and VarName
            otherCols = 2;

            if (numbering == Enumeration.Both && reportType !=2) {
                qCol = 4;
                otherCols++; // AltQnum
            }
            else
            {
                qCol = 3;
            }

            numCols = doc.Tables[1].Columns.Count;

            for (int i = 1; i <= numCols; i++)
            {
                // remove underscores
                doc.Tables[1].Rows[1].Cells[i].Range.Text = doc.Tables[1].Rows[1].Cells[i].Range.Text.Replace("_", " ");
                header = doc.Tables[1].Rows[1].Cells[i].Range.Text.TrimEnd('\r','\a');

                switch (header)
                {
                    case "Qnum":
                        doc.Tables[1].Rows[1].Cells[i].Range.Text = "Q#";
                        //doc.Tables[1].Columns[i].Width = qnumWidth * 72;
                        widthLeft -= qnumWidth;
                        break;
                    case "AltQnum":
                        doc.Tables[1].Rows[1].Cells[i].Range.Text = "AltQ#";
                       // doc.Tables[1].Columns[i].Width = altqnumWidth * 72;
                        widthLeft -= altqnumWidth;
                        break;
                    case "VarName":
                        //doc.Tables[1].Columns[i].Width = varWidth * 72;
                        widthLeft -= varWidth;
                        break;
                    case "Response":
                       // doc.Tables[1].Columns[i].Width = respWidth * 72;
                        widthLeft -= respWidth;
                        break;
                    case "Info":
                       // doc.Tables[1].Columns[i].Width = tcWidth * 72;
                        widthLeft -= tcWidth;
                        break;
                    case "SortBy":
                        //doc.Tables[1].Columns[i].Width = qnumWidth * 72;
                        widthLeft -= qnumWidth;
                        break;
                    case "Comments":
                        //doc.Tables[1].Columns[i].Width = commentWidth * 72;
                        widthLeft -= commentWidth;
                        break;
                    default: // question column
                        if (header.Contains(DateTime.Today.ToString("d").Replace("-", "")))
                        {
                            doc.Tables[1].Rows[1].Cells[i].Range.Text = doc.Tables[1].Rows[1].Cells[i].Range.Text.Replace(DateTime.Today.ToString("d"), "");
                        } 
                        break;
                }

            }


        }

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
        public bool QNInsertion
        {
            get => qnInsertion;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.QNInsertion = value;
                }
                qnInsertion = value;
            }
        }
        public bool AQNInsertion
        {
            get => aqnInsertion;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.AQNInsertion = value;
                }
                aqnInsertion = value;
            }
        }
        public bool CCInsertion
        {
            get => ccInsertion;
            set
            {
                foreach (Survey s in surveys){
                    s.CCInsertion = value;
                }
                ccInsertion = value;
            }
        }
        public bool SemiTel { get => semiTel; set => semiTel = value; }
        public bool SingleField { get => singleField; set => singleField = value; }
        public bool Tables { get => tables; set => tables = value; }
        public bool TablesTranslation { get => tablesTranslation; set => tablesTranslation = value; }
        public String ColOrder { get => colOrder; set => colOrder = value; }
        public bool RepeatedHeadings { get => repeatedHeadings; set => repeatedHeadings = value; }
        public ReadOutOptions NrFormat
        {
            get => nrFormat;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.NrFormat = value;
                }
                nrFormat = value;
            }
        }
        public bool ColorSubs { get => colorSubs; set => colorSubs = value; }
        public bool Web { get => web; set => web = value; }
        public String FileName { get => fileName; set => fileName = value; }
        public Enumeration Numbering
        {
            get => numbering;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.Numbering = value;
                }
                numbering = value;
            }
        }
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
