using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace ITCSurveyReport
{
    /// <summary>
    /// Represents the routing/skips portion of a survey question, also known as Post-programming instructions.
    /// </summary>
    class QuestionRouting
    {
        string routingText;  // the complete text of the filter
        bool hasVar;        // true if the filter contains a variable name
        List<FilterVar> filterVars;      // list of varnames that appear in this filter

        public QuestionRouting()
        {

        }

        /// <summary>
        /// Initializes a new instances of the QuestionFilter class using fields from the provided DataRow object.
        /// </summary>
        /// <param name="question"></param>
        public QuestionRouting(DataRow question)
        {

        }

        public QuestionRouting(string filter)
        {
            string var = Utilities.ExtractVarName(filter);
            routingText = filter;
            // check for vars to set hasVar flag
            if (!var.Equals(""))
                hasVar = true;
            // populate filterVars list
            filterVars = new List<FilterVar>();
            GetRoutingVars();
        }

        private void GetRoutingVars()
        {
            string filterVar;


            int filterVarPos;
            int filterVarLen;

            string routingExp; // the routing expression of the variable e.g. If response = [list], go to [varname].

            string[] filterOptionsList;
            string options;


            Regex rx;
            MatchCollection results;


            while (!routingText.Equals(""))
            {
                FilterVar fv;
                filterVar = Utilities.ExtractVarName(routingText);

                if (filterVar.Equals(""))
                    break;

                rx = new Regex(filterVar + "(=|<|>|<>)" +
                            "(([0-9]+(,\\s[0-9]+)+\\sor\\s[0-9]+)" +
                            "|([0-9]+\\sor\\s[0-9]+)" +
                            "|([0-9]+\\-[0-9]+)" +
                            "|([0-9]+))");

                filterVarPos = routingText.IndexOf(filterVar);
                filterVarLen = filterVar.Length;


                results = rx.Matches(routingText);

                if (results.Count > 0)
                {
                    routingExp = results[0].Value;
                    options = routingExp.Substring(filterVarLen + 1);
                    options = Regex.Replace(options, "[^0-9 <->]", "");

                    filterOptionsList = GetOptionList(options).Split(' ');

                    fv = new FilterVar();
                    fv.Varname = filterVar;
                    if (filterOptionsList.Length != 0)
                    {
                        fv.ResponseCodes = filterOptionsList.Select(Int32.Parse).ToList();
                    }
                    // add to the list of filter vars if it is not already there
                    if (!filterVars.Contains(fv))
                        filterVars.Add(fv);

                }


                routingText = routingText.Substring(filterVarPos + filterVarLen);
            }



        }


        public string GetOptionList(string options)
        {
            string low, high;
            string list = "";
            string ro;

            if (options.IndexOf('-') > 0)
            {
                low = options.Substring(options.IndexOf('-') - 1, 1);
                high = options.Substring(options.IndexOf('-') + 1, 1);

                for (int i = Int32.Parse(low); i < Int32.Parse(high); i++)
                {
                    list += Convert.ToString(i);
                    if (i != Int32.Parse(high))
                    {
                        list += " ";
                    }

                }
            }
            else if (options.StartsWith("<>"))
            {
                list = options.Substring(2);
            }
            else if (options.StartsWith(">"))
            {
                list = options.Substring(1);
            }
            else if (options.StartsWith("<"))
            {
                list = options.Substring(1);
            }
            else
            {
                list = options;
            }

            while (list.IndexOf("  ") > 0)
            {
                list = Regex.Replace(list, "  ", " ");
            }

            return list;
        }

        public string FilterText { get => routingText; set => routingText = value; }
        public bool HasVar { get => hasVar; }
        internal List<FilterVar> FilterVars { get => filterVars; set => filterVars = value; }
    }
}

