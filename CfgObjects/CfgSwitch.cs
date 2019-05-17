using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgSwitch : AbstractCfgObjectDecorator
    {
        public string Name { get { return GetString("name"); } }
        public ICollection<CfgDN> DNs
        { get { return GetMultiRef<CfgDN>("cfg_dn"); } }
    }
}
