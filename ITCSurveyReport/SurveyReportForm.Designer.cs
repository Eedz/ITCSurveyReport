namespace ITCSurveyReport
{
    /// <summary>
    /// 
    /// </summary>
    partial class SurveyReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label detailsLabel;
            System.Windows.Forms.Label fileNameLabel;
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.cmdAddSurvey = new System.Windows.Forms.Button();
            this.cmdRemoveSurvey = new System.Windows.Forms.Button();
            this.lstSelectedSurveys = new System.Windows.Forms.ListBox();
            this.cmdCheckOptions = new System.Windows.Forms.Button();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.pgFilters = new System.Windows.Forms.TabPage();
            this.lstHeadings = new System.Windows.Forms.ListBox();
            this.cmdRemoveHeading = new System.Windows.Forms.Button();
            this.cmdAddHeading = new System.Windows.Forms.Button();
            this.cboHeadings = new System.Windows.Forms.ComboBox();
            this.lstSelectedVarNames = new System.Windows.Forms.ListBox();
            this.cmdRemoveVarName = new System.Windows.Forms.Button();
            this.cmdAddVarName = new System.Windows.Forms.Button();
            this.lblVarNames = new System.Windows.Forms.Label();
            this.cboVarNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQrangeHigh = new System.Windows.Forms.TextBox();
            this.txtQrangeLow = new System.Windows.Forms.TextBox();
            this.lblQuestionRange = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRemovePrefix = new System.Windows.Forms.Button();
            this.cmdAddPrefix = new System.Windows.Forms.Button();
            this.cboPrefixes = new System.Windows.Forms.ComboBox();
            this.lstPrefixes = new System.Windows.Forms.ListBox();
            this.pgFields = new System.Windows.Forms.TabPage();
            this.panelOtherFields = new System.Windows.Forms.Panel();
            this.chkAltQNum3Col = new System.Windows.Forms.CheckBox();
            this.chkAltQNum2Col = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkProductCol = new System.Windows.Forms.CheckBox();
            this.chkDomainCol = new System.Windows.Forms.CheckBox();
            this.chkContentCol = new System.Windows.Forms.CheckBox();
            this.chkTopicCol = new System.Windows.Forms.CheckBox();
            this.chkVarLabelCol = new System.Windows.Forms.CheckBox();
            this.chkFilterCol = new System.Windows.Forms.CheckBox();
            this.panelCommentFilters = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeCommentsSince = new System.Windows.Forms.DateTimePicker();
            this.lstCommentSources = new System.Windows.Forms.ListBox();
            this.lstCommentAuthors = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstStdFields = new System.Windows.Forms.ListBox();
            this.chkCorrected = new System.Windows.Forms.CheckBox();
            this.lblTransFields = new System.Windows.Forms.Label();
            this.lstTransFields = new System.Windows.Forms.ListBox();
            this.lblCommentFields = new System.Windows.Forms.Label();
            this.lstCommentFields = new System.Windows.Forms.ListBox();
            this.cmdToggleExtraFields = new System.Windows.Forms.Button();
            this.pgCompare = new System.Windows.Forms.TabPage();
            this.lblPrimarySurvey = new System.Windows.Forms.Label();
            this.groupLayoutOptions = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.hidePrimaryCheckBox = new System.Windows.Forms.CheckBox();
            this.compareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkHideIdenticalQs = new System.Windows.Forms.CheckBox();
            this.hideIdenticalWordingsCheckBox = new System.Windows.Forms.CheckBox();
            this.beforeAfterReportCheckBox = new System.Windows.Forms.CheckBox();
            this.groupHighlightOptions = new System.Windows.Forms.GroupBox();
            this.flowHighlightOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.highlightNRCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreSimilarWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.hybridHighlightCheckBox = new System.Windows.Forms.CheckBox();
            this.showDeletedFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.chkShowDeletedQuestions = new System.Windows.Forms.CheckBox();
            this.chkReInsertDeletions = new System.Windows.Forms.CheckBox();
            this.showOrderChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupHighlightStyle = new System.Windows.Forms.GroupBox();
            this.cboHighlightScheme = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.convertTrackedChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.highlightCheckBox = new System.Windows.Forms.CheckBox();
            this.gridPrimarySurvey = new System.Windows.Forms.DataGridView();
            this.chkCompare = new System.Windows.Forms.CheckBox();
            this.surveyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkMatchOnRename = new System.Windows.Forms.CheckBox();
            this.pgOrder = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBlankCol = new System.Windows.Forms.CheckBox();
            this.reportLayoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridQnumSurvey = new System.Windows.Forms.DataGridView();
            this.gridColumnOrder = new System.Windows.Forms.DataGridView();
            this.groupEnumeration = new System.Windows.Forms.GroupBox();
            this.optQnumAltQnum = new System.Windows.Forms.RadioButton();
            this.optAltQnumOnly = new System.Windows.Forms.RadioButton();
            this.optQnumOnly = new System.Windows.Forms.RadioButton();
            this.chkShowAllQnums = new System.Windows.Forms.CheckBox();
            this.pgFormatting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstRepeatedFields = new System.Windows.Forms.ListBox();
            this.chkShowRepeatedFields = new System.Windows.Forms.CheckBox();
            this.repeatedHeadingsCheckBox = new System.Windows.Forms.CheckBox();
            this.qNInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.bySectionCheckBox = new System.Windows.Forms.CheckBox();
            this.includeWordingsCheckBox = new System.Windows.Forms.CheckBox();
            this.colorSubsCheckBox = new System.Windows.Forms.CheckBox();
            this.aQNInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.showLongListsCheckBox = new System.Windows.Forms.CheckBox();
            this.cCInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.chkTableFormat = new System.Windows.Forms.CheckBox();
            this.inlineRoutingCheckBox = new System.Windows.Forms.CheckBox();
            this.semiTelCheckBox = new System.Windows.Forms.CheckBox();
            this.lblOrderOptions = new System.Windows.Forms.Label();
            this.chkTranslationTableFormat = new System.Windows.Forms.CheckBox();
            this.pgOutput = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.webCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkCoverPage = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.survNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesColCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesAppCheckBox = new System.Windows.Forms.CheckBox();
            this.excludeTempChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupNRFormat = new System.Windows.Forms.GroupBox();
            this.optNRFormatDontReadOut = new System.Windows.Forms.RadioButton();
            this.optNRFormatDontRead = new System.Windows.Forms.RadioButton();
            this.optNRFormatNeither = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.groupToC = new System.Windows.Forms.GroupBox();
            this.optToCPgNum = new System.Windows.Forms.RadioButton();
            this.optToCQnum = new System.Windows.Forms.RadioButton();
            this.optToCNone = new System.Windows.Forms.RadioButton();
            this.groupFileFormat = new System.Windows.Forms.GroupBox();
            this.optFileFormatPDF = new System.Windows.Forms.RadioButton();
            this.optFileFormatWord = new System.Windows.Forms.RadioButton();
            this.pgFileName = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSecondSources = new System.Windows.Forms.TextBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.txtMainSource = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateBackend = new System.Windows.Forms.DateTimePicker();
            this.lblBackend = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optOrderCompare = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.optLabelCompare = new System.Windows.Forms.RadioButton();
            this.optVarNameCompare = new System.Windows.Forms.RadioButton();
            this.cmdSelfCompare = new System.Windows.Forms.Button();
            this.toolTipStandard = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipStandardT = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipWeb = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipWebT = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardWTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteWTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentSurveyFields = new System.Windows.Forms.Label();
            detailsLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.pgFilters.SuspendLayout();
            this.pgFields.SuspendLayout();
            this.panelOtherFields.SuspendLayout();
            this.panelCommentFilters.SuspendLayout();
            this.pgCompare.SuspendLayout();
            this.groupLayoutOptions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).BeginInit();
            this.groupHighlightOptions.SuspendLayout();
            this.flowHighlightOptions.SuspendLayout();
            this.groupHighlightStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).BeginInit();
            this.pgOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQnumSurvey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumnOrder)).BeginInit();
            this.groupEnumeration.SuspendLayout();
            this.pgFormatting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pgOutput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupNRFormat.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupToC.SuspendLayout();
            this.groupFileFormat.SuspendLayout();
            this.pgFileName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            detailsLabel.Location = new System.Drawing.Point(84, 220);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new System.Drawing.Size(92, 13);
            detailsLabel.TabIndex = 27;
            detailsLabel.Text = "Report Details:";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(6, 421);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(82, 13);
            fileNameLabel.TabIndex = 33;
            fileNameLabel.Text = "Final File Name:";
            // 
            // cboSurveys
            // 
            this.cboSurveys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurveys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveys.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboSurveys.DisplayMember = "Survey";
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboSurveys.Location = new System.Drawing.Point(12, 82);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(108, 21);
            this.cboSurveys.TabIndex = 0;
            this.cboSurveys.ValueMember = "Survey";
            this.cboSurveys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Surveys_KeyDown);
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(126, 81);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(39, 20);
            this.cmdAddSurvey.TabIndex = 1;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.AddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(126, 107);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(38, 25);
            this.cmdRemoveSurvey.TabIndex = 2;
            this.cmdRemoveSurvey.Text = "<-";
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.RemoveSurvey_Click);
            // 
            // lstSelectedSurveys
            // 
            this.lstSelectedSurveys.DisplayMember = "SurveyCode";
            this.lstSelectedSurveys.FormattingEnabled = true;
            this.lstSelectedSurveys.Location = new System.Drawing.Point(171, 79);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(114, 121);
            this.lstSelectedSurveys.TabIndex = 3;
            this.lstSelectedSurveys.ValueMember = "ID";
            this.lstSelectedSurveys.SelectedIndexChanged += new System.EventHandler(this.SelectedSurveys_SelectedIndexChanged);
            // 
            // cmdCheckOptions
            // 
            this.cmdCheckOptions.Location = new System.Drawing.Point(393, 737);
            this.cmdCheckOptions.Name = "cmdCheckOptions";
            this.cmdCheckOptions.Size = new System.Drawing.Size(88, 33);
            this.cmdCheckOptions.TabIndex = 4;
            this.cmdCheckOptions.Text = "Generate";
            this.cmdCheckOptions.UseVisualStyleBackColor = true;
            this.cmdCheckOptions.Click += new System.EventHandler(this.CheckOptions_Click);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.pgFilters);
            this.tabControlOptions.Controls.Add(this.pgFields);
            this.tabControlOptions.Controls.Add(this.pgCompare);
            this.tabControlOptions.Controls.Add(this.pgOrder);
            this.tabControlOptions.Controls.Add(this.pgFormatting);
            this.tabControlOptions.Controls.Add(this.pgOutput);
            this.tabControlOptions.Controls.Add(this.pgFileName);
            this.tabControlOptions.Location = new System.Drawing.Point(12, 206);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(473, 529);
            this.tabControlOptions.TabIndex = 5;
            this.tabControlOptions.Visible = false;
            // 
            // pgFilters
            // 
            this.pgFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFilters.Controls.Add(this.lstHeadings);
            this.pgFilters.Controls.Add(this.cmdRemoveHeading);
            this.pgFilters.Controls.Add(this.cmdAddHeading);
            this.pgFilters.Controls.Add(this.cboHeadings);
            this.pgFilters.Controls.Add(this.lstSelectedVarNames);
            this.pgFilters.Controls.Add(this.cmdRemoveVarName);
            this.pgFilters.Controls.Add(this.cmdAddVarName);
            this.pgFilters.Controls.Add(this.lblVarNames);
            this.pgFilters.Controls.Add(this.cboVarNames);
            this.pgFilters.Controls.Add(this.label3);
            this.pgFilters.Controls.Add(this.txtQrangeHigh);
            this.pgFilters.Controls.Add(this.txtQrangeLow);
            this.pgFilters.Controls.Add(this.lblQuestionRange);
            this.pgFilters.Controls.Add(this.label1);
            this.pgFilters.Controls.Add(this.cmdRemovePrefix);
            this.pgFilters.Controls.Add(this.cmdAddPrefix);
            this.pgFilters.Controls.Add(this.cboPrefixes);
            this.pgFilters.Controls.Add(this.lstPrefixes);
            this.pgFilters.Location = new System.Drawing.Point(4, 22);
            this.pgFilters.Name = "pgFilters";
            this.pgFilters.Padding = new System.Windows.Forms.Padding(3);
            this.pgFilters.Size = new System.Drawing.Size(465, 503);
            this.pgFilters.TabIndex = 0;
            this.pgFilters.Text = "Filters";
            // 
            // lstHeadings
            // 
            this.lstHeadings.FormattingEnabled = true;
            this.lstHeadings.Location = new System.Drawing.Point(142, 326);
            this.lstHeadings.MultiColumn = true;
            this.lstHeadings.Name = "lstHeadings";
            this.lstHeadings.Size = new System.Drawing.Size(101, 160);
            this.lstHeadings.TabIndex = 17;
            // 
            // cmdRemoveHeading
            // 
            this.cmdRemoveHeading.Location = new System.Drawing.Point(112, 354);
            this.cmdRemoveHeading.Name = "cmdRemoveHeading";
            this.cmdRemoveHeading.Size = new System.Drawing.Size(24, 25);
            this.cmdRemoveHeading.TabIndex = 16;
            this.cmdRemoveHeading.Text = "<-";
            this.cmdRemoveHeading.UseVisualStyleBackColor = true;
            this.cmdRemoveHeading.Click += new System.EventHandler(this.cmdRemoveHeading_Click);
            // 
            // cmdAddHeading
            // 
            this.cmdAddHeading.Location = new System.Drawing.Point(110, 326);
            this.cmdAddHeading.Name = "cmdAddHeading";
            this.cmdAddHeading.Size = new System.Drawing.Size(27, 20);
            this.cmdAddHeading.TabIndex = 15;
            this.cmdAddHeading.Text = "->";
            this.cmdAddHeading.UseVisualStyleBackColor = true;
            this.cmdAddHeading.Click += new System.EventHandler(this.cmdAddHeading_Click);
            // 
            // cboHeadings
            // 
            this.cboHeadings.DropDownWidth = 255;
            this.cboHeadings.FormattingEnabled = true;
            this.cboHeadings.Location = new System.Drawing.Point(17, 326);
            this.cboHeadings.Name = "cboHeadings";
            this.cboHeadings.Size = new System.Drawing.Size(87, 21);
            this.cboHeadings.TabIndex = 14;
            // 
            // lstSelectedVarNames
            // 
            this.lstSelectedVarNames.FormattingEnabled = true;
            this.lstSelectedVarNames.Location = new System.Drawing.Point(330, 91);
            this.lstSelectedVarNames.Name = "lstSelectedVarNames";
            this.lstSelectedVarNames.Size = new System.Drawing.Size(101, 173);
            this.lstSelectedVarNames.TabIndex = 13;
            // 
            // cmdRemoveVarName
            // 
            this.cmdRemoveVarName.Location = new System.Drawing.Point(297, 121);
            this.cmdRemoveVarName.Name = "cmdRemoveVarName";
            this.cmdRemoveVarName.Size = new System.Drawing.Size(30, 26);
            this.cmdRemoveVarName.TabIndex = 12;
            this.cmdRemoveVarName.Text = "<-";
            this.cmdRemoveVarName.UseVisualStyleBackColor = true;
            this.cmdRemoveVarName.Click += new System.EventHandler(this.RemoveVarName_Click);
            // 
            // cmdAddVarName
            // 
            this.cmdAddVarName.Location = new System.Drawing.Point(298, 91);
            this.cmdAddVarName.Name = "cmdAddVarName";
            this.cmdAddVarName.Size = new System.Drawing.Size(29, 21);
            this.cmdAddVarName.TabIndex = 11;
            this.cmdAddVarName.Text = "->";
            this.cmdAddVarName.UseVisualStyleBackColor = true;
            this.cmdAddVarName.Click += new System.EventHandler(this.AddVarName_Click);
            // 
            // lblVarNames
            // 
            this.lblVarNames.AutoSize = true;
            this.lblVarNames.Location = new System.Drawing.Point(229, 68);
            this.lblVarNames.Name = "lblVarNames";
            this.lblVarNames.Size = new System.Drawing.Size(56, 13);
            this.lblVarNames.TabIndex = 10;
            this.lblVarNames.Text = "VarNames";
            // 
            // cboVarNames
            // 
            this.cboVarNames.FormattingEnabled = true;
            this.cboVarNames.Location = new System.Drawing.Point(229, 89);
            this.cboVarNames.Name = "cboVarNames";
            this.cboVarNames.Size = new System.Drawing.Size(67, 21);
            this.cboVarNames.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // txtQrangeHigh
            // 
            this.txtQrangeHigh.Location = new System.Drawing.Point(73, 38);
            this.txtQrangeHigh.Name = "txtQrangeHigh";
            this.txtQrangeHigh.Size = new System.Drawing.Size(38, 20);
            this.txtQrangeHigh.TabIndex = 7;
            // 
            // txtQrangeLow
            // 
            this.txtQrangeLow.Location = new System.Drawing.Point(15, 38);
            this.txtQrangeLow.Name = "txtQrangeLow";
            this.txtQrangeLow.Size = new System.Drawing.Size(38, 20);
            this.txtQrangeLow.TabIndex = 6;
            // 
            // lblQuestionRange
            // 
            this.lblQuestionRange.AutoSize = true;
            this.lblQuestionRange.Location = new System.Drawing.Point(14, 11);
            this.lblQuestionRange.Name = "lblQuestionRange";
            this.lblQuestionRange.Size = new System.Drawing.Size(84, 13);
            this.lblQuestionRange.TabIndex = 5;
            this.lblQuestionRange.Text = "Question Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Prefixes";
            // 
            // cmdRemovePrefix
            // 
            this.cmdRemovePrefix.Location = new System.Drawing.Point(85, 120);
            this.cmdRemovePrefix.Name = "cmdRemovePrefix";
            this.cmdRemovePrefix.Size = new System.Drawing.Size(30, 26);
            this.cmdRemovePrefix.TabIndex = 3;
            this.cmdRemovePrefix.Text = "<-";
            this.cmdRemovePrefix.UseVisualStyleBackColor = true;
            this.cmdRemovePrefix.Click += new System.EventHandler(this.RemovePrefix_Click);
            // 
            // cmdAddPrefix
            // 
            this.cmdAddPrefix.Location = new System.Drawing.Point(86, 90);
            this.cmdAddPrefix.Name = "cmdAddPrefix";
            this.cmdAddPrefix.Size = new System.Drawing.Size(29, 21);
            this.cmdAddPrefix.TabIndex = 2;
            this.cmdAddPrefix.Text = "->";
            this.cmdAddPrefix.UseVisualStyleBackColor = true;
            this.cmdAddPrefix.Click += new System.EventHandler(this.AddPrefix_Click);
            // 
            // cboPrefixes
            // 
            this.cboPrefixes.DisplayMember = "ID";
            this.cboPrefixes.FormattingEnabled = true;
            this.cboPrefixes.Location = new System.Drawing.Point(15, 91);
            this.cboPrefixes.Name = "cboPrefixes";
            this.cboPrefixes.Size = new System.Drawing.Size(67, 21);
            this.cboPrefixes.TabIndex = 1;
            this.cboPrefixes.ValueMember = "ID";
            // 
            // lstPrefixes
            // 
            this.lstPrefixes.FormattingEnabled = true;
            this.lstPrefixes.Location = new System.Drawing.Point(121, 91);
            this.lstPrefixes.Name = "lstPrefixes";
            this.lstPrefixes.Size = new System.Drawing.Size(101, 173);
            this.lstPrefixes.TabIndex = 0;
            // 
            // pgFields
            // 
            this.pgFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFields.Controls.Add(this.lblCurrentSurveyFields);
            this.pgFields.Controls.Add(this.panelOtherFields);
            this.pgFields.Controls.Add(this.panelCommentFilters);
            this.pgFields.Controls.Add(this.label2);
            this.pgFields.Controls.Add(this.lstStdFields);
            this.pgFields.Controls.Add(this.chkCorrected);
            this.pgFields.Controls.Add(this.lblTransFields);
            this.pgFields.Controls.Add(this.lstTransFields);
            this.pgFields.Controls.Add(this.lblCommentFields);
            this.pgFields.Controls.Add(this.lstCommentFields);
            this.pgFields.Controls.Add(this.cmdToggleExtraFields);
            this.pgFields.Location = new System.Drawing.Point(4, 22);
            this.pgFields.Name = "pgFields";
            this.pgFields.Padding = new System.Windows.Forms.Padding(3);
            this.pgFields.Size = new System.Drawing.Size(465, 503);
            this.pgFields.TabIndex = 1;
            this.pgFields.Text = "Fields";
            // 
            // panelOtherFields
            // 
            this.panelOtherFields.Controls.Add(this.chkAltQNum3Col);
            this.panelOtherFields.Controls.Add(this.chkAltQNum2Col);
            this.panelOtherFields.Controls.Add(this.label8);
            this.panelOtherFields.Controls.Add(this.chkProductCol);
            this.panelOtherFields.Controls.Add(this.chkDomainCol);
            this.panelOtherFields.Controls.Add(this.chkContentCol);
            this.panelOtherFields.Controls.Add(this.chkTopicCol);
            this.panelOtherFields.Controls.Add(this.chkVarLabelCol);
            this.panelOtherFields.Controls.Add(this.chkFilterCol);
            this.panelOtherFields.Location = new System.Drawing.Point(174, 220);
            this.panelOtherFields.Name = "panelOtherFields";
            this.panelOtherFields.Size = new System.Drawing.Size(142, 248);
            this.panelOtherFields.TabIndex = 28;
            this.panelOtherFields.Visible = false;
            // 
            // chkAltQNum3Col
            // 
            this.chkAltQNum3Col.AutoSize = true;
            this.chkAltQNum3Col.Location = new System.Drawing.Point(1, 178);
            this.chkAltQNum3Col.Name = "chkAltQNum3Col";
            this.chkAltQNum3Col.Size = new System.Drawing.Size(77, 17);
            this.chkAltQNum3Col.TabIndex = 28;
            this.chkAltQNum3Col.Text = "AltQNum 3";
            this.chkAltQNum3Col.UseVisualStyleBackColor = true;
            // 
            // chkAltQNum2Col
            // 
            this.chkAltQNum2Col.AutoSize = true;
            this.chkAltQNum2Col.Location = new System.Drawing.Point(1, 155);
            this.chkAltQNum2Col.Name = "chkAltQNum2Col";
            this.chkAltQNum2Col.Size = new System.Drawing.Size(77, 17);
            this.chkAltQNum2Col.TabIndex = 27;
            this.chkAltQNum2Col.Text = "AltQNum 2";
            this.chkAltQNum2Col.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Other Fields";
            // 
            // chkProductCol
            // 
            this.chkProductCol.AutoSize = true;
            this.chkProductCol.Location = new System.Drawing.Point(1, 132);
            this.chkProductCol.Name = "chkProductCol";
            this.chkProductCol.Size = new System.Drawing.Size(130, 17);
            this.chkProductCol.TabIndex = 25;
            this.chkProductCol.Text = "Product Label Column";
            this.chkProductCol.UseVisualStyleBackColor = true;
            // 
            // chkDomainCol
            // 
            this.chkDomainCol.AutoSize = true;
            this.chkDomainCol.Location = new System.Drawing.Point(1, 40);
            this.chkDomainCol.Name = "chkDomainCol";
            this.chkDomainCol.Size = new System.Drawing.Size(129, 17);
            this.chkDomainCol.TabIndex = 24;
            this.chkDomainCol.Text = "Domain Label Column";
            this.chkDomainCol.UseVisualStyleBackColor = true;
            // 
            // chkContentCol
            // 
            this.chkContentCol.AutoSize = true;
            this.chkContentCol.Location = new System.Drawing.Point(1, 86);
            this.chkContentCol.Name = "chkContentCol";
            this.chkContentCol.Size = new System.Drawing.Size(130, 17);
            this.chkContentCol.TabIndex = 23;
            this.chkContentCol.Text = "Content Label Column";
            this.chkContentCol.UseVisualStyleBackColor = true;
            // 
            // chkTopicCol
            // 
            this.chkTopicCol.AutoSize = true;
            this.chkTopicCol.Location = new System.Drawing.Point(1, 63);
            this.chkTopicCol.Name = "chkTopicCol";
            this.chkTopicCol.Size = new System.Drawing.Size(120, 17);
            this.chkTopicCol.TabIndex = 22;
            this.chkTopicCol.Text = "Topic Label Column";
            this.chkTopicCol.UseVisualStyleBackColor = true;
            // 
            // chkVarLabelCol
            // 
            this.chkVarLabelCol.AutoSize = true;
            this.chkVarLabelCol.Location = new System.Drawing.Point(1, 109);
            this.chkVarLabelCol.Name = "chkVarLabelCol";
            this.chkVarLabelCol.Size = new System.Drawing.Size(106, 17);
            this.chkVarLabelCol.TabIndex = 17;
            this.chkVarLabelCol.Text = "VarLabel Column";
            this.chkVarLabelCol.UseVisualStyleBackColor = true;
            // 
            // chkFilterCol
            // 
            this.chkFilterCol.AutoSize = true;
            this.chkFilterCol.Location = new System.Drawing.Point(1, 17);
            this.chkFilterCol.Name = "chkFilterCol";
            this.chkFilterCol.Size = new System.Drawing.Size(86, 17);
            this.chkFilterCol.TabIndex = 16;
            this.chkFilterCol.Text = "Filter Column";
            this.chkFilterCol.UseVisualStyleBackColor = true;
            // 
            // panelCommentFilters
            // 
            this.panelCommentFilters.Controls.Add(this.label7);
            this.panelCommentFilters.Controls.Add(this.label16);
            this.panelCommentFilters.Controls.Add(this.label6);
            this.panelCommentFilters.Controls.Add(this.label5);
            this.panelCommentFilters.Controls.Add(this.dateTimeCommentsSince);
            this.panelCommentFilters.Controls.Add(this.lstCommentSources);
            this.panelCommentFilters.Controls.Add(this.lstCommentAuthors);
            this.panelCommentFilters.Location = new System.Drawing.Point(319, 220);
            this.panelCommentFilters.Name = "panelCommentFilters";
            this.panelCommentFilters.Size = new System.Drawing.Size(118, 248);
            this.panelCommentFilters.TabIndex = 27;
            this.panelCommentFilters.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Comment Filters";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Comments since";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sources";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Authors";
            // 
            // dateTimeCommentsSince
            // 
            this.dateTimeCommentsSince.Checked = false;
            this.dateTimeCommentsSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeCommentsSince.Location = new System.Drawing.Point(3, 33);
            this.dateTimeCommentsSince.Name = "dateTimeCommentsSince";
            this.dateTimeCommentsSince.ShowCheckBox = true;
            this.dateTimeCommentsSince.Size = new System.Drawing.Size(116, 20);
            this.dateTimeCommentsSince.TabIndex = 5;
            this.dateTimeCommentsSince.ValueChanged += new System.EventHandler(this.CommentsSince_ValueChanged);
            // 
            // lstCommentSources
            // 
            this.lstCommentSources.FormattingEnabled = true;
            this.lstCommentSources.Location = new System.Drawing.Point(6, 174);
            this.lstCommentSources.Name = "lstCommentSources";
            this.lstCommentSources.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCommentSources.Size = new System.Drawing.Size(116, 69);
            this.lstCommentSources.TabIndex = 4;
            this.lstCommentSources.Click += new System.EventHandler(this.CommentSources_Click);
            // 
            // lstCommentAuthors
            // 
            this.lstCommentAuthors.FormattingEnabled = true;
            this.lstCommentAuthors.Location = new System.Drawing.Point(3, 78);
            this.lstCommentAuthors.Name = "lstCommentAuthors";
            this.lstCommentAuthors.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCommentAuthors.Size = new System.Drawing.Size(116, 69);
            this.lstCommentAuthors.TabIndex = 3;
            this.lstCommentAuthors.Click += new System.EventHandler(this.CommentAuthors_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Standard Fields";
            // 
            // lstStdFields
            // 
            this.lstStdFields.FormattingEnabled = true;
            this.lstStdFields.Items.AddRange(new object[] {
            "PreP",
            "PreI",
            "PreA",
            "LitQ",
            "PstI",
            "PstP",
            "RespOptions",
            "NRCodes"});
            this.lstStdFields.Location = new System.Drawing.Point(21, 92);
            this.lstStdFields.Name = "lstStdFields";
            this.lstStdFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStdFields.Size = new System.Drawing.Size(72, 108);
            this.lstStdFields.TabIndex = 10;
            this.lstStdFields.Click += new System.EventHandler(this.StdFields_Click);
            // 
            // chkCorrected
            // 
            this.chkCorrected.AutoSize = true;
            this.chkCorrected.Location = new System.Drawing.Point(21, 206);
            this.chkCorrected.Name = "chkCorrected";
            this.chkCorrected.Size = new System.Drawing.Size(142, 17);
            this.chkCorrected.TabIndex = 18;
            this.chkCorrected.Text = "Use Corrected Wordings";
            this.chkCorrected.UseVisualStyleBackColor = true;
            // 
            // lblTransFields
            // 
            this.lblTransFields.AutoSize = true;
            this.lblTransFields.Location = new System.Drawing.Point(173, 90);
            this.lblTransFields.Name = "lblTransFields";
            this.lblTransFields.Size = new System.Drawing.Size(89, 13);
            this.lblTransFields.TabIndex = 15;
            this.lblTransFields.Text = "Translation Fields";
            this.lblTransFields.Visible = false;
            // 
            // lstTransFields
            // 
            this.lstTransFields.FormattingEnabled = true;
            this.lstTransFields.Location = new System.Drawing.Point(175, 106);
            this.lstTransFields.Name = "lstTransFields";
            this.lstTransFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTransFields.Size = new System.Drawing.Size(117, 108);
            this.lstTransFields.TabIndex = 14;
            this.lstTransFields.Visible = false;
            this.lstTransFields.Click += new System.EventHandler(this.TransFields_Click);
            // 
            // lblCommentFields
            // 
            this.lblCommentFields.AutoSize = true;
            this.lblCommentFields.Location = new System.Drawing.Point(316, 90);
            this.lblCommentFields.Name = "lblCommentFields";
            this.lblCommentFields.Size = new System.Drawing.Size(81, 13);
            this.lblCommentFields.TabIndex = 7;
            this.lblCommentFields.Text = "Comment Fields";
            this.lblCommentFields.Visible = false;
            // 
            // lstCommentFields
            // 
            this.lstCommentFields.FormattingEnabled = true;
            this.lstCommentFields.Location = new System.Drawing.Point(319, 106);
            this.lstCommentFields.Name = "lstCommentFields";
            this.lstCommentFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCommentFields.Size = new System.Drawing.Size(118, 108);
            this.lstCommentFields.TabIndex = 2;
            this.lstCommentFields.Visible = false;
            this.lstCommentFields.Click += new System.EventHandler(this.CommentFields_Click);
            // 
            // cmdToggleExtraFields
            // 
            this.cmdToggleExtraFields.Location = new System.Drawing.Point(174, 70);
            this.cmdToggleExtraFields.Name = "cmdToggleExtraFields";
            this.cmdToggleExtraFields.Size = new System.Drawing.Size(118, 19);
            this.cmdToggleExtraFields.TabIndex = 0;
            this.cmdToggleExtraFields.Text = "Add Extra Fields...";
            this.cmdToggleExtraFields.UseVisualStyleBackColor = true;
            this.cmdToggleExtraFields.Click += new System.EventHandler(this.ToggleExtraFields_Click);
            // 
            // pgCompare
            // 
            this.pgCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgCompare.Controls.Add(this.lblPrimarySurvey);
            this.pgCompare.Controls.Add(this.groupLayoutOptions);
            this.pgCompare.Controls.Add(this.groupHighlightOptions);
            this.pgCompare.Controls.Add(this.gridPrimarySurvey);
            this.pgCompare.Controls.Add(this.chkCompare);
            this.pgCompare.Controls.Add(this.chkMatchOnRename);
            this.pgCompare.Location = new System.Drawing.Point(4, 22);
            this.pgCompare.Name = "pgCompare";
            this.pgCompare.Size = new System.Drawing.Size(465, 503);
            this.pgCompare.TabIndex = 2;
            this.pgCompare.Text = "Comparison";
            // 
            // lblPrimarySurvey
            // 
            this.lblPrimarySurvey.Location = new System.Drawing.Point(14, 246);
            this.lblPrimarySurvey.Name = "lblPrimarySurvey";
            this.lblPrimarySurvey.Size = new System.Drawing.Size(182, 47);
            this.lblPrimarySurvey.TabIndex = 118;
            this.lblPrimarySurvey.Text = "All other surveys will be compared to the reference survey. Surveys not selected " +
    "will contain highlighting.";
            this.lblPrimarySurvey.Visible = false;
            // 
            // groupLayoutOptions
            // 
            this.groupLayoutOptions.Controls.Add(this.flowLayoutPanel1);
            this.groupLayoutOptions.Location = new System.Drawing.Point(253, 344);
            this.groupLayoutOptions.Margin = new System.Windows.Forms.Padding(0);
            this.groupLayoutOptions.Name = "groupLayoutOptions";
            this.groupLayoutOptions.Padding = new System.Windows.Forms.Padding(1);
            this.groupLayoutOptions.Size = new System.Drawing.Size(191, 111);
            this.groupLayoutOptions.TabIndex = 117;
            this.groupLayoutOptions.TabStop = false;
            this.groupLayoutOptions.Text = "Layout Options";
            this.groupLayoutOptions.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.hidePrimaryCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.chkHideIdenticalQs);
            this.flowLayoutPanel1.Controls.Add(this.hideIdenticalWordingsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.beforeAfterReportCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 18);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 92);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // hidePrimaryCheckBox
            // 
            this.hidePrimaryCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HidePrimary", true));
            this.hidePrimaryCheckBox.Location = new System.Drawing.Point(1, 1);
            this.hidePrimaryCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.hidePrimaryCheckBox.Name = "hidePrimaryCheckBox";
            this.hidePrimaryCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.hidePrimaryCheckBox.Size = new System.Drawing.Size(141, 20);
            this.hidePrimaryCheckBox.TabIndex = 25;
            this.hidePrimaryCheckBox.Text = "Hide Reference Survey";
            this.hidePrimaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // compareBindingSource
            // 
            this.compareBindingSource.DataSource = typeof(ITCLib.Comparison);
            // 
            // chkHideIdenticalQs
            // 
            this.chkHideIdenticalQs.AutoSize = true;
            this.chkHideIdenticalQs.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HideIdenticalQuestions", true));
            this.chkHideIdenticalQs.Location = new System.Drawing.Point(1, 21);
            this.chkHideIdenticalQs.Margin = new System.Windows.Forms.Padding(0);
            this.chkHideIdenticalQs.Name = "chkHideIdenticalQs";
            this.chkHideIdenticalQs.Padding = new System.Windows.Forms.Padding(1);
            this.chkHideIdenticalQs.Size = new System.Drawing.Size(143, 19);
            this.chkHideIdenticalQs.TabIndex = 26;
            this.chkHideIdenticalQs.Text = "Hide Identical Questions";
            this.chkHideIdenticalQs.UseVisualStyleBackColor = true;
            // 
            // hideIdenticalWordingsCheckBox
            // 
            this.hideIdenticalWordingsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HideIdenticalWordings", true));
            this.hideIdenticalWordingsCheckBox.Location = new System.Drawing.Point(1, 40);
            this.hideIdenticalWordingsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.hideIdenticalWordingsCheckBox.Name = "hideIdenticalWordingsCheckBox";
            this.hideIdenticalWordingsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.hideIdenticalWordingsCheckBox.Size = new System.Drawing.Size(141, 20);
            this.hideIdenticalWordingsCheckBox.TabIndex = 23;
            this.hideIdenticalWordingsCheckBox.Text = "Hide Identical Wordings";
            this.hideIdenticalWordingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // beforeAfterReportCheckBox
            // 
            this.beforeAfterReportCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "BeforeAfterReport", true));
            this.beforeAfterReportCheckBox.Location = new System.Drawing.Point(1, 60);
            this.beforeAfterReportCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.beforeAfterReportCheckBox.Name = "beforeAfterReportCheckBox";
            this.beforeAfterReportCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.beforeAfterReportCheckBox.Size = new System.Drawing.Size(104, 20);
            this.beforeAfterReportCheckBox.TabIndex = 15;
            this.beforeAfterReportCheckBox.Text = "Before/After Report";
            this.beforeAfterReportCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupHighlightOptions
            // 
            this.groupHighlightOptions.Controls.Add(this.flowHighlightOptions);
            this.groupHighlightOptions.Controls.Add(this.groupHighlightStyle);
            this.groupHighlightOptions.Controls.Add(this.highlightCheckBox);
            this.groupHighlightOptions.Location = new System.Drawing.Point(253, 26);
            this.groupHighlightOptions.Name = "groupHighlightOptions";
            this.groupHighlightOptions.Size = new System.Drawing.Size(191, 315);
            this.groupHighlightOptions.TabIndex = 11;
            this.groupHighlightOptions.TabStop = false;
            this.groupHighlightOptions.Text = "Highlight Options";
            this.groupHighlightOptions.Visible = false;
            // 
            // flowHighlightOptions
            // 
            this.flowHighlightOptions.Controls.Add(this.highlightNRCheckBox);
            this.flowHighlightOptions.Controls.Add(this.ignoreSimilarWordsCheckBox);
            this.flowHighlightOptions.Controls.Add(this.hybridHighlightCheckBox);
            this.flowHighlightOptions.Controls.Add(this.showDeletedFieldsCheckBox);
            this.flowHighlightOptions.Controls.Add(this.chkShowDeletedQuestions);
            this.flowHighlightOptions.Controls.Add(this.chkReInsertDeletions);
            this.flowHighlightOptions.Controls.Add(this.showOrderChangesCheckBox);
            this.flowHighlightOptions.Location = new System.Drawing.Point(28, 164);
            this.flowHighlightOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowHighlightOptions.Name = "flowHighlightOptions";
            this.flowHighlightOptions.Padding = new System.Windows.Forms.Padding(1);
            this.flowHighlightOptions.Size = new System.Drawing.Size(157, 143);
            this.flowHighlightOptions.TabIndex = 10;
            // 
            // highlightNRCheckBox
            // 
            this.highlightNRCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HighlightNR", true));
            this.highlightNRCheckBox.Location = new System.Drawing.Point(1, 1);
            this.highlightNRCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.highlightNRCheckBox.Name = "highlightNRCheckBox";
            this.highlightNRCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.highlightNRCheckBox.Size = new System.Drawing.Size(141, 20);
            this.highlightNRCheckBox.TabIndex = 29;
            this.highlightNRCheckBox.Text = "Highlight NR";
            this.highlightNRCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSimilarWordsCheckBox
            // 
            this.ignoreSimilarWordsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "IgnoreSimilarWords", true));
            this.ignoreSimilarWordsCheckBox.Location = new System.Drawing.Point(1, 21);
            this.ignoreSimilarWordsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ignoreSimilarWordsCheckBox.Name = "ignoreSimilarWordsCheckBox";
            this.ignoreSimilarWordsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.ignoreSimilarWordsCheckBox.Size = new System.Drawing.Size(141, 20);
            this.ignoreSimilarWordsCheckBox.TabIndex = 37;
            this.ignoreSimilarWordsCheckBox.Text = "Ignore Word Variants";
            this.ignoreSimilarWordsCheckBox.UseVisualStyleBackColor = true;
            // 
            // hybridHighlightCheckBox
            // 
            this.hybridHighlightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HybridHighlight", true));
            this.hybridHighlightCheckBox.Location = new System.Drawing.Point(1, 41);
            this.hybridHighlightCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.hybridHighlightCheckBox.Name = "hybridHighlightCheckBox";
            this.hybridHighlightCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.hybridHighlightCheckBox.Size = new System.Drawing.Size(141, 20);
            this.hybridHighlightCheckBox.TabIndex = 35;
            this.hybridHighlightCheckBox.Text = "Markup Differences";
            this.hybridHighlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDeletedFieldsCheckBox
            // 
            this.showDeletedFieldsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedFields", true));
            this.showDeletedFieldsCheckBox.Location = new System.Drawing.Point(1, 61);
            this.showDeletedFieldsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.showDeletedFieldsCheckBox.Name = "showDeletedFieldsCheckBox";
            this.showDeletedFieldsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.showDeletedFieldsCheckBox.Size = new System.Drawing.Size(141, 20);
            this.showDeletedFieldsCheckBox.TabIndex = 47;
            this.showDeletedFieldsCheckBox.Text = "Show Deleted Fields";
            this.showDeletedFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkShowDeletedQuestions
            // 
            this.chkShowDeletedQuestions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedQuestions", true));
            this.chkShowDeletedQuestions.Location = new System.Drawing.Point(1, 81);
            this.chkShowDeletedQuestions.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowDeletedQuestions.Name = "chkShowDeletedQuestions";
            this.chkShowDeletedQuestions.Padding = new System.Windows.Forms.Padding(1);
            this.chkShowDeletedQuestions.Size = new System.Drawing.Size(156, 20);
            this.chkShowDeletedQuestions.TabIndex = 49;
            this.chkShowDeletedQuestions.Text = "Show Deleted Questions";
            this.chkShowDeletedQuestions.UseVisualStyleBackColor = true;
            this.chkShowDeletedQuestions.CheckedChanged += new System.EventHandler(this.ShowDeletedQuestionsCheckBox_CheckedChanged);
            // 
            // chkReInsertDeletions
            // 
            this.chkReInsertDeletions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ReInsertDeletions", true));
            this.chkReInsertDeletions.Location = new System.Drawing.Point(1, 101);
            this.chkReInsertDeletions.Margin = new System.Windows.Forms.Padding(0);
            this.chkReInsertDeletions.Name = "chkReInsertDeletions";
            this.chkReInsertDeletions.Padding = new System.Windows.Forms.Padding(1);
            this.chkReInsertDeletions.Size = new System.Drawing.Size(123, 20);
            this.chkReInsertDeletions.TabIndex = 43;
            this.chkReInsertDeletions.Text = "Re-insert Deletions";
            this.chkReInsertDeletions.UseVisualStyleBackColor = true;
            // 
            // showOrderChangesCheckBox
            // 
            this.showOrderChangesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowOrderChanges", true));
            this.showOrderChangesCheckBox.Location = new System.Drawing.Point(1, 121);
            this.showOrderChangesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.showOrderChangesCheckBox.Name = "showOrderChangesCheckBox";
            this.showOrderChangesCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.showOrderChangesCheckBox.Size = new System.Drawing.Size(141, 20);
            this.showOrderChangesCheckBox.TabIndex = 51;
            this.showOrderChangesCheckBox.Text = "Show Order Changes";
            this.showOrderChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupHighlightStyle
            // 
            this.groupHighlightStyle.Controls.Add(this.cboHighlightScheme);
            this.groupHighlightStyle.Controls.Add(this.radioButton2);
            this.groupHighlightStyle.Controls.Add(this.radioButton1);
            this.groupHighlightStyle.Controls.Add(this.convertTrackedChangesCheckBox);
            this.groupHighlightStyle.Location = new System.Drawing.Point(18, 42);
            this.groupHighlightStyle.Name = "groupHighlightStyle";
            this.groupHighlightStyle.Size = new System.Drawing.Size(152, 117);
            this.groupHighlightStyle.TabIndex = 3;
            this.groupHighlightStyle.TabStop = false;
            this.groupHighlightStyle.Text = "Highlight Style";
            // 
            // cboHighlightScheme
            // 
            this.cboHighlightScheme.FormattingEnabled = true;
            this.cboHighlightScheme.Location = new System.Drawing.Point(18, 88);
            this.cboHighlightScheme.Name = "cboHighlightScheme";
            this.cboHighlightScheme.Size = new System.Drawing.Size(103, 21);
            this.cboHighlightScheme.TabIndex = 3;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "2";
            this.radioButton2.Text = "Tracked Changes";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.HighlightStyle_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "Classic highlight";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.HighlightStyle_CheckedChanged);
            // 
            // convertTrackedChangesCheckBox
            // 
            this.convertTrackedChangesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.compareBindingSource, "ConvertTrackedChanges", true));
            this.convertTrackedChangesCheckBox.Location = new System.Drawing.Point(30, 64);
            this.convertTrackedChangesCheckBox.Name = "convertTrackedChangesCheckBox";
            this.convertTrackedChangesCheckBox.Size = new System.Drawing.Size(85, 20);
            this.convertTrackedChangesCheckBox.TabIndex = 19;
            this.convertTrackedChangesCheckBox.Text = "Real TC";
            this.convertTrackedChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "Highlight", true));
            this.highlightCheckBox.Location = new System.Drawing.Point(29, 19);
            this.highlightCheckBox.Name = "highlightCheckBox";
            this.highlightCheckBox.Size = new System.Drawing.Size(104, 20);
            this.highlightCheckBox.TabIndex = 27;
            this.highlightCheckBox.Text = "Highlight";
            this.highlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // gridPrimarySurvey
            // 
            this.gridPrimarySurvey.AllowUserToAddRows = false;
            this.gridPrimarySurvey.AllowUserToDeleteRows = false;
            this.gridPrimarySurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrimarySurvey.Location = new System.Drawing.Point(12, 67);
            this.gridPrimarySurvey.Name = "gridPrimarySurvey";
            this.gridPrimarySurvey.RowHeadersVisible = false;
            this.gridPrimarySurvey.Size = new System.Drawing.Size(235, 167);
            this.gridPrimarySurvey.TabIndex = 1;
            this.gridPrimarySurvey.Visible = false;
            this.gridPrimarySurvey.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrimarySurvey_CellValueChanged);
            this.gridPrimarySurvey.CurrentCellDirtyStateChanged += new System.EventHandler(this.PrimarySurvey_CurrentCellDirtyStateChanged);
            this.gridPrimarySurvey.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PrimarySurvey_DataBindingComplete);
            // 
            // chkCompare
            // 
            this.chkCompare.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.surveyReportBindingSource, "CompareWordings", true));
            this.chkCompare.Location = new System.Drawing.Point(13, 26);
            this.chkCompare.Name = "chkCompare";
            this.chkCompare.Size = new System.Drawing.Size(104, 24);
            this.chkCompare.TabIndex = 21;
            this.chkCompare.Text = "Compare?";
            this.chkCompare.UseVisualStyleBackColor = true;
            this.chkCompare.CheckedChanged += new System.EventHandler(this.Compare_CheckedChanged);
            // 
            // surveyReportBindingSource
            // 
            this.surveyReportBindingSource.DataSource = typeof(ITCLib.SurveyBasedReport);
            // 
            // chkMatchOnRename
            // 
            this.chkMatchOnRename.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "MatchOnRename", true));
            this.chkMatchOnRename.Location = new System.Drawing.Point(13, 294);
            this.chkMatchOnRename.Margin = new System.Windows.Forms.Padding(0);
            this.chkMatchOnRename.Name = "chkMatchOnRename";
            this.chkMatchOnRename.Padding = new System.Windows.Forms.Padding(1);
            this.chkMatchOnRename.Size = new System.Drawing.Size(196, 20);
            this.chkMatchOnRename.TabIndex = 41;
            this.chkMatchOnRename.Text = "Match variables on previous names";
            this.chkMatchOnRename.UseVisualStyleBackColor = true;
            this.chkMatchOnRename.Visible = false;
            // 
            // pgOrder
            // 
            this.pgOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgOrder.Controls.Add(this.label17);
            this.pgOrder.Controls.Add(this.label4);
            this.pgOrder.Controls.Add(this.chkBlankCol);
            this.pgOrder.Controls.Add(this.gridQnumSurvey);
            this.pgOrder.Controls.Add(this.gridColumnOrder);
            this.pgOrder.Controls.Add(this.groupEnumeration);
            this.pgOrder.Location = new System.Drawing.Point(4, 22);
            this.pgOrder.Name = "pgOrder";
            this.pgOrder.Size = new System.Drawing.Size(465, 503);
            this.pgOrder.TabIndex = 3;
            this.pgOrder.Text = "Order and Numbering";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(30, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "Qnum Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Column Order";
            // 
            // chkBlankCol
            // 
            this.chkBlankCol.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.reportLayoutBindingSource, "BlankColumn", true));
            this.chkBlankCol.Location = new System.Drawing.Point(292, 46);
            this.chkBlankCol.Margin = new System.Windows.Forms.Padding(0);
            this.chkBlankCol.Name = "chkBlankCol";
            this.chkBlankCol.Padding = new System.Windows.Forms.Padding(1);
            this.chkBlankCol.Size = new System.Drawing.Size(138, 17);
            this.chkBlankCol.TabIndex = 56;
            this.chkBlankCol.Text = "Include Blank Column";
            this.chkBlankCol.UseVisualStyleBackColor = true;
            // 
            // reportLayoutBindingSource
            // 
            this.reportLayoutBindingSource.DataSource = typeof(ITCLib.ReportLayout);
            // 
            // gridQnumSurvey
            // 
            this.gridQnumSurvey.AllowUserToAddRows = false;
            this.gridQnumSurvey.AllowUserToDeleteRows = false;
            this.gridQnumSurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQnumSurvey.Location = new System.Drawing.Point(28, 168);
            this.gridQnumSurvey.Name = "gridQnumSurvey";
            this.gridQnumSurvey.RowHeadersVisible = false;
            this.gridQnumSurvey.Size = new System.Drawing.Size(241, 121);
            this.gridQnumSurvey.TabIndex = 55;
            this.gridQnumSurvey.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.QnumSurvey_CellValueChanged);
            this.gridQnumSurvey.CurrentCellChanged += new System.EventHandler(this.QnumSurvey_CurrentCellChanged);
            this.gridQnumSurvey.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.QnumSurvey_DataBindingComplete);
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.AllowUserToAddRows = false;
            this.gridColumnOrder.AllowUserToDeleteRows = false;
            this.gridColumnOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumnOrder.Location = new System.Drawing.Point(27, 46);
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.ReadOnly = true;
            this.gridColumnOrder.RowHeadersVisible = false;
            this.gridColumnOrder.Size = new System.Drawing.Size(242, 88);
            this.gridColumnOrder.TabIndex = 54;
            this.gridColumnOrder.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ColumnOrder_DataBindingComplete);
            // 
            // groupEnumeration
            // 
            this.groupEnumeration.Controls.Add(this.optQnumAltQnum);
            this.groupEnumeration.Controls.Add(this.optAltQnumOnly);
            this.groupEnumeration.Controls.Add(this.optQnumOnly);
            this.groupEnumeration.Controls.Add(this.chkShowAllQnums);
            this.groupEnumeration.Location = new System.Drawing.Point(292, 168);
            this.groupEnumeration.Name = "groupEnumeration";
            this.groupEnumeration.Size = new System.Drawing.Size(122, 121);
            this.groupEnumeration.TabIndex = 53;
            this.groupEnumeration.TabStop = false;
            this.groupEnumeration.Text = "Enumeration";
            // 
            // optQnumAltQnum
            // 
            this.optQnumAltQnum.AutoSize = true;
            this.optQnumAltQnum.Location = new System.Drawing.Point(25, 61);
            this.optQnumAltQnum.Name = "optQnumAltQnum";
            this.optQnumAltQnum.Size = new System.Drawing.Size(47, 17);
            this.optQnumAltQnum.TabIndex = 55;
            this.optQnumAltQnum.TabStop = true;
            this.optQnumAltQnum.Tag = "3";
            this.optQnumAltQnum.Text = "Both";
            this.optQnumAltQnum.UseVisualStyleBackColor = true;
            this.optQnumAltQnum.CheckedChanged += new System.EventHandler(this.EnumerationRadioButton_CheckedChanged);
            // 
            // optAltQnumOnly
            // 
            this.optAltQnumOnly.AutoSize = true;
            this.optAltQnumOnly.Location = new System.Drawing.Point(25, 38);
            this.optAltQnumOnly.Name = "optAltQnumOnly";
            this.optAltQnumOnly.Size = new System.Drawing.Size(65, 17);
            this.optAltQnumOnly.TabIndex = 54;
            this.optAltQnumOnly.TabStop = true;
            this.optAltQnumOnly.Tag = "2";
            this.optAltQnumOnly.Text = "AltQnum";
            this.optAltQnumOnly.UseVisualStyleBackColor = true;
            this.optAltQnumOnly.CheckedChanged += new System.EventHandler(this.EnumerationRadioButton_CheckedChanged);
            // 
            // optQnumOnly
            // 
            this.optQnumOnly.AutoSize = true;
            this.optQnumOnly.Checked = true;
            this.optQnumOnly.Location = new System.Drawing.Point(25, 15);
            this.optQnumOnly.Name = "optQnumOnly";
            this.optQnumOnly.Size = new System.Drawing.Size(53, 17);
            this.optQnumOnly.TabIndex = 53;
            this.optQnumOnly.TabStop = true;
            this.optQnumOnly.Tag = "1";
            this.optQnumOnly.Text = "Qnum";
            this.optQnumOnly.UseVisualStyleBackColor = true;
            this.optQnumOnly.CheckedChanged += new System.EventHandler(this.EnumerationRadioButton_CheckedChanged);
            // 
            // chkShowAllQnums
            // 
            this.chkShowAllQnums.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.surveyReportBindingSource, "ShowAllQnums", true));
            this.chkShowAllQnums.Location = new System.Drawing.Point(12, 91);
            this.chkShowAllQnums.Name = "chkShowAllQnums";
            this.chkShowAllQnums.Size = new System.Drawing.Size(104, 24);
            this.chkShowAllQnums.TabIndex = 52;
            this.chkShowAllQnums.Text = "Show All Qnums";
            this.chkShowAllQnums.UseVisualStyleBackColor = true;
            // 
            // pgFormatting
            // 
            this.pgFormatting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFormatting.Controls.Add(this.groupBox3);
            this.pgFormatting.Location = new System.Drawing.Point(4, 22);
            this.pgFormatting.Name = "pgFormatting";
            this.pgFormatting.Size = new System.Drawing.Size(465, 503);
            this.pgFormatting.TabIndex = 4;
            this.pgFormatting.Text = "Formatting";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(45, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 407);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Functions";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstRepeatedFields, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.chkShowRepeatedFields, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.repeatedHeadingsCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.qNInsertionCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.bySectionCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.includeWordingsCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorSubsCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.aQNInsertionCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.showLongListsCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cCInsertionCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkTableFormat, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.inlineRoutingCheckBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.semiTelCheckBox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderOptions, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkTranslationTableFormat, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 353);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // lstRepeatedFields
            // 
            this.lstRepeatedFields.FormattingEnabled = true;
            this.lstRepeatedFields.Location = new System.Drawing.Point(3, 228);
            this.lstRepeatedFields.Name = "lstRepeatedFields";
            this.lstRepeatedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstRepeatedFields.Size = new System.Drawing.Size(72, 108);
            this.lstRepeatedFields.TabIndex = 56;
            this.lstRepeatedFields.Visible = false;
            this.lstRepeatedFields.Click += new System.EventHandler(this.RepeatedFields_Click);
            // 
            // chkShowRepeatedFields
            // 
            this.chkShowRepeatedFields.AutoSize = true;
            this.chkShowRepeatedFields.Location = new System.Drawing.Point(3, 203);
            this.chkShowRepeatedFields.Name = "chkShowRepeatedFields";
            this.chkShowRepeatedFields.Size = new System.Drawing.Size(103, 17);
            this.chkShowRepeatedFields.TabIndex = 57;
            this.chkShowRepeatedFields.Text = "Repeated Fields";
            this.chkShowRepeatedFields.UseVisualStyleBackColor = true;
            this.chkShowRepeatedFields.CheckedChanged += new System.EventHandler(this.ShowRepeatedFields_CheckedChanged);
            // 
            // repeatedHeadingsCheckBox
            // 
            this.repeatedHeadingsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "RepeatedHeadings", true));
            this.repeatedHeadingsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.repeatedHeadingsCheckBox.Name = "repeatedHeadingsCheckBox";
            this.repeatedHeadingsCheckBox.Size = new System.Drawing.Size(122, 19);
            this.repeatedHeadingsCheckBox.TabIndex = 46;
            this.repeatedHeadingsCheckBox.Text = "Repeat Headings";
            this.repeatedHeadingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // qNInsertionCheckBox
            // 
            this.qNInsertionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "QNInsertion", true));
            this.qNInsertionCheckBox.Location = new System.Drawing.Point(3, 78);
            this.qNInsertionCheckBox.Name = "qNInsertionCheckBox";
            this.qNInsertionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.qNInsertionCheckBox.TabIndex = 44;
            this.qNInsertionCheckBox.Text = "QN Insertion";
            this.qNInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // bySectionCheckBox
            // 
            this.bySectionCheckBox.Location = new System.Drawing.Point(170, 28);
            this.bySectionCheckBox.Name = "bySectionCheckBox";
            this.bySectionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.bySectionCheckBox.TabIndex = 17;
            this.bySectionCheckBox.Text = "By Section";
            this.bySectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeWordingsCheckBox
            // 
            this.includeWordingsCheckBox.Location = new System.Drawing.Point(170, 53);
            this.includeWordingsCheckBox.Name = "includeWordingsCheckBox";
            this.includeWordingsCheckBox.Size = new System.Drawing.Size(120, 19);
            this.includeWordingsCheckBox.TabIndex = 39;
            this.includeWordingsCheckBox.Text = "Include Wordings";
            this.includeWordingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorSubsCheckBox
            // 
            this.colorSubsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "ColorSubs", true));
            this.colorSubsCheckBox.Location = new System.Drawing.Point(3, 28);
            this.colorSubsCheckBox.Name = "colorSubsCheckBox";
            this.colorSubsCheckBox.Size = new System.Drawing.Size(122, 19);
            this.colorSubsCheckBox.TabIndex = 22;
            this.colorSubsCheckBox.Text = "Color Subheadings";
            this.colorSubsCheckBox.UseVisualStyleBackColor = true;
            // 
            // aQNInsertionCheckBox
            // 
            this.aQNInsertionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "AQNInsertion", true));
            this.aQNInsertionCheckBox.Location = new System.Drawing.Point(170, 78);
            this.aQNInsertionCheckBox.Name = "aQNInsertionCheckBox";
            this.aQNInsertionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.aQNInsertionCheckBox.TabIndex = 10;
            this.aQNInsertionCheckBox.Text = "Use AltQnum";
            this.aQNInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLongListsCheckBox
            // 
            this.showLongListsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "ShowLongLists", true));
            this.showLongListsCheckBox.Location = new System.Drawing.Point(3, 53);
            this.showLongListsCheckBox.Name = "showLongListsCheckBox";
            this.showLongListsCheckBox.Size = new System.Drawing.Size(104, 19);
            this.showLongListsCheckBox.TabIndex = 54;
            this.showLongListsCheckBox.Text = "Show Long Lists";
            this.showLongListsCheckBox.UseVisualStyleBackColor = true;
            // 
            // cCInsertionCheckBox
            // 
            this.cCInsertionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "CCInsertion", true));
            this.cCInsertionCheckBox.Location = new System.Drawing.Point(3, 103);
            this.cCInsertionCheckBox.Name = "cCInsertionCheckBox";
            this.cCInsertionCheckBox.Size = new System.Drawing.Size(120, 19);
            this.cCInsertionCheckBox.TabIndex = 14;
            this.cCInsertionCheckBox.Text = "Insert Country Code";
            this.cCInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkTableFormat
            // 
            this.chkTableFormat.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SubsetTables", true));
            this.chkTableFormat.Location = new System.Drawing.Point(3, 128);
            this.chkTableFormat.Name = "chkTableFormat";
            this.chkTableFormat.Size = new System.Drawing.Size(132, 19);
            this.chkTableFormat.TabIndex = 60;
            this.chkTableFormat.Text = "Insert Subset Tables";
            this.chkTableFormat.UseVisualStyleBackColor = true;
            this.chkTableFormat.CheckedChanged += new System.EventHandler(this.TableFormat_CheckedChanged);
            // 
            // inlineRoutingCheckBox
            // 
            this.inlineRoutingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "InlineRouting", true));
            this.inlineRoutingCheckBox.Location = new System.Drawing.Point(3, 153);
            this.inlineRoutingCheckBox.Name = "inlineRoutingCheckBox";
            this.inlineRoutingCheckBox.Size = new System.Drawing.Size(104, 19);
            this.inlineRoutingCheckBox.TabIndex = 38;
            this.inlineRoutingCheckBox.Text = "In-line Routing";
            this.inlineRoutingCheckBox.UseVisualStyleBackColor = true;
            // 
            // semiTelCheckBox
            // 
            this.semiTelCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SemiTel", true));
            this.semiTelCheckBox.Location = new System.Drawing.Point(3, 178);
            this.semiTelCheckBox.Name = "semiTelCheckBox";
            this.semiTelCheckBox.Size = new System.Drawing.Size(104, 19);
            this.semiTelCheckBox.TabIndex = 50;
            this.semiTelCheckBox.Text = "Semi-Telephone";
            this.semiTelCheckBox.UseVisualStyleBackColor = true;
            // 
            // lblOrderOptions
            // 
            this.lblOrderOptions.AutoSize = true;
            this.lblOrderOptions.Location = new System.Drawing.Point(170, 0);
            this.lblOrderOptions.Name = "lblOrderOptions";
            this.lblOrderOptions.Size = new System.Drawing.Size(96, 13);
            this.lblOrderOptions.TabIndex = 141;
            this.lblOrderOptions.Text = "Order Comparisons";
            // 
            // chkTranslationTableFormat
            // 
            this.chkTranslationTableFormat.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SubsetTablesTranslation", true));
            this.chkTranslationTableFormat.Location = new System.Drawing.Point(170, 128);
            this.chkTranslationTableFormat.Name = "chkTranslationTableFormat";
            this.chkTranslationTableFormat.Size = new System.Drawing.Size(104, 19);
            this.chkTranslationTableFormat.TabIndex = 62;
            this.chkTranslationTableFormat.Text = "Use Translation";
            this.chkTranslationTableFormat.UseVisualStyleBackColor = true;
            this.chkTranslationTableFormat.Visible = false;
            // 
            // pgOutput
            // 
            this.pgOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgOutput.Controls.Add(this.groupBox4);
            this.pgOutput.Location = new System.Drawing.Point(4, 22);
            this.pgOutput.Name = "pgOutput";
            this.pgOutput.Padding = new System.Windows.Forms.Padding(3);
            this.pgOutput.Size = new System.Drawing.Size(465, 503);
            this.pgOutput.TabIndex = 5;
            this.pgOutput.Text = "Output";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel3);
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Controls.Add(this.groupNRFormat);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupToC);
            this.groupBox4.Controls.Add(this.groupFileFormat);
            this.groupBox4.Location = new System.Drawing.Point(15, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(349, 451);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Options";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Controls.Add(this.webCheckBox);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.chkCoverPage);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(43, 341);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(261, 104);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // webCheckBox
            // 
            this.webCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.surveyReportBindingSource, "Web", true));
            this.webCheckBox.Location = new System.Drawing.Point(1, 1);
            this.webCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.webCheckBox.Name = "webCheckBox";
            this.webCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.webCheckBox.Size = new System.Drawing.Size(104, 24);
            this.webCheckBox.TabIndex = 70;
            this.webCheckBox.Text = "Web Output";
            this.webCheckBox.UseVisualStyleBackColor = true;
            this.webCheckBox.CheckedChanged += new System.EventHandler(this.WebCheckBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(1);
            this.label10.Size = new System.Drawing.Size(242, 28);
            this.label10.TabIndex = 71;
            this.label10.Text = "Includes PDF format, Cover Page with mode and Web file name";
            // 
            // chkCoverPage
            // 
            this.chkCoverPage.AutoSize = true;
            this.chkCoverPage.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.reportLayoutBindingSource, "CoverPage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCoverPage.Location = new System.Drawing.Point(4, 56);
            this.chkCoverPage.Name = "chkCoverPage";
            this.chkCoverPage.Size = new System.Drawing.Size(82, 17);
            this.chkCoverPage.TabIndex = 72;
            this.chkCoverPage.Text = "Cover Page";
            this.chkCoverPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.survNotesCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.varChangesColCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.varChangesAppCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.excludeTempChangesCheckBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(43, 234);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(261, 101);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // survNotesCheckBox
            // 
            this.survNotesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurvNotes", true));
            this.survNotesCheckBox.Location = new System.Drawing.Point(1, 1);
            this.survNotesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.survNotesCheckBox.Name = "survNotesCheckBox";
            this.survNotesCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.survNotesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.survNotesCheckBox.TabIndex = 58;
            this.survNotesCheckBox.Text = "Survey Notes";
            this.survNotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // varChangesColCheckBox
            // 
            this.varChangesColCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "VarChangesCol", true));
            this.varChangesColCheckBox.Location = new System.Drawing.Point(1, 25);
            this.varChangesColCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.varChangesColCheckBox.Name = "varChangesColCheckBox";
            this.varChangesColCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.varChangesColCheckBox.Size = new System.Drawing.Size(218, 24);
            this.varChangesColCheckBox.TabIndex = 68;
            this.varChangesColCheckBox.Text = "VarName Changes (in VarName column)";
            this.varChangesColCheckBox.UseVisualStyleBackColor = true;
            // 
            // varChangesAppCheckBox
            // 
            this.varChangesAppCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "VarChangesApp", true));
            this.varChangesAppCheckBox.Location = new System.Drawing.Point(1, 49);
            this.varChangesAppCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.varChangesAppCheckBox.Name = "varChangesAppCheckBox";
            this.varChangesAppCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.varChangesAppCheckBox.Size = new System.Drawing.Size(191, 24);
            this.varChangesAppCheckBox.TabIndex = 66;
            this.varChangesAppCheckBox.Text = "Var Name Changes (in Appendix)";
            this.varChangesAppCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludeTempChangesCheckBox
            // 
            this.excludeTempChangesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "ExcludeTempChanges", true));
            this.excludeTempChangesCheckBox.Location = new System.Drawing.Point(1, 73);
            this.excludeTempChangesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.excludeTempChangesCheckBox.Name = "excludeTempChangesCheckBox";
            this.excludeTempChangesCheckBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.excludeTempChangesCheckBox.Size = new System.Drawing.Size(163, 24);
            this.excludeTempChangesCheckBox.TabIndex = 32;
            this.excludeTempChangesCheckBox.Text = "Exclude Hidden Changes";
            this.excludeTempChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupNRFormat
            // 
            this.groupNRFormat.Controls.Add(this.optNRFormatDontReadOut);
            this.groupNRFormat.Controls.Add(this.optNRFormatDontRead);
            this.groupNRFormat.Controls.Add(this.optNRFormatNeither);
            this.groupNRFormat.Location = new System.Drawing.Point(173, 127);
            this.groupNRFormat.Name = "groupNRFormat";
            this.groupNRFormat.Size = new System.Drawing.Size(131, 101);
            this.groupNRFormat.TabIndex = 3;
            this.groupNRFormat.TabStop = false;
            this.groupNRFormat.Text = "NR Format";
            // 
            // optNRFormatDontReadOut
            // 
            this.optNRFormatDontReadOut.AutoSize = true;
            this.optNRFormatDontReadOut.Location = new System.Drawing.Point(11, 64);
            this.optNRFormatDontReadOut.Name = "optNRFormatDontReadOut";
            this.optNRFormatDontReadOut.Size = new System.Drawing.Size(99, 17);
            this.optNRFormatDontReadOut.TabIndex = 2;
            this.optNRFormatDontReadOut.Tag = "2";
            this.optNRFormatDontReadOut.Text = "Don\'t Read Out";
            this.optNRFormatDontReadOut.UseVisualStyleBackColor = true;
            this.optNRFormatDontReadOut.CheckedChanged += new System.EventHandler(this.NRFormat_CheckedChanged);
            // 
            // optNRFormatDontRead
            // 
            this.optNRFormatDontRead.AutoSize = true;
            this.optNRFormatDontRead.Location = new System.Drawing.Point(11, 41);
            this.optNRFormatDontRead.Name = "optNRFormatDontRead";
            this.optNRFormatDontRead.Size = new System.Drawing.Size(79, 17);
            this.optNRFormatDontRead.TabIndex = 1;
            this.optNRFormatDontRead.Tag = "1";
            this.optNRFormatDontRead.Text = "Don\'t Read";
            this.optNRFormatDontRead.UseVisualStyleBackColor = true;
            this.optNRFormatDontRead.CheckedChanged += new System.EventHandler(this.NRFormat_CheckedChanged);
            // 
            // optNRFormatNeither
            // 
            this.optNRFormatNeither.AutoSize = true;
            this.optNRFormatNeither.Checked = true;
            this.optNRFormatNeither.Location = new System.Drawing.Point(11, 18);
            this.optNRFormatNeither.Name = "optNRFormatNeither";
            this.optNRFormatNeither.Size = new System.Drawing.Size(59, 17);
            this.optNRFormatNeither.TabIndex = 0;
            this.optNRFormatNeither.TabStop = true;
            this.optNRFormatNeither.Tag = "0";
            this.optNRFormatNeither.Text = "Neither";
            this.optNRFormatNeither.UseVisualStyleBackColor = true;
            this.optNRFormatNeither.CheckedChanged += new System.EventHandler(this.NRFormat_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButton14);
            this.groupBox7.Controls.Add(this.radioButton13);
            this.groupBox7.Controls.Add(this.radioButton12);
            this.groupBox7.Controls.Add(this.radioButton11);
            this.groupBox7.Location = new System.Drawing.Point(43, 127);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(95, 101);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Paper Size";
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(13, 73);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(38, 17);
            this.radioButton14.TabIndex = 3;
            this.radioButton14.Tag = "4";
            this.radioButton14.Text = "A4";
            this.radioButton14.UseVisualStyleBackColor = true;
            this.radioButton14.CheckedChanged += new System.EventHandler(this.PaperSize_CheckedChanged);
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(13, 55);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(54, 17);
            this.radioButton13.TabIndex = 2;
            this.radioButton13.Tag = "3";
            this.radioButton13.Text = "11x17";
            this.radioButton13.UseVisualStyleBackColor = true;
            this.radioButton13.CheckedChanged += new System.EventHandler(this.PaperSize_CheckedChanged);
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(13, 33);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(51, 17);
            this.radioButton12.TabIndex = 1;
            this.radioButton12.Tag = "2";
            this.radioButton12.Text = "Legal";
            this.radioButton12.UseVisualStyleBackColor = true;
            this.radioButton12.CheckedChanged += new System.EventHandler(this.PaperSize_CheckedChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Checked = true;
            this.radioButton11.Location = new System.Drawing.Point(13, 17);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(52, 17);
            this.radioButton11.TabIndex = 0;
            this.radioButton11.TabStop = true;
            this.radioButton11.Tag = "1";
            this.radioButton11.Text = "Letter";
            this.radioButton11.UseVisualStyleBackColor = true;
            this.radioButton11.CheckedChanged += new System.EventHandler(this.PaperSize_CheckedChanged);
            // 
            // groupToC
            // 
            this.groupToC.Controls.Add(this.optToCPgNum);
            this.groupToC.Controls.Add(this.optToCQnum);
            this.groupToC.Controls.Add(this.optToCNone);
            this.groupToC.Location = new System.Drawing.Point(173, 35);
            this.groupToC.Name = "groupToC";
            this.groupToC.Size = new System.Drawing.Size(131, 88);
            this.groupToC.TabIndex = 1;
            this.groupToC.TabStop = false;
            this.groupToC.Text = "Table of Contents";
            // 
            // optToCPgNum
            // 
            this.optToCPgNum.AutoSize = true;
            this.optToCPgNum.Location = new System.Drawing.Point(13, 60);
            this.optToCPgNum.Name = "optToCPgNum";
            this.optToCPgNum.Size = new System.Drawing.Size(95, 17);
            this.optToCPgNum.TabIndex = 2;
            this.optToCPgNum.Tag = "2";
            this.optToCPgNum.Text = "Page Numbers";
            this.optToCPgNum.UseVisualStyleBackColor = true;
            this.optToCPgNum.CheckedChanged += new System.EventHandler(this.ToC_CheckedChanged);
            // 
            // optToCQnum
            // 
            this.optToCQnum.AutoSize = true;
            this.optToCQnum.Location = new System.Drawing.Point(13, 39);
            this.optToCQnum.Name = "optToCQnum";
            this.optToCQnum.Size = new System.Drawing.Size(112, 17);
            this.optToCQnum.TabIndex = 1;
            this.optToCQnum.Tag = "1";
            this.optToCQnum.Text = "Question Numbers";
            this.optToCQnum.UseVisualStyleBackColor = true;
            this.optToCQnum.CheckedChanged += new System.EventHandler(this.ToC_CheckedChanged);
            // 
            // optToCNone
            // 
            this.optToCNone.AutoSize = true;
            this.optToCNone.Checked = true;
            this.optToCNone.Location = new System.Drawing.Point(13, 21);
            this.optToCNone.Name = "optToCNone";
            this.optToCNone.Size = new System.Drawing.Size(51, 17);
            this.optToCNone.TabIndex = 0;
            this.optToCNone.TabStop = true;
            this.optToCNone.Tag = "0";
            this.optToCNone.Text = "None";
            this.optToCNone.UseVisualStyleBackColor = true;
            this.optToCNone.CheckedChanged += new System.EventHandler(this.ToC_CheckedChanged);
            // 
            // groupFileFormat
            // 
            this.groupFileFormat.Controls.Add(this.optFileFormatPDF);
            this.groupFileFormat.Controls.Add(this.optFileFormatWord);
            this.groupFileFormat.Location = new System.Drawing.Point(43, 35);
            this.groupFileFormat.Name = "groupFileFormat";
            this.groupFileFormat.Size = new System.Drawing.Size(95, 88);
            this.groupFileFormat.TabIndex = 0;
            this.groupFileFormat.TabStop = false;
            this.groupFileFormat.Text = "File Format";
            // 
            // optFileFormatPDF
            // 
            this.optFileFormatPDF.AutoSize = true;
            this.optFileFormatPDF.Location = new System.Drawing.Point(9, 39);
            this.optFileFormatPDF.Name = "optFileFormatPDF";
            this.optFileFormatPDF.Size = new System.Drawing.Size(46, 17);
            this.optFileFormatPDF.TabIndex = 1;
            this.optFileFormatPDF.Tag = "2";
            this.optFileFormatPDF.Text = "PDF";
            this.optFileFormatPDF.UseVisualStyleBackColor = true;
            this.optFileFormatPDF.CheckedChanged += new System.EventHandler(this.FileFormat_CheckedChanged);
            // 
            // optFileFormatWord
            // 
            this.optFileFormatWord.AutoSize = true;
            this.optFileFormatWord.Checked = true;
            this.optFileFormatWord.Location = new System.Drawing.Point(9, 20);
            this.optFileFormatWord.Name = "optFileFormatWord";
            this.optFileFormatWord.Size = new System.Drawing.Size(51, 17);
            this.optFileFormatWord.TabIndex = 0;
            this.optFileFormatWord.TabStop = true;
            this.optFileFormatWord.Tag = "1";
            this.optFileFormatWord.Text = "Word";
            this.optFileFormatWord.UseVisualStyleBackColor = true;
            this.optFileFormatWord.CheckedChanged += new System.EventHandler(this.FileFormat_CheckedChanged);
            // 
            // pgFileName
            // 
            this.pgFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFileName.Controls.Add(this.label14);
            this.pgFileName.Controls.Add(this.label13);
            this.pgFileName.Controls.Add(this.label12);
            this.pgFileName.Controls.Add(detailsLabel);
            this.pgFileName.Controls.Add(this.txtSecondSources);
            this.pgFileName.Controls.Add(fileNameLabel);
            this.pgFileName.Controls.Add(this.detailsTextBox);
            this.pgFileName.Controls.Add(this.fileNameTextBox);
            this.pgFileName.Controls.Add(this.txtMainSource);
            this.pgFileName.Controls.Add(this.label11);
            this.pgFileName.Location = new System.Drawing.Point(4, 22);
            this.pgFileName.Name = "pgFileName";
            this.pgFileName.Padding = new System.Windows.Forms.Padding(3);
            this.pgFileName.Size = new System.Drawing.Size(465, 503);
            this.pgFileName.TabIndex = 6;
            this.pgFileName.Text = "File Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(86, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Main source(s)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(186, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "vs.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 459);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(360, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Note: Date and Time will be appended to the above file name.";
            // 
            // txtSecondSources
            // 
            this.txtSecondSources.Location = new System.Drawing.Point(183, 168);
            this.txtSecondSources.Name = "txtSecondSources";
            this.txtSecondSources.Size = new System.Drawing.Size(183, 20);
            this.txtSecondSources.TabIndex = 2;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.surveyReportBindingSource, "Details", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.detailsTextBox.Location = new System.Drawing.Point(182, 220);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(185, 20);
            this.detailsTextBox.TabIndex = 28;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.surveyReportBindingSource, "FileName", true));
            this.fileNameTextBox.Location = new System.Drawing.Point(6, 437);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.fileNameTextBox.TabIndex = 34;
            // 
            // txtMainSource
            // 
            this.txtMainSource.Location = new System.Drawing.Point(182, 119);
            this.txtMainSource.Name = "txtMainSource";
            this.txtMainSource.Size = new System.Drawing.Size(185, 20);
            this.txtMainSource.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(421, 39);
            this.label11.TabIndex = 0;
            this.label11.Text = "The following pieces of information will be part of the file name. You can also e" +
    "nter a file name which will override the defaults.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 31);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "ITC Survey Report";
            // 
            // dateBackend
            // 
            this.dateBackend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBackend.Location = new System.Drawing.Point(327, 79);
            this.dateBackend.Name = "dateBackend";
            this.dateBackend.Size = new System.Drawing.Size(119, 20);
            this.dateBackend.TabIndex = 8;
            this.dateBackend.ValueChanged += new System.EventHandler(this.dateBackend_ValueChanged);
            // 
            // lblBackend
            // 
            this.lblBackend.AutoSize = true;
            this.lblBackend.Location = new System.Drawing.Point(291, 81);
            this.lblBackend.Name = "lblBackend";
            this.lblBackend.Size = new System.Drawing.Size(30, 13);
            this.lblBackend.TabIndex = 9;
            this.lblBackend.Text = "From";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optOrderCompare);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.optLabelCompare);
            this.panel1.Controls.Add(this.optVarNameCompare);
            this.panel1.Location = new System.Drawing.Point(327, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 92);
            this.panel1.TabIndex = 56;
            // 
            // optOrderCompare
            // 
            this.optOrderCompare.AutoSize = true;
            this.optOrderCompare.Location = new System.Drawing.Point(13, 67);
            this.optOrderCompare.Name = "optOrderCompare";
            this.optOrderCompare.Size = new System.Drawing.Size(51, 17);
            this.optOrderCompare.TabIndex = 2;
            this.optOrderCompare.TabStop = true;
            this.optOrderCompare.Tag = "3";
            this.optOrderCompare.Text = "Order";
            this.optOrderCompare.UseVisualStyleBackColor = true;
            this.optOrderCompare.Visible = false;
            this.optOrderCompare.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 57;
            this.label9.Text = "Report Type";
            // 
            // optLabelCompare
            // 
            this.optLabelCompare.AutoSize = true;
            this.optLabelCompare.Location = new System.Drawing.Point(13, 45);
            this.optLabelCompare.Name = "optLabelCompare";
            this.optLabelCompare.Size = new System.Drawing.Size(94, 17);
            this.optLabelCompare.TabIndex = 1;
            this.optLabelCompare.TabStop = true;
            this.optLabelCompare.Tag = "2";
            this.optLabelCompare.Text = "Topic/Content";
            this.optLabelCompare.UseVisualStyleBackColor = true;
            this.optLabelCompare.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
            // 
            // optVarNameCompare
            // 
            this.optVarNameCompare.AutoSize = true;
            this.optVarNameCompare.Checked = true;
            this.optVarNameCompare.Location = new System.Drawing.Point(13, 22);
            this.optVarNameCompare.Name = "optVarNameCompare";
            this.optVarNameCompare.Size = new System.Drawing.Size(69, 17);
            this.optVarNameCompare.TabIndex = 0;
            this.optVarNameCompare.TabStop = true;
            this.optVarNameCompare.Tag = "1";
            this.optVarNameCompare.Text = "VarName";
            this.optVarNameCompare.UseVisualStyleBackColor = true;
            this.optVarNameCompare.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
            // 
            // cmdSelfCompare
            // 
            this.cmdSelfCompare.Location = new System.Drawing.Point(17, 130);
            this.cmdSelfCompare.Name = "cmdSelfCompare";
            this.cmdSelfCompare.Size = new System.Drawing.Size(103, 23);
            this.cmdSelfCompare.TabIndex = 58;
            this.cmdSelfCompare.Text = "Self-comparison";
            this.cmdSelfCompare.UseVisualStyleBackColor = true;
            this.cmdSelfCompare.Click += new System.EventHandler(this.SelfCompare_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(14, 738);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 60;
            this.lblStatus.Text = "lblStatus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quickReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(507, 24);
            this.menuStrip1.TabIndex = 61;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // quickReportToolStripMenuItem
            // 
            this.quickReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.standardWTranslationToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.websiteWTranslationToolStripMenuItem});
            this.quickReportToolStripMenuItem.Name = "quickReportToolStripMenuItem";
            this.quickReportToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.quickReportToolStripMenuItem.Text = "Quick Report";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // standardWTranslationToolStripMenuItem
            // 
            this.standardWTranslationToolStripMenuItem.Name = "standardWTranslationToolStripMenuItem";
            this.standardWTranslationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.standardWTranslationToolStripMenuItem.Text = "Standard w/ Translation";
            this.standardWTranslationToolStripMenuItem.Click += new System.EventHandler(this.standardWTranslationToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // websiteWTranslationToolStripMenuItem
            // 
            this.websiteWTranslationToolStripMenuItem.Name = "websiteWTranslationToolStripMenuItem";
            this.websiteWTranslationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.websiteWTranslationToolStripMenuItem.Text = "Website w/ Translation";
            this.websiteWTranslationToolStripMenuItem.Click += new System.EventHandler(this.websiteWTranslationToolStripMenuItem_Click);
            // 
            // lblCurrentSurveyFields
            // 
            this.lblCurrentSurveyFields.AutoSize = true;
            this.lblCurrentSurveyFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSurveyFields.Location = new System.Drawing.Point(26, 13);
            this.lblCurrentSurveyFields.Name = "lblCurrentSurveyFields";
            this.lblCurrentSurveyFields.Size = new System.Drawing.Size(218, 15);
            this.lblCurrentSurveyFields.TabIndex = 29;
            this.lblCurrentSurveyFields.Text = "Current Survey\'s Field Selections";
            // 
            // SurveyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(507, 776);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdSelfCompare);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBackend);
            this.Controls.Add(this.dateBackend);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.cmdCheckOptions);
            this.Controls.Add(this.lstSelectedSurveys);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SurveyReportForm";
            this.Text = "Survey Report";
            this.Load += new System.EventHandler(this.SurveyReportForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.pgFilters.ResumeLayout(false);
            this.pgFilters.PerformLayout();
            this.pgFields.ResumeLayout(false);
            this.pgFields.PerformLayout();
            this.panelOtherFields.ResumeLayout(false);
            this.panelOtherFields.PerformLayout();
            this.panelCommentFilters.ResumeLayout(false);
            this.panelCommentFilters.PerformLayout();
            this.pgCompare.ResumeLayout(false);
            this.groupLayoutOptions.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).EndInit();
            this.groupHighlightOptions.ResumeLayout(false);
            this.flowHighlightOptions.ResumeLayout(false);
            this.groupHighlightStyle.ResumeLayout(false);
            this.groupHighlightStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).EndInit();
            this.pgOrder.ResumeLayout(false);
            this.pgOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQnumSurvey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumnOrder)).EndInit();
            this.groupEnumeration.ResumeLayout(false);
            this.groupEnumeration.PerformLayout();
            this.pgFormatting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pgOutput.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupNRFormat.ResumeLayout(false);
            this.groupNRFormat.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupToC.ResumeLayout(false);
            this.groupToC.PerformLayout();
            this.groupFileFormat.ResumeLayout(false);
            this.groupFileFormat.PerformLayout();
            this.pgFileName.ResumeLayout(false);
            this.pgFileName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.Button cmdRemoveSurvey;
        private System.Windows.Forms.ListBox lstSelectedSurveys;
        private System.Windows.Forms.Button cmdCheckOptions;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage pgFilters;
        private System.Windows.Forms.TabPage pgFields;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage pgCompare;
        private System.Windows.Forms.TabPage pgOrder;
        private System.Windows.Forms.TabPage pgFormatting;
        private System.Windows.Forms.DateTimePicker dateBackend;
        private System.Windows.Forms.Label lblBackend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQrangeHigh;
        private System.Windows.Forms.TextBox txtQrangeLow;
        private System.Windows.Forms.Label lblQuestionRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRemovePrefix;
        private System.Windows.Forms.Button cmdAddPrefix;
        private System.Windows.Forms.ComboBox cboPrefixes;
        private System.Windows.Forms.ListBox lstPrefixes;
        private System.Windows.Forms.Label lblVarNames;
        private System.Windows.Forms.ComboBox cboVarNames;
        private System.Windows.Forms.ListBox lstSelectedVarNames;
        private System.Windows.Forms.Button cmdRemoveVarName;
        private System.Windows.Forms.Button cmdAddVarName;
        private System.Windows.Forms.Button cmdToggleExtraFields;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCommentFields;
        private System.Windows.Forms.DateTimePicker dateTimeCommentsSince;
        private System.Windows.Forms.ListBox lstCommentSources;
        private System.Windows.Forms.ListBox lstCommentAuthors;
        private System.Windows.Forms.ListBox lstCommentFields;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkVarLabelCol;
        private System.Windows.Forms.CheckBox chkFilterCol;
        private System.Windows.Forms.Label lblTransFields;
        private System.Windows.Forms.CheckBox chkCorrected;
        private System.Windows.Forms.ListBox lstTransFields;
        private System.Windows.Forms.DataGridView gridPrimarySurvey;
        private System.Windows.Forms.GroupBox groupHighlightOptions;
        private System.Windows.Forms.FlowLayoutPanel flowHighlightOptions;
        private System.Windows.Forms.GroupBox groupHighlightStyle;
        private System.Windows.Forms.ComboBox cboHighlightScheme;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox aQNInsertionCheckBox;
        private System.Windows.Forms.CheckBox cCInsertionCheckBox;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.CheckBox excludeTempChangesCheckBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.CheckBox inlineRoutingCheckBox;
        private System.Windows.Forms.CheckBox semiTelCheckBox;
        private System.Windows.Forms.CheckBox chkShowAllQnums;
        private System.Windows.Forms.CheckBox survNotesCheckBox;
        private System.Windows.Forms.CheckBox chkTableFormat;
        private System.Windows.Forms.CheckBox chkTranslationTableFormat;
        private System.Windows.Forms.CheckBox varChangesAppCheckBox;
        private System.Windows.Forms.CheckBox varChangesColCheckBox;
        private System.Windows.Forms.CheckBox webCheckBox;
        private System.Windows.Forms.GroupBox groupLayoutOptions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupEnumeration;
        private System.Windows.Forms.RadioButton optQnumAltQnum;
        private System.Windows.Forms.RadioButton optAltQnumOnly;
        private System.Windows.Forms.RadioButton optQnumOnly;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox repeatedHeadingsCheckBox;
        private System.Windows.Forms.CheckBox qNInsertionCheckBox;
        private System.Windows.Forms.CheckBox colorSubsCheckBox;
        private System.Windows.Forms.CheckBox showLongListsCheckBox;
        private System.Windows.Forms.Label lblOrderOptions;
        private System.Windows.Forms.TabPage pgOutput;
        private System.Windows.Forms.TabPage pgFileName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupNRFormat;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupToC;
        private System.Windows.Forms.RadioButton optToCPgNum;
        private System.Windows.Forms.RadioButton optToCQnum;
        private System.Windows.Forms.RadioButton optToCNone;
        private System.Windows.Forms.GroupBox groupFileFormat;
        private System.Windows.Forms.RadioButton optFileFormatPDF;
        private System.Windows.Forms.RadioButton optFileFormatWord;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton optNRFormatDontReadOut;
        private System.Windows.Forms.RadioButton optNRFormatDontRead;
        private System.Windows.Forms.RadioButton optNRFormatNeither;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSecondSources;
        private System.Windows.Forms.TextBox txtMainSource;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox beforeAfterReportCheckBox;
        private System.Windows.Forms.CheckBox bySectionCheckBox;
        private System.Windows.Forms.CheckBox convertTrackedChangesCheckBox;
        private System.Windows.Forms.CheckBox chkCompare;
        private System.Windows.Forms.CheckBox hideIdenticalWordingsCheckBox;
        private System.Windows.Forms.CheckBox hidePrimaryCheckBox;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.CheckBox highlightNRCheckBox;
        private System.Windows.Forms.CheckBox hybridHighlightCheckBox;
        private System.Windows.Forms.CheckBox ignoreSimilarWordsCheckBox;
        private System.Windows.Forms.CheckBox includeWordingsCheckBox;
        private System.Windows.Forms.CheckBox chkMatchOnRename;
        private System.Windows.Forms.CheckBox chkReInsertDeletions;
        private System.Windows.Forms.CheckBox showDeletedFieldsCheckBox;
        private System.Windows.Forms.CheckBox chkShowDeletedQuestions;
        private System.Windows.Forms.CheckBox showOrderChangesCheckBox;
        private System.Windows.Forms.BindingSource surveyReportBindingSource;
        private System.Windows.Forms.Label lblPrimarySurvey;
        private System.Windows.Forms.DataGridView gridColumnOrder;
        private System.Windows.Forms.CheckBox chkTopicCol;
        private System.Windows.Forms.CheckBox chkContentCol;
        private System.Windows.Forms.CheckBox chkProductCol;
        private System.Windows.Forms.CheckBox chkDomainCol;
        private System.Windows.Forms.DataGridView gridQnumSurvey;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstStdFields;
        private System.Windows.Forms.Panel panelCommentFilters;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelOtherFields;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstRepeatedFields;
        private System.Windows.Forms.CheckBox chkShowRepeatedFields;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optOrderCompare;
        private System.Windows.Forms.RadioButton optLabelCompare;
        private System.Windows.Forms.RadioButton optVarNameCompare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstHeadings;
        private System.Windows.Forms.Button cmdRemoveHeading;
        private System.Windows.Forms.Button cmdAddHeading;
        private System.Windows.Forms.ComboBox cboHeadings;
        private System.Windows.Forms.Button cmdSelfCompare;
        private System.Windows.Forms.ToolTip toolTipStandard;
        private System.Windows.Forms.ToolTip toolTipStandardT;
        private System.Windows.Forms.ToolTip toolTipWeb;
        private System.Windows.Forms.ToolTip toolTipWebT;
        private System.Windows.Forms.CheckBox chkAltQNum3Col;
        private System.Windows.Forms.CheckBox chkAltQNum2Col;
        private System.Windows.Forms.CheckBox chkBlankCol;
        private System.Windows.Forms.BindingSource compareBindingSource;
        private System.Windows.Forms.CheckBox chkCoverPage;
        private System.Windows.Forms.BindingSource reportLayoutBindingSource;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkHideIdenticalQs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardWTranslationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteWTranslationToolStripMenuItem;
        private System.Windows.Forms.Label lblCurrentSurveyFields;
    }
}

