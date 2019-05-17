using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Output.Text
{
    class TextOutputKit : CfgOutputKit
    {
        private ICfgOutput output = new TextOutput();
        public override ICfgOutput Output
        {
            get { return output; }
        }

        public override string Name
        {
            get { return "Text description to console"; }
        }

        public override string SettingsSummary
        {
            get { return ""; }
        }

        public override SettingsControl SettingsControl
        {
            get { return null; }
        }

        public override void ApplySettings() {}

        public override void ResetSettingsControl() {}
    }
}
