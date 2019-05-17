using System;
using System.Windows.Forms;

namespace CfgDoc.Output.VisioHostDiagram {
	
	/// <summary>
	/// Description of VisioOutputKit.
	/// </summary>
	class VisioHostOutputKit : CfgOutputKit {
		public override string Name { get { return "Visio Server Diagram"; } }
	
		public override string SettingsSummary { get { return ""; } }
		
		private VisioHostOutput output;
		public override ICfgOutput Output { get { return output; } }

		private VisioHostSettingsControl settingsControl;
		public override SettingsControl SettingsControl { get { return settingsControl; } }
				
		public VisioHostOutputKit() {
			VisioHostOutput visioOutput = new VisioHostOutput();
			output = visioOutput;
			settingsControl = new VisioHostSettingsControl();
		}
		
		public override void ApplySettings() {
			new Parser.Parser().parseText(settingsControl.HostText, new Parser.ConsoleParseVisitor());
			new Parser.Parser().parseText(settingsControl.ApplicationText, new Parser.ConsoleParseVisitor());
			
			VisioHostSettings settings = output.Settings;
			settings.Units = settingsControl.Units;
			settings.HostText = settingsControl.HostText;
			settings.ApplicationText = settingsControl.ApplicationText;
			settings.WriteHost = settingsControl.WriteHost;
			settings.WriteApplicationList = settingsControl.WriteApplicationList;
		}
		
		public override void ResetSettingsControl() {
			VisioHostSettings settings = output.Settings;
			settingsControl.Units = settings.Units;
			settingsControl.HostText = settings.HostText;
			settingsControl.ApplicationText = settings.ApplicationText;
			settingsControl.WriteHost = settings.WriteHost;
			settingsControl.WriteApplicationList = settings.WriteApplicationList;
		}
	}
}
