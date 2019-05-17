using System;
using System.Collections.Generic;
using System.Text;
using CfgDoc.Input.Db;

namespace CfgDoc.Input
{
    class ExportFileCfgObject : ICfgObject
    {
        protected Row row;

        public ExportFileCfgObject(Row row)
        {
            this.row = row;
        }

        public string GetString(string fieldName)
        {
            return row.getValue(fieldName);
        }

        public int GetInt(string fieldName)
        {
            return row.getValueAsInt(fieldName);
        }

        public string GetEnum(string fieldName)
        {
            return row.getValueAsEnum(fieldName);
        }

        public ICfgObject GetRef(string refName)
        {
            return new ExportFileCfgObject(row.getRef(refName));
        }

        public ICollection<ICfgObject> GetMultiRefs(string refName)
        {
            ICollection<ICfgObject> result = new List<ICfgObject>();
            foreach (Row refRow in row.getReverseRefs(refName))
                result.Add(new ExportFileCfgObject(refRow));
            return result;
        }
    }
}
