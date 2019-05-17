using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class TableContents
    {
        readonly TableDefinition tableDefinition;

        readonly IDictionary<Key, Row> rows = new Dictionary<Key, Row>();

        public TableContents(TableDefinition tableDefinition)
        {
            this.tableDefinition = tableDefinition;
        }

        public void AddRow(Row row)
        {
            Key index = tableDefinition.getKey(row);

            if (rows.ContainsKey(index))
            {
                if (!tableDefinition.AllowsRepetitiveKey)
                    throw new Exception(string.Format(
                        "Cannot add row to table {0}, index repeated:\nindex={1}, row={2}",
                        tableDefinition.TableName, index, row));
            }
            else {
                rows.Add(index, row);
            }
        }

        public ICollection<Row> GetRows()
        {
            return rows.Values;
        }

        /// <exception cref="KeyNotFoundException">If there is no row with that key.</throws>
        public Row GetRow(Key key)
        {
            try
            {
                return rows[key];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(String.Format(
                    "Row with index {0} not found in table {1}",
                    key, tableDefinition.TableName), e);
            }
        }
    }
}
