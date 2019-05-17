using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CfgDoc.CfgObjects
{
    class CfgObjectUtil
    {
        public class SyntaxException : ApplicationException
        {
            public SyntaxException(string query)
                : base(String.Format("syntax error in query: '{0}'", query)) { }
            public SyntaxException(string query, string msg)
                : base(String.Format(
                    "syntax error in query: '{0}': {1}",
                    query, msg)) { }
        }

        private static Regex queryRegex =
            new Regex(@"(\((?<type>.*)\))?(?<path>.*)");

        /// <summary>
        /// A query is a string with
        /// - an optional "type" indicator and
        /// - a list of dot-separated strings.
        /// 
        /// The type indicator can be "(enum)" or "(int)" or "(string)".
        /// The default type indicator is "(string)".
        /// 
        /// Each of the strings except for the last one is the name of
        /// a reference. The last string is the name of either an integer,
        /// string or enum field. That will depend on the first part of the string.
        /// 
        /// For example, to a CfgServer object, the following queries could be applied:
        /// "host.name"
        /// "(enum)host.os_type"
        /// 
        /// To a CfgSolutionComp object:
        /// "(int)startup_priority"
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="SyntaxException">if the query's syntax is incorrect</exception>
        public static object Query(ICfgObject cfgObject, string query)
        {
            Match match = queryRegex.Match(query);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                string type = groups["type"].ToString();
                string[] path = groups["path"].ToString().Split('.');

                if (path.Length < 1)
                    throw new SyntaxException(query, "no reference path");

                ICfgObject current = cfgObject;
                for (int i = 0; i < path.Length - 1; i++)
                {
                    current = current.GetRef(path[i]);
                }

                string fieldName = path[path.Length - 1];

                switch (type)
                {
                    case "string": return current.GetString(fieldName);
                    case "enum": return current.GetEnum(fieldName);
                    case "int": return current.GetInt(fieldName);
                    case "flexprops": return FlexPropsToString(current.GetMultiRefs(fieldName));
                    case "": return current.GetString(fieldName);
                    default:
                      throw new SyntaxException(
                            query, "type indicator not valid: " + type);
                }
            }
            else
            {
                throw new SyntaxException(query);
            }
        }

        public static string FlexPropsToString(IEnumerable<ICfgObject> flexProps)
        {
            var result = new StringBuilder();

            foreach (var flexProp in flexProps)
            {
                result.AppendLine("[" + flexProp.GetString("prop_name") + "]");

                foreach (var child in flexProp.GetMultiRefs("cfg_flex_prop"))
                {
                    result.AppendLine(child.GetString("prop_name") + "=" + child.GetString("prop_value"));
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public static string FlexPropsToString(IEnumerable<CfgFlexProp> flexProps)
        {
            return FlexPropsToString(flexProps.Cast<ICfgObject>());
        }

        public static string OptionsToString(IEnumerable<CfgAppOption> rawOptions)
        {
            var result = new StringBuilder();

            var options =
                from rawOption in rawOptions
                orderby rawOption.Part
                group rawOption by new { rawOption.Section, rawOption.Option } into option
                select option.Aggregate(
                    string.Empty,
                    (s, o) => s + o.Value,
                    s => new 
                        {
                            Section = option.Key.Section,
                            Option = option.Key.Option,
                            Value = s
                        });
            
            var groupedOptions =
                from option in options
                orderby option.Option
                group option by option.Section into section
                orderby section.Key
                select section;

            foreach (var section in groupedOptions)
            {
                result.AppendLine("[" + section.Key + "]");

                foreach (var option in section)
                {
                    result.AppendLine(option.Option + "=" + option.Value);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
