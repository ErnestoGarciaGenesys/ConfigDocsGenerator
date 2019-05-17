using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class EnumForeignKey : ForeignKey
    {
        private static readonly ILog log = Global.Log;

        private string columnName;
        private DatabaseDefinition.EnumType enumType;

        public EnumForeignKey(string tableName, string columnName,
            DatabaseDefinition.EnumType enumType)
            : base(tableName, "cfg_locale")
        {
            this.columnName = columnName;
            this.enumType = enumType;
        }

        protected override Key createValueOfKey(Row row)
        {
            return new Key("1", "8", 
                ((int)enumType).ToString(),
                row.getValue(columnName));
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
                "EnumForeignKey from {0}.{1} to {2} using enum type {3}",
                tableName, columnName, referencedTableName, enumType);
        }
    }
}
