using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgSystem : AbstractCfgObjectDecorator
    {
        public CfgSystem(ICfgObject decorated) {
            this.decorated = decorated;
        }
        public string GatheredDate { get { return GetString("gathered_date"); } }
        public ICollection<CfgHost> Hosts
        { get { return GetMultiRef<CfgHost>("hosts"); } }
        public ICollection<CfgServer> Servers
        { get { return GetMultiRef<CfgServer>("servers"); } }
        public ICollection<CfgApplication> Applications
        { get { return GetMultiRef<CfgApplication>("applications"); } }
        public ICollection<CfgService> Services
        { get { return GetMultiRef<CfgService>("services"); } }
        public ICollection<CfgSwitch> Switches
        { get { return GetMultiRef<CfgSwitch>("switches"); } }
        public ICollection<CfgTenant> Tenants
        { get { return GetMultiRef<CfgTenant>("tenants"); } }
    }
}
