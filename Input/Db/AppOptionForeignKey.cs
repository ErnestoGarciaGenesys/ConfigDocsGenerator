using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    /// <summary>
    /// For application options or flex_properties (annex tab options)
    /// </summary>
    class AppOptionForeignKey : ForeignKey
    {
        private string columnName;
        private Enum_CfgObjectType objectType;

        public AppOptionForeignKey(string tableName, string columnName,
            string referencedTableName, Enum_CfgObjectType objectType)
            : base(tableName, referencedTableName)
        {
            this.columnName = columnName;
            this.objectType = objectType;
        }

        protected override Key createValueOfKey(Row row)
        {
            if (row.getValueAsInt("object_type") == (int)objectType)
            {
                int parentId = row.getValueAsIntDefault("parent_id", -1);
                if (parentId != 0)
                    return new Key(row.getValue("object_dbid"));
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        protected override string getReferenceName()
        {
            return columnName;
        }

        protected override string getReverseReferenceName()
        {
            return tableName + "_" + objectType;
        }

        public override string ToString()
        {
            return String.Format(
                "AppOptionForeignKey from {0}.{1} to {2} using object type {3}",
                tableName, columnName, referencedTableName, objectType);
        }
    }
}
