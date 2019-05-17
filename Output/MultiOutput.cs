using System.Collections;
using CfgDoc.Input;
using CfgDoc.CfgObjects;

namespace CfgDoc.Output {
	/// <summary>
	/// Description of MultiOutput.
	/// </summary>
	class MultiOutput : ICfgOutput {
		public IList Outputs = new ArrayList();

		public void Generate(CfgSystem system) {
			foreach (ICfgOutput output in Outputs) {
				output.Generate(system);
			}
		}
	}
}
