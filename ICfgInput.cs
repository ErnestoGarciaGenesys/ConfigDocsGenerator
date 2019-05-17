using CfgDoc.Input;
using CfgDoc.CfgObjects;

namespace CfgDoc {
	interface ICfgInput
    {
		CfgSystem GetSystemConfiguration(ILog log);
	}
}
