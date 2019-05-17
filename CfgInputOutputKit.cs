using System;
using System.Windows.Forms;

namespace CfgDoc {
    
    /// <summary>
    /// Each object of this class represents a kind of input/output that
    /// the user can select from the GUI.
    /// </summary>
    public abstract class CfgInputOutputKit {

        /// <summary>
        /// Name of the input/output.
        /// This is the name the user will see for selecting this input/output.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Textual description of the configuration of this input/output.
        /// This is for user information only.
        /// </summary>
        public abstract string SettingsSummary { get; }
        
        /// <summary>
        /// Control for modifying the settings of this input/output.
        /// The control must keep its state on its own, i. e. it must not
        /// update the settings of this input/output before the ApplySettings
        /// method is called.
        /// Can be null if no settings can be configured for this input/output.
        /// </summary>
        public abstract SettingsControl SettingsControl { get; }
        
        /// <summary>
        /// Makes effective the settings set on the settings control to this input/output.
        /// </summary>
        public abstract void ApplySettings();
        
        /// <summary>
        /// Updates the state of the settings control according to the current
        /// settings of this input/output.
        /// </summary>
        public abstract void ResetSettingsControl();
    }
}
