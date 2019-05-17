using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgDN : AbstractCfgObjectDecorator
    {
        public string Number { get { return GetString("number_"); } }
        public string DNType { get { return GetEnum("type"); } }
        public ICollection<CfgFlexProp> FlexProperties
        { get { return GetMultiRef<CfgFlexProp>("cfg_flex_prop_DN"); } }
    }
}
