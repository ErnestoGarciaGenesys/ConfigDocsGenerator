using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc
{
    interface ICfgObject
    {
        string GetString(string fieldName);
        int GetInt(string fieldName);
        string GetEnum(string fieldName);
        ICfgObject GetRef(string refName);
        ICollection<ICfgObject> GetMultiRefs(string refName);
    }
}
