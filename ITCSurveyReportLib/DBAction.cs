using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ITCSurveyReportLib
{
    /// <summary>
    /// Static class for interacting with the Database. TODO create stored procedures on server for each of these
    /// </summary>
    public static class DBAction
    {
        
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);
        private static SqlDataAdapter sql = new SqlDataAdapter();

        //
        // Surveys
        //
        /// <summary>
        /// Returns the survey code for a particular Question ID.
        /// </summary>
        /// <param name="qid">Valid Question ID.</param>
        /// <returns>Survey Code as string, empty string if Question ID is invalid.</returns>
        public static string GetSurveyCodeByQID(int qid)
        {

            string surveyCode = "";
            sql = new SqlDataAdapter();
            string query = "SELECT Survey FROM qrySurveyQuestions WHERE ID = @qid ORDER BY Qnum";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@qid", qid);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        surveyCode = (string)rdr["Survey"];
                    }
                }
            }
                catch (Exception)
            {
                return "";
            }
            finally
            {
                conn.Close();
            }

            return surveyCode;
        }

        /// <summary>
        /// Creates a Survey object with the provided ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Survey GetSurvey(int ID)
        {
            Survey s;

            string query = "SELECT * FROM qrySurveyInfo WHERE ID = @sid";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", ID);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    rdr.Read();
                    s = new Survey
                    {
                        SID = (int)rdr["ID"],
                        SurveyCode = (string)rdr["Survey"],
                        Title = (string)rdr["SurveyTitle"],
                        Mode = (string)rdr["ModeLong"],
                        CountryCode = Int32.Parse((string)rdr["CountryCode"])


                    };
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Languages")))  s.Languages = (string)rdr["Languages"]; 
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Group")))  s.Groups = (string)rdr["Group"]; 
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            s.questions = GetQuestionsBySurvey(s.SID);
            s.GetEssentialQuestions();

            return s;
        }
        
        /// <summary>
        /// Returns a Survey object with the provided survey code.
        /// </summary>
        /// <param name="code">A valid survey code. Null is returned if the survey code is not found in the database.</param>
        /// <param name="withComments"></param>
        /// <param name="withTranslation"></param>
        /// <returns></returns>
        public static Survey GetSurvey(string code, bool withComments = false, bool withTranslation = false)
        {
            Survey s;

            string query = "SELECT * FROM qrySurveyInfo WHERE Survey = @survey";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@survey", code);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    rdr.Read();
                    s = new Survey
                    {
                        SID = (int)rdr["ID"],
                        SurveyCode = (string)rdr["Survey"],
                        Title = (string)rdr["SurveyTitle"],
                        Mode = (string)rdr["ModeLong"],
                        CountryCode = Int32.Parse((string)rdr["CountryCode"])
                    };
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Languages"))) s.Languages = (string)rdr["Languages"];
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Group"))) s.Groups = (string)rdr["Group"];
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            
            s.questions = GetQuestionsBySurvey(s.SID, withComments, withTranslation);
            s.GetEssentialQuestions();

            return s;
        }
        //
        // Variables
        //
        /// <summary>
        /// Returns a VariabelName object with the provided VarName.
        /// </summary>
        /// <param name="varname">A valid VarName.</param>
        /// <returns> Null is returned if the VarName is not found in the database.</returns>
        public static VariableName GetVariable(string varname)
        {
            VariableName v;

            string query = "SELECT * FROM qryVariableInfo WHERE VarName = @varname";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@varname", varname);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    rdr.Read();
                    v = new VariableName
                    {
                        VarName = (string)rdr["VarName"],
                        refVarName = (string)rdr["refVarName"],
                        VarLabel = (string)rdr["VarLabel"],
                        DomainLabel = (string)rdr["Domain"],
                        TopicLabel = (string)rdr["Topic"],
                        ContentLabel = (string)rdr["Content"],
                        ProductLabel = (string)rdr["Product"]

                    };
                    
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            return v;
        }

        //
        // SurveyQuestions
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="withComments"></param>
        /// <param name="withTranslation"></param>
        /// <returns></returns>
        public static SurveyQuestion GetSurveyQuestion(int ID, bool withComments = false, bool withTranslation = false) { return null; }

        /// <summary>
        /// Retrieves a set of records for a particular survey ID and returns a list of SurveyQuestion objects. 
        /// </summary>
        /// <param name="SurvID">Survey ID.</param>
        /// <param name="withComments"></param>
        /// <param name="withTranslation"></param>
        /// <returns>List of SurveyQuestions</returns>
        public static List<SurveyQuestion> GetQuestionsBySurvey(int SurvID, bool withComments = false, bool withTranslation = false)
        {
            List<SurveyQuestion> qs = new List<SurveyQuestion>();
            SurveyQuestion q;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestions WHERE SurvID = @sid ORDER BY Qnum";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", SurvID);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        q = new SurveyQuestion
                        {
                            ID = (int)rdr["ID"],
                            SurveyCode = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            refVarName = (string)rdr["refVarName"],
                            Qnum = (string)rdr["Qnum"],
                            //AltQnum = (string)rdr["AltQnum"],
                            PrePNum = (int)rdr["PreP#"],
                            PreP = (string)rdr["PreP"],
                            PreINum = (int)rdr["PreI#"],
                            PreI = (string)rdr["PreI"],
                            PreANum = (int)rdr["PreA#"],
                            PreA = (string)rdr["PreA"],
                            LitQNum = (int)rdr["LitQ#"],
                            LitQ = (string)rdr["LitQ"],
                            PstINum = (int)rdr["PstI#"],
                            PstI = (string)rdr["PstI"],
                            PstPNum = (int)rdr["PstP#"],
                            PstP = (string)rdr["PstP"],
                            RespName = (string)rdr["RespName"],
                            RespOptions = (string)rdr["RespOptions"],
                            NRName = (string) rdr["NRName"],
                            NRCodes = (string)rdr["NRCodes"],
                            VarLabel = (string)rdr["VarLabel"],
                            TopicLabel = (string)rdr["Topic"],
                            ContentLabel = (string)rdr["Content"],
                            ProductLabel = (string)rdr["Product"],
                            DomainLabel = (string)rdr["Domain"],
                            TableFormat = (bool)rdr["TableFormat"],
                            CorrectedFlag = (bool)rdr["CorrectedFlag"],
                            NumCol = (int) rdr["NumCol"],
                            NumDec = (int) rdr["NumDec"],
                            VarType = (string)rdr["VarType"],
                            ScriptOnly = (bool)rdr["ScriptOnly"]

                        };

                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumFmt"))) q.NumFmt = (string)rdr["NumFmt"];

                        if (withComments)
                            q.Comments = GetCommentsByQuestion(q.ID);

                        if (withTranslation)
                            q.Translations = GetTranslationByQuestion(q.ID);

                        
                        qs.Add(q);
                    }
                    
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            

            return qs;
        }

        /// <summary>
        /// Retrieves a set of records for a particular VarName and returns a list of SurveyQuestion objects. 
        /// </summary>
        /// <param name="varname">A valid VarName.</param>
        /// <returns>List of SurveyQuestions</returns>
        public static List<SurveyQuestion> GetQuestionsByVarName(string varname, bool withComments = false, bool withTranslation = false)
        {
            List<SurveyQuestion> qs = new List<SurveyQuestion>();
            SurveyQuestion q;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestions WHERE VarName = @varname ORDER BY Qnum";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@varname", varname);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        q = new SurveyQuestion
                        {
                            ID = (int)rdr["ID"],
                            SurveyCode = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            refVarName = (string)rdr["refVarName"],
                            Qnum = (string)rdr["Qnum"],
                            //AltQnum = (string)rdr["AltQnum"],
                            PrePNum = (int)rdr["PreP#"],
                            PreP = (string)rdr["PreP"],
                            PreINum = (int)rdr["PreI#"],
                            PreI = (string)rdr["PreI"],
                            PreANum = (int)rdr["PreA#"],
                            PreA = (string)rdr["PreA"],
                            LitQNum = (int)rdr["LitQ#"],
                            LitQ = (string)rdr["LitQ"],
                            PstINum = (int)rdr["PstI#"],
                            PstI = (string)rdr["PstI"],
                            PstPNum = (int)rdr["PstP#"],
                            PstP = (string)rdr["PstP"],
                            RespName = (string)rdr["RespName"],
                            RespOptions = (string)rdr["RespOptions"],
                            NRName = (string)rdr["NRName"],
                            NRCodes = (string)rdr["NRCodes"],
                            VarLabel = (string)rdr["VarLabel"],
                            TopicLabel = (string)rdr["Topic"],
                            ContentLabel = (string)rdr["Content"],
                            ProductLabel = (string)rdr["Product"],
                            DomainLabel = (string)rdr["Domain"],
                            TableFormat = (bool)rdr["TableFormat"],
                            CorrectedFlag = (bool)rdr["CorrectedFlag"],
                            NumCol = (int)rdr["NumCol"],
                            NumDec = (int)rdr["NumDec"],
                            VarType = (string)rdr["VarType"],
                            ScriptOnly = (bool)rdr["ScriptOnly"]

                        };

                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumFmt"))) q.NumFmt = (string)rdr["NumFmt"];

                        if (withComments)
                            q.Comments = GetCommentsByQuestion(q.ID);

                        if (withTranslation)
                            q.Translations = GetTranslationByQuestion(q.ID);


                        qs.Add(q);
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }


            return qs;
        }

        /// <summary>
        /// Retrieves a set of records for a particular VarName and returns a list of SurveyQuestion objects. 
        /// </summary>
        /// <param name="varname">A valid VarName.</param>
        /// <returns>List of SurveyQuestions</returns>
        public static List<SurveyQuestion> GetQuestionsByRefVarName(string refvarname, bool withComments = false, bool withTranslation = false)
        {
            List<SurveyQuestion> qs = new List<SurveyQuestion>();
            SurveyQuestion q;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestions WHERE refVarName = @refvarname ORDER BY Qnum";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@refvarname", refvarname);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        q = new SurveyQuestion
                        {
                            ID = (int)rdr["ID"],
                            SurveyCode = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            refVarName = (string)rdr["refVarName"],
                            Qnum = (string)rdr["Qnum"],
                            //AltQnum = (string)rdr["AltQnum"],
                            PrePNum = (int)rdr["PreP#"],
                            PreP = (string)rdr["PreP"],
                            PreINum = (int)rdr["PreI#"],
                            PreI = (string)rdr["PreI"],
                            PreANum = (int)rdr["PreA#"],
                            PreA = (string)rdr["PreA"],
                            LitQNum = (int)rdr["LitQ#"],
                            LitQ = (string)rdr["LitQ"],
                            PstINum = (int)rdr["PstI#"],
                            PstI = (string)rdr["PstI"],
                            PstPNum = (int)rdr["PstP#"],
                            PstP = (string)rdr["PstP"],
                            RespName = (string)rdr["RespName"],
                            RespOptions = (string)rdr["RespOptions"],
                            NRName = (string)rdr["NRName"],
                            NRCodes = (string)rdr["NRCodes"],
                            VarLabel = (string)rdr["VarLabel"],
                            TopicLabel = (string)rdr["Topic"],
                            ContentLabel = (string)rdr["Content"],
                            ProductLabel = (string)rdr["Product"],
                            DomainLabel = (string)rdr["Domain"],
                            TableFormat = (bool)rdr["TableFormat"],
                            CorrectedFlag = (bool)rdr["CorrectedFlag"],
                            NumCol = (int)rdr["NumCol"],
                            NumDec = (int)rdr["NumDec"],
                            VarType = (string)rdr["VarType"],
                            ScriptOnly = (bool)rdr["ScriptOnly"]

                        };

                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumFmt"))) q.NumFmt = (string)rdr["NumFmt"];

                        if (withComments)
                            q.Comments = GetCommentsByQuestion(q.ID);

                        if (withTranslation)
                            q.Translations = GetTranslationByQuestion(q.ID);


                        qs.Add(q);
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }


            return qs;
        }


        /// <summary>
        /// Fills the raw survey table with wordings, labels, corrected and table flags from a backup database.
        /// </summary>
        /// <remarks>
        /// This could be achieved by changing the FROM clause in GetSurveyTable but often there are columns that don't exist in the backups, due to 
        /// their age and all the changes that have happened to the database over the years. 
        /// </remarks>
        public static List<SurveyQuestion> GetQuestionsBySurveyFromBackup (string surveyCode, DateTime backup) {

            List<SurveyQuestion> qs = new List<SurveyQuestion>();
            SurveyQuestion q;
            DataTable rawTable;
            string filePath = backup.ToString("yyyy-MM-dd") + ".7z";
            BackupConnection bkp = new BackupConnection(filePath);
            string select = "SELECT tblSurveyNumbers.[ID], [Qnum] AS SortBy, [Survey], tblSurveyNumbers.[VarName], refVarName, Qnum, AltQnum, CorrectedFlag, TableFormat, tblDomain.[Domain], " +
                "[Topic], [Content], VarLabel, [Product], PreP, PreI, PreA, LitQ, PstI, PstP, RespOptions, NRCodes ";
            string where = "Survey = '" + surveyCode + "'";


            if (bkp.Connected)
            {
                Console.Write("unzipped");
                rawTable = bkp.GetSurveyTable(select, where);
            }
            else
            {
                // could not unzip backup/7zip not installed etc. 
                return null;
            }

            foreach (DataRow r in rawTable.Rows)
            {
                q = new SurveyQuestion
                {
                    ID = (int)r["ID"],
                    SurveyCode = (string)r["Survey"],
                    VarName = (string)r["VarName"],
                    refVarName = (string)r["refVarName"],
                    Qnum = (string)r["Qnum"],
                    //AltQnum = (string)r["AltQnum"],
                    PrePNum = (int)r["PreP#"],
                    PreP = (string)r["PreP"],
                    PreINum = (int)r["PreI#"],
                    PreI = (string)r["PreI"],
                    PreANum = (int)r["PreA#"],
                    PreA = (string)r["PreA"],
                    LitQNum = (int)r["LitQ#"],
                    LitQ = (string)r["LitQ"],
                    PstINum = (int)r["PstI#"],
                    PstI = (string)r["PstI"],
                    PstPNum = (int)r["PstP#"],
                    PstP = (string)r["PstP"],
                    RespName = (string)r["RespName"],
                    RespOptions = (string)r["RespOptions"],
                    NRName = (string)r["NRName"],
                    NRCodes = (string)r["NRCodes"],
                    VarLabel = (string)r["VarLabel"],
                    TopicLabel = (string)r["Topic"],
                    ContentLabel = (string)r["Content"],
                    ProductLabel = (string)r["Product"],
                    DomainLabel = (string)r["Domain"],
                    TableFormat = (bool)r["TableFormat"],
                    CorrectedFlag = (bool)r["CorrectedFlag"],
                    NumCol = (int)r["NumCol"],
                    NumDec = (int)r["NumDec"],
                    VarType = (string)r["VarType"],
                    ScriptOnly = (bool)r["ScriptOnly"]
                };

                if (!String.IsNullOrEmpty((string)r["NumFmt"])) q.NumFmt = (string)r["NumFmt"];

                qs.Add(q);
            }

            return qs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyCode"></param>
        /// <returns></returns>
        public static List<SurveyQuestion> GetCorrectedWordings(string surveyCode)
        {
            List<SurveyQuestion> qs = new List<SurveyQuestion>();


            string query = "SELECT C.QID AS ID, SN.VarName, C.PreP, C.PreI, C.PreA, C.LitQ, C.PstI, C.PstP, C.RespOptions," +
                "C.NRCodes FROM qrySurveyQuestionsCorrected AS C INNER JOIN qrySurveyQuestions AS SN ON C.QID = SN.ID " +
                "WHERE SN.Survey =@survey";


            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@survey", surveyCode);

            conn.Open();

            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        SurveyQuestion q = new SurveyQuestion
                        {
                            ID = (int)rdr["ID"],
                            SurveyCode = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            PreP = (string)rdr["PreP"],
                            PreI = (string)rdr["PreI"],
                            PreA = (string)rdr["PreA"],
                            LitQ = (string)rdr["LitQ"],
                            PstI = (string)rdr["PstI"],
                            PstP = (string)rdr["PstP"],
                            RespOptions = (string)rdr["RespOptions"],
                            NRCodes = (string)rdr["NRCodes"],
                        };

                        qs.Add(q);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            return qs;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="withComments"></param>
        /// <param name="withTranslation"></param>
        public static void FillQuestionsBySurvey (Survey s, bool withComments = false, bool withTranslation = false)
        {
            List<SurveyQuestion> qs = new List<SurveyQuestion>();
            SurveyQuestion q;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestions WHERE SurvID = @sid ORDER BY Qnum";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", s.SID);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        q = new SurveyQuestion
                        {
                            ID = (int)rdr["ID"],
                            SurveyCode = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            refVarName = (string)rdr["refVarName"],
                            Qnum = (string)rdr["Qnum"],
                            //AltQnum = (string)rdr["AltQnum"],
                            PrePNum = (int)rdr["PreP#"],
                            PreP = (string)rdr["PreP"],
                            PreINum = (int)rdr["PreI#"],
                            PreI = (string)rdr["PreI"],
                            PreANum = (int)rdr["PreA#"],
                            PreA = (string)rdr["PreA"],
                            LitQNum = (int)rdr["LitQ#"],
                            LitQ = (string)rdr["LitQ"],
                            PstINum = (int)rdr["PstI#"],
                            PstI = (string)rdr["PstI"],
                            PstPNum = (int)rdr["PstP#"],
                            PstP = (string)rdr["PstP"],
                            RespName = (string)rdr["RespName"],
                            RespOptions = (string)rdr["RespOptions"],
                            NRName = (string)rdr["NRName"],
                            NRCodes = (string)rdr["NRCodes"],
                            VarLabel = (string)rdr["VarLabel"],
                            TopicLabel = (string)rdr["Topic"],
                            ContentLabel = (string)rdr["Content"],
                            ProductLabel = (string)rdr["Product"],
                            DomainLabel = (string)rdr["Domain"],
                            TableFormat = (bool)rdr["TableFormat"],
                            CorrectedFlag = (bool)rdr["CorrectedFlag"],
                            NumCol = (int)rdr["NumCol"],
                            NumDec = (int)rdr["NumDec"],
                            VarType = (string)rdr["VarType"],
                            ScriptOnly = (bool)rdr["ScriptOnly"]
                        };

                        if (!rdr.IsDBNull(rdr.GetOrdinal("NumFmt"))) q.NumFmt = (string)rdr["NumFmt"];

                        if (withComments)
                            q.Comments = GetCommentsByQuestion(q.ID);

                        if (withTranslation)
                            q.Translations = GetTranslationByQuestion(q.ID);


                        s.questions.Add(q);
                    }

                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                conn.Close();
            }

        }

        //
        // Comments
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SurvID"></param>
        /// <returns></returns>
        public static List<Comment> GetCommentsBySurvey (int SurvID)
        {
            List<Comment> cs = new List<Comment>();
            Comment c;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qryCommentsQues WHERE SurvID = @sid";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", SurvID);
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        c = new Comment
                        {
                            ID = (int)rdr["ID"],
                            QID = (int)rdr["QID"],
                            Survey = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            CID = (int)rdr["CID"],
                            Notes = (string)rdr["Notes"],
                            NoteDate = (DateTime)rdr["NoteDate"],
                            NoteInit = (int)rdr["NoteInit"],
                            Name = (string)rdr["Name"],
                            SourceName = (string)rdr["SourceName"],
                            NoteType = (string)rdr["NoteType"],
                            Source = (string)rdr["Source"],
                            SurvID = (int)rdr["SurvID"]
                        };

                        
                        cs.Add(c);
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }


            return cs;
        }

        // TODO TEST with all arguments
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SurvID"></param>
        /// <param name="commentTypes"></param>
        /// <param name="commentDate"></param>
        /// <param name="commentAuthors"></param>
        /// <param name="commentSources"></param>
        /// <returns></returns>
        public static List<Comment> GetCommentsBySurvey(int SurvID, List<string> commentTypes = null, DateTime? commentDate = null, List<int> commentAuthors = null, List<string> commentSources = null)
        {
            List<Comment> cs = new List<Comment>();
            Comment c;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qryCommentsQues WHERE SurvID = @sid";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", SurvID);

            if (commentTypes != null && commentTypes.Count != 0)
            {
                sql.SelectCommand.Parameters.AddWithValue("@commentTypes", String.Join(",", commentTypes));
                query += " AND NoteType IN (@commentTypes)";
            }

            if (commentDate != null)
            {
                sql.SelectCommand.Parameters.AddWithValue("@commentDate", commentDate);
                query += " AND NoteDate >= (@commentDate)";
            }

            if (commentAuthors != null && commentAuthors.Count != 0)
            {
                sql.SelectCommand.Parameters.AddWithValue("@commentAuthors", String.Join(",", commentAuthors));
                query += " AND NoteInit IN (@commentAuthors)";
            }

            if (commentSources!= null && commentSources.Count != 0)
            {
                sql.SelectCommand.Parameters.AddWithValue("@commentSources", String.Join(",", commentSources));
                query += " AND Source IN (@commentSources)";
            }

            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        c = new Comment
                        {
                            ID = (int)rdr["ID"],
                            QID = (int)rdr["QID"],
                            Survey = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            CID = (int)rdr["CID"],
                            Notes = (string)rdr["Notes"],
                            NoteDate = (DateTime)rdr["NoteDate"],
                            NoteInit = (int)rdr["NoteInit"],
                            Name = (string)rdr["Name"],
                            SourceName = (string)rdr["SourceName"],
                            NoteType = (string)rdr["NoteType"],
                            Source = (string)rdr["Source"],
                            SurvID = (int)rdr["SurvID"]
                        };
                        cs.Add(c);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

            return cs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QID"></param>
        /// <returns></returns>
        public static List<Comment> GetCommentsByQuestion(int QID) { return null; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="commentTypes"></param>
        /// <param name="commentDate"></param>
        /// <param name="commentAuthors"></param>
        /// <param name="commentSources"></param>
        public static void FillCommentsBySurvey(Survey s, List<string> commentTypes = null, DateTime? commentDate = null, List<int> commentAuthors = null, List<string> commentSources = null)
        {
            
            Comment c;
            sql = new SqlDataAdapter();

            // build the SQL query, with filters
            string query = "SELECT * FROM qryCommentsQues WHERE SurvID = @sid";
            
            sql.SelectCommand = new SqlCommand();
            sql.SelectCommand.Parameters.AddWithValue("@sid", s.SID);

            if (commentTypes != null && commentTypes.Count != 0)
            {
                query += " AND (";
                for (int i =0;i<commentTypes.Count; i ++)
                {
                    sql.SelectCommand.Parameters.AddWithValue("@commentTypes" + i, commentTypes[i]);
                    query += " NoteType = @commentTypes" + i + " OR ";
                }
                query = Utilities.TrimString(query, " OR ");
                query += ")";
            }

            if (commentDate != null)
            {
                sql.SelectCommand.Parameters.AddWithValue("@commentDate", commentDate.Value);
                query += " AND NoteDate >= @commentDate";
            }

            if (commentAuthors != null && commentAuthors.Count != 0)
            {
                query += " AND (";
                for (int i = 0; i < commentAuthors.Count; i++)
                {
                    sql.SelectCommand.Parameters.AddWithValue("@commentAuthors" + i, commentAuthors[i]);
                    query += " NoteInit = @commentAuthors" + i + " OR ";
                }
                query = Utilities.TrimString(query, " OR ");
                query += ")";
            }

            if (commentSources != null && commentSources.Count != 0)
            {
                query += " AND (";
                for (int i = 0; i < commentAuthors.Count; i++)
                {
                    sql.SelectCommand.Parameters.AddWithValue("@commentSources" + i, commentSources[i]);
                    query += " SourceName = @commentSources" + i + " OR ";
                }
                query = Utilities.TrimString(query, " OR ");
                query += ")";
            }

            query += " ORDER BY NoteDate DESC";

            // set the command
            sql.SelectCommand.CommandText = query;
            sql.SelectCommand.Connection = conn;

            conn.Open();
            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        c = new Comment
                        {
                            ID = (int)rdr["ID"],
                            QID = (int)rdr["QID"],
                            Survey = (string)rdr["Survey"],
                            VarName = (string)rdr["VarName"],
                            CID = (int)rdr["CID"],
                            Notes = (string)rdr["Notes"],
                            NoteDate = (DateTime)rdr["NoteDate"],
                            NoteInit = (int)rdr["NoteInit"],
                            Name = (string)rdr["Name"],
                            NoteType = (string)rdr["NoteType"],
                            SurvID = (int)rdr["SurvID"]
                        };
                        if (!rdr.IsDBNull(rdr.GetOrdinal("SourceName"))) c.SourceName = (string)rdr["SourceName"];
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Source"))) c.Source = (string)rdr["Source"];

                        s.QuestionByID((int)rdr["QID"]).Comments.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return;
            }
            finally
            {
                conn.Close();
            }

            
        }

        //
        // Translations
        //
        // TODO Test
        public static List<Translation> GetTranslationBySurvey (int SurvID, string language)
        {
            List<Translation> ts = new List<Translation>();
            Translation t;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestionsTranslation WHERE SurvID = @sid AND Lang = @language";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", SurvID);
            sql.SelectCommand.Parameters.AddWithValue("@lang", language);

            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        t = new Translation
                        {
                            ID = (int)rdr["ID"],
                            QID = (int)rdr["QID"],
                            Language = (string)rdr["Lang"],
                            TranslationText = (string)rdr["Translation"],
                            Bilingual = (bool)rdr["Bilingual"]
                        };
                        ts.Add(t);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return ts;
        }

        public static void FillTranslationsBySurvey(Survey s, string language)
        {
            
            Translation t;
            sql = new SqlDataAdapter();
            string query = "SELECT * FROM qrySurveyQuestionsTranslations WHERE SurvID = @sid AND Lang = @lang";
            conn.Open();
            sql.SelectCommand = new SqlCommand(query, conn);
            sql.SelectCommand.Parameters.AddWithValue("@sid", s.SID);
            sql.SelectCommand.Parameters.AddWithValue("@lang", language);

            try
            {
                using (SqlDataReader rdr = sql.SelectCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        t = new Translation
                        {
                            ID = (int)rdr["ID"],
                            QID = (int)rdr["QID"],
                            Language = (string)rdr["Lang"],
                            TranslationText = (string)rdr["Translation"],
                            Bilingual = (bool)rdr["Bilingual"]
                        };
                        s.QuestionByID(t.QID).Translations.Add(t);
                        
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
            
        }

        /// <summary>
        /// Creates a DataTable containing the translation data for a given survey and language(s). A question filter can be supplied to get a specific set of records.
        /// <returns>The merger of the individual translation data tables.</returns>
        /// </summary>
        public static DataTable GetTranslationsBySurvey(string surveyCode, List<string> langs, string qFilter = null)
        {
            string query = "";
            string where = "";
            string whereLang = "";

            // instantiate the return table
            DataTable translationTable = new DataTable();

            // instantiate the data tables list
            List<DataTable> translationTables = new List<DataTable>();

            // create the filter for the query
            where = "WHERE Survey = '" + surveyCode + "'";

            if (qFilter != "") { where += " AND " + qFilter; }

            // create a data table for each language, set its primary key, add it to the list of translation tables
            for (int i = 0; i < langs.Count; i++)
            {
                DataTable t;
                t = new DataTable();
                whereLang = " AND Lang ='" + langs[i] + "'";

                query = "SELECT QID AS ID, VarName, refVarName, " +
                    "Replace(Replace(Replace(Replace(Translation, '&gt;', '>'), '&lt;', '<'), '&nbsp;', ' '), '<br>','\r\n') AS [" + langs[i] + "] " +
                    "FROM qrySurveyQuestionsTranslations " + where + whereLang;


                // run the query and fill the data table
                conn.Open();
                sql.SelectCommand = new SqlCommand(query, conn);
                sql.Fill(t);

                conn.Close();

                t.PrimaryKey = new DataColumn[] { t.Columns["ID"] };

                // TODO get corrected wordings (see GetCorrectedWordings)
                // TODO get headings

                translationTables.Add(t);
            }

            // merge all translations into one table
            translationTable = new DataTable();

            foreach (DataTable t in translationTables)
                translationTable.Merge(t);

            return translationTable;
        }

        public static DataTable GetTranslationBySurveyFromBackup(string surveyCode, List<string> langs, string qFilter = null)
        {
            string query = "";
            string where = "";
            string whereLang = "";

            // instantiate the return table
            DataTable translationTable = new DataTable();

            // instantiate the data tables list
            List<DataTable> translationTables = new List<DataTable>();

            // create the filter for the query
            where = "WHERE Survey = '" + surveyCode + "'";

            if (qFilter != "") { where += " AND " + qFilter; }

            // create a data table for each language, set its primary key, add it to the list of translation tables
            for (int i = 0; i < langs.Count; i++)
            {
                DataTable t;
                t = new DataTable();
                whereLang = " AND Lang ='" + langs[i] + "'";

                query = "SELECT QID AS ID, VarName, refVarName, " +
                    "Replace(Replace(Replace(Replace(Translation, '&gt;', '>'), '&lt;', '<'), '&nbsp;', ' '), '<br>','\r\n') AS [" + langs[i] + "] " +
                    "FROM qrySurveyQuestionsTranslations " + where + whereLang;


                // run the query and fill the data table
                conn.Open();
                sql.SelectCommand = new SqlCommand(query, conn);
                sql.Fill(t);

                conn.Close();

                t.PrimaryKey = new DataColumn[] { t.Columns["ID"] };

                // TODO get corrected wordings (see GetCorrectedWordings)
                // TODO get headings

                translationTables.Add(t);
            }

            // merge all translations into one table
            translationTable = new DataTable();

            foreach (DataTable t in translationTables)
                translationTable.Merge(t);

            return translationTable;
        }

        public static List<Translation> GetTranslationByQuestion (int QID, string language = null) {
            // if language is null, return all translations
            return null;
        }


        //
        // VarNames
        //

        private static string GetPreviousNames(string survey, string varname, bool excludeTempNames)
        {

            string varlist = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ISISConnectionString"].ConnectionString);
            DataTable surveyListTable = new DataTable("ChangedSurveys");
            string query = "SELECT dbo.FN_VarNamePreviousNames(@varname, @survey, @excludeTemp)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@varname", SqlDbType.VarChar);
            cmd.Parameters["@varname"].Value = varname;
            cmd.Parameters.Add("@survey", SqlDbType.VarChar);
            cmd.Parameters["@survey"].Value = survey;
            cmd.Parameters.Add("@excludeTemp", SqlDbType.Bit);
            cmd.Parameters["@excludeTemp"].Value = excludeTempNames;

            conn.Open();
            try
            {
                varlist = (string)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
#if DEBUG
                Console.WriteLine(ex.ToString());
#endif
                return "Error";
            }
            conn.Close();
            if (!varlist.Equals(varname)) { varlist = "(Prev. " + varlist.Substring(varname.Length + 1) + ")"; } else { varlist = ""; }
            return varlist;
        }

    }
}
