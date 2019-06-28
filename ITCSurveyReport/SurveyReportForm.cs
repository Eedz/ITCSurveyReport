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
        
        SurveyBasedReport SR;
        Comparison compare;
        ReportTypes reportType;
        UserPrefs UP;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;

        // background color RGB values
        int backColorR = 55;
        int backColorG = 170;
        int backColorB = 136;

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
            
            // start with blank constructor, default settings
            reportType = ReportTypes.Standard;
            SR = new SurveyBasedReport();
            UP = new UserPrefs();
            
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

            compare = new Comparison();
            compare.SimilarWords = DBAction.GetSimilarWords(); // TODO this could be handled much better

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

            lblStatus.Visible = false;
            lblStatus.Text = "Ready.";
            cmdCheckOptions.Visible = false;
            


        }

        #region Menu Strip
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

            int result;

            // set file name to the user's report path
            SR.FileName = UP.ReportPath;

            PopulateSurveys();

            // if standard is not chosen, create a new SR with the chosen template
            switch (reportType)
            {
                case ReportTypes.Standard:
                    
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
                    
                    break;
                case ReportTypes.Label:

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
                    
                    break;
            }

        }

        /// <summary>
        /// For each survey in the report, fill the question list, comments and translations as needed.
        /// </summary>
        private void PopulateSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
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
                    DBAction.FillCommentsBySurvey(rs, rs.CommentFields, rs.CommentDate, rs.CommentAuthors, rs.CommentSources);
                }

                // translations
                foreach (string language in rs.TransFields)
                    DBAction.FillTranslationsBySurvey(rs, language);

                // varchanges (for appendix)
                if (SR.VarChangesApp)
                    rs.VarChanges = DBAction.GetVarNameChangeBySurvey(rs.SurveyCode);
            }
        }

        #region Current Survey "Load" Methods

        // bind each control to the selected survey's corresponding fields
        private void LoadSurveyOptions()
        {
            if (CurrentSurvey == null)
                return;

            // backend date
            dateBackend.DataBindings.Clear();
            dateBackend.DataBindings.Add ("Value", CurrentSurvey, "Backend");

            // filters
            // Qnum range
            txtQrangeLow.DataBindings.Clear();
            txtQrangeLow.DataBindings.Add("Text", CurrentSurvey, "QRangeLow");
            txtQrangeHigh.DataBindings.Clear();
            txtQrangeHigh.DataBindings.Add("Text", CurrentSurvey, "QRangeHigh");

            // prefixes
            LoadPrefixes(CurrentSurvey.SurveyCode);
            lstPrefixes.DataBindings.Clear();
            lstPrefixes.DataSource = CurrentSurvey.Prefixes;

            // headings
            LoadHeadings(CurrentSurvey.SurveyCode);
            lstHeadings.DataBindings.Clear();
            lstHeadings.DataSource = CurrentSurvey.Headings;

            // varnames
            LoadVarNames(CurrentSurvey.SurveyCode);
            lstSelectedVarNames.DataBindings.Clear();
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;

            // standard fields
            lstStdFields.SelectedItems.Clear();
            foreach (object item in CurrentSurvey.StdFieldsChosen)
            {
                for (int i = 0; i < lstStdFields.Items.Count; i++)
                    if (item.ToString().Equals(lstStdFields.Items[i].ToString()))
                        lstStdFields.SetSelected(i, true);
                    
            }

            // extrafields
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

            dateTimeCommentsSince.DataBindings.Clear();
            dateTimeCommentsSince.DataBindings.Add("Value", CurrentSurvey, "CommentDate");
            if (CurrentSurvey.CommentDate == null)
            {
                dateTimeCommentsSince.Checked = false;
            }

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
            cboPrefixes.ValueMember = "Prefix";
            cboPrefixes.DisplayMember = "Prefix";
            cboPrefixes.DataSource = DBAction.GetVariablePrefixes(survey);
            cboPrefixes.SelectedItem = null;
        }

        // TODO filter on selected prefixes?
        private void LoadVarNames(string survey)
        {
            cboVarNames.ValueMember = "VarName";
            cboVarNames.DisplayMember = "VarName";

            if (lstPrefixes.Items.Count > 0)
            {
                cboVarNames.DataSource = DBAction.GetVariableList(survey);
            }
            else
            {
                cboVarNames.DataSource = DBAction.GetVariableList(survey);
            }
            
            cboVarNames.SelectedItem = null;
        }

        private void LoadHeadings(string survey)
        {            
            cboHeadings.ValueMember = "Qnum";
            cboHeadings.DisplayMember = "PreP";
            cboHeadings.DataSource = DBAction.GetHeadings(survey);
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


        #region Top of Form

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
            
            UpdateGrids();

            // show the options tabs if at least one survey is chosen
            if (lstSelectedSurveys.Items.Count > 0)
            {
                lblStatus.Visible = true;
                cmdCheckOptions.Visible = true;
                tabControlOptions.Visible = true;
            }

            // update report defaults
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

            UpdateGrids();

            // hide the options tabs no surveys are chosen
            if (lstSelectedSurveys.Items.Count < 1)
            {
                lblStatus.Visible = false;
                cmdCheckOptions.Visible = false;
                tabControlOptions.Visible = false;
            }

            // update report defaults
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        private void UpdateCurrentSurvey()
        {
            CurrentSurvey = (ReportSurvey)lstSelectedSurveys.SelectedItem;
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

            if (!CheckForDiffCountry())
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
                else if (CheckForDiffCountry())
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


            if (SR.ReportType == ReportTypes.Label || !HasF2F())
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

        private void UpdateGrids()
        {
            // populate the primary survey grid
            gridPrimarySurvey.DataSource = SR.Surveys;
            gridPrimarySurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridPrimarySurvey.Refresh();

            // popluate the column order grid
            //gridColumnOrder.DataSource = SR.ColumnOrder;
            //gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           // gridColumnOrder.Refresh();

            // populate the qnum survey grid
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();
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

        /// <summary>
        /// Checks if there are at least 2 different countries in the report.
        /// </summary>
        /// <returns>True if there are surveys from at least 2 different countries in the report, false otherwise.</returns>
        private bool CheckForDiffCountry()
        {
            if (SR.Surveys.Count <= 1)
                return false;

            string prefix;
            prefix = SR.Surveys[0].SurveyCodePrefix;
            foreach (Survey s in SR.Surveys)
                if (s.SurveyCodePrefix != prefix)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks to see if there are any F2F surveys in the report.
        /// </summary>
        /// <returns>Returns true if any of the selected surveys are F2F surveys.</returns>
        private bool HasF2F()
        {
            foreach (Survey s in SR.Surveys)
                if (s.Mode.ModeAbbrev == "F2F")
                    return true;

            return false;
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
            UpdateDefaultOptions();
            UpdateFileNameTab();
        }

        // TODO check if backup exists for this date
        private void dateBackend_ValueChanged(object sender, EventArgs e)
        {
            
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



        #region Filters Tab
        // TODO do not add duplicates
        // Add the selected prefix to the Current Survey's prefix list and refresh the Prefix listbox
        private void AddPrefix_Click(object sender, EventArgs e)
        {
            if (cboPrefixes.SelectedValue != null)
            {
                CurrentSurvey.Prefixes.Add(cboPrefixes.SelectedValue.ToString());
                lstPrefixes.DataSource = null;
                lstPrefixes.DataSource = CurrentSurvey.Prefixes;
            }
        }

        // Remove the selected prefix from the Current Survey's prefix list and refresh the Prefix listbox
        private void RemovePrefix_Click(object sender, EventArgs e)
        {
            if (lstPrefixes.SelectedValue != null)
            {
                CurrentSurvey.Prefixes.Remove(lstPrefixes.SelectedValue.ToString());
                lstPrefixes.DataSource = null;
                lstPrefixes.DataSource = CurrentSurvey.Prefixes;
            }
        }

        private void AddVarName_Click(object sender, EventArgs e)
        {
            if (cboVarNames.SelectedValue != null)
            {
                CurrentSurvey.Varnames.Add(cboVarNames.SelectedValue.ToString());
                lstSelectedVarNames.DataSource = null;
                lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
            }
        }

        private void RemoveVarName_Click(object sender, EventArgs e)
        {
            if (lstSelectedVarNames.SelectedValue != null)
            {
                CurrentSurvey.Varnames.Remove(lstSelectedVarNames.SelectedValue.ToString());
                lstSelectedVarNames.DataSource = null;
                lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
            }
        }

        private void cmdAddHeading_Click(object sender, EventArgs e)
        {
           
            Heading h = (Heading)cboHeadings.SelectedItem;
            // add it to the survey's headings collection
            CurrentSurvey.Headings.Add(h);
            // refresh the selected headings list box, using the PreP as the display
            lstHeadings.DataSource = null;
            lstHeadings.DisplayMember = "PreP";
            lstHeadings.ValueMember = "Qnum";
            lstHeadings.DataSource = CurrentSurvey.Headings;
          
        }

        private void cmdRemoveHeading_Click(object sender, EventArgs e)
        {
            if (lstHeadings.SelectedItem != null) {
                CurrentSurvey.Headings.Remove((Heading)lstHeadings.SelectedItem);
                lstHeadings.DataSource = null;
                lstHeadings.DataSource = CurrentSurvey.Headings;
            }
        }
        #endregion

        #region Fields Tab
        //

        private void StdFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.StdFieldsChosen.Clear();
            for (int i = 0; i < lstStdFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.StdFieldsChosen.Add(lstStdFields.SelectedItems[i].ToString());
            }
        }

       
        private void ToggleExtraFields_Click(object sender, EventArgs e)
        {
            lblCommentFields.Visible = true;
            lstCommentFields.Visible = true;
            
            lblTransFields.Visible = true;
            lstTransFields.Visible = true;

            panelCommentFilters.Visible = true;
            panelOtherFields.Visible = true;

        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's translation list. The list is cleared first, then the selected items are added back.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransFields_Click(object sender, EventArgs e)
        {
            // remove report columns for any languages current in the list
            for (int i= 0; i < SR.ColumnOrder.Count; i ++)
            {
                foreach (string language in CurrentSurvey.TransFields)
                {
                    if (SR.ColumnOrder[i].ColumnName == CurrentSurvey.SurveyCode + " " + CurrentSurvey.Backend.ToString("d") + " " + language)
                        SR.ColumnOrder.RemoveAt(i);
                }
            }
            // clear the list and add back the selected items
            CurrentSurvey.TransFields.Clear();

            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
                SR.AddColumn(CurrentSurvey.SurveyCode + " " + CurrentSurvey.Backend.ToString("d") + " " + lstTransFields.SelectedItems[i].ToString());
            }
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's comment field list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentFields_Click(object sender, EventArgs e)
        {
            // remove report column that may already be there
            for (int i = 0; i < SR.ColumnOrder.Count; i++)
            {
                
                if (SR.ColumnOrder[i].ColumnName == CurrentSurvey.SurveyCode + " " + CurrentSurvey.Backend.ToString("d") + " Comments")
                    SR.ColumnOrder.RemoveAt(i);
                
            }

            CurrentSurvey.CommentFields.Clear();

            for (int i = 0; i < lstCommentFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentFields.Add(lstCommentFields.SelectedItems[i].ToString());
            }

            if (CurrentSurvey.CommentFields.Count > 1)
                SR.AddColumn(CurrentSurvey.SurveyCode + " " + CurrentSurvey.Backend.ToString("d") + " Comments");
        }

        private void CommentsSince_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker d = sender as DateTimePicker;
            if (d.Checked)
                CurrentSurvey.CommentDate = d.Value;
        }

        private void CommentAuthors_Click(object sender, EventArgs e)
        {
            
            CurrentSurvey.CommentAuthors.Clear();

            for (int i = 0; i < lstCommentAuthors.SelectedItems.Count; i++)
            {
                DataRowView r = (DataRowView) lstCommentAuthors.SelectedItems[i];
                CurrentSurvey.CommentAuthors.Add((int)r[0]);
            }
        }

        private void CommentSources_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentSources.Clear();

            for (int i = 0; i < lstCommentSources.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentSources.Add(lstCommentSources.SelectedItems[i].ToString());
            }
        }

        

        

        #endregion

        #region Comparison Tab

        private void Compare_CheckedChanged(object sender, EventArgs e)
        {
            gridPrimarySurvey.Visible = chkCompare.Checked;
            lblPrimarySurvey.Visible = chkCompare.Checked;
            chkMatchOnRename.Visible = chkCompare.Checked;
            groupHighlightOptions.Visible = chkCompare.Checked;
            groupLayoutOptions.Visible = chkCompare.Checked;
        }

        // Once the gridview is bound, hide unecessary columns and rename SurveyCode to Survey
        private void PrimarySurvey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridPrimarySurvey.ColumnCount; i++)
            {
                switch (gridPrimarySurvey.Columns[i].Name)
                {
                    case "SurveyCode":
                        gridPrimarySurvey.Columns[i].HeaderText = "Survey";                   
                        break;
                    case "Backend":
                    case "Corrected":
                    case "Primary":
                        break;
                    default:
                        gridPrimarySurvey.Columns[i].Visible = false;
                        break;
                }
            }
        }

        // If a cell is modified, commit the change to fire the CellValueChanged event
        private void PrimarySurvey_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridPrimarySurvey.IsCurrentCellDirty)
                gridPrimarySurvey.CommitEdit(DataGridViewDataErrorContexts.Commit);            
        }

        // If the cell that was modified is in the Primary column, uncheck the other rows so that there is always 
        // a single Primary row
        private void PrimarySurvey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (gridPrimarySurvey.Columns[e.ColumnIndex].Name == "Primary")
            {
                var isChecked = (bool)gridPrimarySurvey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    for (int i = 0; i < gridPrimarySurvey.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            gridPrimarySurvey.Rows[i].Cells[e.ColumnIndex].Value = !isChecked;
                        }
                    }
                }
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



        private void BlankCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            SR.LayoutOptions.BlankColumn = c.Checked;
            SR.AddColumn("Comments");
        }

        // Once the gridview is bound, hide unecessary columns and rename SurveyCode to Survey
        private void QnumSurvey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridQnumSurvey.ColumnCount; i++)
            {
                switch (gridQnumSurvey.Columns[i].Name)
                {
                    case "SurveyCode":
                        gridQnumSurvey.Columns[i].HeaderText = "Survey";
                        break;
                    case "Backend":
                    case "Corrected":
                    case "Qnum":
                        break;
                    default:
                        gridQnumSurvey.Columns[i].Visible = false;
                        break;
                }
            }
        }

        // If a cell is modified, commit the change to fire the CellValueChanged event
        private void QnumSurvey_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridQnumSurvey.IsCurrentCellDirty)
                gridQnumSurvey.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // If the cell that was modified is in the Qnum column, uncheck the other rows so that there is always 
        // a single Primary row
        private void QnumSurvey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridQnumSurvey.Columns[e.ColumnIndex].Name == "Qnum")
            {
                var isChecked = (bool)gridQnumSurvey.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    for (int i = 0; i < gridQnumSurvey.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            gridQnumSurvey.Rows[i].Cells[e.ColumnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }
        

      
        private void ColumnOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
    
        }

        
        private void EnumerationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32 (r.Tag);

            SR.Numbering = (Enumeration) sel;
            
            UpdateColumnList();
        }

        private void UpdateColumnList()
        {
            gridColumnOrder.DataSource = SR.ColumnOrder;
            gridColumnOrder.Refresh();
        }

        #endregion

        #region Formatting Tab
        private void TableFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (SR.Surveys.Count == 1 && SR.Surveys[0].TransFields.Count == 1)
                chkTranslationTableFormat.Visible = chkTableFormat.Checked;
            else
                chkTranslationTableFormat.Visible = false;
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
                optFileFormatPDF.Checked = true;
            else
                optFileFormatWord.Checked = true;

        }

        #endregion

        
    }
}
