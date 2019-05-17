using System.Collections.Generic;

namespace CfgDoc.CfgObjects
{
    class CfgFlexProp : AbstractCfgObjectDecorator
    {
        public string Name { get { return GetString("prop_name"); } }
        public string Value { get { return GetString("prop_value"); } }
        public CfgFlexProp Parent { get { return GetRef<CfgFlexProp>("parent_dbid"); } }
        public ICollection<CfgFlexProp> Children
        { get { return GetMultiRef<CfgFlexProp>("cfg_flex_prop"); } }
    }
}
