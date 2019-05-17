using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class DbidForeignKey : ForeignKey
    {
        private static readonly ILog log = Global.Log;

        private string columnName;

        public DbidForeignKey(string tableName, string columnName, string referencedTableName)
            : base(tableName, referencedTableName)
        {
            this.columnName = columnName;
        }

        protected override Key createValueOfKey(Row row)
        {
            string columnValue = row.getValue(columnName);
            return columnValue != "0" ?
                new Key(columnValue) :
                null;
        }

        protected override string getReferenceName()
        {
            return columnName;
        }

        protected override string getReverseReferenceName()
        {
            return tableName;
        }

        public override string ToString()
        {
            return String.Format(
                "DbidForeignKey from {0}.{1} to {2}",
                tableName, columnName, referencedTableName);
        }
    }
}
