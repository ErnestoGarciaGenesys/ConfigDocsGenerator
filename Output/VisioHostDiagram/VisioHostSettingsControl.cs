using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// FIXME: behave gracefully when syntax is not correct.
namespace CfgDoc.Output.VisioHostDiagram {
	public partial class VisioHostSettingsControl {
		
		public VisioHostSettings.UnitsEnum Units {
			get {
				return UsUnitsRadio.Checked ?
					VisioHostSettings.UnitsEnum.US :
					VisioHostSettings.UnitsEnum.Metric;
			}
			
			set {
				UsUnitsRadio.Checked = (value == VisioHostSettings.UnitsEnum.US);
				MetricUnitsRadio.Checked = (value != VisioHostSettings.UnitsEnum.US);
			}
		}
		
		public bool WriteHost {
			get { return hostCheckBox.Checked; }
			set { hostCheckBox.Checked = value; }
		}
		
		public string HostText {
			get { return hostTextBox.Text; }
			set { hostTextBox.Text = value; }
		}
		
		public bool WriteApplicationList {
			get { return applicationCheckBox.Checked; }
			set { applicationCheckBox.Checked = value; }
		}

		public string ApplicationText {
			get { return applicationTextBox.Text; }
			set { applicationTextBox.Text = value; }
		}
		
		public VisioHostSettingsControl() {
			InitializeComponent();
		}
	}
}
