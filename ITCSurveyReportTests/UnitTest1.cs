using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITCLib;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace ITCSurveyReportTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingleSurveySingleQuestionReportTable()
        {
            SurveyReport SR = new SurveyReport();
            ReportSurvey s = new ReportSurvey("Test");

            SR.AddSurvey(s);

            SurveyQuestion sq = new SurveyQuestion();
            sq.VarName = "AA000";
            sq.Qnum = "000";
            sq.PreP = "Test PreP";
            sq.LitQ = "Test LitQ";
            sq.RespOptions = "1   Yes";

            s.AddQuestion(sq);

            int result = SR.GenerateReport();

            Assert.IsTrue(result == 0);

            Assert.IsTrue(SR.ReportTable.Rows.Count == 1);
        }

        [TestMethod]
        public void SingleSurveyMultiQuestionReportTable()
        {
            SurveyReport SR = new SurveyReport();
            ReportSurvey s = new ReportSurvey("Test");

            SR.AddSurvey(s);

            for (int i = 0; i < 10; i++)
            {
                SurveyQuestion sq = new SurveyQuestion();
                sq.VarName = "AA" + i.ToString("000");
                sq.Qnum = i.ToString("000");
                sq.PreP = "Test PreP" + i;
                sq.LitQ = "Test LitQ" + i;
                for (int j = 1; j <= i; j++)
                    sq.RespOptions += j + "   Response Option " + j;

                s.AddQuestion(sq);
            }

            int result = SR.GenerateReport();

            Assert.IsTrue(result == 0);

            Assert.IsTrue(SR.ReportTable.Rows.Count == 10);
        }



        [TestMethod]
        public void TestSimilarWords()
        {
            string[][] test = DBAction.GetSimilarWords();

            Assert.IsTrue(test[0][0] == "fetus");
            Assert.IsTrue(test[0][1] == "foetus");
        }


        [TestMethod]
        public void Comparison_ExtraOtherQ()
        {
            SurveyReport SR = new SurveyReport();
            ReportSurvey p = new ReportSurvey("TestPrimary");



            SurveyQuestion sq = new SurveyQuestion();
            sq.VarName = "AA000";
            sq.Qnum = "000";
            sq.PreP = "Test PreP";
            sq.LitQ = "Test LitQ";
            sq.RespOptions = "1   Yes";

            p.AddQuestion(sq);

            ReportSurvey o = new ReportSurvey("TestOther");

            o.AddQuestion(sq);

            SurveyQuestion sq2 = new SurveyQuestion();
            sq2.VarName = "AA001";
            sq2.Qnum = "000";
            sq2.PreP = "Test PreP";
            sq2.LitQ = "Test LitQ";
            sq2.RespOptions = "1   Yes";

            o.AddQuestion(sq2);

            p.Primary = true;
            o.Qnum = true;

            SR.AddSurvey(o);
            SR.AddSurvey(p);

            SR.GenerateReport();

            Assert.IsTrue(SR.ReportTable.Rows.Count == 2);


        }

        

    }
}
