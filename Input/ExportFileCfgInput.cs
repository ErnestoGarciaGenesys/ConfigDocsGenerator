using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using CfgDoc.Input.Db;
using CfgDoc.CfgObjects;

namespace CfgDoc.Input 
{
    /// <summary>
    /// Description of CfgExportInput.
    /// </summary>
    class ExportFileCfgInput : ICfgInput
    {
        private DatabaseContents cfgDb;
        
        public TextReader ExportReader;

        public CfgSystem GetSystemConfiguration(ILog log)
        {
            ExportFileParser parser = new ExportFileParser();
            parser.ExportReader = ExportReader;
            parser.RowParsed +=
                new ExportFileParser.RowParsedDelegate(parser_RowParsed);
            parser.InfoParsed +=
                new ExportFileParser.InfoParsedDelegate(parser_InfoParsed);
            parser.Log = log;

            cfgDb = new DatabaseContents();
            parser.parse();
            cfgDb.ResolveReferences();
            CfgSystem result = 
                new CfgSystem(
                    new DefaultCfgObjectDecorator(
                        new ExportFileCfgSystem(cfgDb)));
            return result;
        }

        void parser_InfoParsed(string infoType, string value)
        {
            switch (infoType)
            {
                case "gatheredDate":
                    cfgDb.GatheredDate = value;
                    break;
            }
        }

        private void parser_RowParsed(string tableName, IDictionary<string, string> columns)
        {
            TableDefinition tableDef = DatabaseDefinition.getTableDefinition(tableName);

            if (tableDef != null && tableDef.readRow(columns))
            {
                Row row = new Row();

                foreach (KeyValuePair<string, string> col in columns)
                {
                    row.addValue(col.Key, col.Value);
                }

                cfgDb.GetTable(tableName).AddRow(row);
            }
        }
    }
}
