using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Output.Html
{
    class HtmlOutputKit : CfgOutputKit
    {
		public override string Name { get { return "HTML pages"; } }
	
		public override string SettingsSummary { get { return ""; } }
		
		private HtmlOutput output;
		public override ICfgOutput Output { get { return output; } }

		private HtmlSettingsControl settingsControl;
		public override SettingsControl SettingsControl { get { return settingsControl; } }

        public HtmlOutputKit()
        {
            HtmlOutput htmlOutput = new HtmlOutput();
            output = htmlOutput;
            settingsControl = new HtmlSettingsControl();
		}
		
		public override void ApplySettings() {
			HtmlSettings settings = output.Settings;
			settings.OutputPath = settingsControl.OutputPath;
            settings.CompanyName = settingsControl.CompanyName;
            settings.ProjectId = settingsControl.ProjectId;
            settings.ProjectName = settingsControl.ProjectName;
            settings.AuthorName = settingsControl.AuthorName;
            settings.DiagramFilePath = settingsControl.DiagramFilePath;
            settings.Description = settingsControl.Description;
		}
		
		public override void ResetSettingsControl() {
			HtmlSettings settings = output.Settings;
            settingsControl.OutputPath = settings.OutputPath;
            settingsControl.CompanyName = settings.CompanyName;
            settingsControl.ProjectId = settings.ProjectId;
            settingsControl.ProjectName = settings.ProjectName;
            settingsControl.AuthorName = settings.AuthorName;
            settingsControl.DiagramFilePath = settings.DiagramFilePath;
            settingsControl.Description = settings.Description;
        }
    }
}
