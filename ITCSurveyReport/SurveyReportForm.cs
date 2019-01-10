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
using ITCSurveyReportLib;

namespace ITCSurveyReport
{
    // TODO use using statements to fill Filter combo boxes
    // TODO create class for headings to be used in the heading Filter
    public partial class SurveyReportForm : Form
    {
        VarNameReport SR;
        UserPrefs UP;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;
        // background color RGB values
        int backColorR = 55;
        int backColorG = 170;
        int backColorB = 136;

        SqlDataAdapter sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

        /// <summary>
        /// 
        /// </summary>
        public SurveyReportForm()
        {
            InitializeComponent();
        }

        private void SurveyReportForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sql;
            DataTable surveyList = new DataTable();
            sql = new SqlDataAdapter("SELECT Survey FROM qrySurveys ORDER BY ISO_Code, Wave, Survey", conn);

            //using (conn) {
            conn.Open();
            sql.Fill(surveyList);
            conn.Close();
            
            cboSurveys.DataSource = surveyList;
            cboSurveys.ValueMember = "Survey";
            cboSurveys.DisplayMember = "Survey";
            //}


            pgCompareTab = pgCompare;
            tabControlOptions.TabPages.Remove(pgCompare);

            
            // start with blank constructor, default settings
            SR = new VarNameReport();
            UP = new UserPrefs();
            SR.FileName = UP.ReportPath;

            surveyReportBindingSource.DataSource = SR;

            lstRepeatedFields.Items.Add("PreP");
            lstRepeatedFields.Items.Add("PreI");
            lstRepeatedFields.Items.Add("PreA");
            lstRepeatedFields.Items.Add("LitQ");
            lstRepeatedFields.Items.Add("RespOptions");
            lstRepeatedFields.Items.Add("NRCodes");
            lstRepeatedFields.Items.Add("PstI");
            lstRepeatedFields.Items.Add("PstP");
        }

        private void ReportType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.ReportType = (ReportTypes)sel;
        }

        private void CheckOptions_Click(object sender, EventArgs e)
        {
            
            // if standard is not chosen, create a new SR with the chosen template


            if (lstSelectedSurveys.SelectedIndex != -1)
            {
                int result;
                
                txtOptions.Text = SR.ToString();
                result = SR.GenerateReport();
                switch (result)
                {
                    case 0: // no errors
                        break;
                    case 1:
                        MessageBox.Show("One or more surveys contain no records.");
                        // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                        break;
                    default:
                        break;
                }

                //surveyView.DataSource = null;
                //surveyView.DataSource = SR.Surveys[0].rawTable;
                //surveyView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //surveyView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //if (SR.Surveys.Count > 1)
                //{
                //    surveyView2.DataSource = null;
                //    surveyView2.DataSource = SR.Surveys[1].rawTable;
                //    surveyView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //    surveyView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //}

                //gridFinalReport.DataSource = null;
                //gridFinalReport.DataSource = SR.ReportTable;
                //gridFinalReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //gridFinalReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void Surveys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdAddSurvey.PerformClick();
                cboSurveys.Focus();
            }

        }

        private void SelectedSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItem != null)
            {
                CurrentSurvey = (ReportSurvey)lstSelectedSurveys.SelectedItem;
                LoadSurveyOptions();
            }
        }

        // bind each control to the selected survey's corresponding fields
        private void LoadSurveyOptions()
        {
            
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
            LoadExtraFields(CurrentSurvey.SurveyCode);
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

        }

        private void LoadPrefixes(string survey)
        {
            SqlDataAdapter sql;
            DataTable prefixes = new DataTable();
            sql = new SqlDataAdapter("SELECT Left(VarName,2) AS Prefix FROM qrySurveyQuestions WHERE Survey ='" + survey + "' GROUP BY Left(VarName,2)", conn);

            //using (conn) {
                conn.Open();
                sql.Fill(prefixes);
                conn.Close();

                cboPrefixes.DataSource = prefixes;
                cboPrefixes.ValueMember = "Prefix";
                cboPrefixes.DisplayMember = "Prefix";
            //}
            
            
        }

        private void LoadVarNames(string survey)
        {
            SqlDataAdapter sql;
            DataTable varnames = new DataTable();
            sql = new SqlDataAdapter("SELECT VarName FROM qrySurveyQuestions WHERE Survey ='" + survey + "' GROUP BY VarName", conn);

            //using (conn) {
            conn.Open();
            sql.Fill(varnames);
            conn.Close();

            cboVarNames.DataSource = varnames;
            cboVarNames.ValueMember = "VarName";
            cboVarNames.DisplayMember = "VarName";
            //}
        }

        private void LoadHeadings(string survey)
        {
            DataTable headings = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString)) {
                using (SqlDataAdapter sql = new SqlDataAdapter("SELECT Qnum, PreP FROM qrySurveyQuestions WHERE Survey ='" + survey + "' AND VarName LIKE 'Z%' GROUP BY Qnum, PreP ORDER BY Qnum", conn))
                {
                    conn.Open();
                    sql.Fill(headings);
                    conn.Close();

                    cboHeadings.DataSource = headings;
                    cboHeadings.ValueMember = "Qnum";
                    cboHeadings.DisplayMember = "PreP";
                }
            }
        }

        private void LoadExtraFields(string survey)
        {
            SqlDataAdapter sql;

            // load comment types
            sql = new SqlDataAdapter("SELECT NoteType FROM qryVarComments WHERE Survey ='" + survey + "' GROUP BY NoteType", conn);

            DataTable t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();
            lstCommentFields.Items.Clear();
            foreach (DataRow row in t.Rows) { lstCommentFields.Items.Add(row[0]); }
            
            lstCommentFields.ValueMember = "NoteType";
            lstCommentFields.DisplayMember = "NoteType";

            // load comment authors and sources
            sql = new SqlDataAdapter("SELECT DISTINCT NoteInit, Name FROM qryCommentsAll INNER JOIN qrySurveyInfo ON qryCommentsAll.SID = qrySurveyInfo.ID WHERE Survey = '" + survey + "' " +
                    "UNION SELECT DISTINCT NoteInit, Name FROM qryCommentsAll INNER JOIN qrySurveyInfo ON qryCommentsAll.WID = qrySurveyInfo.WaveID WHERE Survey = '" + survey + "'", conn);

            t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();

            lstCommentAuthors.DataSource = t;
            lstCommentAuthors.DisplayMember = "Name";
            lstCommentAuthors.ValueMember = "NoteInit";
            lstCommentAuthors.SetSelected(0, false);

            sql = new SqlDataAdapter("SELECT DISTINCT SourceName FROM qryCommentsAll INNER JOIN qrySurveyInfo ON qryCommentsAll.SID = qrySurveyInfo.ID WHERE Survey = '" + survey + "' " +
                    "UNION SELECT DISTINCT SourceName FROM qryCommentsAll INNER JOIN qrySurveyInfo ON qryCommentsAll.WID = qrySurveyInfo.WaveID WHERE Survey = '" + survey + "'", conn);

            t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();

            foreach (DataRow row in t.Rows) { lstCommentSources.Items.Add(row[0]); }

            // load translation languages
            sql = new SqlDataAdapter("SELECT Lang FROM qryTranslation AS T INNER JOIN qrySurveyQuestions AS SQ ON T.QID = SQ.ID " +
                "WHERE SQ.Survey ='" + survey + "' GROUP BY Lang", conn);

            t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();
            lstTransFields.Items.Clear();
            foreach (DataRow row in t.Rows) { lstTransFields.Items.Add(row[0]); }
            
            lstTransFields.ValueMember = "Lang";
            lstTransFields.DisplayMember = "Lang";

        }

        

        #region Top of Form

        private void AddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the VarNameReport object
            ReportSurvey s;
            try
            {
                s = new ReportSurvey(DBAction.GetSurvey(cboSurveys.SelectedValue.ToString()));
            }catch (Exception ex)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            SR.AddSurvey(s);
            SR.AutoSetPrimary();
            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            if (lstSelectedSurveys.Items.Count >=2 && !tabControlOptions.TabPages.Contains(pgCompareTab)) { tabControlOptions.TabPages.Insert(2,pgCompareTab); }
            gridPrimarySurvey.DataSource = null;
            gridPrimarySurvey.DataSource = SR.Surveys;
            gridPrimarySurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridPrimarySurvey.Refresh();

            gridColumnOrder.DataSource = null;
            gridColumnOrder.DataSource = SR.ColumnOrder;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();

            gridQnumSurvey.DataSource = null;
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();

            if (lstSelectedSurveys.Items.Count > 0)
                tabControlOptions.Visible = true;
        }

        private void RemoveSurvey_Click(object sender, EventArgs e)
        {
            // remove survey from the VarNameReport object
            SR.Surveys.Remove((ReportSurvey)lstSelectedSurveys.SelectedItem);
            SR.AutoSetPrimary();
            // TODO remove all column associated with the survey from the column order collection
            //for (int i = 0 to SR.ColumnOrder.)
            //SR.ColumnOrder.Remove()
            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";
            if (lstSelectedSurveys.Items.Count < 2) { tabControlOptions.TabPages.Remove(pgCompareTab); }
            gridPrimarySurvey.DataSource = null;
            gridPrimarySurvey.DataSource = SR.Surveys;
            gridPrimarySurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridPrimarySurvey.Refresh();

            gridColumnOrder.DataSource = null;
            gridColumnOrder.DataSource = SR.ColumnOrder;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();

            gridQnumSurvey.DataSource = null;
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();

            if (lstSelectedSurveys.Items.Count < 1)
                tabControlOptions.Visible = false;
        }

        private void SelfCompare_Click(object sender, EventArgs e)
        {
            // add another survey with the already selected survey code
           
            ReportSurvey s;
            Survey item = lstSelectedSurveys.SelectedItem as Survey;
            try
            {
                s = new ReportSurvey(DBAction.GetSurvey(item.SurveyCode));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Survey not found.");
                return;
            }
            // add survey to the VarNameReport object
            SR.AddSurvey(s);
            SR.AutoSetPrimary();
            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            if (lstSelectedSurveys.Items.Count >= 2 && !tabControlOptions.TabPages.Contains(pgCompareTab)) { tabControlOptions.TabPages.Insert(2, pgCompareTab); }
            gridPrimarySurvey.DataSource = null;
            gridPrimarySurvey.DataSource = SR.Surveys;
            gridPrimarySurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridPrimarySurvey.Refresh();

            gridColumnOrder.DataSource = null;
            gridColumnOrder.DataSource = SR.ColumnOrder;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();

            gridQnumSurvey.DataSource = null;
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();

            if (lstSelectedSurveys.Items.Count > 0)
                tabControlOptions.Visible = true;
            // set focus to calendar
            dateBackend.Focus();

        }

        #endregion

        #region Filters Tab
        // TODO do not add duplicates
        // TODO check for null when removing
        // Add the selected prefix to the Current Survey's prefix list and refresh the Prefix listbox
        private void AddPrefix_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Prefixes.Add(cboPrefixes.SelectedValue.ToString());
            lstPrefixes.DataSource = null;
            lstPrefixes.DataSource = CurrentSurvey.Prefixes;
        }

        // Remove the selected prefix from the Current Survey's prefix list and refresh the Prefix listbox
        private void RemovePrefix_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Prefixes.Remove(lstPrefixes.SelectedValue.ToString());
            lstPrefixes.DataSource = null;
            lstPrefixes.DataSource = CurrentSurvey.Prefixes;
        }

        private void AddVarName_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Varnames.Add(cboVarNames.SelectedValue.ToString());
            lstSelectedVarNames.DataSource = null;
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
        }

        private void RemoveVarName_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentSurvey.Varnames.Remove(lstSelectedVarNames.SelectedValue.ToString());
            }
            catch (NullReferenceException ne)
            {
            }
            lstSelectedVarNames.DataSource = null;
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
        }

        private void cmdAddHeading_Click(object sender, EventArgs e)
        {
            // cast the selected item as a datarowview
            DataRowView item = (DataRowView) cboHeadings.SelectedItem;
            // create a new heading object and fill its members
            Heading h = new Heading
            {
             
                Qnum = (string)item[0],
                Prep = (string)item[1]
            };
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
            try
            {
                CurrentSurvey.Headings.Remove((Heading)lstHeadings.SelectedItem);
            }
            catch (NullReferenceException ne)
            {
            }
            lstHeadings.DataSource = null;
            lstHeadings.DataSource = CurrentSurvey.Headings;
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
        private void TransFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.TransFields.Clear();

            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
            }
        }

        private void CommentFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentFields.Clear();

            for (int i = 0; i < lstCommentFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentFields.Add(lstCommentFields.SelectedItems[i].ToString());
            }
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

        private void CorrectedWordings_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.Corrected = c.Checked;
        }

        private void BlankCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            SR.LayoutOptions.BlankColumn = c.Checked;
        }

        private void FilterCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.FilterCol = c.Checked;
        }

        private void DomainCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.DomainLabelCol = c.Checked;
        }

        private void TopicCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.TopicLabelCol = c.Checked;
        }

        private void ContentCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.ContentLabelCol = c.Checked;
        }

        private void VarLabelCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.VarLabelCol = c.Checked;
        }

        private void ProductCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.ProductLabelCol = c.Checked;
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

            SR.SurveyCompare.HighlightStyle = (HStyle)sel;
        }

        private void ShowDeletedQuestionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chkReInsertDeletions.Visible = chkShowDeletedQuestions.Checked;
        }

        #endregion

        #region Order and Numbering tab

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
        

        // Once the gridview is bound, hide unecessary columns and rename SurveyCode to Survey
        private void ColumnOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int i = 0; i < gridColumnOrder.ColumnCount; i++)
            //{
            //    switch (gridColumnOrder.Columns[i].Name)
            //    {
            //        case "SurveyCode":
            //            gridColumnOrder.Columns[i].HeaderText = "Survey";
            //            break;
            //        case "Backend":
            //        case "Corrected":
            //        case "Primary":
            //            break;
            //        default:
            //            gridColumnOrder.Columns[i].Visible = false;
            //            break;
            //    }
            //}
        }

        
        private void EnumerationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32 (r.Tag);

            SR.Numbering = (Enumeration) sel;
            
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
            //SR.RepeatedFields.Clear();
            //foreach (Survey s in SR.Surveys)
            //{
            //    s.RepeatedFields.Clear();
            //}
            //for (int i = 0; i < lstRepeatedFields.SelectedItems.Count; i++)
            //{
            //    SR.RepeatedFields.Add(lstRepeatedFields.SelectedItems[i].ToString());
            //    foreach(Survey s in SR.Surveys)
            //    {
            //        s.RepeatedFields.Add(lstRepeatedFields.SelectedItems[i].ToString());
            //    }
            //}
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





        #endregion

       
    }
}
