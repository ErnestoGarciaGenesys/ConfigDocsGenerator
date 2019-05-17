using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgSolutionComp : AbstractCfgObjectDecorator
    {
        public CfgService Service { get { return GetRef<CfgService>("solution_dbid"); } }
        public CfgApplication Application
        { get { return GetRef<CfgApplication>("app_dbid"); } }
        public int StartupPriority { get { return GetInt("startup_priority"); } }
        public int IsOptional { get { return GetInt("is_optional"); } }
    }
}
