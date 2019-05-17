using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgApplication : AbstractCfgObjectDecorator
    {
        public string Dbid { get { return GetString("dbid"); } }
        public string Name { get { return GetString("name"); } }
        public string Type { get { return GetEnum("type"); } }
        public string Version { get { return GetString("version"); } }
        public ICollection<CfgAppOption> Options
        { get { return GetMultiRef<CfgAppOption>("cfg_app_option_Application"); } }
        public ICollection<CfgFlexProp> FlexProperties
        { get { return GetMultiRef<CfgFlexProp>("cfg_flex_prop_Application"); } }
    }
}
