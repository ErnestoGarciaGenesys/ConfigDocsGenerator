using System.Collections.Generic;

namespace CfgDoc.Input.Db
{
    class TableDefinition
    {
        static readonly string[] defaultKeyColumns = new string[] { "dbid" };

        readonly string tableName;
        string[] keyColumns = defaultKeyColumns;
        readonly ICollection<ForeignKey> foreignKeys = new List<ForeignKey>();
 
        bool allowsRepetitiveKey = false;

        public TableDefinition(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName { get { return tableName; } }

        public string[] KeyColumns
        {
            get { return keyColumns; }
            set { keyColumns = value; }
        }

        public ICollection<ForeignKey> ForeignKeys
        {
            get { return foreignKeys; }
        }

        public bool AllowsRepetitiveKey
        {
            get { return allowsRepetitiveKey; }
            set { allowsRepetitiveKey = value; }
        }

        public bool readRow(IDictionary<string, string> columns)
        {
            return readRowImpl(columns);
        }

        virtual protected bool readRowImpl(IDictionary<string, string> columns)
        {
            return true;
        }

        /// <exception cref="KeyNotFoundException">
        ///     If the row does not contain all key columns of the table.
        /// </exception>
        public Key getKey(Row row)
        {
            List<string> values = new List<string>();

            for (int i = 0; i < keyColumns.Length; i++)
            {
                var column = keyColumns[i];

                if (row.ContainsValueColumn(column))
                {
                    values.Add(row.getValue(keyColumns[i]));
                }
            }

            return new Key(values.ToArray());
        }
    }
}
