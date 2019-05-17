using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;

namespace CfgDoc.Input {
    
    /// <summary>
    /// Parse Genesys Configuration Exports.
    /// Users of this class have to make use of delegates to do actions on the rows parsed.
    /// </summary>
    // FIXME: improve this class: does not work properly with multiline insert statements,
    //       which happen sometimes.
    public class ExportFileParser {        
        public TextReader ExportReader;

        public delegate void InfoParsedDelegate(string infoType, string value);
        public event InfoParsedDelegate InfoParsed;

        public delegate void RowParsedDelegate(string itemType, IDictionary<string, string> columns);
        public event RowParsedDelegate RowParsed;

        private ILog genLog;
        public ILog Log { set { genLog = value; } }

        private void errorFound(string line, int lineNumber, string message, Exception exception)
        {
            string logMessage = String.Format("in line {0}: {1}: ({2})", lineNumber, message, line);
            genLog.Append("error", logMessage, exception);
        }

        public void parse()
        {
            string line = "";
            int lineNumber = 1;
            try {
                while ((line = ExportReader.ReadLine()) != null) {
                    parseLine(line, lineNumber);
                    lineNumber++;
                }
            }
            catch (Exception e) {
              errorFound(line, lineNumber, "Error reading the stream.", e);
            }
        }
        
        private static Regex blankLineRegex = new Regex(@"^\s*$");

        private static Regex firstSelectLineRegex = new Regex(
            @"^select distinct.*Created on (?<gatheredDate>.*?);");

        private static Regex selectLineRegex = new Regex("^select");
        
        private static Regex insertLineRegex = new Regex(
            @"^insert\s+into\s+(?<itemType>.*?)\s*" +
            @"\((?<columnNames>.*?)\)\s*" +
            @"values\s*\((?<columnValues>.*?)\)\s*$"
        );
        
        private void parseLine(string line, int lineNumber) {
            try {
                Match match = insertLineRegex.Match(line);
                if (match.Success) {
                    GroupCollection groups = match.Groups;
                    String[] columnNames = groups["columnNames"].ToString().Split(',');
                    String[] columnValues = groups["columnValues"].ToString().Split(',');

                    IDictionary<string, string> columns = new Dictionary<string, string>();
                    for (int i = 0; i < columnNames.Length; i++) {
                        columns[columnNames[i]] = columnValues[i].Trim('\'');
                    }
                
                    RowParsed(groups["itemType"].ToString(), columns);
                }
                else 
                {
                    Match match2 = firstSelectLineRegex.Match(line);
                    if (match2.Success)
                    {
                        string gatheredDate = match2.Groups["gatheredDate"].ToString();
                        InfoParsed("gatheredDate", gatheredDate);
                            
                    }
                    else if (!blankLineRegex.Match(line).Success &&
                             !selectLineRegex.Match(line).Success) 
                    {
                        errorFound(line, lineNumber, "Unexpected line.", null);
                    }
                }
            }
            catch (Exception e) {
                errorFound(line, lineNumber, "Error parsing line.", e);
            }
        }
        
        public class Test {
            // TODO: Add test code for various configuration export files.

            private static string dictionaryToString<K, V>(IDictionary<K, V> dictionary)
            {
                string res = "";
                foreach (KeyValuePair<K, V> kv in dictionary)
                {
                    res += kv.Key + "=" + kv.Value + ", ";
                }
                return res;
            }

            private static void testRowParsed(string itemType, IDictionary<string, string> columns)
            {
                Console.WriteLine(itemType + ": " + dictionaryToString(columns));
            }

            private static void testInfoParsed(string infoType, string value)
            {
                Console.WriteLine(infoType + "=" + value);
            }
            
            public static void test(string file) {
                ExportFileParser parser = new ExportFileParser();
                parser.ExportReader = new StreamReader(file);
                
                parser.RowParsed +=
                    new ExportFileParser.RowParsedDelegate(testRowParsed);
                parser.InfoParsed +=
                    new ExportFileParser.InfoParsedDelegate(testInfoParsed);

                parser.parse();
            }
        }
    }
}
