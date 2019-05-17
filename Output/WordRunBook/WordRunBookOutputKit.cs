using System;
using System.Collections.Generic;
using System.Text;
using CfgDoc.Output.Html;

namespace CfgDoc.Output.WordRunBook
{
    class WordRunBookOutputKit : CfgOutputKit
    {
        private WordRunBookOutput output = new WordRunBookOutput();

        private WordRunBookSettingsControl settingsControl =
            new WordRunBookSettingsControl();

        public override ICfgOutput Output
        {
            get { return output; }
        }

        public override string Name
        {
            get { return "Word Run Book"; }
        }

        public override string SettingsSummary
        {
            get { return ""; }
        }

        public override SettingsControl SettingsControl
        {
            get { return settingsControl; }
        }

        public override void ApplySettings() {
            output.FilePath = settingsControl.OutputPath;
        }

        public override void ResetSettingsControl() {
            settingsControl.OutputPath = output.FilePath;
        }
    }
}
