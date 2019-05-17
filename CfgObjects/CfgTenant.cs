using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgTenant : AbstractCfgObjectDecorator
    {
        public string Dbid { get { return GetString("dbid"); } }
        public string Name { get { return GetString("name"); } }
        public ICollection<CfgFlexProp> FlexProperties
        { get { return GetMultiRef<CfgFlexProp>("cfg_flex_prop_Tenant"); } }
    }
}
