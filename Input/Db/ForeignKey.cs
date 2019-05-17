using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    /// <summary>
    /// A ForeignKey specifies, given a row, how to construct an index to the 
    /// referenced table in order to find the referenced Row.
    /// 
    /// It also contains the way to store this reference in the source row and
    /// the referenced row.
    /// 
    /// Subclasses have to define concrete behaviours by overriding the abstract
    /// methods defined in this abstract class.
    /// </summary>
    abstract class ForeignKey
    {
        protected readonly string tableName;
        protected readonly string referencedTableName;

        protected ForeignKey(string tableName, string referencedTable)
        {
            this.tableName = tableName;
            this.referencedTableName = referencedTable;
        }

        /// <summary>
        /// Can be null if no reference is to be created for the row given.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        abstract protected Key createValueOfKey(Row row);

        /// <summary>
        /// Can be null if no reference is to be stored inside the source row.
        /// </summary>
        abstract protected string getReferenceName();

        /// <summary>
        /// Can be null if no reference is to be stored inside the source row.
        /// </summary>
        abstract protected string getReverseReferenceName();

        abstract public override string ToString();

        public void resolve(DatabaseContents db, string tableName, Row row)
        {
            Key index = createValueOfKey(row);

            if (index != null)
            {
                TableContents referencedTable = db.GetTable(referencedTableName);
                try
                {
                    Row referencedRow = referencedTable.GetRow(index);

                    string referenceName = getReferenceName();
                    if (referenceName != null)
                        row.addRef(referenceName, referencedRow);

                    string reverseReferenceName = getReverseReferenceName();
                    if (reverseReferenceName != null)
                        referencedRow.addReverseRef(reverseReferenceName, row);
                }
                catch (KeyNotFoundException e)
                {
                    Global.Log.Append("warn",
                        "could not resolve reference " + this.ToString(), e);
                }
            }
        }
    }
}
