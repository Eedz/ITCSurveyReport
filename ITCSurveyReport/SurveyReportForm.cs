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

namespace ITCSurveyReport
{
    public partial class SurveyReportForm : Form
    {
        SurveyReport SR;
        UserPrefs UP;
        Survey CurrentSurvey;
        TabPage pgCompareTab;
        // background color RGB values
        int backColorR = 55;
        int backColorG = 170;
        int backColorB = 136;

        SqlDataAdapter sql;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);

        
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

            SR = new SurveyReport();
            UP = new UserPrefs();
            SR.FileName = UP.ReportPath;
            surveyReportBindingSource.DataSource = SR;
        }

        private void cmdCheckOptions_Click(object sender, EventArgs e)
        {
            
            if (lstSelectedSurveys.SelectedIndex != -1)
            {
                int result;
                //MessageBox.Show(SR.ToString());
                txtOptions.Text = SR.ToString();
                result = SR.GenerateSurveyReport();
                switch (result)
                {
                    case 0: // no errors
                        break;
                    case 1:
                        MessageBox.Show("One or more surveys contain no records.");
                        break;
                    default:
                        break;
                }

                surveyView.DataSource = null;
                surveyView.DataSource = SR.Surveys[0].finalTable;
                surveyView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                surveyView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                if (SR.Surveys.Count > 1)
                {
                    surveyView2.DataSource = null;
                    surveyView2.DataSource = SR.Surveys[1].finalTable;
                    surveyView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    surveyView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                gridFinalReport.DataSource = null;
                gridFinalReport.DataSource = SR.reportTable;
                gridFinalReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridFinalReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void cboSurveys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmdAddSurvey.PerformClick();
        }

        private void lstSelectedSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItem != null)
            {
                CurrentSurvey = (Survey)lstSelectedSurveys.SelectedItem;
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

            // varnames
            LoadVarNames(CurrentSurvey.SurveyCode);
            lstSelectedVarNames.DataBindings.Clear();
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;

            // fields
            LoadExtraFields(CurrentSurvey.SurveyCode);

            // standard fields
            lstStdFields.SelectedItems.Clear();
            foreach (object item in CurrentSurvey.StdFields)
            {
                for (int i = 0; i < lstStdFields.Items.Count; i++)
                    if (item.ToString().Equals(lstStdFields.Items[i].ToString()))
                        lstStdFields.SetSelected(i, true);
                    
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

        private void LoadPrefixes(String survey)
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

        private void LoadVarNames(String survey)
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

        private void LoadExtraFields(String survey)
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
        private void cmdAddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            Survey s = new Survey(cboSurveys.SelectedValue.ToString());

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
            gridColumnOrder.DataSource = SR.Surveys;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();

            gridQnumSurvey.DataSource = null;
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();

            if (lstSelectedSurveys.Items.Count > 0)
                tabControlOptions.Visible = true;
        }

        private void cmdRemoveSurvey_Click(object sender, EventArgs e)
        {
            // remove survey from the SurveyReport object
            SR.Surveys.Remove((Survey)lstSelectedSurveys.SelectedItem);
            SR.AutoSetPrimary();

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
            gridColumnOrder.DataSource = SR.Surveys;
            gridColumnOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridColumnOrder.Refresh();

            gridQnumSurvey.DataSource = null;
            gridQnumSurvey.DataSource = SR.Surveys;
            gridQnumSurvey.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridQnumSurvey.Refresh();

            if (lstSelectedSurveys.Items.Count < 1)
                tabControlOptions.Visible = false;
        }

        

        #endregion

        #region Filters Tab
        // Add the selected prefix to the Current Survey's prefix list and refresh the Prefix listbox
        private void cmdAddPrefix_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Prefixes.Add(cboPrefixes.SelectedValue.ToString());
            lstPrefixes.DataSource = null;
            lstPrefixes.DataSource = CurrentSurvey.Prefixes;
        }

        // Remove the selected prefix from the Current Survey's prefix list and refresh the Prefix listbox
        private void cmdRemovePrefix_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Prefixes.Remove(lstPrefixes.SelectedValue.ToString());
            lstPrefixes.DataSource = null;
            lstPrefixes.DataSource = CurrentSurvey.Prefixes;
        }

        private void cmdAddVarName_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Varnames.Add(cboVarNames.SelectedValue.ToString());
            lstSelectedVarNames.DataSource = null;
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
        }

        private void cmdRemoveVarName_Click(object sender, EventArgs e)
        {
            CurrentSurvey.Varnames.Remove(lstSelectedVarNames.SelectedValue.ToString());
            lstSelectedVarNames.DataSource = null;
            lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;
        }
        #endregion

        #region Fields Tab
        //

        private void lstStdFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.StdFields.Clear();
            for (int i = 0; i < lstStdFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.StdFields.Add(lstStdFields.SelectedItems[i].ToString());
            }
        }

       
        private void cmdToggleExtraFields_Click(object sender, EventArgs e)
        {
            lblCommentFields.Visible = true;
            lstCommentFields.Visible = true;
            
            lblTransFields.Visible = true;
            lstTransFields.Visible = true;

            panelCommentFilters.Visible = true;
            panelOtherFields.Visible = true;

        }
        private void lstTransFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.TransFields.Clear();

            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
            }
        }

        private void lstCommentFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentFields.Clear();

            if (lstCommentFields.SelectedItems.Count > 0)
                CurrentSurvey.CommentCol = true;

            for (int i = 0; i < lstCommentFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.CommentFields.Add(lstCommentFields.SelectedItems[i].ToString());
            }
        }

        private void dateTimeCommentsSince_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker d = sender as DateTimePicker;
            if (d.Checked)
                CurrentSurvey.CommentDate = d.Value;
        }

        private void lstCommentAuthors_Click(object sender, EventArgs e)
        {
            
            CurrentSurvey.CommentAuthors.Clear();

            for (int i = 0; i < lstCommentAuthors.SelectedItems.Count; i++)
            {
                DataRowView r = (DataRowView) lstCommentAuthors.SelectedItems[i];
                CurrentSurvey.CommentAuthors.Add((int)r[0]);
            }
        }

        private void lstCommentSources_Click(object sender, EventArgs e)
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

        private void chkBlankCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            SR.LayoutOptions.BlankColumn = c.Checked;
        }

        private void chkFilterCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.FilterCol = c.Checked;
        }

        private void chkDomainCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.DomainLabelCol = c.Checked;
        }

        private void chkTopicCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.TopicLabelCol = c.Checked;
        }

        private void chkContentCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.ContentLabelCol = c.Checked;
        }

        private void chkVarLabelCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.VarLabelCol = c.Checked;
        }

        private void chkProductCol_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            CurrentSurvey.ProductLabelCol = c.Checked;
        }

        #endregion

        #region Comparison Tab
        // Once the gridview is bound, hide unecessary columns and rename SurveyCode to Survey
        private void gridPrimarySurvey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
        private void gridPrimarySurvey_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridPrimarySurvey.IsCurrentCellDirty)
                gridPrimarySurvey.CommitEdit(DataGridViewDataErrorContexts.Commit);            
        }

        // If the cell that was modified is in the Primary column, uncheck the other rows so that there is always 
        // a single Primary row
        private void gridPrimarySurvey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        #endregion

        #region Order and Numbering tab

        // Once the gridview is bound, hide unecessary columns and rename SurveyCode to Survey
        private void gridQnumSurvey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
        private void gridQnumSurvey_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridQnumSurvey.IsCurrentCellDirty)
                gridQnumSurvey.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // If the cell that was modified is in the Qnum column, uncheck the other rows so that there is always 
        // a single Primary row
        private void gridQnumSurvey_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
        private void gridColumnOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < gridColumnOrder.ColumnCount; i++)
            {
                switch (gridColumnOrder.Columns[i].Name)
                {
                    case "SurveyCode":
                        gridColumnOrder.Columns[i].HeaderText = "Survey";
                        break;
                    case "Backend":
                    case "Corrected":
                    case "Primary":
                        break;
                    default:
                        gridColumnOrder.Columns[i].Visible = false;
                        break;
                }
            }
        }

        
        private void enumerationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32 (r.Tag);

            SR.Numbering = (Enumeration) sel;
            
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
