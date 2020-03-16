using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITCLib;
using System.Data;

namespace ITCSurveyReportTests
{
    /// <summary>
    /// Summary description for ISR_Comment_Test
    /// </summary>
    [TestClass]
    public class ISR_Comment_Test
    {
        SurveyReport SR;
        public ISR_Comment_Test()
        {
           

            SR = new SurveyReport();

            ReportSurvey s1 = new ReportSurvey("TT1");

            SurveyQuestion q1 = new SurveyQuestion("AA000", "001")
            {
                PreP = "Ask all.",
                LitQ = "Do you smoke?",
                RespOptions = "1   Yes\r\n2   No",
                NRCodes = "8   Refused\r\n9   Don't Know",
            };

            QuestionComment c1 = new QuestionComment()
            {
                NoteDate = new DateTime(2019, 10, 16),
                Notes = new Note(1, "Comment text."),
                NoteInit = 33,
                Name = "Eddie B",
                Source = "Eddie B"
            };

            q1.Comments.Add(c1);
            

            s1.AddQuestion(q1);
            SR.AddSurvey(s1);
            SR.SetColumnOrder();
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AllComments_NoFilters()
        {
            SR.GenerateReport();

            DataTable d = SR.ReportTable;

            //Assert.IsTrue()
        }
    }
}
