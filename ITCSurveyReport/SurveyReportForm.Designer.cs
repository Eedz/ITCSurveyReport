namespace ITCSurveyReport
{
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
            System.Windows.Forms.Label blankColumnLabel;
            System.Windows.Forms.Label coverPageLabel;
            System.Windows.Forms.Label beforeAfterReportLabel;
            System.Windows.Forms.Label bySectionLabel;
            System.Windows.Forms.Label convertTrackedChangesLabel;
            System.Windows.Forms.Label doCompareLabel;
            System.Windows.Forms.Label hideIdenticalWordingsLabel;
            System.Windows.Forms.Label hidePrimaryLabel;
            System.Windows.Forms.Label highlightLabel;
            System.Windows.Forms.Label highlightNRLabel;
            System.Windows.Forms.Label highlightSchemeLabel;
            System.Windows.Forms.Label highlightStyleLabel;
            System.Windows.Forms.Label hybridHighlightLabel;
            System.Windows.Forms.Label ignoreSimilarWordsLabel;
            System.Windows.Forms.Label includeWordingsLabel;
            System.Windows.Forms.Label matchOnRenameLabel;
            System.Windows.Forms.Label reInsertDeletionsLabel;
            System.Windows.Forms.Label selfCompareLabel;
            System.Windows.Forms.Label showDeletedFieldsLabel;
            System.Windows.Forms.Label showDeletedQuestionsLabel;
            System.Windows.Forms.Label showOrderChangesLabel;
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
            this.lstSelTransFields = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCorrected = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstStdFields = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSelStdFields = new System.Windows.Forms.ListBox();
            this.lstSelCommentFields = new System.Windows.Forms.ListBox();
            this.chkVarLabelCol = new System.Windows.Forms.CheckBox();
            this.chkFilterCol = new System.Windows.Forms.CheckBox();
            this.lblTransFields = new System.Windows.Forms.Label();
            this.lstTransFields = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCommentFields = new System.Windows.Forms.Label();
            this.dateTimeCommentsSince = new System.Windows.Forms.DateTimePicker();
            this.lstCommentSources = new System.Windows.Forms.ListBox();
            this.lstCommentAuthors = new System.Windows.Forms.ListBox();
            this.lstCommentFields = new System.Windows.Forms.ListBox();
            this.cmdToggleExtraFields = new System.Windows.Forms.Button();
            this.pgCompare = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupHighlightOptions = new System.Windows.Forms.GroupBox();
            this.flowHighlightOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.groupHighlightStyle = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.gridPrimarySurvey = new System.Windows.Forms.DataGridView();
            this.pgOrder = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.showAllQnumsCheckBox = new System.Windows.Forms.CheckBox();
            this.pgFormatting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.repeatedHeadingsCheckBox = new System.Windows.Forms.CheckBox();
            this.qNInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.colorSubsCheckBox = new System.Windows.Forms.CheckBox();
            this.aQNInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.showLongListsCheckBox = new System.Windows.Forms.CheckBox();
            this.cCInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.tablesCheckBox = new System.Windows.Forms.CheckBox();
            this.inlineRoutingCheckBox = new System.Windows.Forms.CheckBox();
            this.semiTelCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tablesTranslationCheckBox = new System.Windows.Forms.CheckBox();
            this.pgOutput = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.checkTablesCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.webCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.survNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesColCheckBox = new System.Windows.Forms.CheckBox();
            this.varChangesAppCheckBox = new System.Windows.Forms.CheckBox();
            this.excludeTempChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            this.blankColumnCheckBox = new System.Windows.Forms.CheckBox();
            this.coverPageCheckBox = new System.Windows.Forms.CheckBox();
            this.beforeAfterReportCheckBox = new System.Windows.Forms.CheckBox();
            this.bySectionCheckBox = new System.Windows.Forms.CheckBox();
            this.convertTrackedChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.doCompareCheckBox = new System.Windows.Forms.CheckBox();
            this.hideIdenticalWordingsCheckBox = new System.Windows.Forms.CheckBox();
            this.hidePrimaryCheckBox = new System.Windows.Forms.CheckBox();
            this.highlightCheckBox = new System.Windows.Forms.CheckBox();
            this.highlightNRCheckBox = new System.Windows.Forms.CheckBox();
            this.highlightSchemeTextBox = new System.Windows.Forms.TextBox();
            this.highlightStyleTextBox = new System.Windows.Forms.TextBox();
            this.hybridHighlightCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreSimilarWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.includeWordingsCheckBox = new System.Windows.Forms.CheckBox();
            this.matchOnRenameCheckBox = new System.Windows.Forms.CheckBox();
            this.reInsertDeletionsCheckBox = new System.Windows.Forms.CheckBox();
            this.selfCompareCheckBox = new System.Windows.Forms.CheckBox();
            this.showDeletedFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.showDeletedQuestionsCheckBox = new System.Windows.Forms.CheckBox();
            this.showOrderChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.surveyView = new System.Windows.Forms.DataGridView();
            this.surveyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            detailsLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            blankColumnLabel = new System.Windows.Forms.Label();
            coverPageLabel = new System.Windows.Forms.Label();
            beforeAfterReportLabel = new System.Windows.Forms.Label();
            bySectionLabel = new System.Windows.Forms.Label();
            convertTrackedChangesLabel = new System.Windows.Forms.Label();
            doCompareLabel = new System.Windows.Forms.Label();
            hideIdenticalWordingsLabel = new System.Windows.Forms.Label();
            hidePrimaryLabel = new System.Windows.Forms.Label();
            highlightLabel = new System.Windows.Forms.Label();
            highlightNRLabel = new System.Windows.Forms.Label();
            highlightSchemeLabel = new System.Windows.Forms.Label();
            highlightStyleLabel = new System.Windows.Forms.Label();
            hybridHighlightLabel = new System.Windows.Forms.Label();
            ignoreSimilarWordsLabel = new System.Windows.Forms.Label();
            includeWordingsLabel = new System.Windows.Forms.Label();
            matchOnRenameLabel = new System.Windows.Forms.Label();
            reInsertDeletionsLabel = new System.Windows.Forms.Label();
            selfCompareLabel = new System.Windows.Forms.Label();
            showDeletedFieldsLabel = new System.Windows.Forms.Label();
            showDeletedQuestionsLabel = new System.Windows.Forms.Label();
            showOrderChangesLabel = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.pgFilters.SuspendLayout();
            this.pgFields.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pgCompare.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupHighlightOptions.SuspendLayout();
            this.groupHighlightStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).BeginInit();
            this.pgOrder.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox5.SuspendLayout();
            this.pgFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView)).BeginInit();
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
            // blankColumnLabel
            // 
            blankColumnLabel.AutoSize = true;
            blankColumnLabel.Location = new System.Drawing.Point(681, 456);
            blankColumnLabel.Name = "blankColumnLabel";
            blankColumnLabel.Size = new System.Drawing.Size(75, 13);
            blankColumnLabel.TabIndex = 10;
            blankColumnLabel.Text = "Blank Column:";
            // 
            // coverPageLabel
            // 
            coverPageLabel.AutoSize = true;
            coverPageLabel.Location = new System.Drawing.Point(780, 492);
            coverPageLabel.Name = "coverPageLabel";
            coverPageLabel.Size = new System.Drawing.Size(66, 13);
            coverPageLabel.TabIndex = 12;
            coverPageLabel.Text = "Cover Page:";
            // 
            // beforeAfterReportLabel
            // 
            beforeAfterReportLabel.AutoSize = true;
            beforeAfterReportLabel.Location = new System.Drawing.Point(938, 44);
            beforeAfterReportLabel.Name = "beforeAfterReportLabel";
            beforeAfterReportLabel.Size = new System.Drawing.Size(101, 13);
            beforeAfterReportLabel.TabIndex = 14;
            beforeAfterReportLabel.Text = "Before After Report:";
            // 
            // bySectionLabel
            // 
            bySectionLabel.AutoSize = true;
            bySectionLabel.Location = new System.Drawing.Point(938, 74);
            bySectionLabel.Name = "bySectionLabel";
            bySectionLabel.Size = new System.Drawing.Size(61, 13);
            bySectionLabel.TabIndex = 16;
            bySectionLabel.Text = "By Section:";
            // 
            // convertTrackedChangesLabel
            // 
            convertTrackedChangesLabel.AutoSize = true;
            convertTrackedChangesLabel.Location = new System.Drawing.Point(938, 104);
            convertTrackedChangesLabel.Name = "convertTrackedChangesLabel";
            convertTrackedChangesLabel.Size = new System.Drawing.Size(135, 13);
            convertTrackedChangesLabel.TabIndex = 18;
            convertTrackedChangesLabel.Text = "Convert Tracked Changes:";
            // 
            // doCompareLabel
            // 
            doCompareLabel.AutoSize = true;
            doCompareLabel.Location = new System.Drawing.Point(938, 134);
            doCompareLabel.Name = "doCompareLabel";
            doCompareLabel.Size = new System.Drawing.Size(69, 13);
            doCompareLabel.TabIndex = 20;
            doCompareLabel.Text = "Do Compare:";
            // 
            // hideIdenticalWordingsLabel
            // 
            hideIdenticalWordingsLabel.AutoSize = true;
            hideIdenticalWordingsLabel.Location = new System.Drawing.Point(938, 164);
            hideIdenticalWordingsLabel.Name = "hideIdenticalWordingsLabel";
            hideIdenticalWordingsLabel.Size = new System.Drawing.Size(123, 13);
            hideIdenticalWordingsLabel.TabIndex = 22;
            hideIdenticalWordingsLabel.Text = "Hide Identical Wordings:";
            // 
            // hidePrimaryLabel
            // 
            hidePrimaryLabel.AutoSize = true;
            hidePrimaryLabel.Location = new System.Drawing.Point(938, 194);
            hidePrimaryLabel.Name = "hidePrimaryLabel";
            hidePrimaryLabel.Size = new System.Drawing.Size(69, 13);
            hidePrimaryLabel.TabIndex = 24;
            hidePrimaryLabel.Text = "Hide Primary:";
            // 
            // highlightLabel
            // 
            highlightLabel.AutoSize = true;
            highlightLabel.Location = new System.Drawing.Point(938, 224);
            highlightLabel.Name = "highlightLabel";
            highlightLabel.Size = new System.Drawing.Size(51, 13);
            highlightLabel.TabIndex = 26;
            highlightLabel.Text = "Highlight:";
            // 
            // highlightNRLabel
            // 
            highlightNRLabel.AutoSize = true;
            highlightNRLabel.Location = new System.Drawing.Point(938, 254);
            highlightNRLabel.Name = "highlightNRLabel";
            highlightNRLabel.Size = new System.Drawing.Size(70, 13);
            highlightNRLabel.TabIndex = 28;
            highlightNRLabel.Text = "Highlight NR:";
            // 
            // highlightSchemeLabel
            // 
            highlightSchemeLabel.AutoSize = true;
            highlightSchemeLabel.Location = new System.Drawing.Point(938, 282);
            highlightSchemeLabel.Name = "highlightSchemeLabel";
            highlightSchemeLabel.Size = new System.Drawing.Size(49, 13);
            highlightSchemeLabel.TabIndex = 30;
            highlightSchemeLabel.Text = "Scheme:";
            // 
            // highlightStyleLabel
            // 
            highlightStyleLabel.AutoSize = true;
            highlightStyleLabel.Location = new System.Drawing.Point(938, 308);
            highlightStyleLabel.Name = "highlightStyleLabel";
            highlightStyleLabel.Size = new System.Drawing.Size(33, 13);
            highlightStyleLabel.TabIndex = 32;
            highlightStyleLabel.Text = "Style:";
            // 
            // hybridHighlightLabel
            // 
            hybridHighlightLabel.AutoSize = true;
            hybridHighlightLabel.Location = new System.Drawing.Point(938, 336);
            hybridHighlightLabel.Name = "hybridHighlightLabel";
            hybridHighlightLabel.Size = new System.Drawing.Size(84, 13);
            hybridHighlightLabel.TabIndex = 34;
            hybridHighlightLabel.Text = "Hybrid Highlight:";
            // 
            // ignoreSimilarWordsLabel
            // 
            ignoreSimilarWordsLabel.AutoSize = true;
            ignoreSimilarWordsLabel.Location = new System.Drawing.Point(938, 366);
            ignoreSimilarWordsLabel.Name = "ignoreSimilarWordsLabel";
            ignoreSimilarWordsLabel.Size = new System.Drawing.Size(107, 13);
            ignoreSimilarWordsLabel.TabIndex = 36;
            ignoreSimilarWordsLabel.Text = "Ignore Similar Words:";
            // 
            // includeWordingsLabel
            // 
            includeWordingsLabel.AutoSize = true;
            includeWordingsLabel.Location = new System.Drawing.Point(938, 396);
            includeWordingsLabel.Name = "includeWordingsLabel";
            includeWordingsLabel.Size = new System.Drawing.Size(93, 13);
            includeWordingsLabel.TabIndex = 38;
            includeWordingsLabel.Text = "Include Wordings:";
            // 
            // matchOnRenameLabel
            // 
            matchOnRenameLabel.AutoSize = true;
            matchOnRenameLabel.Location = new System.Drawing.Point(938, 426);
            matchOnRenameLabel.Name = "matchOnRenameLabel";
            matchOnRenameLabel.Size = new System.Drawing.Size(100, 13);
            matchOnRenameLabel.TabIndex = 40;
            matchOnRenameLabel.Text = "Match On Rename:";
            // 
            // reInsertDeletionsLabel
            // 
            reInsertDeletionsLabel.AutoSize = true;
            reInsertDeletionsLabel.Location = new System.Drawing.Point(938, 456);
            reInsertDeletionsLabel.Name = "reInsertDeletionsLabel";
            reInsertDeletionsLabel.Size = new System.Drawing.Size(100, 13);
            reInsertDeletionsLabel.TabIndex = 42;
            reInsertDeletionsLabel.Text = "Re Insert Deletions:";
            // 
            // selfCompareLabel
            // 
            selfCompareLabel.AutoSize = true;
            selfCompareLabel.Location = new System.Drawing.Point(938, 486);
            selfCompareLabel.Name = "selfCompareLabel";
            selfCompareLabel.Size = new System.Drawing.Size(73, 13);
            selfCompareLabel.TabIndex = 44;
            selfCompareLabel.Text = "Self Compare:";
            // 
            // showDeletedFieldsLabel
            // 
            showDeletedFieldsLabel.AutoSize = true;
            showDeletedFieldsLabel.Location = new System.Drawing.Point(938, 516);
            showDeletedFieldsLabel.Name = "showDeletedFieldsLabel";
            showDeletedFieldsLabel.Size = new System.Drawing.Size(107, 13);
            showDeletedFieldsLabel.TabIndex = 46;
            showDeletedFieldsLabel.Text = "Show Deleted Fields:";
            // 
            // showDeletedQuestionsLabel
            // 
            showDeletedQuestionsLabel.AutoSize = true;
            showDeletedQuestionsLabel.Location = new System.Drawing.Point(938, 546);
            showDeletedQuestionsLabel.Name = "showDeletedQuestionsLabel";
            showDeletedQuestionsLabel.Size = new System.Drawing.Size(127, 13);
            showDeletedQuestionsLabel.TabIndex = 48;
            showDeletedQuestionsLabel.Text = "Show Deleted Questions:";
            // 
            // showOrderChangesLabel
            // 
            showOrderChangesLabel.AutoSize = true;
            showOrderChangesLabel.Location = new System.Drawing.Point(938, 576);
            showOrderChangesLabel.Name = "showOrderChangesLabel";
            showOrderChangesLabel.Size = new System.Drawing.Size(111, 13);
            showOrderChangesLabel.TabIndex = 50;
            showOrderChangesLabel.Text = "Show Order Changes:";
            // 
            // cboSurveys
            // 
            this.cboSurveys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.Location = new System.Drawing.Point(8, 65);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(108, 21);
            this.cboSurveys.TabIndex = 0;
            this.cboSurveys.UseWaitCursor = true;
            this.cboSurveys.ValueMember = "Survey";
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(122, 64);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(39, 20);
            this.cmdAddSurvey.TabIndex = 1;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.cmdAddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(122, 90);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(38, 25);
            this.cmdRemoveSurvey.TabIndex = 2;
            this.cmdRemoveSurvey.Text = "<-";
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.cmdRemoveSurvey_Click);
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
            this.lstSelectedSurveys.SelectedIndexChanged += new System.EventHandler(this.lstSelectedSurveys_SelectedIndexChanged);
            // 
            // cmdCheckOptions
            // 
            this.cmdCheckOptions.Location = new System.Drawing.Point(533, 48);
            this.cmdCheckOptions.Name = "cmdCheckOptions";
            this.cmdCheckOptions.Size = new System.Drawing.Size(88, 33);
            this.cmdCheckOptions.TabIndex = 4;
            this.cmdCheckOptions.Text = "Check Options";
            this.cmdCheckOptions.UseVisualStyleBackColor = true;
            this.cmdCheckOptions.Click += new System.EventHandler(this.cmdCheckOptions_Click);
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
            this.cmdRemoveVarName.Click += new System.EventHandler(this.cmdRemoveVarName_Click);
            // 
            // cmdAddVarName
            // 
            this.cmdAddVarName.Location = new System.Drawing.Point(89, 228);
            this.cmdAddVarName.Name = "cmdAddVarName";
            this.cmdAddVarName.Size = new System.Drawing.Size(29, 21);
            this.cmdAddVarName.TabIndex = 11;
            this.cmdAddVarName.Text = "->";
            this.cmdAddVarName.UseVisualStyleBackColor = true;
            this.cmdAddVarName.Click += new System.EventHandler(this.cmdAddVarName_Click);
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
            this.label3.Location = new System.Drawing.Point(86, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // txtQrangeHigh
            // 
            this.txtQrangeHigh.Location = new System.Drawing.Point(102, 33);
            this.txtQrangeHigh.Name = "txtQrangeHigh";
            this.txtQrangeHigh.Size = new System.Drawing.Size(38, 20);
            this.txtQrangeHigh.TabIndex = 7;
            // 
            // txtQrangeLow
            // 
            this.txtQrangeLow.Location = new System.Drawing.Point(43, 32);
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
            this.cmdRemovePrefix.Click += new System.EventHandler(this.cmdRemovePrefix_Click);
            // 
            // cmdAddPrefix
            // 
            this.cmdAddPrefix.Location = new System.Drawing.Point(86, 90);
            this.cmdAddPrefix.Name = "cmdAddPrefix";
            this.cmdAddPrefix.Size = new System.Drawing.Size(29, 21);
            this.cmdAddPrefix.TabIndex = 2;
            this.cmdAddPrefix.Text = "->";
            this.cmdAddPrefix.UseVisualStyleBackColor = true;
            this.cmdAddPrefix.Click += new System.EventHandler(this.cmdAddPrefix_Click);
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
            this.pgFields.Controls.Add(this.lstSelTransFields);
            this.pgFields.Controls.Add(this.panel1);
            this.pgFields.Controls.Add(this.lstSelCommentFields);
            this.pgFields.Controls.Add(this.chkVarLabelCol);
            this.pgFields.Controls.Add(this.chkFilterCol);
            this.pgFields.Controls.Add(this.lblTransFields);
            this.pgFields.Controls.Add(this.lstTransFields);
            this.pgFields.Controls.Add(this.label6);
            this.pgFields.Controls.Add(this.label5);
            this.pgFields.Controls.Add(this.lblCommentFields);
            this.pgFields.Controls.Add(this.dateTimeCommentsSince);
            this.pgFields.Controls.Add(this.lstCommentSources);
            this.pgFields.Controls.Add(this.lstCommentAuthors);
            this.pgFields.Controls.Add(this.lstCommentFields);
            this.pgFields.Controls.Add(this.cmdToggleExtraFields);
            this.pgFields.Location = new System.Drawing.Point(4, 22);
            this.pgFields.Name = "pgFields";
            this.pgFields.Padding = new System.Windows.Forms.Padding(3);
            this.pgFields.Size = new System.Drawing.Size(465, 503);
            this.pgFields.TabIndex = 1;
            this.pgFields.Text = "Fields";
            // 
            // lstSelTransFields
            // 
            this.lstSelTransFields.FormattingEnabled = true;
            this.lstSelTransFields.Location = new System.Drawing.Point(286, 170);
            this.lstSelTransFields.Name = "lstSelTransFields";
            this.lstSelTransFields.Size = new System.Drawing.Size(119, 108);
            this.lstSelTransFields.TabIndex = 21;
            this.lstSelTransFields.Visible = false;
            this.lstSelTransFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSelTransFields_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkCorrected);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lstStdFields);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lstSelStdFields);
            this.panel1.Location = new System.Drawing.Point(3, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 209);
            this.panel1.TabIndex = 20;
            // 
            // chkCorrected
            // 
            this.chkCorrected.AutoSize = true;
            this.chkCorrected.Location = new System.Drawing.Point(7, 164);
            this.chkCorrected.Name = "chkCorrected";
            this.chkCorrected.Size = new System.Drawing.Size(142, 17);
            this.chkCorrected.TabIndex = 18;
            this.chkCorrected.Text = "Use Corrected Wordings";
            this.chkCorrected.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Double-click to Add/Remove";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Selected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Available";
            // 
            // lstStdFields
            // 
            this.lstStdFields.FormattingEnabled = true;
            this.lstStdFields.Location = new System.Drawing.Point(3, 33);
            this.lstStdFields.Name = "lstStdFields";
            this.lstStdFields.Size = new System.Drawing.Size(70, 108);
            this.lstStdFields.TabIndex = 10;
            this.lstStdFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstStdFields_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Standard Fields";
            // 
            // lstSelStdFields
            // 
            this.lstSelStdFields.DataSource = this.surveyReportBindingSource;
            this.lstSelStdFields.FormattingEnabled = true;
            this.lstSelStdFields.Location = new System.Drawing.Point(79, 33);
            this.lstSelStdFields.Name = "lstSelStdFields";
            this.lstSelStdFields.Size = new System.Drawing.Size(70, 108);
            this.lstSelStdFields.TabIndex = 1;
            this.lstSelStdFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSelStdFields_MouseDoubleClick);
            // 
            // lstSelCommentFields
            // 
            this.lstSelCommentFields.FormattingEnabled = true;
            this.lstSelCommentFields.Location = new System.Drawing.Point(287, 43);
            this.lstSelCommentFields.Name = "lstSelCommentFields";
            this.lstSelCommentFields.Size = new System.Drawing.Size(118, 108);
            this.lstSelCommentFields.TabIndex = 19;
            this.lstSelCommentFields.Visible = false;
            this.lstSelCommentFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSelCommentFields_MouseDoubleClick);
            // 
            // chkVarLabelCol
            // 
            this.chkVarLabelCol.AutoSize = true;
            this.chkVarLabelCol.Location = new System.Drawing.Point(164, 307);
            this.chkVarLabelCol.Name = "chkVarLabelCol";
            this.chkVarLabelCol.Size = new System.Drawing.Size(106, 17);
            this.chkVarLabelCol.TabIndex = 17;
            this.chkVarLabelCol.Text = "VarLabel Column";
            this.chkVarLabelCol.UseVisualStyleBackColor = true;
            // 
            // chkFilterCol
            // 
            this.chkFilterCol.AutoSize = true;
            this.chkFilterCol.Location = new System.Drawing.Point(164, 284);
            this.chkFilterCol.Name = "chkFilterCol";
            this.chkFilterCol.Size = new System.Drawing.Size(86, 17);
            this.chkFilterCol.TabIndex = 16;
            this.chkFilterCol.Text = "Filter Column";
            this.chkFilterCol.UseVisualStyleBackColor = true;
            // 
            // lblTransFields
            // 
            this.lblTransFields.AutoSize = true;
            this.lblTransFields.Location = new System.Drawing.Point(161, 154);
            this.lblTransFields.Name = "lblTransFields";
            this.lblTransFields.Size = new System.Drawing.Size(89, 13);
            this.lblTransFields.TabIndex = 15;
            this.lblTransFields.Text = "Translation Fields";
            this.lblTransFields.Visible = false;
            // 
            // lstTransFields
            // 
            this.lstTransFields.FormattingEnabled = true;
            this.lstTransFields.Location = new System.Drawing.Point(163, 170);
            this.lstTransFields.Name = "lstTransFields";
            this.lstTransFields.Size = new System.Drawing.Size(117, 108);
            this.lstTransFields.TabIndex = 14;
            this.lstTransFields.Visible = false;
            this.lstTransFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTransFields_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sources";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Authors";
            this.label5.Visible = false;
            // 
            // lblCommentFields
            // 
            this.lblCommentFields.AutoSize = true;
            this.lblCommentFields.Location = new System.Drawing.Point(160, 27);
            this.lblCommentFields.Name = "lblCommentFields";
            this.lblCommentFields.Size = new System.Drawing.Size(81, 13);
            this.lblCommentFields.TabIndex = 7;
            this.lblCommentFields.Text = "Comment Fields";
            this.lblCommentFields.Visible = false;
            // 
            // dateTimeCommentsSince
            // 
            this.dateTimeCommentsSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeCommentsSince.Location = new System.Drawing.Point(315, 21);
            this.dateTimeCommentsSince.Name = "dateTimeCommentsSince";
            this.dateTimeCommentsSince.Size = new System.Drawing.Size(90, 20);
            this.dateTimeCommentsSince.TabIndex = 5;
            this.dateTimeCommentsSince.Visible = false;
            // 
            // lstCommentSources
            // 
            this.lstCommentSources.FormattingEnabled = true;
            this.lstCommentSources.Location = new System.Drawing.Point(411, 108);
            this.lstCommentSources.Name = "lstCommentSources";
            this.lstCommentSources.Size = new System.Drawing.Size(43, 43);
            this.lstCommentSources.TabIndex = 4;
            this.lstCommentSources.Visible = false;
            // 
            // lstCommentAuthors
            // 
            this.lstCommentAuthors.FormattingEnabled = true;
            this.lstCommentAuthors.Location = new System.Drawing.Point(411, 44);
            this.lstCommentAuthors.Name = "lstCommentAuthors";
            this.lstCommentAuthors.Size = new System.Drawing.Size(43, 43);
            this.lstCommentAuthors.TabIndex = 3;
            this.lstCommentAuthors.Visible = false;
            // 
            // lstCommentFields
            // 
            this.lstCommentFields.FormattingEnabled = true;
            this.lstCommentFields.Location = new System.Drawing.Point(163, 43);
            this.lstCommentFields.Name = "lstCommentFields";
            this.lstCommentFields.Size = new System.Drawing.Size(118, 108);
            this.lstCommentFields.TabIndex = 2;
            this.lstCommentFields.Visible = false;
            this.lstCommentFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCommentFields_MouseDoubleClick);
            // 
            // cmdToggleExtraFields
            // 
            this.cmdToggleExtraFields.Location = new System.Drawing.Point(163, 8);
            this.cmdToggleExtraFields.Name = "cmdToggleExtraFields";
            this.cmdToggleExtraFields.Size = new System.Drawing.Size(118, 19);
            this.cmdToggleExtraFields.TabIndex = 0;
            this.cmdToggleExtraFields.Text = "Add Extra Fields...";
            this.cmdToggleExtraFields.UseVisualStyleBackColor = true;
            this.cmdToggleExtraFields.Click += new System.EventHandler(this.cmdToggleExtraFields_Click);
            // 
            // pgCompare
            // 
            this.pgCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgCompare.Controls.Add(this.groupBox1);
            this.pgCompare.Controls.Add(this.groupHighlightOptions);
            this.pgCompare.Controls.Add(this.gridPrimarySurvey);
            this.pgCompare.Location = new System.Drawing.Point(4, 22);
            this.pgCompare.Name = "pgCompare";
            this.pgCompare.Size = new System.Drawing.Size(465, 503);
            this.pgCompare.TabIndex = 2;
            this.pgCompare.Text = "Comparison";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(234, 379);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(191, 110);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layout Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 18);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 83);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupHighlightOptions
            // 
            this.groupHighlightOptions.Controls.Add(this.flowHighlightOptions);
            this.groupHighlightOptions.Controls.Add(this.groupHighlightStyle);
            this.groupHighlightOptions.Location = new System.Drawing.Point(234, 29);
            this.groupHighlightOptions.Name = "groupHighlightOptions";
            this.groupHighlightOptions.Size = new System.Drawing.Size(191, 336);
            this.groupHighlightOptions.TabIndex = 11;
            this.groupHighlightOptions.TabStop = false;
            this.groupHighlightOptions.Text = "Highlight Options";
            // 
            // flowHighlightOptions
            // 
            this.flowHighlightOptions.Location = new System.Drawing.Point(28, 164);
            this.flowHighlightOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowHighlightOptions.Name = "flowHighlightOptions";
            this.flowHighlightOptions.Padding = new System.Windows.Forms.Padding(1);
            this.flowHighlightOptions.Size = new System.Drawing.Size(157, 168);
            this.flowHighlightOptions.TabIndex = 10;
            // 
            // groupHighlightStyle
            // 
            this.groupHighlightStyle.Controls.Add(this.comboBox1);
            this.groupHighlightStyle.Controls.Add(this.radioButton2);
            this.groupHighlightStyle.Controls.Add(this.radioButton1);
            this.groupHighlightStyle.Location = new System.Drawing.Point(18, 42);
            this.groupHighlightStyle.Name = "groupHighlightStyle";
            this.groupHighlightStyle.Size = new System.Drawing.Size(152, 117);
            this.groupHighlightStyle.TabIndex = 3;
            this.groupHighlightStyle.TabStop = false;
            this.groupHighlightStyle.Text = "Highlight Style";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 45);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // gridPrimarySurvey
            // 
            this.gridPrimarySurvey.AllowUserToAddRows = false;
            this.gridPrimarySurvey.AllowUserToDeleteRows = false;
            this.gridPrimarySurvey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrimarySurvey.Location = new System.Drawing.Point(13, 71);
            this.gridPrimarySurvey.Name = "gridPrimarySurvey";
            this.gridPrimarySurvey.RowHeadersVisible = false;
            this.gridPrimarySurvey.Size = new System.Drawing.Size(184, 167);
            this.gridPrimarySurvey.TabIndex = 1;
            // 
            // pgOrder
            // 
            this.pgOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgOrder.Controls.Add(this.groupBox2);
            this.pgOrder.Location = new System.Drawing.Point(4, 22);
            this.pgOrder.Name = "pgOrder";
            this.pgOrder.Size = new System.Drawing.Size(465, 503);
            this.pgOrder.TabIndex = 3;
            this.pgOrder.Text = "Order and Numbering";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.showAllQnumsCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(155, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 121);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enumeration";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(25, 62);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(85, 17);
            this.radioButton5.TabIndex = 55;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(26, 38);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 54;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(30, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 53;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // showAllQnumsCheckBox
            // 
            this.showAllQnumsCheckBox.Location = new System.Drawing.Point(39, 91);
            this.showAllQnumsCheckBox.Name = "showAllQnumsCheckBox";
            this.showAllQnumsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.showAllQnumsCheckBox.TabIndex = 52;
            this.showAllQnumsCheckBox.Text = "Show All Qnums";
            this.showAllQnumsCheckBox.UseVisualStyleBackColor = true;
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
            this.groupBox3.Size = new System.Drawing.Size(374, 348);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Functions";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.repeatedHeadingsCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.qNInsertionCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorSubsCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.aQNInsertionCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.showLongListsCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cCInsertionCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tablesCheckBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.inlineRoutingCheckBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.semiTelCheckBox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tablesTranslationCheckBox, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 223);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // repeatedHeadingsCheckBox
            // 
            this.repeatedHeadingsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.repeatedHeadingsCheckBox.Name = "repeatedHeadingsCheckBox";
            this.repeatedHeadingsCheckBox.Size = new System.Drawing.Size(104, 19);
            this.repeatedHeadingsCheckBox.TabIndex = 46;
            this.repeatedHeadingsCheckBox.Text = "Repeat Headings";
            this.repeatedHeadingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // qNInsertionCheckBox
            // 
            this.qNInsertionCheckBox.Location = new System.Drawing.Point(3, 78);
            this.qNInsertionCheckBox.Name = "qNInsertionCheckBox";
            this.qNInsertionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.qNInsertionCheckBox.TabIndex = 44;
            this.qNInsertionCheckBox.Text = "QN Insertion";
            this.qNInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorSubsCheckBox
            // 
            this.colorSubsCheckBox.Location = new System.Drawing.Point(3, 28);
            this.colorSubsCheckBox.Name = "colorSubsCheckBox";
            this.colorSubsCheckBox.Size = new System.Drawing.Size(122, 19);
            this.colorSubsCheckBox.TabIndex = 22;
            this.colorSubsCheckBox.Text = "Color Subheadings";
            this.colorSubsCheckBox.UseVisualStyleBackColor = true;
            // 
            // aQNInsertionCheckBox
            // 
            this.aQNInsertionCheckBox.Location = new System.Drawing.Point(170, 78);
            this.aQNInsertionCheckBox.Name = "aQNInsertionCheckBox";
            this.aQNInsertionCheckBox.Size = new System.Drawing.Size(104, 19);
            this.aQNInsertionCheckBox.TabIndex = 10;
            this.aQNInsertionCheckBox.Text = "Use AltQnum";
            this.aQNInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLongListsCheckBox
            // 
            this.showLongListsCheckBox.Location = new System.Drawing.Point(3, 53);
            this.showLongListsCheckBox.Name = "showLongListsCheckBox";
            this.showLongListsCheckBox.Size = new System.Drawing.Size(104, 19);
            this.showLongListsCheckBox.TabIndex = 54;
            this.showLongListsCheckBox.Text = "Show Long Lists";
            this.showLongListsCheckBox.UseVisualStyleBackColor = true;
            // 
            // cCInsertionCheckBox
            // 
            this.cCInsertionCheckBox.Location = new System.Drawing.Point(3, 103);
            this.cCInsertionCheckBox.Name = "cCInsertionCheckBox";
            this.cCInsertionCheckBox.Size = new System.Drawing.Size(120, 19);
            this.cCInsertionCheckBox.TabIndex = 14;
            this.cCInsertionCheckBox.Text = "Insert Country Code";
            this.cCInsertionCheckBox.UseVisualStyleBackColor = true;
            // 
            // tablesCheckBox
            // 
            this.tablesCheckBox.Location = new System.Drawing.Point(3, 128);
            this.tablesCheckBox.Name = "tablesCheckBox";
            this.tablesCheckBox.Size = new System.Drawing.Size(132, 19);
            this.tablesCheckBox.TabIndex = 60;
            this.tablesCheckBox.Text = "Insert Subset Tables";
            this.tablesCheckBox.UseVisualStyleBackColor = true;
            // 
            // inlineRoutingCheckBox
            // 
            this.inlineRoutingCheckBox.Location = new System.Drawing.Point(3, 153);
            this.inlineRoutingCheckBox.Name = "inlineRoutingCheckBox";
            this.inlineRoutingCheckBox.Size = new System.Drawing.Size(104, 19);
            this.inlineRoutingCheckBox.TabIndex = 38;
            this.inlineRoutingCheckBox.Text = "In-line Routing";
            this.inlineRoutingCheckBox.UseVisualStyleBackColor = true;
            // 
            // semiTelCheckBox
            // 
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
            // tablesTranslationCheckBox
            // 
            this.tablesTranslationCheckBox.Location = new System.Drawing.Point(170, 128);
            this.tablesTranslationCheckBox.Name = "tablesTranslationCheckBox";
            this.tablesTranslationCheckBox.Size = new System.Drawing.Size(104, 19);
            this.tablesTranslationCheckBox.TabIndex = 62;
            this.tablesTranslationCheckBox.Text = "Use Translation";
            this.tablesTranslationCheckBox.UseVisualStyleBackColor = true;
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
            this.groupBox4.Controls.Add(this.groupBox5);
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
            this.varChangesColCheckBox.Location = new System.Drawing.Point(1, 25);
            this.varChangesColCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.varChangesColCheckBox.Name = "varChangesColCheckBox";
            this.varChangesColCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.varChangesColCheckBox.Size = new System.Drawing.Size(183, 24);
            this.varChangesColCheckBox.TabIndex = 68;
            this.varChangesColCheckBox.Text = "VarName Changes (in VarName column)";
            this.varChangesColCheckBox.UseVisualStyleBackColor = true;
            // 
            // varChangesAppCheckBox
            // 
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
            this.groupBox8.Controls.Add(this.radioButton17);
            this.groupBox8.Controls.Add(this.radioButton16);
            this.groupBox8.Controls.Add(this.radioButton15);
            this.groupBox8.Location = new System.Drawing.Point(173, 127);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(131, 101);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "NR Format";
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(11, 64);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(99, 17);
            this.radioButton17.TabIndex = 2;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "Don\'t Read Out";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(11, 41);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(79, 17);
            this.radioButton16.TabIndex = 1;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "Don\'t Read";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(11, 18);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(59, 17);
            this.radioButton15.TabIndex = 0;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "Neither";
            this.radioButton15.UseVisualStyleBackColor = true;
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
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "A4";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(13, 55);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(54, 17);
            this.radioButton13.TabIndex = 2;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "11x17";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(13, 33);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(51, 17);
            this.radioButton12.TabIndex = 1;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "Legal";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(13, 17);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(52, 17);
            this.radioButton11.TabIndex = 0;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "Letter";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton10);
            this.groupBox6.Controls.Add(this.radioButton9);
            this.groupBox6.Controls.Add(this.radioButton8);
            this.groupBox6.Location = new System.Drawing.Point(173, 35);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(131, 88);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Table of Contents";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(13, 60);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(95, 17);
            this.radioButton10.TabIndex = 2;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Page Numbers";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(13, 39);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(112, 17);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Question Numbers";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(13, 21);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(51, 17);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "None";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton7);
            this.groupBox5.Controls.Add(this.radioButton6);
            this.groupBox5.Location = new System.Drawing.Point(43, 35);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(95, 88);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "File Format";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(9, 39);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(46, 17);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "PDF";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(9, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(51, 17);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Word";
            this.radioButton6.UseVisualStyleBackColor = true;
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
            // blankColumnCheckBox
            // 
            this.blankColumnCheckBox.Location = new System.Drawing.Point(762, 451);
            this.blankColumnCheckBox.Name = "blankColumnCheckBox";
            this.blankColumnCheckBox.Size = new System.Drawing.Size(104, 24);
            this.blankColumnCheckBox.TabIndex = 11;
            this.blankColumnCheckBox.Text = "checkBox1";
            this.blankColumnCheckBox.UseVisualStyleBackColor = true;
            // 
            // coverPageCheckBox
            // 
            this.coverPageCheckBox.Location = new System.Drawing.Point(852, 487);
            this.coverPageCheckBox.Name = "coverPageCheckBox";
            this.coverPageCheckBox.Size = new System.Drawing.Size(104, 24);
            this.coverPageCheckBox.TabIndex = 13;
            this.coverPageCheckBox.Text = "checkBox1";
            this.coverPageCheckBox.UseVisualStyleBackColor = true;
            // 
            // beforeAfterReportCheckBox
            // 
            this.beforeAfterReportCheckBox.Location = new System.Drawing.Point(1079, 39);
            this.beforeAfterReportCheckBox.Name = "beforeAfterReportCheckBox";
            this.beforeAfterReportCheckBox.Size = new System.Drawing.Size(104, 24);
            this.beforeAfterReportCheckBox.TabIndex = 15;
            this.beforeAfterReportCheckBox.Text = "checkBox1";
            this.beforeAfterReportCheckBox.UseVisualStyleBackColor = true;
            // 
            // bySectionCheckBox
            // 
            this.bySectionCheckBox.Location = new System.Drawing.Point(1079, 69);
            this.bySectionCheckBox.Name = "bySectionCheckBox";
            this.bySectionCheckBox.Size = new System.Drawing.Size(104, 24);
            this.bySectionCheckBox.TabIndex = 17;
            this.bySectionCheckBox.Text = "checkBox1";
            this.bySectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertTrackedChangesCheckBox
            // 
            this.convertTrackedChangesCheckBox.Location = new System.Drawing.Point(1079, 99);
            this.convertTrackedChangesCheckBox.Name = "convertTrackedChangesCheckBox";
            this.convertTrackedChangesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.convertTrackedChangesCheckBox.TabIndex = 19;
            this.convertTrackedChangesCheckBox.Text = "checkBox1";
            this.convertTrackedChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // doCompareCheckBox
            // 
            this.doCompareCheckBox.Location = new System.Drawing.Point(1079, 129);
            this.doCompareCheckBox.Name = "doCompareCheckBox";
            this.doCompareCheckBox.Size = new System.Drawing.Size(104, 24);
            this.doCompareCheckBox.TabIndex = 21;
            this.doCompareCheckBox.Text = "checkBox1";
            this.doCompareCheckBox.UseVisualStyleBackColor = true;
            // 
            // hideIdenticalWordingsCheckBox
            // 
            this.hideIdenticalWordingsCheckBox.Location = new System.Drawing.Point(1079, 159);
            this.hideIdenticalWordingsCheckBox.Name = "hideIdenticalWordingsCheckBox";
            this.hideIdenticalWordingsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.hideIdenticalWordingsCheckBox.TabIndex = 23;
            this.hideIdenticalWordingsCheckBox.Text = "checkBox1";
            this.hideIdenticalWordingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // hidePrimaryCheckBox
            // 
            this.hidePrimaryCheckBox.Location = new System.Drawing.Point(1079, 189);
            this.hidePrimaryCheckBox.Name = "hidePrimaryCheckBox";
            this.hidePrimaryCheckBox.Size = new System.Drawing.Size(104, 24);
            this.hidePrimaryCheckBox.TabIndex = 25;
            this.hidePrimaryCheckBox.Text = "checkBox1";
            this.hidePrimaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.Location = new System.Drawing.Point(1079, 219);
            this.highlightCheckBox.Name = "highlightCheckBox";
            this.highlightCheckBox.Size = new System.Drawing.Size(104, 24);
            this.highlightCheckBox.TabIndex = 27;
            this.highlightCheckBox.Text = "checkBox1";
            this.highlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightNRCheckBox
            // 
            this.highlightNRCheckBox.Location = new System.Drawing.Point(1079, 249);
            this.highlightNRCheckBox.Name = "highlightNRCheckBox";
            this.highlightNRCheckBox.Size = new System.Drawing.Size(104, 24);
            this.highlightNRCheckBox.TabIndex = 29;
            this.highlightNRCheckBox.Text = "checkBox1";
            this.highlightNRCheckBox.UseVisualStyleBackColor = true;
            // 
            // highlightSchemeTextBox
            // 
            this.highlightSchemeTextBox.Location = new System.Drawing.Point(1079, 279);
            this.highlightSchemeTextBox.Name = "highlightSchemeTextBox";
            this.highlightSchemeTextBox.Size = new System.Drawing.Size(104, 20);
            this.highlightSchemeTextBox.TabIndex = 31;
            // 
            // highlightStyleTextBox
            // 
            this.highlightStyleTextBox.Location = new System.Drawing.Point(1079, 305);
            this.highlightStyleTextBox.Name = "highlightStyleTextBox";
            this.highlightStyleTextBox.Size = new System.Drawing.Size(104, 20);
            this.highlightStyleTextBox.TabIndex = 33;
            // 
            // hybridHighlightCheckBox
            // 
            this.hybridHighlightCheckBox.Location = new System.Drawing.Point(1079, 331);
            this.hybridHighlightCheckBox.Name = "hybridHighlightCheckBox";
            this.hybridHighlightCheckBox.Size = new System.Drawing.Size(104, 24);
            this.hybridHighlightCheckBox.TabIndex = 35;
            this.hybridHighlightCheckBox.Text = "checkBox1";
            this.hybridHighlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSimilarWordsCheckBox
            // 
            this.ignoreSimilarWordsCheckBox.Location = new System.Drawing.Point(1079, 361);
            this.ignoreSimilarWordsCheckBox.Name = "ignoreSimilarWordsCheckBox";
            this.ignoreSimilarWordsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ignoreSimilarWordsCheckBox.TabIndex = 37;
            this.ignoreSimilarWordsCheckBox.Text = "checkBox1";
            this.ignoreSimilarWordsCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeWordingsCheckBox
            // 
            this.includeWordingsCheckBox.Location = new System.Drawing.Point(1079, 391);
            this.includeWordingsCheckBox.Name = "includeWordingsCheckBox";
            this.includeWordingsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.includeWordingsCheckBox.TabIndex = 39;
            this.includeWordingsCheckBox.Text = "checkBox1";
            this.includeWordingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchOnRenameCheckBox
            // 
            this.matchOnRenameCheckBox.Location = new System.Drawing.Point(1079, 421);
            this.matchOnRenameCheckBox.Name = "matchOnRenameCheckBox";
            this.matchOnRenameCheckBox.Size = new System.Drawing.Size(104, 24);
            this.matchOnRenameCheckBox.TabIndex = 41;
            this.matchOnRenameCheckBox.Text = "checkBox1";
            this.matchOnRenameCheckBox.UseVisualStyleBackColor = true;
            // 
            // reInsertDeletionsCheckBox
            // 
            this.reInsertDeletionsCheckBox.Location = new System.Drawing.Point(1079, 451);
            this.reInsertDeletionsCheckBox.Name = "reInsertDeletionsCheckBox";
            this.reInsertDeletionsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.reInsertDeletionsCheckBox.TabIndex = 43;
            this.reInsertDeletionsCheckBox.Text = "checkBox1";
            this.reInsertDeletionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // selfCompareCheckBox
            // 
            this.selfCompareCheckBox.Location = new System.Drawing.Point(1079, 481);
            this.selfCompareCheckBox.Name = "selfCompareCheckBox";
            this.selfCompareCheckBox.Size = new System.Drawing.Size(104, 24);
            this.selfCompareCheckBox.TabIndex = 45;
            this.selfCompareCheckBox.Text = "checkBox1";
            this.selfCompareCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDeletedFieldsCheckBox
            // 
            this.showDeletedFieldsCheckBox.Location = new System.Drawing.Point(1079, 511);
            this.showDeletedFieldsCheckBox.Name = "showDeletedFieldsCheckBox";
            this.showDeletedFieldsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.showDeletedFieldsCheckBox.TabIndex = 47;
            this.showDeletedFieldsCheckBox.Text = "checkBox1";
            this.showDeletedFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDeletedQuestionsCheckBox
            // 
            this.showDeletedQuestionsCheckBox.Location = new System.Drawing.Point(1079, 541);
            this.showDeletedQuestionsCheckBox.Name = "showDeletedQuestionsCheckBox";
            this.showDeletedQuestionsCheckBox.Size = new System.Drawing.Size(104, 24);
            this.showDeletedQuestionsCheckBox.TabIndex = 49;
            this.showDeletedQuestionsCheckBox.Text = "checkBox1";
            this.showDeletedQuestionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showOrderChangesCheckBox
            // 
            this.showOrderChangesCheckBox.Location = new System.Drawing.Point(1079, 571);
            this.showOrderChangesCheckBox.Name = "showOrderChangesCheckBox";
            this.showOrderChangesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.showOrderChangesCheckBox.TabIndex = 51;
            this.showOrderChangesCheckBox.Text = "checkBox1";
            this.showOrderChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // surveyView
            // 
            this.surveyView.AllowUserToAddRows = false;
            this.surveyView.AllowUserToDeleteRows = false;
            this.surveyView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveyView.Location = new System.Drawing.Point(488, 186);
            this.surveyView.Name = "surveyView";
            this.surveyView.RowHeadersVisible = false;
            this.surveyView.Size = new System.Drawing.Size(444, 248);
            this.surveyView.TabIndex = 52;
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
            this.ClientSize = new System.Drawing.Size(1250, 800);
            this.Controls.Add(this.surveyView);
            this.Controls.Add(beforeAfterReportLabel);
            this.Controls.Add(this.beforeAfterReportCheckBox);
            this.Controls.Add(bySectionLabel);
            this.Controls.Add(this.bySectionCheckBox);
            this.Controls.Add(convertTrackedChangesLabel);
            this.Controls.Add(this.convertTrackedChangesCheckBox);
            this.Controls.Add(doCompareLabel);
            this.Controls.Add(this.doCompareCheckBox);
            this.Controls.Add(hideIdenticalWordingsLabel);
            this.Controls.Add(this.hideIdenticalWordingsCheckBox);
            this.Controls.Add(hidePrimaryLabel);
            this.Controls.Add(this.hidePrimaryCheckBox);
            this.Controls.Add(highlightLabel);
            this.Controls.Add(this.highlightCheckBox);
            this.Controls.Add(highlightNRLabel);
            this.Controls.Add(this.highlightNRCheckBox);
            this.Controls.Add(highlightSchemeLabel);
            this.Controls.Add(this.highlightSchemeTextBox);
            this.Controls.Add(highlightStyleLabel);
            this.Controls.Add(this.highlightStyleTextBox);
            this.Controls.Add(hybridHighlightLabel);
            this.Controls.Add(this.hybridHighlightCheckBox);
            this.Controls.Add(ignoreSimilarWordsLabel);
            this.Controls.Add(this.ignoreSimilarWordsCheckBox);
            this.Controls.Add(includeWordingsLabel);
            this.Controls.Add(this.includeWordingsCheckBox);
            this.Controls.Add(matchOnRenameLabel);
            this.Controls.Add(this.matchOnRenameCheckBox);
            this.Controls.Add(reInsertDeletionsLabel);
            this.Controls.Add(this.reInsertDeletionsCheckBox);
            this.Controls.Add(selfCompareLabel);
            this.Controls.Add(this.selfCompareCheckBox);
            this.Controls.Add(showDeletedFieldsLabel);
            this.Controls.Add(this.showDeletedFieldsCheckBox);
            this.Controls.Add(showDeletedQuestionsLabel);
            this.Controls.Add(this.showDeletedQuestionsCheckBox);
            this.Controls.Add(showOrderChangesLabel);
            this.Controls.Add(this.showOrderChangesCheckBox);
            this.Controls.Add(coverPageLabel);
            this.Controls.Add(this.coverPageCheckBox);
            this.Controls.Add(blankColumnLabel);
            this.Controls.Add(this.blankColumnCheckBox);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pgCompare.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupHighlightOptions.ResumeLayout(false);
            this.groupHighlightStyle.ResumeLayout(false);
            this.groupHighlightStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimarySurvey)).EndInit();
            this.pgOrder.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pgFileName.ResumeLayout(false);
            this.pgFileName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyView)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeCommentsSince;
        private System.Windows.Forms.ListBox lstCommentSources;
        private System.Windows.Forms.ListBox lstCommentAuthors;
        private System.Windows.Forms.ListBox lstCommentFields;
        private System.Windows.Forms.ListBox lstSelStdFields;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstStdFields;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkVarLabelCol;
        private System.Windows.Forms.CheckBox chkFilterCol;
        private System.Windows.Forms.Label lblTransFields;
        private System.Windows.Forms.CheckBox chkCorrected;
        private System.Windows.Forms.ListBox lstSelCommentFields;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstSelTransFields;
        private System.Windows.Forms.ListBox lstTransFields;
        private System.Windows.Forms.DataGridView gridPrimarySurvey;
        private System.Windows.Forms.GroupBox groupHighlightOptions;
        private System.Windows.Forms.FlowLayoutPanel flowHighlightOptions;
        private System.Windows.Forms.GroupBox groupHighlightStyle;
        private System.Windows.Forms.ComboBox comboBox1;
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
        private System.Windows.Forms.CheckBox showAllQnumsCheckBox;
        private System.Windows.Forms.CheckBox survNotesCheckBox;
        private System.Windows.Forms.CheckBox tablesCheckBox;
        private System.Windows.Forms.CheckBox tablesTranslationCheckBox;
        private System.Windows.Forms.CheckBox varChangesAppCheckBox;
        private System.Windows.Forms.CheckBox varChangesColCheckBox;
        private System.Windows.Forms.CheckBox webCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
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
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox blankColumnCheckBox;
        private System.Windows.Forms.CheckBox coverPageCheckBox;
        private System.Windows.Forms.CheckBox beforeAfterReportCheckBox;
        private System.Windows.Forms.CheckBox bySectionCheckBox;
        private System.Windows.Forms.CheckBox convertTrackedChangesCheckBox;
        private System.Windows.Forms.CheckBox doCompareCheckBox;
        private System.Windows.Forms.CheckBox hideIdenticalWordingsCheckBox;
        private System.Windows.Forms.CheckBox hidePrimaryCheckBox;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.CheckBox highlightNRCheckBox;
        private System.Windows.Forms.TextBox highlightSchemeTextBox;
        private System.Windows.Forms.TextBox highlightStyleTextBox;
        private System.Windows.Forms.CheckBox hybridHighlightCheckBox;
        private System.Windows.Forms.CheckBox ignoreSimilarWordsCheckBox;
        private System.Windows.Forms.CheckBox includeWordingsCheckBox;
        private System.Windows.Forms.CheckBox matchOnRenameCheckBox;
        private System.Windows.Forms.CheckBox reInsertDeletionsCheckBox;
        private System.Windows.Forms.CheckBox selfCompareCheckBox;
        private System.Windows.Forms.CheckBox showDeletedFieldsCheckBox;
        private System.Windows.Forms.CheckBox showDeletedQuestionsCheckBox;
        private System.Windows.Forms.CheckBox showOrderChangesCheckBox;
        private System.Windows.Forms.DataGridView surveyView;
        private System.Windows.Forms.BindingSource surveyReportBindingSource;
    }
}

