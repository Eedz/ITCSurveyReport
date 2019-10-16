using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ITCLib;

namespace ITCSurveyReport
{
    /// <summary>
    /// User interface for generating a Survey-based report.
    /// </summary>
    public partial class SurveyReportForm : Form
    {
        // TODO depending on which type of report is chosen, create an object of that type and bind the controls of the form to that type
        SurveyBasedReport SR;
        // this report survey is just to hold the question filter selections. Just before the report is run, the filters will be copied to each report survey object in the report's list.
        ReportSurvey questionFilters;
        int filterBy;
        Comparison compare;
        ReportTypes reportType;
        UserPrefs UP;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;
        //BindingSource ReportBindingSource;

        // background color RGB values
        //int backColorR = 55;
        //int backColorG = 170;
        //int backColorB = 136;

        // quick report descriptions
        string standardToolTipText = "Standard Survey Printout\r\n" +
                                    "Includes:\r\n" +
                                    "Blank Column\r\n" +
                                    "VarName Changes\r\n" +
                                    "QN Insertion (F2F only)\r\n" +
                                    "Don't Read (F2F only)\r\n" +
                                    "For 2 or more surveys:\r\n" +
                                    "Classic Highlighting with Re-inserted deletions";

        

        /// <summary>
        /// 
        /// </summary>
        public SurveyReportForm()
        {
            InitializeComponent();
            
            cmdAddSurvey.Text = char.ConvertFromUtf32(0x2192);
            cmdRemoveSurvey.Text= char.ConvertFromUtf32(0x2190);
            cmdAddPrefixHeading.Text = char.ConvertFromUtf32(0x2192);
            cmdRemovePrefixHeading.Text = char.ConvertFromUtf32(0x2190);
            cmdAddVarName.Text = char.ConvertFromUtf32(0x2192);
            cmdRemoveVarName.Text = char.ConvertFromUtf32(0x2190);

            // start with blank constructor, default settings
            reportType = ReportTypes.Standard;
            SR = new SurveyBasedReport();
            UP = new UserPrefs();
            questionFilters = new ReportSurvey();
        }

        /// <summary>
        /// After the form is created, perform some initial setup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyReportForm_Load(object sender, EventArgs e)
        {
            // fill the survey drop down
            cboSurveys.ValueMember = "Survey";
            cboSurveys.DisplayMember = "Survey";
            cboSurveys.DataSource = DBAction.GetSurveyList();

            // add tooltips for the quick reports
            // toolTipStandard.SetToolTip(this.optStd, standardToolTipText);
            toolTipStandard.ShowAlways = true;
            toolTipStandard.AutomaticDelay = 0;
            toolTipStandard.AutoPopDelay = 30000;

            // hide the comparison tab until it is needed
            pgCompareTab = pgCompare;
            tabControlOptions.TabPages.Remove(pgCompare);

            // bind the controls of the form to the SR object
            surveyReportBindingSource.DataSource = SR;

            compare = new Comparison()
            {
                SimilarWords = DBAction.GetSimilarWords() // populate the similar words list
            };

            compareBindingSource.DataSource = compare;

            reportLayoutBindingSource.DataSource = SR.LayoutOptions;
            
            // populate the repeated fields list
            lstRepeatedFields.Items.Add("PreP");
            lstRepeatedFields.Items.Add("PreI");
            lstRepeatedFields.Items.Add("PreA");
            lstRepeatedFields.Items.Add("LitQ");
            lstRepeatedFields.Items.Add("RespOptions");
            lstRepeatedFields.Items.Add("NRCodes");
            lstRepeatedFields.Items.Add("PstI");
            lstRepeatedFields.Items.Add("PstP");

            // populate highlight scheme box
            cboHighlightScheme.DataSource = Enum.GetValues(typeof(HScheme));


            // bind selected surveys to the list of surveys in SR
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            // bind question filters to the holding object
            filterBy = 1;
            txtQrangeLow.DataBindings.Add("Text", questionFilters, "QRangeLow");
            txtQrangeHigh.DataBindings.Add("Text", questionFilters, "QRangeHigh");
            // varnames     
            lstSelectedVarNames.DataSource = questionFilters.Varnames;

            optQuestionRange.Checked = true;

            lblStatus.Visible = false;
            lblStatus.Text = "Ready.";
            cmdCheckOptions.Visible = false;
            


        }

        //private void ChangeReportType(ReportTypes type)
        //{
        //    switch (type) {
        //        case ReportTypes.Standard:
        //            ReportBindingSource = null;
        //            break;
        //        case ReportTypes.Label:
        //            ReportBindingSource = null;
        //            break;
        //        case ReportTypes.Order:
        //            ReportBindingSource = null;
        //            break;
        //    }
        //}

        private void BindControls()
        {

        }

        #region Menu Strip

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void standardWTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void websiteWTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion



        /// <summary>
        /// Generate the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckOptions_Click(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItems.Count == 0)
            {
                MessageBox.Show("No surveys selected.");
                return;
            }
            UpdateColumnOrder();
            // set file name to the user's report path
            SR.FileName = UP.ReportPath;

            // get the survey data for all chosen surveys
            PopulateSurveys();

            // if standard is not chosen, create a new SR with the chosen template
            switch (reportType)
            {
                case ReportTypes.Standard:

                    RunSurveyReport();
                  
                    break;
                case ReportTypes.Label:

                    RunLabelReport();
                    
                    break;
            }

        }

        private void RunSurveyReport()
        {
            int result;
            SurveyReport survReport = new SurveyReport(SR)
            {
                SurveyCompare = compare
            };

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", survReport, "ReportStatus"));

            result = survReport.GenerateReport();
            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }


            // output report to Word/PDF
            survReport.OutputReportTableXML();
            
        }

        private void RunLabelReport()
        {
            int result;
            TopicContentReport TC = new TopicContentReport(SR);

            result = TC.GenerateLabelReport();
            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }

            TC.OutputReportTable();
        }

        

        /// <summary>
        /// For each survey in the report, fill the question list, comments and translations as needed.
        /// </summary>
        private void PopulateSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
                if (filterBy == 1)
                {
                    rs.QRangeHigh = questionFilters.QRangeHigh;
                    rs.QRangeLow = questionFilters.QRangeLow;
                    rs.Prefixes = null;
                    rs.Headings = null;
                }
                else if (filterBy == 2)
                {
                    rs.QRangeHigh = 0;
                    rs.QRangeLow = 0;
                    rs.Prefixes = questionFilters.Prefixes;
                    rs.Headings = null;
                } else if (filterBy == 3)
                {
                    rs.QRangeHigh = 0;
                    rs.QRangeLow = 0;
                    rs.Prefixes = null;
                    rs.Headings = questionFilters.Headings;
                }
                
                rs.Varnames = questionFilters.Varnames;

                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();

                // questions
                if (rs.Backend.Date != DateTime.Today)
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetBackupQuestions(rs, rs.Backend)));
                else
                    DBAction.FillQuestions(rs);

                // correct questions
                if (rs.Corrected)
                {
                    DBAction.FillCorrectedQuestions(rs);
                    rs.CorrectWordings();
                }

                // previous names (for Var column)
                DBAction.FillPreviousNames(rs, SR.ExcludeTempChanges);

                // survey notes
                if (SR.SurvNotes)
                    rs.SurveyNotes = DBAction.GetSurvCommentsBySurvey(rs.SID);

                // comments
                if (rs.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                    //DBAction.FillCommentsBySurvey(rs, rs.CommentFields, rs.CommentDate, rs.CommentAuthors, rs.CommentSources, rs.CommentText);
                }

                // translations
                foreach (string language in rs.TransFields)
                    DBAction.FillTranslationsBySurvey(rs, language);

                // filters
                if (rs.FilterCol)
                    rs.MakeFilterList();

                // varchanges (for appendix)
                if (SR.VarChangesApp)
                    rs.VarChanges = DBAction.GetVarNameChangeBySurvey(rs.SurveyCode, SR.ExcludeTempChanges);
            }
        }

        private void UpdateColumnOrder()
        {
            List<ReportColumn> columns = new List<ReportColumn>();
            for (int i = 0; i < gridColumnOrder.ColumnCount; i++)
            {
                columns.Add(new ReportColumn(gridColumnOrder.Columns[i].HeaderText, gridColumnOrder.Columns[i].DisplayIndex + 1));
            }
            SR.ColumnOrder = columns;
        }

        #region Current Survey "Load" Methods

        // bind each control to the selected survey's corresponding fields
        private void LoadSurveyOptions()
        {
            if (CurrentSurvey == null)
                return;

            // backend date
            dateBackend.DataBindings.Clear();
            dateBackend.DataBindings.Add("Value", CurrentSurvey, "Backend");

            // question filters will be applied to all surveys rather than individually. so we will not bind these properties
            // filters
            // Qnum range
            //txtQrangeLow.DataBindings.Clear();
            //txtQrangeLow.DataBindings.Add("Text", CurrentSurvey, "QRangeLow");
            //txtQrangeHigh.DataBindings.Clear();
            //txtQrangeHigh.DataBindings.Add("Text", CurrentSurvey, "QRangeHigh");

            //// prefixes
            if (filterBy == 2)
            {
                LoadPrefixes(CurrentSurvey.SurveyCode);
                //lstPrefixes.DataBindings.Clear();
                //lstPrefixes.DataSource = CurrentSurvey.Prefixes;
            } else if (filterBy == 3) { 
                //// headings
                LoadHeadings(CurrentSurvey.SurveyCode);
                //lstHeadings.DataBindings.Clear();
                //lstHeadings.DataSource = CurrentSurvey.Headings;
            }
            //// varnames
            LoadVarNames(CurrentSurvey.SurveyCode);
            //lstSelectedVarNames.DataBindings.Clear();
            //lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;

            // standard fields
            lstStdFields.SelectedItems.Clear();
            foreach (object item in CurrentSurvey.StdFieldsChosen)
            {
                for (int i = 0; i < lstStdFields.Items.Count; i++)
                    if (item.ToString().Equals(lstStdFields.Items[i].ToString()))
                        lstStdFields.SetSelected(i, true);
                    
            }

            // comments and translations
            // list them
            LoadExtraFields(CurrentSurvey);
            // select them
            foreach (object item in CurrentSurvey.TransFields)
            {
                for (int i = 0; i < lstTransFields.Items.Count; i++)
                    if (item.ToString().Equals(lstTransFields.Items[i].ToString()))
                        lstTransFields.SetSelected(i, true);

            }

            foreach (object item in CurrentSurvey.CommentFields)
            {
                for (int i = 0; i < lstCommentFields.Items.Count; i++)
                    if (item.ToString().Equals(lstCommentFields.Items[i].ToString()))
                        lstCommentFields.SetSelected(i, true);

            }

            switch (CurrentSurvey.RoutingFormat)
            {
                case RoutingStyle.Normal:
                    optRoutingStyleNormal.Checked = true;
                    break;
                case RoutingStyle.Grey:
                    optRoutingStyleGrey.Checked = true;
                    break;
                case RoutingStyle.None:
                    optRoutingStyleNone.Checked = true;
                    break;
            }

            chkEnglishRouting.DataBindings.Clear();
            chkEnglishRouting.DataBindings.Add("Checked", CurrentSurvey, "EnglishRouting");


            txtCommentFilter.DataBindings.Clear();
            txtCommentFilter.DataBindings.Add("Text", CurrentSurvey, "CommentText");

            chkCorrected.Visible = CurrentSurvey.HasCorrectedWordings;

            chkCorrected.DataBindings.Clear();
            chkCorrected.DataBindings.Add("Checked", CurrentSurvey, "Corrected");

            // extra fields
            chkFilterCol.DataBindings.Clear();
            chkFilterCol.DataBindings.Add("Checked", CurrentSurvey, "FilterCol");
            chkDomainCol.DataBindings.Clear();
            chkDomainCol.DataBindings.Add("Checked", CurrentSurvey, "DomainLabelCol");
            chkTopicCol.DataBindings.Clear();
            chkTopicCol.DataBindings.Add("Checked", CurrentSurvey, "TopicLabelCol");
            chkContentCol.DataBindings.Clear();
            chkContentCol.DataBindings.Add("Checked", CurrentSurvey, "ContentLabelCol");
            chkVarLabelCol.DataBindings.Clear();
            chkVarLabelCol.DataBindings.Add("Checked", CurrentSurvey, "VarLabelCol");
            chkProductCol.DataBindings.Clear();
            chkProductCol.DataBindings.Add("Checked", CurrentSurvey, "ProductLabelCol");
            chkAltQNum2Col.DataBindings.Clear();
            chkAltQNum2Col.DataBindings.Add("Checked", CurrentSurvey, "AltQnum2Col");
            chkAltQNum3Col.DataBindings.Clear();
            chkAltQNum3Col.DataBindings.Add("Checked", CurrentSurvey, "AltQnum3Col");

        }

        private void LoadPrefixes(string survey)
        {
            cboPrefixesHeadings.DataSource = null;
            cboPrefixesHeadings.ValueMember = "Prefix";
            cboPrefixesHeadings.DisplayMember = "Prefix";
            cboPrefixesHeadings.DataSource = DBAction.GetVariablePrefixes(survey);
            cboPrefixesHeadings.SelectedItem = null;
        }

        private void LoadVarNames(string survey)
        {
            cboVarNames.ValueMember = "VarName";
            cboVarNames.DisplayMember = "VarName";
            
            if (lstPrefixesHeadings.Items.Count > 0)
            {
                List<string> vars = DBAction.GetVariableList(survey);
                
                List<string> prefixes = (List<string>)lstPrefixesHeadings.DataSource;

                vars = vars.Where(x => prefixes.Contains(x.Substring(0, 2))).ToList();
                
                cboVarNames.DataSource = vars;
            }
            else
            {
                cboVarNames.DataSource = DBAction.GetVariableList(survey);
            }
            
            cboVarNames.SelectedItem = null;
        }

        private void LoadHeadings(string survey)
        {
            cboPrefixesHeadings.DataSource = null;
            cboPrefixesHeadings.ValueMember = "Qnum";
            cboPrefixesHeadings.DisplayMember = "PreP";
            cboPrefixesHeadings.DataSource = DBAction.GetHeadings(survey);
        }

        private void LoadExtraFields(Survey survey)
        {
            // load comment types
            List<string> noteTypes = DBAction.GetQuesCommentTypes(survey.SID);

            lstCommentFields.Items.Clear();
            foreach (string s in noteTypes)
                lstCommentFields.Items.Add(s); 

            // load comment authors
            List<Person> authors = DBAction.GetCommentAuthors(survey.SID);

            lstCommentAuthors.DisplayMember = "Name";
            lstCommentAuthors.ValueMember = "NoteInit";
            lstCommentAuthors.DataSource = authors;
            
            if (lstCommentAuthors.Items.Count >0 )
                lstCommentAuthors.SetSelected(0, false);

            // load comment source names (authorities)
            List<string> sourceNames = DBAction.GetCommentSourceNames(survey.SurveyCode);

            foreach (string s in sourceNames)
                lstCommentSources.Items.Add(s);

            // load translation languages
            List<string> langs = DBAction.GetLanguages(survey);

            lstTransFields.Items.Clear();
            foreach (string s in langs)
                lstTransFields.Items.Add(s);

        }

        #endregion


        #region Top of Form (Add and Remove surveys)

        private void AddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            ReportSurvey s;
            try
            {
                s = new ReportSurvey(DBAction.GetSurveyInfo(cboSurveys.SelectedItem.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            if (cboSurveys.SelectedIndex < cboSurveys.Items.Count-1)
                cboSurveys.SelectedIndex++;

            AddSurvey(s);
        }

        private void SelfCompare_Click(object sender, EventArgs e)
        {
            // add another survey with the already selected survey code

            ReportSurvey s;
            Survey item = lstSelectedSurveys.SelectedItem as Survey;
            try
            {
                s = new ReportSurvey(DBAction.GetSurveyInfo(item.SurveyCode));
            }
            catch (Exception)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            AddSurvey(s);

            // set focus to calendar
            dateBackend.Focus();

        }

        /// <summary>
        /// Add a survey to the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being added to the report.</param>
        private void AddSurvey(ReportSurvey s)
        {
            
            SR.AddSurvey(s);

            UpdateReportColumns(null, null);
            UpdateGrids();

            // show the options tabs if at least one survey is chosen
            if (lstSelectedSurveys.Items.Count > 0)
            {
                lblStatus.Visible = true;
                cmdCheckOptions.Visible = true;
                tabControlOptions.Visible = true;
            }

            // update report defaults
            ShowTranslationSubsetTableOption();
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        private void RemoveSurvey_Click(object sender, EventArgs e)
        {
            RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
        }

        /// <summary>
        /// Remove a survey from the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being removed from the report.</param>
        private void RemoveSurvey(ReportSurvey s)
        {
            // remove survey from the SurveyReport object
            SR.RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
            GC.Collect();

            UpdateReportColumns(null,null);
            UpdateGrids();

            // hide the options tabs no surveys are chosen
            if (lstSelectedSurveys.Items.Count < 1)
            {
                lblStatus.Visible = false;
                cmdCheckOptions.Visible = false;
                tabControlOptions.Visible = false;
            }

            // update report defaults
            ShowTranslationSubsetTableOption();
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        /// <summary>
        /// Update the report type in the SR object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            reportType = (ReportTypes)sel;
            SR.ReportType = reportType;
            ShowTranslationSubsetTableOption();
            UpdateDefaultOptions();
            UpdateFileNameTab();
        }

        private void dateBackend_ValueChanged(object sender, EventArgs e)
        {

            if (dateBackend.Value == DateTime.Today)
                return;

            string filePath = dateBackend.Value.ToString("yyyy-MM-dd");

            BackupConnection bkp = new BackupConnection(dateBackend.Value);

            if (!bkp.IsValidBackup())
            {

                MessageBox.Show("No backup found for this date.");
                dateBackend.Value = bkp.GetNearestBackup();
            }



        }

        /// <summary>
        /// Allow Enter/Return key to add the currently highlighted Survey in the combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Surveys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdAddSurvey.PerformClick();
                cboSurveys.Focus();
            }
        }

        /// <summary>
        /// Set the CurrentSurvey object to the currently selected survey in the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItem != null)
            {
                UpdateCurrentSurvey();
                LoadSurveyOptions();
            }
        }
        #endregion

        

        private void UpdateCurrentSurvey()
        {
            CurrentSurvey = (ReportSurvey)lstSelectedSurveys.SelectedItem;
            if (CurrentSurvey == null)
                return;

            lblCurrentSurveyFields.Text = CurrentSurvey.SurveyCode + " (" + CurrentSurvey.Backend.ToString("d") + ") field selections.";
        }

        private void UpdateDefaultOptions()
        {
            int surveyCount = SR.Surveys.Count;
            if (surveyCount > 1 && SR.ReportType == ReportTypes.Standard) {
                if( !tabControlOptions.TabPages.Contains(pgCompareTab)) tabControlOptions.TabPages.Insert(2,pgCompareTab);
                chkCompare.Enabled = true;
                chkCompare.Checked = true;
            }
            else
            {
                tabControlOptions.TabPages.Remove(pgCompareTab);
                chkCompare.Enabled = false;
                chkCompare.Checked = false;
            }

            if (!SR.CheckForDiffCountry())
                compare.MatchOnRename = true;
            else
                compare.MatchOnRename = false;

            cboHighlightScheme.Enabled = surveyCount == 2;


            if (surveyCount == 2) {
                if (SR.Surveys[0].SurveyCode == SR.Surveys[1].SurveyCode) // self compare
                {
                    cboHighlightScheme.SelectedItem = HScheme.Sequential;
                    compare.HighlightScheme = HScheme.Sequential;
                    cboHighlightScheme.Enabled = false;
                }
                else if (SR.CheckForDiffCountry())
                {
                    
                    cboHighlightScheme.SelectedItem = HScheme.AcrossCountry;
                    compare.HighlightScheme = HScheme.AcrossCountry;
                    cboHighlightScheme.Enabled = false;
                }
                else
                {
                    compare.HighlightScheme = HScheme.Sequential;
                    cboHighlightScheme.SelectedItem = HScheme.Sequential;
                    
                }
            }
            else
            {
                cboHighlightScheme.SelectedItem = HScheme.AcrossCountry;
            }
            beforeAfterReportCheckBox.Enabled = surveyCount == 2;

            semiTelCheckBox.Enabled = !(SR.ReportType == ReportTypes.Order) && !(surveyCount > 1);

            chkTableFormat.Enabled = !(surveyCount > 1);

            if (surveyCount > 1 || SR.ReportType == ReportTypes.Label)
            {
                SR.SubsetTables = false;
                chkTableFormat.Enabled = false;
                SR.SubsetTablesTranslation = false;
                chkTranslationTableFormat.Visible = false;
                chkTranslationTableFormat.Enabled = false;
            }


            if (SR.ReportType == ReportTypes.Label || !SR.HasF2F())
            {
                inlineRoutingCheckBox.Enabled = false;

            }
            else
            {
                inlineRoutingCheckBox.Enabled = true;
            }

            if (surveyCount > 1) {
                inlineRoutingCheckBox.Enabled = compare.HighlightStyle != HStyle.TrackedChanges;
            }


            // order comparisons
            // check for order comparison
            lblOrderOptions.Visible = SR.ReportType == ReportTypes.Order;
            includeWordingsCheckBox.Visible = SR.ReportType == ReportTypes.Order;
            bySectionCheckBox.Visible = SR.ReportType == ReportTypes.Order;

            // table of contents disabled for T/C reports, since it needs headings
            if (SR.ReportType == ReportTypes.Label)
            {
                optToCNone.Checked = true; // changing the checked state updates the SR object
            }

            groupToC.Enabled = SR.ReportType == ReportTypes.Standard;
            optToCPgNum.Enabled = !(surveyCount > 1);

            // "Don't read" options disabled for T/C and order reports
            if (SR.ReportType != ReportTypes.Standard)
                optNRFormatNeither.Checked = true;

            groupNRFormat.Enabled = SR.ReportType == ReportTypes.Standard;

            // Web format is disabled for T/C and order reports
            if (SR.ReportType != ReportTypes.Standard)
                webCheckBox.Checked = false;

            webCheckBox.Enabled = SR.ReportType == ReportTypes.Standard;
  
        }

        private void ShowTranslationSubsetTableOption()
        {
            if (SR.ReportType == ReportTypes.Standard && SR.Surveys.Count == 1 && SR.Surveys[0].TransFields.Count == 1)
                chkTranslationTableFormat.Visible = chkTableFormat.Checked;
            else
                chkTranslationTableFormat.Visible = false;
        }

        private void UpdateGrids()
        {
            UpdatePrimarySurveyGrid();
            UpdateColumnOrderGrid();
            UpdateQnumSurveyGrid();
        }

        private void UpdatePrimarySurveyGrid()
        {
            // populate the primary survey list
            chklstPrimarySurvey.Items.Clear();
            chklstPrimarySurvey.Items.AddRange(SR.Surveys.ToArray());

            // check off the primary survey
            for (int i = 0; i < chklstPrimarySurvey.Items.Count; i++)
            {
                ReportSurvey r = (ReportSurvey)chklstPrimarySurvey.Items[i];
                if (r.Primary)
                {
                    chklstPrimarySurvey.SetItemChecked(i, true);
                    chklstPrimarySurvey.SelectedItem = chklstPrimarySurvey.Items[i];
                }
                else
                    chklstPrimarySurvey.SetItemChecked(i, false);
            }
        }

        private void UpdateColumnOrderGrid()
        {
            // popluate the column order grid
            gridColumnOrder.Columns.Clear();
            DataTable columns = new DataTable();
            foreach (ReportColumn rc in SR.ColumnOrder)
            {
                columns.Columns.Add(new DataColumn(rc.ColumnName));

            }

            gridColumnOrder.DataSource = columns;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();
        }

        private void UpdateQnumSurveyGrid()
        {
            // populate the qnum survey grid
            chklstQnumSurvey.Items.Clear();
            chklstQnumSurvey.Items.AddRange(SR.Surveys.ToArray());

            // check off the qnum survey
            for (int i = 0; i < chklstQnumSurvey.Items.Count; i++)
            {
                ReportSurvey r = (ReportSurvey)chklstQnumSurvey.Items[i];
                if (r.Qnum)
                {
                    chklstQnumSurvey.SetItemChecked(i, true);
                    chklstQnumSurvey.SelectedItem = chklstQnumSurvey.Items[i];
                }
                else
                    chklstQnumSurvey.SetItemChecked(i, false);
            }
        }

        private void UpdateReportColumns(object sender, EventArgs e)
        {
            // force property to update before refreshing column list
            if (sender != null && sender is CheckBox)
            {
                CheckBox c = (CheckBox)sender;
                c.DataBindings[0].WriteValue();
            }

            SR.UpdateColumnOrder();
            UpdateColumnOrderGrid();
        }

        private void UpdateFileNameTab()
        {
            if (SR.Surveys.Count == 0)
                return;

            ReportSurvey primary = SR.PrimarySurvey();
            string mainSource = primary.SurveyCode;
            string secondSources = "";

            if (primary.Backend != DateTime.Today)
                mainSource += " on " + primary.Backend;


            foreach(ReportSurvey o in SR.NonPrimarySurveys())
            {
                secondSources += o.SurveyCode;
                if (o.Backend != DateTime.Today)
                {
                    secondSources += " on " + o.Backend;
                }

                secondSources += ", ";
            }

            secondSources = Utilities.TrimString(secondSources, ", ");

            txtMainSource.Text = mainSource;
            txtSecondSources.Text = secondSources;
            
       
        }

        private void UpdateReportDetails()
        {
            string details = "";
            string extras = "", comments = "", translation = "", filters = "", labels = "";
            switch (SR.ReportType)
            {
                case ReportTypes.Standard:
                    break;
                case ReportTypes.Label:
                    details += "Content comparison.";
                    break;
                case ReportTypes.Order:
                    details += "Order comparison.";
                    break;
            }

            foreach (ReportSurvey rs in SR.Surveys)
            {
                if (rs.CommentFields.Count > 0 && string.IsNullOrEmpty(comments))
                    comments += "comments, ";

                if (rs.TransFields.Count > 1 && string.IsNullOrEmpty(translation))
                    translation += "translation, ";

                if ((rs.VarLabelCol || rs.TopicLabelCol || rs.DomainLabelCol || rs.ContentLabelCol || rs.ProductLabelCol) && string.IsNullOrEmpty(labels))
                    labels += "labels, ";

                if (rs.FilterCol && string.IsNullOrEmpty(filters))
                    filters += "Filters, ";

            }

            extras = comments + translation + filters + labels;

            if (!string.IsNullOrEmpty(extras))
                details += " With " + extras;

            SR.Details = details;
        }


        #region Filters Tab
        // Add the selected prefix to the Current Survey's prefix list and refresh the Prefix listbox
        private void AddPrefix(object sender, EventArgs e)
        {
            if (cboPrefixesHeadings.SelectedValue != null && !lstPrefixesHeadings.Items.Contains(cboPrefixesHeadings.SelectedValue))
            {
                questionFilters.Prefixes.Add(cboPrefixesHeadings.SelectedValue.ToString());
                lstPrefixesHeadings.DataSource = null;
                lstPrefixesHeadings.DataSource = questionFilters.Prefixes;
                LoadVarNames(CurrentSurvey.SurveyCode);
            }
        }

        // Remove the selected prefix from the Current Survey's prefix list and refresh the Prefix listbox
        private void RemovePrefix(object sender, EventArgs e)
        {
            if (lstPrefixesHeadings.SelectedValue != null)
            {
                questionFilters.Prefixes.Remove(lstPrefixesHeadings.SelectedValue.ToString());
                lstPrefixesHeadings.DataSource = null;
                lstPrefixesHeadings.DataSource = questionFilters.Prefixes;
                LoadVarNames(CurrentSurvey.SurveyCode); 
            }
        }

        private void AddVarName_Click(object sender, EventArgs e)
        {
            if (cboVarNames.SelectedValue != null && !lstSelectedVarNames.Items.Contains(cboVarNames.SelectedValue))
            {
                questionFilters.Varnames.Add(cboVarNames.SelectedValue.ToString());
                lstSelectedVarNames.DataSource = null;
                lstSelectedVarNames.DataSource = questionFilters.Varnames;
            }
        }

        private void RemoveVarName_Click(object sender, EventArgs e)
        {
            if (lstSelectedVarNames.SelectedValue != null)
            {
                questionFilters.Varnames.Remove(lstSelectedVarNames.SelectedValue.ToString());
                lstSelectedVarNames.DataSource = null;
                lstSelectedVarNames.DataSource = questionFilters.Varnames;
            }
        }

        private void AddHeading(object sender, EventArgs e)
        {
           
            Heading h = (Heading)cboPrefixesHeadings.SelectedItem;
            // add it to the survey's headings collection
            questionFilters.Headings.Add(h);
            // refresh the selected headings list box, using the PreP as the display
            lstPrefixesHeadings.DataSource = null;
            lstPrefixesHeadings.DisplayMember = "PreP";
            lstPrefixesHeadings.ValueMember = "Qnum";
            lstPrefixesHeadings.DataSource = questionFilters.Headings;
          
        }

        private void RemoveHeading(object sender, EventArgs e)
        {
            if (lstPrefixesHeadings.SelectedItem != null) {
                questionFilters.Headings.Remove((Heading)lstPrefixesHeadings.SelectedItem);
                lstPrefixesHeadings.DataSource = null;
                lstPrefixesHeadings.DataSource = questionFilters.Headings;
            }
        }

        private void QuestionFilter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            filterBy = Convert.ToInt32(r.Tag);

            if (!r.Checked) return;

            txtQrangeHigh.Enabled = filterBy == 1;
            txtQrangeLow.Enabled = filterBy == 1;

            cboPrefixesHeadings.Enabled = filterBy == 2 || filterBy == 3;
            lstPrefixesHeadings.Enabled = filterBy == 2 || filterBy == 3;
            cmdAddPrefixHeading.Enabled = filterBy == 2 || filterBy == 3;
            cmdRemovePrefixHeading.Enabled = filterBy == 2 || filterBy == 3;

            switch (filterBy)
            {
                case 1:
                    lblPrefixOrHeading.Text = "Prefixes/Headings";

                    break;
                case 2:
                    lblPrefixOrHeading.Text = "Prefixes";

                    cboPrefixesHeadings.Width = 65;
                    cboPrefixesHeadings.DropDownWidth = 65;
                    LoadPrefixes(CurrentSurvey.SurveyCode);

                    cmdAddPrefixHeading.Left = 110;
                    cmdAddPrefixHeading.Click -= AddHeading;
                    cmdAddPrefixHeading.Click += AddPrefix;

                    cmdRemovePrefixHeading.Left = 110;
                    cmdRemovePrefixHeading.Click -= RemoveHeading;
                    cmdRemovePrefixHeading.Click += RemovePrefix;

                    lstPrefixesHeadings.Width = 65;
                    lstPrefixesHeadings.Left = 145;

                    lstPrefixesHeadings.DataSource = null;
                    lstPrefixesHeadings.Items.Clear();
                    lstPrefixesHeadings.DisplayMember = "Prefix";
                    lstPrefixesHeadings.ValueMember = "Prefix";
                    lstPrefixesHeadings.DataSource = questionFilters.Prefixes;

                    break;
                case 3:
                    lblPrefixOrHeading.Text = "Headings";

                    cboPrefixesHeadings.Width = 200;
                    cboPrefixesHeadings.DropDownWidth = 300;
                    LoadHeadings(CurrentSurvey.SurveyCode);

                    cmdAddPrefixHeading.Left = 245;
                    cmdAddPrefixHeading.Click -= AddPrefix;
                    cmdAddPrefixHeading.Click += AddHeading;

                    cmdRemovePrefixHeading.Left = 245;
                    cmdRemovePrefixHeading.Click -= RemovePrefix;
                    cmdRemovePrefixHeading.Click += RemoveHeading;

                    lstPrefixesHeadings.Width = 180;
                    lstPrefixesHeadings.Left = 280;

                    lstPrefixesHeadings.DataSource = null;
                    lstPrefixesHeadings.Items.Clear();
                    lstPrefixesHeadings.DisplayMember = "PreP";
                    lstPrefixesHeadings.ValueMember = "Qnum";
                    lstPrefixesHeadings.DataSource = questionFilters.Headings;
                    break;

            }
        }

        #endregion

        #region Fields Tab

        /// <summary>
        /// Adds the selected items in the list to the current survey's standard field list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StdFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.StdFieldsChosen.Clear();
            for (int i = 0; i < lstStdFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.StdFieldsChosen.Add(lstStdFields.SelectedItems[i].ToString());
            }
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's translation list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.TransFields.Clear();
            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
               
            }
            ShowTranslationSubsetTableOption();
            UpdateReportColumns(sender, e);
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's comment field list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentFields.Clear();
            for (int i = 0; i < lstCommentFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentFields.Add(lstCommentFields.SelectedItems[i].ToString());
            }

            UpdateReportColumns(sender, e);
        }

        /// <summary>
        /// Bind the date time picker's value to the current survey's CommentDate property, but only if the control is checked. If not, the CommentDate should be null.
        /// In this case, the binding needs to be removed first, because the control will not accept a null value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentsSince_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker d = sender as DateTimePicker;

            dateTimeCommentsSince.DataBindings.Clear();

            if (!d.Checked)
            {
                CurrentSurvey.CommentDate = null;
            }
            else
            {
                CurrentSurvey.CommentDate = dateTimeCommentsSince.Value;
                dateTimeCommentsSince.DataBindings.Add("Value", CurrentSurvey, "CommentDate");
            }
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's comment authors list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentAuthors_Click(object sender, EventArgs e)
        {            
            CurrentSurvey.CommentAuthors.Clear();
            for (int i = 0; i < lstCommentAuthors.SelectedItems.Count; i++)
            {
                Person r = (Person) lstCommentAuthors.SelectedItems[i];
                CurrentSurvey.CommentAuthors.Add(r.ID);
            }
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's comment source list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentSources_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentSources.Clear();
            for (int i = 0; i < lstCommentSources.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentSources.Add(lstCommentSources.SelectedItems[i].ToString());
            }
        }

        private void RoutingStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            CurrentSurvey.RoutingFormat = (RoutingStyle)sel;
        }

        #endregion

        #region Comparison Tab

        private void Compare_CheckedChanged(object sender, EventArgs e)
        {
            lblPrimarySurvey.Visible = chkCompare.Checked;
            chkMatchOnRename.Visible = chkCompare.Checked;
            groupHighlightOptions.Visible = chkCompare.Checked;
            groupLayoutOptions.Visible = chkCompare.Checked;
        }

        private void chklstPrimarySurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedItems = chklstPrimarySurvey.CheckedItems;

            ReportSurvey r = (ReportSurvey)checkedItems[0];
            SR.SetPrimary(r.ID);
        }

        private void chklstPrimarySurvey_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chklstPrimarySurvey.CheckedItems.Count == 1)
            {
                bool isCheckedItemBeingUnchecked = (e.CurrentValue == CheckState.Checked);
                if (isCheckedItemBeingUnchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
                else
                {
                    Int32 checkedItemIndex = chklstPrimarySurvey.CheckedIndices[0];
                    chklstPrimarySurvey.ItemCheck -= chklstPrimarySurvey_ItemCheck;
                    chklstPrimarySurvey.SetItemChecked(checkedItemIndex, false);
                    chklstPrimarySurvey.ItemCheck += chklstPrimarySurvey_ItemCheck;
                }

                return;
            }
        }

        private void HighlightStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            compare.HighlightStyle = (HStyle)sel;
        }

        private void ShowDeletedQuestionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chkReInsertDeletions.Visible = chkShowDeletedQuestions.Checked;
        }

        #endregion

        #region Order and Numbering tab

        private void gridColumnOrder_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            List<ReportColumn> columns = new List<ReportColumn>();
            DataGridView dgv = (DataGridView)sender;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                columns.Add(new ReportColumn(dgv.Columns[i].HeaderText, e.Column.Index + 1));
            }
            SR.ColumnOrder = columns;
        }

        private void chklstQnumSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedItems = chklstQnumSurvey.CheckedItems;

            ReportSurvey r = (ReportSurvey)checkedItems[0];
            SR.SetQnumSurvey(r.ID);
        }

        private void chklstQnumSurvey_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chklstQnumSurvey.CheckedItems.Count == 1)
            {
                bool isCheckedItemBeingUnchecked = (e.CurrentValue == CheckState.Checked);
                if (isCheckedItemBeingUnchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
                else
                {
                    Int32 checkedItemIndex = chklstQnumSurvey.CheckedIndices[0];
                    chklstQnumSurvey.ItemCheck -= chklstPrimarySurvey_ItemCheck;
                    chklstQnumSurvey.SetItemChecked(checkedItemIndex, false);
                    chklstQnumSurvey.ItemCheck += chklstPrimarySurvey_ItemCheck;
                }

                return;
            }
        }

        
        private void EnumerationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32 (r.Tag);

            SR.Numbering = (Enumeration) sel;

            UpdateReportColumns(null, null);
        }

        

        #endregion

        #region Formatting Tab

        private void qNInsertionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            aQNInsertionCheckBox.Visible = qNInsertionCheckBox.Checked;
        }

        private void TableFormat_CheckedChanged(object sender, EventArgs e)
        {
            ShowTranslationSubsetTableOption();
        }

        private void ShowRepeatedFields_CheckedChanged(object sender, EventArgs e)
        {
            lstRepeatedFields.Visible = chkShowRepeatedFields.Checked;
        }

        private void RepeatedFields_Click(object sender, EventArgs e)
        {
            
            foreach (ReportSurvey s in SR.Surveys)
                s.RepeatedFields.Clear();
            
            for (int i = 0; i < lstRepeatedFields.SelectedItems.Count; i++)
            {
                foreach (ReportSurvey s in SR.Surveys)
                {
                    s.RepeatedFields.Add(lstRepeatedFields.SelectedItems[i].ToString());
                }
            }
        }
        #endregion  

        #region Output Tab
        private void FileFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.FileFormat = (FileFormats)sel;
        }

        private void ToC_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.ToC = (TableOfContents)sel;
        }

        private void PaperSize_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.PaperSize = (PaperSizes)sel;
        }

        private void NRFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.NrFormat = (ReadOutOptions)sel;
        }

        private void WebCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (webCheckBox.Checked)
            {
                optFileFormatPDF.Checked = true;
                chkCoverPage.Checked = true;
            }
            else
            {
                chkCoverPage.Checked = false;
                optFileFormatWord.Checked = true;
            }

        }
















        #endregion

        

        private void tabControlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SR.UpdateColumnOrder();
            //UpdateGrids();
        }

        

        

        

    }
}
