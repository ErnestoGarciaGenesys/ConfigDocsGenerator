using System;

namespace CfgDoc {
	public class SettingsControl : System.Windows.Forms.UserControl {
		public delegate void SettingsChangedDelegate();
		public event SettingsChangedDelegate SettingsChanged;
		
		protected void fireSettingsChanged() {
			if (SettingsChanged != null)
				SettingsChanged();
		}
	}
}
