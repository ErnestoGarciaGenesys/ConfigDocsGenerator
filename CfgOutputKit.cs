using System;

namespace CfgDoc {
	abstract class CfgOutputKit : CfgInputOutputKit {
		public abstract ICfgOutput Output { get; }
	}
}
