﻿using System;
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

            //chkDoCompare.DataBindings.Add("Checked", surveyReportBindingSource, "SurveyCompare.DoCompare");


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
            surveyReportBindingSource.DataSource = SR;
            
            
        }

        
               

        private void cmdCheckOptions_Click(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedIndex != -1)
            {
                MessageBox.Show(SR.ToString());
                SR.GenerateSurveyReport();
                
                
                surveyView.DataSource = CurrentSurvey.finalTable;
                Utilities.Export_Data_To_Word(surveyView, "test.doc");
            }
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
            
            //MessageBox.Show("Loading survey: " + sel.SurveyCode);
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

            //fields
            LoadExtraFields(CurrentSurvey.SurveyCode);
            // standard fields
            lstSelStdFields.DataSource = CurrentSurvey.StdFields;
            chkCorrected.DataBindings.Clear();
            chkCorrected.DataBindings.Add("Checked", CurrentSurvey, "Corrected");
            // extra fields
            chkFilterCol.DataBindings.Clear();
            chkFilterCol.DataBindings.Add("Checked", CurrentSurvey, "FilterCol");
            chkVarLabelCol.DataBindings.Clear();
            chkVarLabelCol.DataBindings.Add("Checked", CurrentSurvey, "VarLabelCol");
            
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
            sql = new SqlDataAdapter("SELECT NoteType FROM qryVarComments WHERE Survey ='" + survey + "' GROUP BY NoteType", conn);

            DataTable t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();
            foreach (DataRow row in t.Rows) { lstCommentFields.Items.Add(row[0]); }
            
            lstCommentFields.ValueMember = "NoteType";
            lstCommentFields.DisplayMember = "NoteType";

            sql = new SqlDataAdapter("SELECT Lang FROM qryTranslation AS T INNER JOIN qrySurveyQuestions AS SQ ON T.QID = SQ.ID " +
                "WHERE SQ.Survey ='" + survey + "' GROUP BY Lang", conn);

            t = new DataTable();

            conn.Open();
            sql.Fill(t);
            conn.Close();
            foreach (DataRow row in t.Rows) { lstTransFields.Items.Add(row[0]); }
            
            lstTransFields.ValueMember = "Lang";
            lstTransFields.DisplayMember = "Lang";
        }

        

        #region Top of Form
        private void cmdAddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            Survey s = new Survey()
            {
                SurveyCode = cboSurveys.SelectedValue.ToString()
            };
            SR.AddSurvey(s);
            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            if (lstSelectedSurveys.Items.Count >=2) { tabControlOptions.TabPages.Insert(2,pgCompareTab); }
        }

        private void cmdRemoveSurvey_Click(object sender, EventArgs e)
        {
            // remove survey from the SurveyReport object
            SR.Surveys.Remove((Survey)lstSelectedSurveys.SelectedItem);

            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";
            if (lstSelectedSurveys.Items.Count < 2) { tabControlOptions.TabPages.Remove(pgCompareTab); }
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
        private void lstStdFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CurrentSurvey.StdFields.Add(lstStdFields.SelectedItem.ToString());
            lstStdFields.Items.Remove(lstStdFields.SelectedItem);
            lstSelStdFields.DataSource = null;
            lstSelStdFields.DataSource = CurrentSurvey.StdFields;
        }

        private void lstSelStdFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstStdFields.Items.Add(lstSelStdFields.SelectedValue.ToString());
            CurrentSurvey.StdFields.Remove(lstSelStdFields.SelectedValue.ToString());
            lstSelStdFields.DataSource = null;
            lstSelStdFields.DataSource = CurrentSurvey.StdFields;
        }
        private void cmdToggleExtraFields_Click(object sender, EventArgs e)
        {
            lblCommentFields.Visible = true;
            lstCommentFields.Visible = true;
            lstSelCommentFields.Visible = true;
            lblTransFields.Visible = true;
            lstTransFields.Visible = true;
            lstSelTransFields.Visible = true;
            dateTimeCommentsSince.Visible = true;
            chkFilterCol.Visible = true;
            chkVarLabelCol.Visible = true;
            chkBlankCol.Visible = true;

        }
        private void lstCommentFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CurrentSurvey.CommentFields.Add(lstCommentFields.SelectedItem.ToString());
            lstCommentFields.Items.Remove(lstCommentFields.SelectedItem);
            lstSelCommentFields.DataSource = null;
            lstSelCommentFields.DataSource = CurrentSurvey.CommentFields;
        }

        private void lstSelCommentFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstCommentFields.Items.Add(lstSelCommentFields.SelectedValue.ToString());
            CurrentSurvey.CommentFields.Remove(lstSelCommentFields.SelectedValue.ToString());
            lstSelCommentFields.DataSource = null;
            lstSelCommentFields.DataSource = CurrentSurvey.CommentFields;
        }

        private void lstTransFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CurrentSurvey.TransFields.Add(lstTransFields.SelectedItem.ToString());
            lstTransFields.Items.Remove(lstTransFields.SelectedItem);
            lstSelTransFields.DataSource = null;
            lstSelTransFields.DataSource = CurrentSurvey.TransFields;
        }

        private void lstSelTransFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstTransFields.Items.Add(lstSelTransFields.SelectedValue.ToString());
            CurrentSurvey.TransFields.Remove(lstSelTransFields.SelectedValue.ToString());
            lstSelTransFields.DataSource = null;
            lstSelTransFields.DataSource = CurrentSurvey.TransFields;
        }





        #endregion

        #region Comparison Tab


        #endregion

       
    }
}
