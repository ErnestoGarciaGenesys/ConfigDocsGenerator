using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class CfgAppOption : AbstractCfgObjectDecorator
    {
        public CfgApplication Application
        { get { return GetRef<CfgApplication>("object_dbid"); } }
        public string Section { get { return GetString("section"); } }
        public string Option { get { return GetString("opt"); } }
        public int Part { get { return GetInt("part"); } }
        public string Value { get { return GetString("val"); } }
    }
}
