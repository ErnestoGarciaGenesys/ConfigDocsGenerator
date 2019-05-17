using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class DatabaseContents
    {
        IDictionary<string, TableContents> tables = new Dictionary<string, TableContents>();

        /// <summary>
        /// Gets a table or creates it.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public TableContents GetTable(string tableName)
        {
            TableContents table;
            bool exists = tables.TryGetValue(tableName, out table);

            if (!exists)
            {
                table = new TableContents(DatabaseDefinition.getTableDefinition(tableName));
                tables[tableName] = table;
            }
            
            return table;
        }

        private string gatheredDate;
        public string GatheredDate
        {
            set { gatheredDate = value; }
            get { return gatheredDate; }
        }

        public void ResolveReferences()
        {
            foreach (KeyValuePair<string, TableContents> kv in tables)
            {
                string tableName = kv.Key;
                TableContents table = kv.Value;

                foreach (Row row in table.GetRows())
                {
                    foreach (ForeignKey reference in DatabaseDefinition.getTableDefinition(tableName).ForeignKeys)
                    {
                        reference.resolve(this, tableName, row);
                    }
                }
            }
        }
    }
}
