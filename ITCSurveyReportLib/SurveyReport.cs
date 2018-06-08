using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.ComponentModel;


namespace ITCSurveyReport
{
    public enum ReportTemplate { Standard, StandardTranslation, Website, WebsiteTranslation, Automatic }
    public enum Enumeration { Qnum=1, AltQnum, Both }
    public enum ReadOutOptions { Neither, DontRead, DontReadOut }
    public enum RoutingType { Other, IfResponse, Otherwise, If }
    public enum FileFormats { DOC=1, PDF }
    public enum TableOfContents { None, Qnums, PageNums }
    public enum PaperSizes { Letter=1, Legal, Eleven17, A4 }
    public enum ReportTypes { Standard=1, Label, Order }

    // TODO T/C report
    // TODO order report
    // TODO backup data

    public class SurveyReport
    {
        #region Survey Report Properties

        // the dataset containing all the tables needed for the report
        //DataSet SurveyReportData;
        DataTable reportTable;
        SqlDataAdapter sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);
        // the surveys appearing in the report
        List<Survey> surveys;

        // formatting and layout options
        ReportFormatting formatting;
        ReportLayout layoutoptions;

        // comparison class
        Comparison surveycompare;

        // report source and type
        int mainSource;
        ReportTypes reportType;

        // filters applying to all surveys in the report
        //String qRange;
        //List<String> prefixes;
        //String[] headings;
        //String[] varnames;

        // comparison options
        bool compare;

        // formatting and layout options
        List<string> repeatedFields;
        bool inlineRouting;
        bool showLongLists;
        bool qnInsertion;
        bool aqnInsertion;
        bool ccInsertion;
        bool semiTel;
        bool singleField;
        bool tables;
        bool tablesTranslation;
        List<string> columnOrder;
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
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

            layoutoptions = new ReportLayout();
            formatting = new ReportFormatting();
            surveycompare = new Comparison();
            surveys = new List<Survey>();

            // default settings

            reportType = ReportTypes.Standard;

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
            repeatedFields = new List<string>{ "PreP", "PreI", "PreA", "LitQ", "PstI", "PstP", "RespOptions", "NRCodes" };
            
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

        // after surveys have been selected, this can be used to auto select other options
        public void LoadTemplateSettings(ReportTemplate t)
        {
            
            switch (t)
            {
                case ReportTemplate.Standard:

                    // default settings
                    reportType = ReportTypes.Standard;

                    layoutoptions.BlankColumn = true;
                    
                    // comparison options
                    compare = false;

                    // formatting and layout options
                    repeatedHeadings = true;
                    colorSubs = true;
                    showLongLists = false;
                    qnInsertion = false;
                    aqnInsertion = false;
                    ccInsertion = true;
                    tables = false;
                    tablesTranslation = false;
                    inlineRouting = false;
                    semiTel = false;
                    repeatedFields = new List<string> { "PreP", "PreI", "PreA", "LitQ", "PstI", "PstP", "RespOptions", "NRCodes" };

                    numbering = Enumeration.Qnum;
                    survNotes = false;
                    varChangesApp = false;
                    varChangesCol = true;
                    excludeTempChanges = true;
                    showAllQnums = false;

                    nrFormat = ReadOutOptions.DontRead;
                    web = false;
                    fileName = "";
                    details = "";

                    // TODO review the need for these options
                    
                    singleField = true;
                    break;
                case ReportTemplate.StandardTranslation:
                    break;
                case ReportTemplate.Website:
                    break;
                case ReportTemplate.WebsiteTranslation:
                    break;
                case ReportTemplate.Automatic:
                    break;
                    
            }
        }
        #endregion

        #region Methods and Functions

        /// <summary>
        /// Main control procedure. Creates the selected report type.
        /// </summary>
        /// <returns></returns>
        public int GenerateSurveyReport()
        {
            switch (reportType)
            {
                case ReportTypes.Standard:

                    if (GenerateStandardReport() == 1)
                        return 1;


                    break;
                case ReportTypes.Label:

                    break;
                case ReportTypes.Order:
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Creates a survey report in standard form. Standard form displays one or more surveys in Qnum order. Additional surveys are matched up
        /// based on refVarName and have their wordings compared to each other.
        /// </summary>
        /// <returns></returns>
        private int GenerateStandardReport()
        {
            foreach (Survey s in surveys)
            {
                s.GenerateSourceTable();
                // TODO figure out datasets
                // create a relationship between main survey and other surveys on refVarName

                if (s.rawTable.Rows.Count == 0)
                {
                    return 1;
                }
                //SurveyReportData.Tables.Add(s.rawTable);
            }


            // perform comparisons
            if (surveys.Count > 1)
            {
                foreach (Survey s in surveys) {
                    if (!s.Primary)
                    {
                        SurveyCompare = new Comparison(GetPrimarySurvey(), s);
                        SurveyCompare.CompareByVarName();
                    }
                }

                //SurveyCompare.CompareByVarName(surveys);
                //SurveyCompare.CompareTranslations(surveys);
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

            reportTable = QnumSurvey().finalTable.Copy();
            reportTable.AcceptChanges();

            if (surveys.Count > 1)
            {
                foreach (Survey s in Surveys)
                {
                    if (s.Qnum)
                    {

                        //reportTable.Merge(s.finalTable, false, MissingSchemaAction.Add);
                    }
                    else
                    {
                        
                        reportTable.Merge(s.finalTable, false, MissingSchemaAction.Add);
                        // update the qnum and sortby columns to the original found in the qnum survey
                        for (int i = 0; i < reportTable.Rows.Count; i ++)
                        {
                            try
                            {
                                reportTable.Rows[i]["SortBy"] = QnumSurvey().finalTable.Rows[i]["SortBy"];
                                reportTable.Rows[i]["Qnum"] = QnumSurvey().finalTable.Rows[i]["Qnum"];
                            }
                            catch (Exception e)
                            {
                                continue;
                            }

                        }
                    }
                }
                
            }


            // this could also be where we remove the primary survey if hidePrimary is true


            reportTable.PrimaryKey = new DataColumn[] { reportTable.Columns["VarName"] };
            reportTable.Columns.Remove("refVarName");

            // ensure that the first 2-3 columns are in the right order
            if (numbering == Enumeration.AltQnum)
            {
                reportTable.Columns["AltQnum"].SetOrdinal(0);
                reportTable.Columns["VarName"].SetOrdinal(1);

            }
            else if (numbering == Enumeration.Qnum)
            {
                reportTable.Columns["Qnum"].SetOrdinal(0);
                reportTable.Columns["VarName"].SetOrdinal(1);
            }
            else
            {
                reportTable.Columns["Qnum"].SetOrdinal(0);
                reportTable.Columns["AltQnum"].SetOrdinal(1);
                reportTable.Columns["VarName"].SetOrdinal(2);
            }

            if (LayoutOptions.BlankColumn)
                reportTable.Columns.Add(new DataColumn("Comments", Type.GetType("System.String")));


            // TODO set the column order as defined by the ColumnOrder property

            
            // at this point the reportTable should be exactly how we want it to appear, minus interpreting tags

            // sort the report
            DataView dv = reportTable.DefaultView;
            dv.Sort = "SortBy ASC";
            reportTable = dv.ToTable();
            reportTable.Columns.Remove("SortBy");

            // output report to Word/PDF
            OutputReportTable();
            return 0;
        }

        private int GenerateLabelReport()
        {
            foreach (Survey s in surveys)
            {
                s.GenerateSourceTable();
                // TODO figure out datasets
                // create a relationship between main survey and other surveys on refVarName

                if (s.rawTable.Rows.Count == 0)
                {
                    return 1;
                }
                //SurveyReportData.Tables.Add(s.rawTable);
            }



            return 0;
        }

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


        // Add a Survey object to the list of surveys and set it's ID to the next available number starting with 1
        public void AddSurvey(Survey s) {
            int newID=1;
            surveys.Add(s);

            while (GetSurvey(newID) != null) {
                newID++;
            }
            if (newID == 1)
                s.Qnum = true;
            else
                s.Qnum = false; 

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

            Word.Application appWord;   // instance of MSWord
            Word.Document docReport;    // the report document
            Word.Table surveyTable;     // the table in the document containing the survey(s)

            int rowCount = reportTable.Rows.Count;          // number of rows in the survey table
            int columnCount = reportTable.Columns.Count;    // number of columns in the survey table
            int clearCols; // the number of columns that should have their contents cleared, for headings

            // create the instance of Word
            appWord = new Word.Application();
            appWord.Visible = false;
            // disable spelling and grammar checks (useful for foreign languages)
            appWord.Options.CheckSpellingAsYouType = false;
            appWord.Options.CheckGrammarAsYouType = false;

            // create the document
            //  TODO store template path somewhere
            switch (LayoutOptions.PaperSize) {
                case PaperSizes.Letter:
                    docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLandLet.dotx");
                    break;
                case PaperSizes.Legal:
                    docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLandLeg.dotx");
                    break;
                case PaperSizes.Eleven17:
                    docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLand11.dotx");
                    break;
                case PaperSizes.A4:
                    docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLandA4.dotx");
                    break;
                default:
                    docReport = appWord.Documents.Add("\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\Templates\\SMGLandLet.dotx");
                    break;
            }
            // add a table
            surveyTable = docReport.Tables.Add(docReport.Range(0, 0), rowCount + 1, columnCount);

            // fill header row
            for (int c = 1; c <= columnCount; c++)
            {
                surveyTable.Cell(1, c).Range.Text = reportTable.Columns[c - 1].Caption;
            }

            // fill the rest of the rows
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    surveyTable.Cell(r + 2, c + 1).Range.Text = reportTable.Rows[r][c].ToString();
                }
            }
            
            // table style
            surveyTable.Rows.AllowBreakAcrossPages = -1;
            surveyTable.Rows.Alignment = 0;
            surveyTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
            surveyTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            surveyTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            surveyTable.Borders.OutsideColor = Word.WdColor.wdColorGray25;
            surveyTable.Borders.InsideColor = Word.WdColor.wdColorGray25;
            surveyTable.Select();
            docReport.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;

            //header row style
            surveyTable.Rows[1].Range.Bold = 1;
            surveyTable.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorRose;
            surveyTable.Rows[1].Borders.OutsideColor = Word.WdColor.wdColorBlack;
            surveyTable.Rows[1].Borders.InsideColor = Word.WdColor.wdColorBlack;
            surveyTable.Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalTop;
            surveyTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            // repeat heading row
            if (repeatedHeadings)
                surveyTable.Rows[1].HeadingFormat = -1;
            else
                surveyTable.Rows[1].HeadingFormat = 0;

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
                docReport.Application.Selection.Text = docReport.Application.Selection.Text + "\r\n" + HighlightingKey();
            }
            docReport.Application.Selection.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            // if there are filters, add a description of the filter
            docReport.Application.Selection.Text = "\r\n" + FilterLegend();
            docReport.Application.Selection.Font.Size = 12;

            // footer text
            docReport.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InsertAfter("\t" + ReportTitle() +
                "\t\t" + "Generated on " + DateTime.Today.ToString("d"));

            //
            docReport.Paragraphs.SpaceAfter = 0;

            // format column names and widths
            FormatColumns(docReport);

            // TODO format subset tables
            if (tables && numbering == Enumeration.Qnum && reportType == ReportTypes.Standard) {
                //appWord.Visible = true;
                LayoutOptions.FormatTables(docReport, tablesTranslation);
            }

            // create TOC
            if (layoutoptions.ToC != TableOfContents.None) { MakeToC(docReport); }

            // create title page
            if (layoutoptions.CoverPage) { MakeTitlePage(docReport); }

            // format section headings
            if (reportType == ReportTypes.Standard)
            {

                // process headings
                formatting.FormatHeadings(docReport, (int) numbering, false, showAllQnums, colorSubs);
            }

            // update TOC due to formatting changes (see if the section headings can be done first, then the TOC could update itself)
            if (layoutoptions.ToC == TableOfContents.PageNums && docReport.TablesOfContents.Count > 0) { docReport.TablesOfContents[1].Update(); }

            // TODO add survey notes appendix
            if (survNotes) { MakeSurveyNotesAppendix(docReport); }

            // TODO add varname changes as appendix
            if (varChangesApp) { MakeVarChangesAppendix(); }

            // interpret formatting tags
            formatting.FormatTags(appWord, docReport, surveycompare.Highlight);

            // TODO convert TC tags into real tracked changes
            if (surveycompare.ConvertTrackedChanges) { formatting.ConvertTC(docReport); }

            // TODO format shading for order comparisons
            if (reportType == ReportTypes.Order) { formatting.FormatShading(docReport); }

            fileName += ReportFileName() + ", " + DateTime.Today.ToString("d").Replace("-", "");
            fileName += ".doc";

            //save the file
            docReport.SaveAs2(fileName);




            // close the document and word if this is an automatic survey
            if (batch) {
                if (layoutoptions.FileFormat == FileFormats.PDF)
                {
                    docReport.ExportAsFixedFormat(fileName.Replace(".doc", ".pdf"), Word.WdExportFormat.wdExportFormatPDF, true,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint, Word.WdExportRange.wdExportAllDocument, 1, 1,
                        Word.WdExportItem.wdExportDocumentContent, true, true, Word.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false);
                }
                docReport.Close();
                appWord.Quit();
            }
            else
            {
                if (layoutoptions.FileFormat == FileFormats.PDF)
                {
                    try
                    {
                        docReport.ExportAsFixedFormat(fileName.Replace(".doc", ".pdf"), Word.WdExportFormat.wdExportFormatPDF, true,
                            Word.WdExportOptimizeFor.wdExportOptimizeForPrint, Word.WdExportRange.wdExportAllDocument, 1, 1,
                            Word.WdExportItem.wdExportDocumentContent, true, true, Word.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false);
                    } catch (Exception e)
                    {
                        // TODO handle the error (PDF converter not installed, or file in use
                    }
                    finally
                    {
                        docReport.Close();
                        appWord.Quit();
                    }
                }
                else
                {
                    appWord.Visible = true;
                }
                
            }
            
        }

        // TODO 
        public void IncludeOrderChanges() { }

        // TODO 
        public void IncludeDeletedQuestions() { }

        // TODO 
        public void MarkOrderChanges() { }
  
        public String GetReInsertedComments() { return ""; }


        /// <summary>
        /// Creates a new section at the beginning of the document. Adds a table containing the ITC logo, the survey title and additional information
        ///about the survey.
        /// </summary>
        /// <param name="doc"></param>
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
            // TODO see if the resource file can be used here
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

        /// <summary>
        /// Creates a new section at the top of the document. Adds a table of contens in 1 of 2 ways. Either a TableOfContents object is created and 
        /// based on the headings in the document, or the text and Qnums for each heading are listed in a table.
        /// </summary>
        /// <param name="doc">Document object</param>
        public void MakeToC(Word.Document doc) {
            // exit if no headings found
            //if (Utilities.DTLookup(reportTable, "Qnum", "Qnum = 'reghead'").Equals(""))
            //    return;

            DataRow[] headingRows;
            string[,] headings;
            Survey qnumSurvey = QnumSurvey();
            object missingType = Type.Missing;
            switch (LayoutOptions.ToC)
            {
                case TableOfContents.None:
                    break;
                case TableOfContents.Qnums:

                    headingRows = qnumSurvey.finalTable.Select("VarName Like 'Z%'");
                    headings = new string[headingRows.Length, 2];
                    
                    for (int i = 0; i < headingRows.Length; i ++) 
                    {
                        headings[i, 0] = (string) headingRows[i]["PreP"];
                        headings[i, 1] = (string)headingRows[i]["SortBy"];
                        headings[i, 1] = headings[i, 1].Substring(0, 3);
                    }
                    // create new section in document
                    doc.Range(0, 0).InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);
                    // create table of contents
                    doc.Tables.Add(doc.Range(0, 0), headings.GetUpperBound(0) + 1, 2, Word.WdDefaultTableBehavior.wdWord8TableBehavior, Word.WdAutoFitBehavior.wdAutoFitContent);
                    // format table
                    doc.Sections[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    doc.Sections[1].Range.Font.Name = "Cambria (Headings)";
                    doc.Sections[1].Range.Font.Size = 12;

                    // fill table
                    doc.Tables[1].Cell(1, 1).Range.Text = "TABLE OF CONTENTS";
                    doc.Tables[1].Cell(1, 1).Range.Font.Bold = -1;
                    for (int i = 0; i < headings.GetUpperBound(0); i++)
                    {
                        doc.Tables[1].Cell(i + 2, 1).Range.Text = headings[i, 0];
                        doc.Tables[1].Cell(i + 2, 2).Range.Text = headings[i, 1];
                        doc.Tables[1].Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    }
                    doc.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleNone;
                    doc.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone;

                    break;
                case TableOfContents.PageNums:
                    // create new section in document
                    doc.Range(0, 0).InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);
                    doc.TablesOfContents.Add(doc.Range(0, 0), true, 1, 3, false, missingType, missingType, missingType, missingType, true);
                    break;
            }

        }

        // TODO fix date conversion in query
        public void MakeSurveyNotesAppendix(Word.Document doc) {
            Word.Range r;
            Word.Table t;
            DataTable surveyNotes = new DataTable();
            String cmdText = "SELECT Survey, Notes, NoteDate + '\r\n' + Name + '\r\n' + NoteType AS Author " +
                "FROM (qryCommentsAll LEFT JOIN qryNotes ON qryCommentsAll.CID = qryNotes.ID) LEFT JOIN qrySurveyInfo ON qryCommentsAll.SID = qrySurveyInfo.ID " +
                "WHERE Survey IN ('" + String.Join("','",Surveys) + "')";


            SqlCommand cmd = new SqlCommand();

            // set the command text and connection
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            // set the sql adapter's command to the cmd object
            sql.SelectCommand = cmd;
            // open connection and fill the table with results
            conn.Open();
            sql.Fill(surveyNotes);
            conn.Close();
            //surveyNotes.PrimaryKey = new DataColumn[] { surveyNotes.Columns["ID"] };

            r = doc.Range(doc.Content.StoryLength, doc.Content.StoryLength);
            r.InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);
            r.Font.Size = 20;
            r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            r.Text = "Appendix\r\nSurveyNotes";
            r.Move(Word.WdUnits.wdLine, 2);
            t = doc.Tables.Add(r, surveyNotes.Rows.Count, 3);
            for (int i = 0; i < surveyNotes.Rows.Count; i ++)
            {
                t.Cell(i + 1, 1).Range.Text  = (string)surveyNotes.Rows[i]["Survey"];
                t.Cell(i + 1, 2).Range.Text = (string)surveyNotes.Rows[i]["Notes"];
                t.Cell(i + 1, 3).Range.Text = (string)surveyNotes.Rows[i]["Author"];

            }

        }

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

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addDate"></param>
        /// <returns>String</returns>
        public String ReportTitle(bool addDate = false) {
            String title = "";
            String surveyCodes = "";

            if (surveys.Count == 1) {
                title = surveys[0].Title;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                if (surveys[i].Backend != DateTime.Today) {surveyCodes += " on " + surveys[i].Backend.ToString("d");}
                surveyCodes += " vs. ";
            }
            // trim off " vs. "
            if (surveyCodes.EndsWith(" vs. ")) { surveyCodes = surveyCodes.Substring(0, surveyCodes.Length - 5); }
            finalfilename = surveyCodes;
            if (details != "") { finalfilename += ", " + details; }
            if (!batch) { finalfilename += " generated"; }

            return finalfilename;
        }

        /// <summary>
        /// Returns a string describing the highlighting uses in the document.
        /// </summary>
        /// <returns></returns>
        public String HighlightingKey () {
            string currentSurv;
            string others = "";
            string primary = "";
            string otherH = "";
            string primaryH = "";
            string differentH = "";
            string orderChanges = "";
            bool showQnumOrder = false;
            string qnumorder = "";

            string finalKey= "";

            foreach (Survey s in surveys)
            {
                currentSurv = s.SurveyCode;
                if (s.Backend != DateTime.Today)
                    currentSurv += " on " + s.Backend.ToString("d");

                if (!s.Primary)
                    others += ", " + currentSurv;
                else
                    primary += currentSurv;

                if (s.Qnum && s.ID != 1)
                {
                    showQnumOrder = true;
                    qnumorder = currentSurv;
                }


            }
            others = Utilities.TrimString(others, ", ");

            if (reportType ==ReportTypes.Standard)
            {
                if (surveycompare.HighlightStyle == HStyle.Classic)
                {
                    otherH = "[yellow]In " + others + " only.[/yellow]";
                    primaryH = "\t[t]In " + primary + " only.[/t]";
                    differentH = "\t[brightgreen] Different in " + primary + " and " + others + "[/brightgreen]";
                    if (surveycompare.HybridHighlight)
                        differentH += "\r\n" + "<Font Color=Blue>In " + others + " only.</Font>\t<Font Color=Red>In " + primary + " only.</Font>";

                } else if (surveycompare.HighlightStyle == HStyle.TrackedChanges)
                {
                    otherH = "<Font Color=Red>In " + primary + " only.</Font>";
                    primaryH = "\t<Font Color=Blue>In " + others + " only.</Font>";
                }

                if (surveycompare.ShowOrderChanges)
                    orderChanges = "\r\n" + "Pink file: location in " + primary + "\tBlue fill: location in " + others;

                if (showQnumOrder)
                    qnumorder = "Question order determined by: " + qnumorder;
                else
                    qnumorder = "";

                finalKey = "Highlighting key: " + otherH + differentH;
                if (surveycompare.ShowDeletedFields || surveycompare.ShowDeletedQuestions)
                    finalKey += primaryH;

                finalKey += "\r\n" + qnumorder + orderChanges;
                   
            }
            else if (reportType == ReportTypes.Order)
            {
                finalKey = "Highlighting key:  [yellow] In " + primary + " only [/yellow]";
                if (surveycompare.ShowDeletedFields || surveycompare.ShowDeletedQuestions)
                    finalKey += "   [t]   In " + others + " only [/t] ";
            }

            return finalKey;
        }

        public void SetColumnOrder() { }

        public void RemoveDuplicateColums() { }

        public void StatusUpdate() { }

        public bool IsCompleteTF() { return true; }

        public bool IsCompleteSurvey() { return true; }

        /// <summary>
        /// Format the header row so with the appropriate widths and titles
        /// </summary>
        /// <param name="doc"></param>
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
                case PaperSizes.Letter: widthLeft = 10.5; break;
                case PaperSizes.Legal: widthLeft = 13.5; break;
                case PaperSizes.Eleven17: widthLeft = 16.5; break; 
                case PaperSizes.A4: widthLeft = 11.7; break;
                default: widthLeft = 10.5; break;
            }
            // Qnum and VarName
            otherCols = 2;

            if (numbering == Enumeration.Both && reportType !=ReportTypes.Label) {
                qCol = 4;
                otherCols++; // AltQnum
            }
            else
            {
                qCol = 3;
            }

            doc.Tables[1].AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitFixed);

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
                        doc.Tables[1].Columns[i].Width = qnumWidth * 72;
                        widthLeft -= qnumWidth;
                        break;
                    case "AltQnum":
                        doc.Tables[1].Rows[1].Cells[i].Range.Text = "AltQ#";
                        doc.Tables[1].Columns[i].Width = altqnumWidth * 72;
                        widthLeft -= altqnumWidth;
                        break;
                    case "VarName":
                        doc.Tables[1].Columns[i].Width = varWidth * 72;
                        widthLeft -= varWidth;
                        break;
                    case "Response":
                        doc.Tables[1].Columns[i].Width = respWidth * 72;
                        widthLeft -= respWidth;
                        break;
                    case "Info":
                        doc.Tables[1].Columns[i].Width = tcWidth * 72;
                        widthLeft -= tcWidth;
                        break;
                    case "SortBy":
                        doc.Tables[1].Columns[i].Width = qnumWidth * 72;
                        widthLeft -= qnumWidth;
                        break;
                    case "Comments":
                        doc.Tables[1].Columns[i].Width = commentWidth * 72;
                        widthLeft -= commentWidth;
                        break;
                    default: 
                        // question column with date, format date
                        if (header.Contains(DateTime.Today.ToString("d").Replace("-", "")))
                        {
                            doc.Tables[1].Rows[1].Cells[i].Range.Text = doc.Tables[1].Rows[1].Cells[i].Range.Text.Replace(DateTime.Today.ToString("d"), "");
                        } 

                        // an additional AltQnum column
                        if (header.Contains("AltQnum"))
                        {
                            doc.Tables[1].Columns[i].Width = altqnumWidth * 72;
                            widthLeft -= altqnumWidth;
                        } else if (header.Contains("AltQnum")) // an additional Qnum column
                        {
                            doc.Tables[1].Columns[i].Width = qnumWidth * 72;
                            widthLeft -= qnumWidth;
                        }

                        // filter column
                        if (header.Contains("Filters"))
                        {
                            // TODO set to Verdana 9 font
                        }

                        // TODO test these
                        if (reportType == ReportTypes.Order)
                        {
                            if (header.Contains("VarName"))
                            {
                                doc.Tables[1].Columns[i].Width = varWidth * 72;
                                widthLeft -= varWidth;
                            } else if (header.Contains("Qnum")) {
                                doc.Tables[1].Columns[i].Width = (qnumWidth * 2) * 72;
                                widthLeft -= qnumWidth;
                            } else if (header.Contains("Question")) {
                                doc.Tables[1].Columns[i].Width = (float)3.5 * 72;
                                widthLeft -= 3.5;
                            }
                        }

                        break;
                }
                
            }
            // TODO distribute the rest of the columns

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

        public ReportTypes ReportType { get { return reportType; } set { reportType = value; } }

        
        //public String QRange { get => qRange; set => qRange = value; }
        //public String[] Prefixes { get => prefixes; set => prefixes = value; }
        //public String[] Headings { get => headings; set => headings = value; }
        //public String[] Varnames { get => varnames; set => varnames = value; }
        
        public bool Compare { get => compare; set => compare = value; }
        
        public List<string> RepeatedFields
        {
            get => repeatedFields;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.RepeatedFields = value;
                }
                repeatedFields = value;
            }
        }
        public bool InlineRouting
        {
            get => inlineRouting;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.InlineRouting = value;
                }
                inlineRouting = value;
            }
        }
        public bool ShowLongLists
        {
            get => showLongLists;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.ShowLongLists = value;
                }
                showLongLists = value;
            }
        }
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
        public bool Tables { get => tables;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.SubsetTables = value;
                }
                tables = value;
            }
        }
        public bool TablesTranslation { get => tablesTranslation; set
            {
                foreach (Survey s in surveys)
                {
                    s.SubsetTablesTranslation = value;
                }
                tablesTranslation = value;
            }
        }
        public List<string> ColumnOrder { get => columnOrder; set => columnOrder = value; }
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
        public bool VarChangesCol {
            get => varChangesCol;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.IncludePrevNames = value;
                }
                varChangesCol = value;
            }
        }

        public bool ExcludeTempChanges { get => excludeTempChanges; set => excludeTempChanges = value; }
        public bool ShowAllQnums {
            get => showAllQnums;
            set
            {
                foreach (Survey s in surveys)
                {
                    s.ShowAllQnums = value;
                }
                showAllQnums = value;
            }
        }
        public String Details { get => details; set => details = value; }
        public bool Combine { get => combine; set => combine = value; }
        public bool CheckOrder { get => checkOrder; set => checkOrder = value; }
        public bool CheckTables { get => checkTables; set => checkTables = value; }
        public bool Batch { get => batch; set => batch = value; }
        public Comparison SurveyCompare { get => surveycompare; set => surveycompare = value; }
        public ReportLayout LayoutOptions { get => layoutoptions; set => layoutoptions = value; }
        public DataTable ReportTable { get => reportTable; set => reportTable = value; }




        #endregion

    }

        
}
