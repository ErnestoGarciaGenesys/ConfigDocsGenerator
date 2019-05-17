using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class Row
    {
        IDictionary<string, string> values =
            new Dictionary<string, string>();

        IDictionary<string, Row> refs =
            new Dictionary<string, Row>();

        IDictionary<string, ICollection<Row>> reverseRefs =
            new Dictionary<string, ICollection<Row>>();


        public bool ContainsValueColumn(string columnName)
        {
            return values.ContainsKey(columnName);
        }

        /// <exception cref="KeyNotFoundException">If no column exists with that name.</exception>
        public string getValue(string columnName)
        {
            try
            {
                return values[columnName];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(
                    String.Format("column '{0}' does not exist in row {1}", columnName, this),
                    e);
            }
        }

        public string getValueDefault(string columnName, string defaultValue)
        {
            string value;
            bool exists = values.TryGetValue(columnName, out value);
            return exists ? value : defaultValue;
        }

        public int getValueAsInt(string columnName)
        {
            return int.Parse(getValue(columnName));
        }

        public int getValueAsIntDefault(string columnName, int defaultValue)
        {
            string value;
            bool exists = values.TryGetValue(columnName, out value);
            return exists ? int.Parse(value) : defaultValue;
        }

        public ICollection<string> getAllColumnNames()
        {
            return values.Keys;
        }

        public void addValue(string columnName, string value)
        {
            values.Add(columnName, value);
        }

        public void addRef(string refName, Row refRow)
        {
            refs.Add(refName, refRow);
        }

        public Row getRef(string refName)
        {
            return refs[refName];
        }

        public Row getRefOrNull(string columnName)
        {
            Row row;
            bool exists = refs.TryGetValue(columnName, out row);
            return exists ? row : null;
        }

        public void addReverseRef(string refName, Row refRow)
        {
            ICollection<Row> rows;
            bool exists = reverseRefs.TryGetValue(refName, out rows);

            if (!exists)
            {
                rows = new List<Row>();
                reverseRefs.Add(refName, rows);
            }

            rows.Add(refRow);
        }

        public ICollection<Row> getReverseRefs(string refName)
        {
            ICollection<Row> rows;
            bool exists = reverseRefs.TryGetValue(refName, out rows);

            if (!exists)
            {
                rows = new List<Row>();
                reverseRefs.Add(refName, rows);
            }

            return rows;
        }

        public Row getReverseRef(string refName)
        {
            ICollection<Row> rows = getReverseRefs(refName);

            if (rows.Count == 0)
                throw new Exception("No reference from " + refName);
            else if (rows.Count > 1)
                throw new Exception("More than one reference from " + refName);

            return rows.GetEnumerator().Current;
        }

        public string getValueAsEnum(string refName)
        {
            return this.getRef(refName).getValue("lc_value");
        }

        public string getValueAsEnumDefault(string columnName, string defaultValue)
        {
            Row row = getRefOrNull(columnName);
            return row == null ?
                defaultValue :
                row.getValueDefault("lc_value", defaultValue);
        }

        public override string ToString()
        {
            return base.ToString() + "(" + Util.ToString.Collection(values, ", ") + ")";
        }
    }
}
 