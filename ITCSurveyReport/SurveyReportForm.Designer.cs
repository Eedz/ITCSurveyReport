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
            this.label8 = new System.Windows.Forms.Label();
            this.chkProductCol = new System.Windows.Forms.CheckBox();
            this.chkDomainCol = new System.Windows.Forms.CheckBox();
            this.chkContentCol = new System.Windows.Forms.CheckBox();
            this.chkTopicCol = new System.Windows.Forms.CheckBox();
            this.chkBlankCol = new System.Windows.Forms.CheckBox();
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
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.hidePrimaryCheckBox = new System.Windows.Forms.CheckBox();
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
            this.doCompareCheckBox = new System.Windows.Forms.CheckBox();
            this.matchOnRenameCheckBox = new System.Windows.Forms.CheckBox();
            this.pgOrder = new System.Windows.Forms.TabPage();
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkTranslationTableFormat = new System.Windows.Forms.CheckBox();
            this.pgOutput = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.checkTablesCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.webCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.coverPageCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.survNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesColCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesAppCheckBox = new System.Windows.Forms.CheckBox();
            this.excludeTempChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.optNRFormatDontReadOut = new System.Windows.Forms.RadioButton();
            this.optNRFormatDontRead = new System.Windows.Forms.RadioButton();
            this.optNRFormatNeither = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.optToCPgNum = new System.Windows.Forms.RadioButton();
            this.optToCQnum = new System.Windows.Forms.RadioButton();
            this.optToCNone = new System.Windows.Forms.RadioButton();
            this.groupFileFormat = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.pgFileName = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateBackend = new System.Windows.Forms.DateTimePicker();
            this.lblBackend = new System.Windows.Forms.Label();
            this.surveyView = new System.Windows.Forms.DataGridView();
            this.surveyView2 = new System.Windows.Forms.DataGridView();
            this.gridFinalReport = new System.Windows.Forms.DataGridView();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optOrderCompare = new System.Windows.Forms.RadioButton();
            this.optLabelCompare = new System.Windows.Forms.RadioButton();
            this.optVarNameCompare = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.surveyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            detailsLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.pgFilters.SuspendLayout();
            this.pgFields.SuspendLayout();
            this.panelOtherFields.SuspendLayout();
            this.panelCommentFilters.SuspendLayout();
            this.pgCompare.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupHighlightOptions.SuspendLayout();
            this.flowHighlightOptions.SuspendLayout();
            this.groupHighlightStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).BeginInit();
            this.pgOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQnumSurvey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumnOrder)).BeginInit();
            this.groupEnumeration.SuspendLayout();
            this.pgFormatting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pgOutput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupFileFormat.SuspendLayout();
            this.pgFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinalReport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).BeginInit();
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
            this.cboSurveys.Location = new System.Drawing.Point(8, 65);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(108, 21);
            this.cboSurveys.TabIndex = 0;
            this.cboSurveys.ValueMember = "Survey";
            this.cboSurveys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Surveys_KeyDown);
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(122, 64);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(39, 20);
            this.cmdAddSurvey.TabIndex = 1;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.AddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(122, 90);
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
            this.lstSelectedSurveys.Location = new System.Drawing.Point(167, 64);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(114, 95);
            this.lstSelectedSurveys.TabIndex = 3;
            this.lstSelectedSurveys.ValueMember = "ID";
            this.lstSelectedSurveys.SelectedIndexChanged += new System.EventHandler(this.SelectedSurveys_SelectedIndexChanged);
            // 
            // cmdCheckOptions
            // 
            this.cmdCheckOptions.Location = new System.Drawing.Point(488, 126);
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
            this.tabControlOptions.Location = new System.Drawing.Point(8, 165);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(473, 529);
            this.tabControlOptions.TabIndex = 5;
            this.tabControlOptions.Visible = false;
            // 
            // pgFilters
            // 
            this.pgFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
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
            // lstSelectedVarNames
            // 
            this.lstSelectedVarNames.FormattingEnabled = true;
            this.lstSelectedVarNames.Location = new System.Drawing.Point(121, 228);
            this.lstSelectedVarNames.Name = "lstSelectedVarNames";
            this.lstSelectedVarNames.Size = new System.Drawing.Size(101, 108);
            this.lstSelectedVarNames.TabIndex = 13;
            // 
            // cmdRemoveVarName
            // 
            this.cmdRemoveVarName.Location = new System.Drawing.Point(88, 258);
            this.cmdRemoveVarName.Name = "cmdRemoveVarName";
            this.cmdRemoveVarName.Size = new System.Drawing.Size(30, 26);
            this.cmdRemoveVarName.TabIndex = 12;
            this.cmdRemoveVarName.Text = "<-";
            this.cmdRemoveVarName.UseVisualStyleBackColor = true;
            this.cmdRemoveVarName.Click += new System.EventHandler(this.RemoveVarName_Click);
            // 
            // cmdAddVarName
            // 
            this.cmdAddVarName.Location = new System.Drawing.Point(89, 228);
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
            this.lblVarNames.Location = new System.Drawing.Point(20, 205);
            this.lblVarNames.Name = "lblVarNames";
            this.lblVarNames.Size = new System.Drawing.Size(56, 13);
            this.lblVarNames.TabIndex = 10;
            this.lblVarNames.Text = "VarNames";
            // 
            // cboVarNames
            // 
            this.cboVarNames.FormattingEnabled = true;
            this.cboVarNames.Location = new System.Drawing.Point(20, 226);
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
            this.lstPrefixes.Size = new System.Drawing.Size(101, 95);
            this.lstPrefixes.TabIndex = 0;
            // 
            // pgFields
            // 
            this.pgFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
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
            this.panelOtherFields.Controls.Add(this.label8);
            this.panelOtherFields.Controls.Add(this.chkProductCol);
            this.panelOtherFields.Controls.Add(this.chkDomainCol);
            this.panelOtherFields.Controls.Add(this.chkContentCol);
            this.panelOtherFields.Controls.Add(this.chkTopicCol);
            this.panelOtherFields.Controls.Add(this.chkBlankCol);
            this.panelOtherFields.Controls.Add(this.chkVarLabelCol);
            this.panelOtherFields.Controls.Add(this.chkFilterCol);
            this.panelOtherFields.Location = new System.Drawing.Point(163, 158);
            this.panelOtherFields.Name = "panelOtherFields";
            this.panelOtherFields.Size = new System.Drawing.Size(142, 248);
            this.panelOtherFields.TabIndex = 28;
            this.panelOtherFields.Visible = false;
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
            this.chkProductCol.Location = new System.Drawing.Point(2, 173);
            this.chkProductCol.Name = "chkProductCol";
            this.chkProductCol.Size = new System.Drawing.Size(130, 17);
            this.chkProductCol.TabIndex = 25;
            this.chkProductCol.Text = "Product Label Column";
            this.chkProductCol.UseVisualStyleBackColor = true;
            this.chkProductCol.CheckedChanged += new System.EventHandler(this.ProductCol_CheckedChanged);
            // 
            // chkDomainCol
            // 
            this.chkDomainCol.AutoSize = true;
            this.chkDomainCol.Location = new System.Drawing.Point(2, 81);
            this.chkDomainCol.Name = "chkDomainCol";
            this.chkDomainCol.Size = new System.Drawing.Size(129, 17);
            this.chkDomainCol.TabIndex = 24;
            this.chkDomainCol.Text = "Domain Label Column";
            this.chkDomainCol.UseVisualStyleBackColor = true;
            this.chkDomainCol.CheckedChanged += new System.EventHandler(this.DomainCol_CheckedChanged);
            // 
            // chkContentCol
            // 
            this.chkContentCol.AutoSize = true;
            this.chkContentCol.Location = new System.Drawing.Point(2, 127);
            this.chkContentCol.Name = "chkContentCol";
            this.chkContentCol.Size = new System.Drawing.Size(130, 17);
            this.chkContentCol.TabIndex = 23;
            this.chkContentCol.Text = "Content Label Column";
            this.chkContentCol.UseVisualStyleBackColor = true;
            this.chkContentCol.CheckedChanged += new System.EventHandler(this.ContentCol_CheckedChanged);
            // 
            // chkTopicCol
            // 
            this.chkTopicCol.AutoSize = true;
            this.chkTopicCol.Location = new System.Drawing.Point(2, 104);
            this.chkTopicCol.Name = "chkTopicCol";
            this.chkTopicCol.Size = new System.Drawing.Size(120, 17);
            this.chkTopicCol.TabIndex = 22;
            this.chkTopicCol.Text = "Topic Label Column";
            this.chkTopicCol.UseVisualStyleBackColor = true;
            this.chkTopicCol.CheckedChanged += new System.EventHandler(this.TopicCol_CheckedChanged);
            // 
            // chkBlankCol
            // 
            this.chkBlankCol.Location = new System.Drawing.Point(2, 33);
            this.chkBlankCol.Margin = new System.Windows.Forms.Padding(0);
            this.chkBlankCol.Name = "chkBlankCol";
            this.chkBlankCol.Padding = new System.Windows.Forms.Padding(1);
            this.chkBlankCol.Size = new System.Drawing.Size(104, 17);
            this.chkBlankCol.TabIndex = 11;
            this.chkBlankCol.Text = "Blank Column";
            this.chkBlankCol.UseVisualStyleBackColor = true;
            this.chkBlankCol.CheckedChanged += new System.EventHandler(this.BlankCol_CheckedChanged);
            // 
            // chkVarLabelCol
            // 
            this.chkVarLabelCol.AutoSize = true;
            this.chkVarLabelCol.Location = new System.Drawing.Point(2, 150);
            this.chkVarLabelCol.Name = "chkVarLabelCol";
            this.chkVarLabelCol.Size = new System.Drawing.Size(106, 17);
            this.chkVarLabelCol.TabIndex = 17;
            this.chkVarLabelCol.Text = "VarLabel Column";
            this.chkVarLabelCol.UseVisualStyleBackColor = true;
            this.chkVarLabelCol.CheckedChanged += new System.EventHandler(this.VarLabelCol_CheckedChanged);
            // 
            // chkFilterCol
            // 
            this.chkFilterCol.AutoSize = true;
            this.chkFilterCol.Location = new System.Drawing.Point(2, 58);
            this.chkFilterCol.Name = "chkFilterCol";
            this.chkFilterCol.Size = new System.Drawing.Size(86, 17);
            this.chkFilterCol.TabIndex = 16;
            this.chkFilterCol.Text = "Filter Column";
            this.chkFilterCol.UseVisualStyleBackColor = true;
            this.chkFilterCol.CheckedChanged += new System.EventHandler(this.FilterCol_CheckedChanged);
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
            this.panelCommentFilters.Location = new System.Drawing.Point(308, 158);
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
            this.label2.Location = new System.Drawing.Point(7, 14);
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
            this.lstStdFields.Location = new System.Drawing.Point(10, 30);
            this.lstStdFields.Name = "lstStdFields";
            this.lstStdFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStdFields.Size = new System.Drawing.Size(72, 108);
            this.lstStdFields.TabIndex = 10;
            this.lstStdFields.Click += new System.EventHandler(this.StdFields_Click);
            // 
            // chkCorrected
            // 
            this.chkCorrected.AutoSize = true;
            this.chkCorrected.Location = new System.Drawing.Point(10, 144);
            this.chkCorrected.Name = "chkCorrected";
            this.chkCorrected.Size = new System.Drawing.Size(142, 17);
            this.chkCorrected.TabIndex = 18;
            this.chkCorrected.Text = "Use Corrected Wordings";
            this.chkCorrected.UseVisualStyleBackColor = true;
            this.chkCorrected.CheckedChanged += new System.EventHandler(this.CorrectedWordings_CheckedChanged);
            // 
            // lblTransFields
            // 
            this.lblTransFields.AutoSize = true;
            this.lblTransFields.Location = new System.Drawing.Point(162, 28);
            this.lblTransFields.Name = "lblTransFields";
            this.lblTransFields.Size = new System.Drawing.Size(89, 13);
            this.lblTransFields.TabIndex = 15;
            this.lblTransFields.Text = "Translation Fields";
            this.lblTransFields.Visible = false;
            // 
            // lstTransFields
            // 
            this.lstTransFields.FormattingEnabled = true;
            this.lstTransFields.Location = new System.Drawing.Point(164, 44);
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
            this.lblCommentFields.Location = new System.Drawing.Point(305, 28);
            this.lblCommentFields.Name = "lblCommentFields";
            this.lblCommentFields.Size = new System.Drawing.Size(81, 13);
            this.lblCommentFields.TabIndex = 7;
            this.lblCommentFields.Text = "Comment Fields";
            this.lblCommentFields.Visible = false;
            // 
            // lstCommentFields
            // 
            this.lstCommentFields.FormattingEnabled = true;
            this.lstCommentFields.Location = new System.Drawing.Point(308, 44);
            this.lstCommentFields.Name = "lstCommentFields";
            this.lstCommentFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCommentFields.Size = new System.Drawing.Size(118, 108);
            this.lstCommentFields.TabIndex = 2;
            this.lstCommentFields.Visible = false;
            this.lstCommentFields.Click += new System.EventHandler(this.CommentFields_Click);
            // 
            // cmdToggleExtraFields
            // 
            this.cmdToggleExtraFields.Location = new System.Drawing.Point(163, 8);
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
            this.pgCompare.Controls.Add(this.label15);
            this.pgCompare.Controls.Add(this.groupBox1);
            this.pgCompare.Controls.Add(this.groupHighlightOptions);
            this.pgCompare.Controls.Add(this.gridPrimarySurvey);
            this.pgCompare.Controls.Add(this.doCompareCheckBox);
            this.pgCompare.Controls.Add(this.matchOnRenameCheckBox);
            this.pgCompare.Location = new System.Drawing.Point(4, 22);
            this.pgCompare.Name = "pgCompare";
            this.pgCompare.Size = new System.Drawing.Size(465, 503);
            this.pgCompare.TabIndex = 2;
            this.pgCompare.Text = "Comparison";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(14, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 47);
            this.label15.TabIndex = 118;
            this.label15.Text = "All other surveys will be compared to the reference survey. Surveys not selected " +
    "will contain highlighting.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(253, 344);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(191, 88);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layout Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.hidePrimaryCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.hideIdenticalWordingsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.beforeAfterReportCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 18);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // hidePrimaryCheckBox
            // 
            this.hidePrimaryCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.HidePrimary", true));
            this.hidePrimaryCheckBox.Location = new System.Drawing.Point(1, 1);
            this.hidePrimaryCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.hidePrimaryCheckBox.Name = "hidePrimaryCheckBox";
            this.hidePrimaryCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.hidePrimaryCheckBox.Size = new System.Drawing.Size(141, 20);
            this.hidePrimaryCheckBox.TabIndex = 25;
            this.hidePrimaryCheckBox.Text = "Hide Reference Survey";
            this.hidePrimaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // hideIdenticalWordingsCheckBox
            // 
            this.hideIdenticalWordingsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.HideIdenticalWordings", true));
            this.hideIdenticalWordingsCheckBox.Location = new System.Drawing.Point(1, 21);
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
            this.beforeAfterReportCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.BeforeAfterReport", true));
            this.beforeAfterReportCheckBox.Location = new System.Drawing.Point(1, 41);
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
            this.highlightNRCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.HighlightNR", true));
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
            this.ignoreSimilarWordsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.IgnoreSimilarWords", true));
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
            this.hybridHighlightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.HybridHighlight", true));
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
            this.showDeletedFieldsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.ShowDeletedFields", true));
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
            this.chkShowDeletedQuestions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.ShowDeletedQuestions", true));
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
            this.chkReInsertDeletions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.ReInsertDeletions", true));
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
            this.showOrderChangesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.ShowOrderChanges", true));
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
            this.convertTrackedChangesCheckBox.Location = new System.Drawing.Point(30, 64);
            this.convertTrackedChangesCheckBox.Name = "convertTrackedChangesCheckBox";
            this.convertTrackedChangesCheckBox.Size = new System.Drawing.Size(85, 20);
            this.convertTrackedChangesCheckBox.TabIndex = 19;
            this.convertTrackedChangesCheckBox.Text = "Real TC";
            this.convertTrackedChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.Highlight", true));
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
            this.gridPrimarySurvey.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrimarySurvey_CellValueChanged);
            this.gridPrimarySurvey.CurrentCellDirtyStateChanged += new System.EventHandler(this.PrimarySurvey_CurrentCellDirtyStateChanged);
            this.gridPrimarySurvey.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PrimarySurvey_DataBindingComplete);
            // 
            // doCompareCheckBox
            // 
            this.doCompareCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "Compare", true));
            this.doCompareCheckBox.Location = new System.Drawing.Point(13, 26);
            this.doCompareCheckBox.Name = "doCompareCheckBox";
            this.doCompareCheckBox.Size = new System.Drawing.Size(104, 24);
            this.doCompareCheckBox.TabIndex = 21;
            this.doCompareCheckBox.Text = "Compare?";
            this.doCompareCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchOnRenameCheckBox
            // 
            this.matchOnRenameCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "SurveyCompare.MatchOnRename", true));
            this.matchOnRenameCheckBox.Location = new System.Drawing.Point(13, 294);
            this.matchOnRenameCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.matchOnRenameCheckBox.Name = "matchOnRenameCheckBox";
            this.matchOnRenameCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.matchOnRenameCheckBox.Size = new System.Drawing.Size(196, 20);
            this.matchOnRenameCheckBox.TabIndex = 41;
            this.matchOnRenameCheckBox.Text = "Match variables on previous names";
            this.matchOnRenameCheckBox.UseVisualStyleBackColor = true;
            // 
            // pgOrder
            // 
            this.pgOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgOrder.Controls.Add(this.gridQnumSurvey);
            this.pgOrder.Controls.Add(this.gridColumnOrder);
            this.pgOrder.Controls.Add(this.groupEnumeration);
            this.pgOrder.Location = new System.Drawing.Point(4, 22);
            this.pgOrder.Name = "pgOrder";
            this.pgOrder.Size = new System.Drawing.Size(465, 503);
            this.pgOrder.TabIndex = 3;
            this.pgOrder.Text = "Order and Numbering";
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
            this.chkShowAllQnums.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "ShowAllQnums", true));
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
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
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
            this.chkTableFormat.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "Tables", true));
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "Order Comparisons";
            // 
            // chkTranslationTableFormat
            // 
            this.chkTranslationTableFormat.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "TablesTranslation", true));
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
            this.groupBox4.Controls.Add(this.flowLayoutPanel4);
            this.groupBox4.Controls.Add(this.flowLayoutPanel3);
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupFileFormat);
            this.groupBox4.Location = new System.Drawing.Point(15, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(349, 451);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Options";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel4.Controls.Add(this.checkOrderCheckBox);
            this.flowLayoutPanel4.Controls.Add(this.checkTablesCheckBox);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(188, 341);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(116, 104);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // checkOrderCheckBox
            // 
            this.checkOrderCheckBox.Location = new System.Drawing.Point(1, 1);
            this.checkOrderCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.checkOrderCheckBox.Name = "checkOrderCheckBox";
            this.checkOrderCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.checkOrderCheckBox.Size = new System.Drawing.Size(104, 24);
            this.checkOrderCheckBox.TabIndex = 16;
            this.checkOrderCheckBox.Text = "Check Order";
            this.checkOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkTablesCheckBox
            // 
            this.checkTablesCheckBox.Location = new System.Drawing.Point(1, 25);
            this.checkTablesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.checkTablesCheckBox.Name = "checkTablesCheckBox";
            this.checkTablesCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.checkTablesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.checkTablesCheckBox.TabIndex = 18;
            this.checkTablesCheckBox.Text = "Check Tables";
            this.checkTablesCheckBox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Controls.Add(this.webCheckBox);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.coverPageCheckBox);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(43, 341);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(129, 104);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // webCheckBox
            // 
            this.webCheckBox.Location = new System.Drawing.Point(1, 1);
            this.webCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.webCheckBox.Name = "webCheckBox";
            this.webCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.webCheckBox.Size = new System.Drawing.Size(104, 24);
            this.webCheckBox.TabIndex = 70;
            this.webCheckBox.Text = "Web Output";
            this.webCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(1);
            this.label10.Size = new System.Drawing.Size(119, 41);
            this.label10.TabIndex = 71;
            this.label10.Text = "Includes PDF format, Cover Page with mode and Web file name";
            // 
            // coverPageCheckBox
            // 
            this.coverPageCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.surveyReportBindingSource, "LayoutOptions.CoverPage", true));
            this.coverPageCheckBox.Location = new System.Drawing.Point(1, 66);
            this.coverPageCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.coverPageCheckBox.Name = "coverPageCheckBox";
            this.coverPageCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.coverPageCheckBox.Size = new System.Drawing.Size(104, 24);
            this.coverPageCheckBox.TabIndex = 13;
            this.coverPageCheckBox.Text = "CoverPage";
            this.coverPageCheckBox.UseVisualStyleBackColor = true;
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.optNRFormatDontReadOut);
            this.groupBox8.Controls.Add(this.optNRFormatDontRead);
            this.groupBox8.Controls.Add(this.optNRFormatNeither);
            this.groupBox8.Location = new System.Drawing.Point(173, 127);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(131, 101);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "NR Format";
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.optToCPgNum);
            this.groupBox6.Controls.Add(this.optToCQnum);
            this.groupBox6.Controls.Add(this.optToCNone);
            this.groupBox6.Location = new System.Drawing.Point(173, 35);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(131, 88);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Table of Contents";
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
            this.groupFileFormat.Controls.Add(this.radioButton7);
            this.groupFileFormat.Controls.Add(this.radioButton6);
            this.groupFileFormat.Location = new System.Drawing.Point(43, 35);
            this.groupFileFormat.Name = "groupFileFormat";
            this.groupFileFormat.Size = new System.Drawing.Size(95, 88);
            this.groupFileFormat.TabIndex = 0;
            this.groupFileFormat.TabStop = false;
            this.groupFileFormat.Text = "File Format";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(9, 39);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(46, 17);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.Tag = "2";
            this.radioButton7.Text = "PDF";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.FileFormat_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(9, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(51, 17);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Tag = "1";
            this.radioButton6.Text = "Word";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.FileFormat_CheckedChanged);
            // 
            // pgFileName
            // 
            this.pgFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFileName.Controls.Add(this.label14);
            this.pgFileName.Controls.Add(this.label13);
            this.pgFileName.Controls.Add(this.label12);
            this.pgFileName.Controls.Add(detailsLabel);
            this.pgFileName.Controls.Add(this.textBox2);
            this.pgFileName.Controls.Add(fileNameLabel);
            this.pgFileName.Controls.Add(this.detailsTextBox);
            this.pgFileName.Controls.Add(this.fileNameTextBox);
            this.pgFileName.Controls.Add(this.textBox1);
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(183, 168);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 20);
            this.textBox2.TabIndex = 2;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(182, 220);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(185, 20);
            this.detailsTextBox.TabIndex = 28;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(6, 437);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.fileNameTextBox.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 1;
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
            this.lblTitle.Location = new System.Drawing.Point(66, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 31);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "ITC Survey Report";
            // 
            // dateBackend
            // 
            this.dateBackend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBackend.Location = new System.Drawing.Point(337, 66);
            this.dateBackend.Name = "dateBackend";
            this.dateBackend.Size = new System.Drawing.Size(119, 20);
            this.dateBackend.TabIndex = 8;
            // 
            // lblBackend
            // 
            this.lblBackend.AutoSize = true;
            this.lblBackend.Location = new System.Drawing.Point(301, 68);
            this.lblBackend.Name = "lblBackend";
            this.lblBackend.Size = new System.Drawing.Size(30, 13);
            this.lblBackend.TabIndex = 9;
            this.lblBackend.Text = "From";
            // 
            // surveyView
            // 
            this.surveyView.AllowUserToAddRows = false;
            this.surveyView.AllowUserToDeleteRows = false;
            this.surveyView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveyView.Location = new System.Drawing.Point(488, 186);
            this.surveyView.Name = "surveyView";
            this.surveyView.ReadOnly = true;
            this.surveyView.RowHeadersVisible = false;
            this.surveyView.Size = new System.Drawing.Size(318, 219);
            this.surveyView.TabIndex = 52;
            // 
            // surveyView2
            // 
            this.surveyView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveyView2.Location = new System.Drawing.Point(488, 423);
            this.surveyView2.Name = "surveyView2";
            this.surveyView2.Size = new System.Drawing.Size(318, 271);
            this.surveyView2.TabIndex = 53;
            // 
            // gridFinalReport
            // 
            this.gridFinalReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFinalReport.Location = new System.Drawing.Point(820, 186);
            this.gridFinalReport.Name = "gridFinalReport";
            this.gridFinalReport.Size = new System.Drawing.Size(277, 364);
            this.gridFinalReport.TabIndex = 54;
            // 
            // txtOptions
            // 
            this.txtOptions.Location = new System.Drawing.Point(642, 19);
            this.txtOptions.Multiline = true;
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOptions.Size = new System.Drawing.Size(454, 155);
            this.txtOptions.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optOrderCompare);
            this.panel1.Controls.Add(this.optLabelCompare);
            this.panel1.Controls.Add(this.optVarNameCompare);
            this.panel1.Location = new System.Drawing.Point(493, 23);
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
            this.optOrderCompare.CheckedChanged += new System.EventHandler(this.ReportType_CheckedChanged);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(503, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Report Type";
            // 
            // surveyReportBindingSource
            // 
            this.surveyReportBindingSource.DataSource = typeof(ITCSurveyReport.SurveyReport);
            // 
            // SurveyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1136, 714);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtOptions);
            this.Controls.Add(this.gridFinalReport);
            this.Controls.Add(this.surveyView2);
            this.Controls.Add(this.surveyView);
            this.Controls.Add(this.lblBackend);
            this.Controls.Add(this.dateBackend);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.cmdCheckOptions);
            this.Controls.Add(this.lstSelectedSurveys);
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
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupHighlightOptions.ResumeLayout(false);
            this.flowHighlightOptions.ResumeLayout(false);
            this.groupHighlightStyle.ResumeLayout(false);
            this.groupHighlightStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).EndInit();
            this.pgOrder.ResumeLayout(false);
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
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupFileFormat.ResumeLayout(false);
            this.groupFileFormat.PerformLayout();
            this.pgFileName.ResumeLayout(false);
            this.pgFileName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinalReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).EndInit();
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
        private System.Windows.Forms.CheckBox checkOrderCheckBox;
        private System.Windows.Forms.CheckBox checkTablesCheckBox;
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
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage pgOutput;
        private System.Windows.Forms.TabPage pgFileName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton optToCPgNum;
        private System.Windows.Forms.RadioButton optToCQnum;
        private System.Windows.Forms.RadioButton optToCNone;
        private System.Windows.Forms.GroupBox groupFileFormat;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkBlankCol;
        private System.Windows.Forms.CheckBox coverPageCheckBox;
        private System.Windows.Forms.CheckBox beforeAfterReportCheckBox;
        private System.Windows.Forms.CheckBox bySectionCheckBox;
        private System.Windows.Forms.CheckBox convertTrackedChangesCheckBox;
        private System.Windows.Forms.CheckBox doCompareCheckBox;
        private System.Windows.Forms.CheckBox hideIdenticalWordingsCheckBox;
        private System.Windows.Forms.CheckBox hidePrimaryCheckBox;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.CheckBox highlightNRCheckBox;
        private System.Windows.Forms.CheckBox hybridHighlightCheckBox;
        private System.Windows.Forms.CheckBox ignoreSimilarWordsCheckBox;
        private System.Windows.Forms.CheckBox includeWordingsCheckBox;
        private System.Windows.Forms.CheckBox matchOnRenameCheckBox;
        private System.Windows.Forms.CheckBox chkReInsertDeletions;
        private System.Windows.Forms.CheckBox showDeletedFieldsCheckBox;
        private System.Windows.Forms.CheckBox chkShowDeletedQuestions;
        private System.Windows.Forms.CheckBox showOrderChangesCheckBox;
        private System.Windows.Forms.DataGridView surveyView;
        private System.Windows.Forms.BindingSource surveyReportBindingSource;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView gridColumnOrder;
        private System.Windows.Forms.CheckBox chkTopicCol;
        private System.Windows.Forms.CheckBox chkContentCol;
        private System.Windows.Forms.CheckBox chkProductCol;
        private System.Windows.Forms.CheckBox chkDomainCol;
        private System.Windows.Forms.DataGridView gridQnumSurvey;
        private System.Windows.Forms.DataGridView surveyView2;
        private System.Windows.Forms.DataGridView gridFinalReport;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstStdFields;
        private System.Windows.Forms.Panel panelCommentFilters;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelOtherFields;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOptions;
        private System.Windows.Forms.ListBox lstRepeatedFields;
        private System.Windows.Forms.CheckBox chkShowRepeatedFields;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optOrderCompare;
        private System.Windows.Forms.RadioButton optLabelCompare;
        private System.Windows.Forms.RadioButton optVarNameCompare;
        private System.Windows.Forms.Label label9;
    }
}

