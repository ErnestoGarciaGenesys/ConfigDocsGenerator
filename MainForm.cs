using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CfgDoc.CfgObjects;
using CfgDoc.Log;

namespace CfgDoc {
    
    public partial class MainForm {
        
        /// Selected output kit.
        /// Is null when no output is selected.
        CfgOutputKit selectedOutput;
        
        /// Settings control of selected output kit.
        /// Is null when no output is selected or when selected output has 
        /// no settings control.
        /// If it is null, then the settings form has no control in it.
        /// If it is not null, then this control is on the settings form, and
        /// its SettingsChanged event is set to notify the settings form on changes.
        SettingsControl outputSettingsControl;
        
        /// Form displayed when settings button is clicked.
        /// If outputSettingsControl is not null, its ApplyChanges event is set
        /// to apply changes on the selected output.
        SettingsForm settingsForm = new SettingsForm();

        /// <summary>
        /// Displays generation logs.
        /// </summary>
        GenerationLogForm logForm = new GenerationLogForm();

        ILog log;


        [STAThread]
        public static void Main(string[] args) {
            //log4net.Config.BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
        public MainForm() {
            InitializeComponent();

            OutputCombo.DisplayMember = "Name";
            OutputCombo.Items.Add(new Output.WordRunBook.WordRunBookOutputKit());
            OutputCombo.Items.Add(new Output.VisioHostDiagram.VisioHostOutputKit());
            OutputCombo.Items.Add(new Output.Html.HtmlOutputKit());
            OutputCombo.Items.Add(new Output.Text.TextOutputKit());
                        
            outputSettingsButton.Enabled = false;

            log = new CompositeLog(logForm, new ConsoleLog());
        }
        
        void GenerateButtonClick(object sender, System.EventArgs e) {
            try
            {
                if (ReferenceEquals(OutputCombo.SelectedItem, null))
                    throw new Exception("No output selected.");

                Input.ExportFileCfgInput input = new Input.ExportFileCfgInput();
                try {
                    input.ExportReader = new System.IO.StreamReader(inputFileTextBox.Text);
                }
                catch (Exception ex) {
                    throw new Exception("Could not open input file. " + ex.Message, ex);
                }

                CfgSystem system;
                using (input.ExportReader)
                {
                    log.Append("info", "Reading input...", null);
                    system = input.GetSystemConfiguration(log);
                    log.Append("info", "Finished reading input.", null);
                }

                Output.TextOutput textOutput = new Output.TextOutput();
                Output.MultiOutput multiOutput = new Output.MultiOutput();
                //multiOutput.Outputs.Add(textOutput);
                multiOutput.Outputs.Add(selectedOutput.Output);
                log.Append("info", "Generating output...", null);
                multiOutput.Generate(system);
                log.Append("info", "Finished generating output.", null);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show(ex.ToString(), "Exception on Generation",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        void OutputSettingsButtonClick(object sender, System.EventArgs e) {
            selectedOutput.ResetSettingsControl();
            settingsForm.SettingsChanged = false;
            settingsForm.ShowDialog();
        }
        
        /// React to when the output selected is changed, to satisfy the invariant 
        /// conditions of internal fields.
        void OutputComboSelectedIndexChanged(object sender, System.EventArgs e) {
            CfgOutputKit newOutput =
                (CfgOutputKit)OutputCombo.SelectedItem;
            
            if (newOutput != selectedOutput) {
                selectedOutput = newOutput;
            
                if (outputSettingsControl != null) {
                    outputSettingsControl.SettingsChanged -= settingsForm.makeSettingsChanged;
                    settingsForm.ApplyChanges -= selectedOutput.ApplySettings;
                }

                if (ReferenceEquals(selectedOutput, null))
                {
                    settingsForm.Text = "Settings...";
                    outputSettingsControl = null;
                    settingsForm.SettingsControl = null;
                }
                else {
                    settingsForm.Text = "Settings for " + selectedOutput.Name + "...";
                    outputSettingsControl = selectedOutput.SettingsControl;
                    settingsForm.SettingsControl = outputSettingsControl;
                    if (outputSettingsControl != null) {
                        outputSettingsControl.SettingsChanged += settingsForm.makeSettingsChanged;
                        settingsForm.ApplyChanges += selectedOutput.ApplySettings;
                    }
                }
                outputSettingsButton.Enabled = (outputSettingsControl != null);
            }
        }

        private void showLogButton_Click(object sender, EventArgs e)
        {
            logForm.Show();
        }
    }
}
