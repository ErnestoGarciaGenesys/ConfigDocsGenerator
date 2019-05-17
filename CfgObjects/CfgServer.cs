using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgServer : AbstractCfgObjectDecorator
    {
        public CfgHost Host { get { return GetRef<CfgHost>("host_dbid"); } }
        public CfgApplication Application
        { get { return GetRef<CfgApplication>("app_dbid"); } }
    }
}
