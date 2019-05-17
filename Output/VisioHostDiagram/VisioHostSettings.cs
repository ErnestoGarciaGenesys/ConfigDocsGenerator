using System;

namespace CfgDoc.Output.VisioHostDiagram {
	public class VisioHostSettings {
		string stencilName;
		
		public string StencilName {
			get { return stencilName; }
		}
	
		public enum UnitsEnum { US, Metric };
		UnitsEnum units;
		public UnitsEnum Units {
			get { return units; }
			set {
				units = value;
				switch (units) {
					case UnitsEnum.US: stencilName = "SERVER_U.VSS"; break;
					case UnitsEnum.Metric: stencilName = "SERVER_M.VSS"; break;
				}
			}
		}
		
		public bool WriteHost = true;
		
		string hostText;
		public string HostText {
			get { return hostText; }
			set { hostText = value; }
		}
		
		public bool WriteApplicationList = true;
		
		string applicationText;
		public string ApplicationText {
			get { return applicationText; }
			set { applicationText = value; }
		}
		
		public VisioHostSettings() {
			Units = UnitsEnum.Metric;
			hostText = "$beginbold$$name$$endbold$ ($beginitalic$$ip$$enditalic$)";
			applicationText = "- $name$ $beginitalic$$primary$$enditalic$ ($type$ $version$)";
		}
	}
}
