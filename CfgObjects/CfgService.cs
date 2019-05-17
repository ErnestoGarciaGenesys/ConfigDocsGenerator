using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgService : AbstractCfgObjectDecorator
    {
        public string Dbid { get { return GetString("dbid"); } }
        public string Name { get { return GetString("name"); } }
        public string SolutionType { get { return GetEnum("solution_type"); } }
        public ICollection<CfgSolutionComp> SolutionComps
        { get { return GetMultiRef<CfgSolutionComp>("cfg_solution_comp"); } }
    }
}
