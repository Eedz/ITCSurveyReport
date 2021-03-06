﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace ITCSurveyReport
{
    class Comparison
    {
        // data tables
        public DataTable changes;

        // general comparison options
        bool selfCompare;
        bool doCompare; // 

        //
        bool hidePrimary;
        bool showDeletedFields;
        bool showDeletedQuestions;
        bool reInsertDeletions;
        bool hideIdenticalWordings;
        bool showOrderChanges;
        bool beforeAfterReport;
        bool ignoreSimilarWords;
        bool convertTrackedChanges;
        bool matchOnRename;

        // ordercomparisons
        bool includeWordings;
        bool bySection;

        // highlight options
        public enum HScheme { Sequential = 1, AcrossCountry = 2 }
        public enum HStyle { Classic = 1, TrackedChanges = 2 }
        bool highlight;
        HStyle highlightStyle;
        HScheme highlightScheme;
        bool highlightNR;
        bool hybridHighlight;

        public Comparison()
        {
            selfCompare = false;
            doCompare = false;

            hidePrimary = false;
            showDeletedFields = false;
            showDeletedQuestions = false;
            reInsertDeletions = false;
            hideIdenticalWordings = false;
            showOrderChanges = false;
            beforeAfterReport = false;
            ignoreSimilarWords = false;
            convertTrackedChanges = false;
            matchOnRename = false;

            includeWordings = false;
            bySection = false;

            highlight = false;
            highlightStyle = HStyle.Classic;
            highlightScheme = HScheme.Sequential;
            highlightNR = true;
            hybridHighlight = false;
        }

        public void CompareByVarName(List<Survey> SurveyList) {
            DataTable primary = new DataTable();
            DataTable other = new DataTable();

            foreach (Survey s in SurveyList)
            {
                if (s.Primary) {
                    primary = s.rawTable;
                    break;
                }
            }

            foreach (Survey s in SurveyList)
            {
                if (!s.Primary) { other = s.rawTable; }

                CompareSurveyTables(primary, other);
            }

            

           

        }



        public void CompareSurveyTables (DataTable dt1, DataTable dt2)
        {
            foreach (DataRow rPrime in dt1.Rows)
            {
                foreach (DataRow rOther in dt2.Rows)
                {
                    if (rOther["refVarName"].Equals(rPrime["refVarName"]))
                    {
                        CompareWordings(rPrime, rOther, "PreP");
                        CompareWordings(rPrime, rOther, "PreI");
                        CompareWordings(rPrime, rOther, "PreA");
                        CompareWordings(rPrime, rOther, "LitQ");
                        CompareWordings(rPrime, rOther, "PstI");
                        CompareWordings(rPrime, rOther, "PstP");
                        CompareWordings(rPrime, rOther, "RespOptions");
                        if (highlightNR) { CompareWordings(rPrime, rOther, "NRCodes"); }
                    }
                }
            }
        }

        public void CompareWordings (DataRow rPrime, DataRow rOther, String fieldname)
        {
            String highlightStartNew;
            String highlightEndNew;
            String highlightStartDiff;
            String highlightEndDiff;
            String highlightStartMiss;
            String highlightEndMiss;

            bool highlightVar;
            bool highlightWord;

            if (highlightStyle == HStyle.Classic)
            {
                if (highlightScheme == HScheme.Sequential)
                {
                    highlightVar = true;
                    highlightWord = true;
                } else if (highlightScheme == HScheme.AcrossCountry)
                {
                    highlightVar = true;
                    highlightWord = false;
                }
                highlightStartNew = "[yellow]";
                highlightEndNew = "[/yellow]";

                highlightStartDiff = "[brightgreen]";
                highlightEndDiff = "[/brightgreen]";

                highlightStartMiss = "[t][s]";
                highlightEndMiss = "[/s][/t]";
            }
            else if (highlightStyle == HStyle.TrackedChanges)
            {

            }
            

            if (rPrime[fieldname].Equals(rOther[fieldname])){

            }
            else
            {
                if (rOther[fieldname].Equals("") && showDeletedFields)
                {
                    rOther[fieldname] = "[t][s]" + rPrime[fieldname] + "[/t][/s]";
                }else if (rPrime[fieldname].Equals(""))
                {
                    rOther[fieldname] = "[yellow]" + rOther[fieldname] + "[/yellow]";
                }
                else
                {
                    if (hybridHighlight)
                    {
                        // tracked changes  and brightgreen
                        rOther[fieldname] = "[brightgreen]" + rOther[fieldname] + "[/brightgreen]";
                    }
                    else
                    {
                        rOther[fieldname] = "[brightgreen]" + rOther[fieldname] + "[/brightgreen]";
                    }
                }
            }
            rOther.AcceptChanges();
        }

        #region LINQ attempts
        // Marks differences between 2 tables in the specified field
        // Get all rows that differ in the specified field. Then, insert [brightgreen] tags around the entire field.
        public void CompareField<T>(DataTable dt1, DataTable dt2, String fieldname)
        {
            var results = from table2 in dt2.AsEnumerable()
                          join table1 in dt1.AsEnumerable() on table2.Field<string>("refVarName") equals table1.Field<string>("refVarName")
                          where !table2.Field<T>(fieldname).Equals(table1.Field<T>(fieldname))
                          select table2;

            foreach (DataRow r in results)
            {
                if (r[fieldname].Equals(""))
                {
                    // blue?
                    r[fieldname] = "[yellow]" + r[fieldname] + "[/yellow]";
                }
                else
                {
                    r[fieldname] = "[brightgreen]" + r[fieldname] + "[/brightgreen]";
                }

                r.AcceptChanges();

            }
        }

        // Marks unique variables 
        public void CompareVars(DataTable dt1, DataTable dt2)
        {
            var results = from table2 in dt2.AsEnumerable()
                          join table1 in dt1.AsEnumerable() on table2.Field<string>("refVarName") equals table1.Field<string>("refVarName") into a
                          from table1 in a.DefaultIfEmpty()
                          where table1 == null
                          select table2;

            foreach (DataRow r in results)
            {
                r["PreP"] = "[yellow]" + r["PreP"] + "[/yellow]";
                r["PreI"] = "[yellow]" + r["PreI"] + "[/yellow]";
                r["PreA"] = "[yellow]" + r["PreA"] + "[/yellow]";
                r["LitQ"] = "[yellow]" + r["LitQ"] + "[/yellow]";
                r["PstI"] = "[yellow]" + r["PstI"] + "[/yellow]";
                r["PstP"] = "[yellow]" + r["PstP"] + "[/yellow]";
                r["RespOptions"] = "[yellow]" + r["RespOptions"] + "[/yellow]";
                r["NRCodes"] = "[yellow]" + r["NRCodes"] + "[/yellow]";
                r.AcceptChanges();

            }
        }
        #endregion

        public bool DoCompare { get => doCompare; set => doCompare = value; }
        public bool SelfCompare { get => selfCompare; set => selfCompare = value; }

        [CategoryAttribute("Layout Options"), DescriptionAttribute("Hide the primary survey.")]
        public bool HidePrimary { get => hidePrimary; set => hidePrimary = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Show deleted fields in blue.")]
        public bool ShowDeletedFields { get => showDeletedFields; set => showDeletedFields = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Show deleted questions (depends on Scheme).")]
        public bool ShowDeletedQuestions { get => showDeletedQuestions; set => showDeletedQuestions = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Re-insert deleted questions after the last common question.")]
        public bool ReInsertDeletions { get => reInsertDeletions; set => reInsertDeletions = value; }
        [CategoryAttribute("Layout Options"), DescriptionAttribute("Hide identical wording fields.")]
        public bool HideIdenticalWordings { get => hideIdenticalWordings; set => hideIdenticalWordings = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight changes to the order or questions.")]
        public bool ShowOrderChanges { get => showOrderChanges; set => showOrderChanges = value; }
        [CategoryAttribute("Layout Options"), DescriptionAttribute("Create a 3-column report in old-marked-new order.")]
        public bool BeforeAfterReport { get => beforeAfterReport; set => beforeAfterReport = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Ignore words with alternate spellings (honor/honour).")]
        public bool IgnoreSimilarWords { get => ignoreSimilarWords; set => ignoreSimilarWords = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Convert tracked changes highlighting to actual tracked changes.")]
        public bool ConvertTrackedChanges { get => convertTrackedChanges; set => convertTrackedChanges = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Try to match questions based on previous names.")]
        public bool MatchOnRename { get => matchOnRename; set => matchOnRename = value; }

        

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight differences between surveys."), DefaultValueAttribute(true)]
        public bool Highlight { get => highlight; set => highlight = value; }

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Classic (Green, Yellow, Blue) or Tracked Changes."), DisplayNameAttribute("Style"), DefaultValueAttribute(1)]
        public HStyle HighlightStyle { get => highlightStyle; set => highlightStyle = value; }

        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Determines how deleted questions are shown."), DisplayNameAttribute("Scheme"),DefaultValueAttribute(1)]
        public HScheme HighlightScheme { get => highlightScheme; set => highlightScheme = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("Highlight changes in the Non-response field."), DefaultValueAttribute(true)]
        public bool HighlightNR { get => highlightNR; set => highlightNR = value; }
        [CategoryAttribute("Highlighting Options"), DescriptionAttribute("For wording differences, use both Green and Tracked Changes."), DefaultValueAttribute(false)]
        public bool HybridHighlight { get => hybridHighlight; set => hybridHighlight = value; }

        [CategoryAttribute("Order Comparisons"), DescriptionAttribute("Include a column for the wordings."), DefaultValueAttribute(false)]
        public bool IncludeWordings { get => includeWordings; set => includeWordings = value; }
        [CategoryAttribute("Order Comparisons"), DescriptionAttribute("Display the report by section."), DefaultValueAttribute(false)]
        public bool BySection { get => bySection; set => bySection = value; }


    }
}
