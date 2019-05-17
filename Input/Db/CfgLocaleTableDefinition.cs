using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class CfgLocaleTableDefinition : TableDefinition
    {
        public CfgLocaleTableDefinition() :
            base("cfg_locale") { }

        protected override bool readRowImpl(IDictionary<string, string> columns)
        {
            int lcType = int.Parse(columns["lc_type"]);
            return Enum.IsDefined(typeof(DatabaseDefinition.EnumType), lcType);
        }
    }
}
