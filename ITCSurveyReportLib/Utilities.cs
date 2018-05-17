﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace ITCSurveyReport
{
    public enum VarNameFormat { NoCC, WithCC, NonStd}
    public static class Utilities
    {
        public static DataTable CreateDataTable(String name, String[] fields, String[] types)   
        {
            DataTable dt;
            System.Type dataType = null;
            dt = new DataTable(name);

            if (fields.Length != types.Length)
            {
                throw new System.ArgumentException("fields and types must have the same number of elements.");
            }

            for (int i = 0; i < fields.Length; i ++)
            {
                switch (types[i])
                {
                    case "string":
                        dataType = System.Type.GetType("System.String");
                        break;
                    case "int":
                        dataType = System.Type.GetType("System.Int32");
                        break;
                    default:
                        dataType = System.Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(new DataColumn(fields[i], dataType));

            }
            return dt;
        }

        public static void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "your header text";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.SaveAs2(filename);

                //NASSIM LOUCHANI
            }
        }

        public static DateTime PreviousWorkDay(DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsWeekend(date));
                
            return date;
            
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ||
                   date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static String TrimString (String input, String totrim)
        {
            while (input.EndsWith(totrim))
            {
                input = input.Substring(0, input.Length - totrim.Length);
            }
            while (input.StartsWith(totrim))
            {
                input = input.Substring(totrim.Length);
            }
            return input;
        }

        public static int CountLines(String input)
        {
            int newLineLen = Environment.NewLine.Length;
            int numLines = input.Length - input.Replace(Environment.NewLine, string.Empty).Length;
            if (newLineLen != 0)
            {
                numLines /= newLineLen;
                numLines++;
            }
            return numLines;
        }

        // returns the first record matching the criteria
        public static string DTLookup(DataTable dt, string field, string criteria)
        {

            DataRow[] dr = dt.Select(criteria);
            string result = "";
            if (dr.Length == 0)
            {
                result = "";
            }
            else
            { 
                result = (string)dr[0][field];
            }
            

            return result;
        }

        //public static int DTLookup(DataTable dt, string field, string criteria)
        //{
        //    int result = 0;
        //    return result;
        //}

        public static string ChangeCC (string varname, int cc = 0)
        {
            string result = "";
            VarNameFormat format = GetVarNameFormat(varname);
            
            

            if (varname.Equals("") || cc <0 || cc>99) { result = ""; }

            if (format == VarNameFormat.NonStd) { result = varname; }

            if (cc == 0)
            {
                if (format == VarNameFormat.NoCC)
                {
                    result = varname;
                }else if (format== VarNameFormat.WithCC)
                {
                    result = varname.Substring(0, 2) + varname.Substring(5);
                }
                
            } else
            {
                if (format == VarNameFormat.NoCC)
                {
                    result = varname.Substring(0,2) + cc + varname.Substring(2);
                }
                else if (format == VarNameFormat.WithCC)
                {
                    result = varname.Substring(1, 2) + varname.Substring(5);
                }
            }

            return result;
            

        }
        
        public static VarNameFormat GetVarNameFormat (string varname)
        {
            VarNameFormat result;
            Regex rx;

            rx = new Regex("[A-Z]{2}\\d{3}");

            if (rx.Match(varname).Success)
            {
                result = VarNameFormat.NoCC;
            }
            else
            {
                rx = new Regex("[A-Z]{2}\\d{5}");
                if (rx.Match(varname).Success)
                {
                    result = VarNameFormat.WithCC;
                }
                else
                {
                    result = VarNameFormat.NonStd;
                }
            }

            return result;
        }

        public static string ExtractVarName (string input)
        {
            string var = "";
            Regex rx = new Regex("[A-Z]{2}\\d{3}");

            if (rx.Match(input).Success)
            {
                var = rx.Matches(input)[0].Value;
            }
            return var;
        }

        public static string RemoveTags (string input)
        {
            string output = input;
            output = output.Replace("[yellow]", "");
            output = output.Replace("[/yellow]", "");
            output = output.Replace("[brightgreen]", "");
            output = output.Replace("[/brightgreen]", "");
            output = output.Replace("[t]", "");
            output = output.Replace("[s]", "");
            output = output.Replace("[/t]", "");
            output = output.Replace("[/s]", "");


            return output;
        }
    }
}
