using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Data;

namespace ITCSurveyReportLib
{
    // NOTE: NOT NEEDED ANYMORE
    // this report is just a regular ISR report where the question is removed and the labels are included
    // added an option to ISR to include question column
    /// <summary>
    /// Deprecated class. Absorbed into VarNameReport.cs
    /// </summary>
    public class SurveyOverviewReport : SurveyBasedReport
    {
        /*
        public int GenerateSurveyOverview()
        {
            DataTable dt = MakeFinalTable(Surveys[0]);

            reportTable = new DataView(dt).ToTable(false, new string[] { "Qnum", "VarName", "VarLabel", "Topic", "Content" });

            OutputSurveyOverview();

            return 0;
        }

        /// <summary>
        /// Returns a string describing the highlighting uses in the document. TODO
        /// </summary>
        /// <returns></returns>
        public string HighlightingKey()
        {
            string currentSurv;
            string others = "";
            string primary = "";
            string otherH = "";
            string primaryH = "";
            string differentH = "";
            string orderChanges = "";
            bool showQnumOrder = false;
            string qnumorder = "";

            string finalKey = "";

            foreach (ReportSurvey s in Surveys)
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

            

            return finalKey;
        }

        public void OutputSurveyOverview()
        {
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
            switch (LayoutOptions.PaperSize)
            {
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
            if (RepeatedHeadings)
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
            if (Surveys.Count > 1)
            {
                docReport.Application.Selection.Text = docReport.Application.Selection.Text + "\r\n" + HighlightingKey();
            }
            docReport.Application.Selection.Collapse(Word.WdCollapseDirection.wdCollapseEnd);

            // if there are filters, add a description of the filter
            //docReport.Application.Selection.Text = "\r\n" + FilterLegend();
            //docReport.Application.Selection.Font.Size = 12;

            // footer text
            docReport.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InsertAfter("\t" + ReportTitle() +
                "\t\t" + "Generated on " + DateTime.Today.ToString("d"));

            //
            docReport.Paragraphs.SpaceAfter = 0;

            // format column names and widths
            FormatColumns(docReport);

            // format section headings
            if (ReportType == ReportTypes.Standard)
            {
                // process headings
                Formatting.FormatHeadings(docReport, (int)Numbering, true, ShowAllQnums, ColorSubs);
            }

            Formatting.FormatTags(appWord, docReport, false);

            FileName += ReportFileName() + ", " + DateTime.Today.ToString("d").Replace("-", "") + " (" + DateTime.Now.ToString("hh.mm.ss") + ")";
            FileName += ".doc";

            //save the file
            docReport.SaveAs2(FileName);





            if (LayoutOptions.FileFormat == FileFormats.PDF)
            {
                try
                {
                    docReport.ExportAsFixedFormat(FileName.Replace(".doc", ".pdf"), Word.WdExportFormat.wdExportFormatPDF, true,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint, Word.WdExportRange.wdExportAllDocument, 1, 1,
                        Word.WdExportItem.wdExportDocumentContent, true, true, Word.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false);
                }
                catch (Exception)
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
        */
    }

}
