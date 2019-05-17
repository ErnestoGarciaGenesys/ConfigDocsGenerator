using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgHost : AbstractCfgObjectDecorator
    {
        public string Dbid { get { return GetString("dbid"); } }
        public string Name { get { return GetString("name"); } }
        public string IpAddress { get { return GetString("ip_address"); } }
        public string OsType { get { return GetEnum("os_type"); } }
        public string OsVersion { get { return GetString("os_version"); } }
        public string LcaPort { get { return GetString("lca_port"); } }
        public ICollection<CfgServer> Servers
        { get { return GetMultiRef<CfgServer>("cfg_server"); } }
    }
}
