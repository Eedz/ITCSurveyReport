﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ITCSurveyReportLib
{
    /// <summary>
    /// Represents a Survey that is to be used in a report. Additional properties are to used to specify which parts of the survey are to be reported.
    /// </summary>
    public class ReportSurvey : Survey
    {
        // report properties
        public int ID { get; set; }                         // unique id for report, NOT the database ID
        public DateTime Backend { get ; set; }               // date of backup

        // question filters
        public int QRangeLow { get; set; }
        public int QRangeHigh { get; set; }
        public List<string> Prefixes { get; set; }
        public List<Heading> Headings { get ; set; }
        public List<string> Varnames { get; set; }

        // comment filters
        public DateTime? CommentDate { get; set; }
        public List<int> CommentAuthors { get; set; }
        public List<string> CommentSources { get; set; }
        public List<string> CommentFields { get; set; }     // comment types

        // translation languages
        public List<string> TransFields { get; set; }

        // standard field options
        public List<string> StdFields { get; }
        public List<string> StdFieldsChosen { get; set; }
        public List<string> RepeatedFields { get; set; }

        // additional info 
        public bool VarLabelCol { get; set; }
        public bool DomainLabelCol { get; set; }
        public bool TopicLabelCol { get; set; }
        public bool ContentLabelCol { get; set; }
        public bool ProductLabelCol { get; set; }
        public bool FilterCol { get; set; }

        // attributes
        public bool Primary { get; set; }                   // true if this is the primary survey
        public bool Qnum { get; set; }                      // true if this is the qnum-defining survey
        public bool Corrected { get; set; }                 // true if this uses corrected wordings
        public bool Marked { get; set; }                    // true if the survey contains tracked changes (for 3-way report)

        
        #region Constructors
        
        public ReportSurvey() :base()
        {
            Backend = DateTime.Today;
            
            Prefixes = new List<string>();
            Varnames = new List<string>();
            Headings = new List<Heading>();

            CommentDate = null;
            CommentAuthors = new List<int>();
            CommentSources = new List<string>();

            RepeatedFields = new List<string>();
            CommentFields = new List<string>();
            TransFields = new List<string>();

            StdFields = new List<string>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };

            StdFieldsChosen = new List<string>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };
            
        }

        /// <summary>
        /// Constructor for copying a base version of a survey.
        /// </summary>
        /// <param name="s"></param>
        public ReportSurvey(Survey s)
        {
            // copy values from base 
            SID = s.SID;
            SurveyCode = s.SurveyCode;
            Title = s.Title;
            Languages = s.Languages;
            Groups = s.Groups;
            Mode = s.Mode;
            CountryCode = s.CountryCode;
            WebName = s.WebName;

            EssentialList = s.EssentialList;
   
            questions = s.questions;
            correctedQuestions = s.correctedQuestions;

            // initialize derived properties
            Backend = DateTime.Today;

            Prefixes = new List<string>();
            Varnames = new List<string>();
            Headings = new List<Heading>();

            CommentDate = null;
            CommentAuthors = new List<int>();
            CommentSources = new List<string>();

            RepeatedFields = new List<string>();
            CommentFields = new List<string>();
            TransFields = new List<string>();

            StdFields = new List<string>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };

            StdFieldsChosen = new List<string>
            {
                "PreP",
                "PreI",
                "PreA",
                "LitQ",
                "RespOptions",
                "NRCodes",
                "PstI",
                "PstP"
            };
        }

        #endregion

        #region Methods and Functions
        /// <summary>
        /// Returns a WHERE clause restricting records to selected question range, prefix list and/or varname list.
        /// </summary>
        /// <returns>String to be used right after the WHERE keyword.</returns>
        public string GetQuestionFilter()
        {
            string filter = "";

            filter = GetQRangeFilter();

            if (Prefixes != null && Prefixes.Count != 0) { filter += " AND SUBSTRING(VarName,1,2) IN ('" + string.Join("','", Prefixes) + "')"; }
            if (Varnames != null && Varnames.Count != 0) { filter += " AND VarName IN ('" + string.Join("','", Varnames) + "')"; }
            if (Headings != null && Headings.Count != 0) { filter += " AND (" + GetHeadingFilter() + ")"; }
            filter = Utilities.TrimString(filter, " AND ");
            return filter;
        }

        /// <summary>
        /// Returns a filter expression restricting the range of Qnums.
        /// </summary>
        /// <returns></returns>
        private string GetQRangeFilter()
        {
            string filter = "";
            if (QRangeLow == 0 && QRangeHigh == 0) { return ""; }
            if (QRangeLow <= QRangeHigh)
            {
                filter = "Qnum >= '" + QRangeLow.ToString().PadLeft(3, '0') + "' AND Qnum <= '" + QRangeHigh.ToString().PadLeft(3, '0') + "'";
            }
            return filter;
        }

        /// <summary>
        /// Returns a WHERE condition based on the chosen headings. TEST use first 3 digits of heading
        /// </summary>
        /// <returns></returns>
        private string GetHeadingFilter()
        {
            List<SurveyQuestion> raw;
            string currentVar;
            string filter = "";
            foreach (Heading h in Headings)
            {
                raw = questions.FindAll(x => Int32.Parse(x.Qnum.Substring(0, 3)) > Int32.Parse(h.Qnum.Substring(0, 3)));
                
                filter += " OR Qnum >= '" + h.Qnum + "'";
                foreach (SurveyQuestion r in raw)
                {
                    currentVar = r.refVarName;
                    // when we reach the next heading, add its qnum to the end of the filter expression
                    if (currentVar.StartsWith("Z"))
                    {
                        filter += " AND Qnum < '" + r.Qnum + "'";
                        break;
                    }
                }

            }
            filter = Utilities.TrimString(filter, " OR ");
            return filter;
        }

        /// <summary>
        /// Remove repeated values from the wording fields (PreP, PreI, PreA, LitQ, PstI, Pstp, RespOptions, NRCodes) unless they are requested. 
        /// This applies only to series questions, which are questions whose Qnum ends in a letter.
        /// </summary>
        public void RemoveRepeats()
        {
            int mainQnum = 0;
            String currQnum = "";
            int currQnumInt = 0;
            bool firstRow = true;
            bool removeAll = false;
            SurveyQuestion refQ = null; // this array will hold the 'a' question's fields

            // only try to remove repeats if there are more than 0 rows
            if (questions.Count == 0) return;

            // sort questions by Qnum
            questions.Sort((x, y) => x.Qnum.CompareTo(y.Qnum));


            //
            foreach (SurveyQuestion sq in questions)
            {
                currQnum = sq.Qnum;
                if (currQnum.Length != 4) { continue; }

                // get the integer value of the current qnum
                int.TryParse(currQnum.Substring(0, 3), out currQnumInt);

                // if this row is in table format, we need to remove all repeats, regardless of repeated designations
                if (sq.TableFormat)
                    removeAll = true;
                else
                    removeAll = false;

                // if this is a non-series row, the first member of a series, the first row in the report, or a new Qnum, make this row the reference row
                if (currQnum.Length == 3 || (currQnum.EndsWith("a")) || firstRow || currQnumInt != mainQnum)
                {
                    mainQnum = currQnumInt;
                    // copy the current question's contents into a new object for reference
                    refQ = new SurveyQuestion
                    {
                        PreP = sq.PreP,
                        PreI = sq.PreI,
                        PreA = sq.PreA,
                        LitQ = sq.LitQ,
                        PstI = sq.PstI,
                        PstP = sq.PstP,
                        RespOptions = sq.RespOptions,
                        NRCodes = sq.NRCodes
                    };
                }
                else
                {
                    // if we are inside a series, compare the wording fields to the reference question
                    // if the current column is a standard wording column and has not been designated as a repeated field, compare wordings
                    if ((StdFields.Contains("PreP") && !RepeatedFields.Contains("PreP")) || removeAll)
                    {
                        // if the current question's wording field matches the reference question's, clear it. 
                        // otherwise, set the reference question's field to the current question's field
                        // this will cause a new reference point for that particular field, but not the fields that were identical to the original reference question
                        if (Utilities.RemoveTags(sq.PreP).Equals(Utilities.RemoveTags(refQ.PreP)))
                            sq.PreP = "";
                        else
                            refQ.PreP = sq.PreP;
                    }
                    // PreI
                    if ((StdFields.Contains("PreI") && !RepeatedFields.Contains("PreI")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.PreI).Equals(Utilities.RemoveTags(refQ.PreI)))
                            sq.PreI = "";
                        else
                            refQ.PreI = sq.PreI;
                    }
                    // PreA
                    if ((StdFields.Contains("PreA") && !RepeatedFields.Contains("PreA")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.PreA).Equals(Utilities.RemoveTags(refQ.PreA)))
                            sq.PreA = "";
                        else
                            refQ.PreA = sq.PreA;
                    }
                    // LitQ
                    if ((StdFields.Contains("LitQ") && !RepeatedFields.Contains("LitQ")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.LitQ).Equals(Utilities.RemoveTags(refQ.LitQ)))
                            sq.LitQ = "";
                        else
                            refQ.LitQ = sq.LitQ;
                    }
                    // PstI
                    if ((StdFields.Contains("PstI") && !RepeatedFields.Contains("PstI")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.PstI).Equals(Utilities.RemoveTags(refQ.PstI)))
                            sq.PstI = "";
                        else
                            refQ.PstI = sq.PstI;
                    }
                    // RespOptions
                    if ((StdFields.Contains("RespOptions") && !RepeatedFields.Contains("RespOptions")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.RespOptions).Equals(Utilities.RemoveTags(refQ.RespOptions)))
                            sq.RespOptions = "";
                        else
                            refQ.RespOptions = sq.RespOptions;
                    }
                    // NRCodes
                    if ((StdFields.Contains("NRCodes") && !RepeatedFields.Contains("NRCodes")) || removeAll)
                    {
                        if (Utilities.RemoveTags(sq.NRCodes).Equals(Utilities.RemoveTags(refQ.NRCodes)))
                            sq.NRCodes = "";
                        else
                            refQ.NRCodes = sq.NRCodes;
                    }


                }

                firstRow = false; // after once through the loop, we are no longer on the first row
            }
        }

        /// <summary>
        /// Remove repeated values from the wording fields (PreP, PreI, PreA, LitQ, PstI, Pstp, RespOptions, NRCodes) unless they are requested. 
        /// This applies only to series questions, which are questions whose Qnum ends in a letter.
        /// </summary>
        public void RemoveRepeatsTC()
        {
            string mainTopic = "";
            string mainContent = "";
            string currTopic = "";
            string currContent = "";

            bool firstRow = true;
            SurveyQuestion refQ = null;// this will hold the 'a' question's fields

            // only try to remove repeats if there are more than 0 rows
            if (questions.Count == 0) return;

            // sort questions by Qnum
            questions.Sort((x, y) => x.Qnum.CompareTo(y.Qnum));

            foreach (SurveyQuestion sq in questions)
            {
                currTopic = sq.TopicLabel;
                currContent = sq.ContentLabel;

                // if this is a non-series row, the first member of a series, the first row in the report, or a new Qnum, make this row the reference row
                if (!currTopic.Equals(mainTopic) || (!currContent.Equals(mainContent)) || firstRow)
                {
                    mainTopic = currTopic;
                    mainContent = currContent;
                    // copy the row's contents into an array
                    refQ = new SurveyQuestion
                    {
                        PreP = sq.PreP,
                        PreI = sq.PreI,
                        PreA = sq.PreA,
                        LitQ = sq.LitQ,
                        PstI = sq.PstI,
                        PstP = sq.PstP,
                        RespOptions = sq.RespOptions,
                        NRCodes = sq.NRCodes
                    };
                }
                else
                {
                    // if we are inside a series, compare the wording fields to the reference question
                    // if the current column is a standard wording column and has not been designated as a repeated field, compare wordings
                    if ((StdFields.Contains("PreP") && !RepeatedFields.Contains("PreP")))
                    {
                        // if the current question's wording field matches the reference question's, clear it. 
                        // otherwise, set the reference question's field to the current question's field
                        // this will cause a new reference point for that particular field, but not the fields that were identical to the original reference question
                        if (Utilities.RemoveTags(sq.PreP).Equals(Utilities.RemoveTags(refQ.PreP)))
                            sq.PreP = "";
                        else
                            refQ.PreP = sq.PreP;
                    }
                    // PreI
                    if ((StdFields.Contains("PreI") && !RepeatedFields.Contains("PreI")))
                    {
                        if (Utilities.RemoveTags(sq.PreI).Equals(Utilities.RemoveTags(refQ.PreI)))
                            sq.PreI = "";
                        else
                            refQ.PreI = sq.PreI;
                    }
                    // PreA
                    if ((StdFields.Contains("PreA") && !RepeatedFields.Contains("PreA")))
                    {
                        if (Utilities.RemoveTags(sq.PreA).Equals(Utilities.RemoveTags(refQ.PreA)))
                            sq.PreA = "";
                        else
                            refQ.PreA = sq.PreA;
                    }
                    // LitQ
                    if ((StdFields.Contains("LitQ") && !RepeatedFields.Contains("LitQ")))
                    {
                        if (Utilities.RemoveTags(sq.LitQ).Equals(Utilities.RemoveTags(refQ.LitQ)))
                            sq.LitQ = "";
                        else
                            refQ.LitQ = sq.LitQ;
                    }
                    // PstI
                    if ((StdFields.Contains("PstI") && !RepeatedFields.Contains("PstI")))
                    {
                        if (Utilities.RemoveTags(sq.PstI).Equals(Utilities.RemoveTags(refQ.PstI)))
                            sq.PstI = "";
                        else
                            refQ.PstI = sq.PstI;
                    }
                    // RespOptions
                    if ((StdFields.Contains("RespOptions") && !RepeatedFields.Contains("RespOptions")))
                    {
                        if (Utilities.RemoveTags(sq.RespOptions).Equals(Utilities.RemoveTags(refQ.RespOptions)))
                            sq.RespOptions = "";
                        else
                            refQ.RespOptions = sq.RespOptions;
                    }
                    // NRCodes
                    if ((StdFields.Contains("NRCodes") && !RepeatedFields.Contains("NRCodes")))
                    {
                        if (Utilities.RemoveTags(sq.NRCodes).Equals(Utilities.RemoveTags(refQ.NRCodes)))
                            sq.NRCodes = "";
                        else
                            refQ.NRCodes = sq.NRCodes;
                    }
                }
                firstRow = false; // after once through the loop, we are no longer on the first row
            }
        }

        public override string ToString()
        {
            PropertyInfo[] _PropertyInfos = null;
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
