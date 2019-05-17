using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CfgDoc.Output.WordRunBook
{
    public partial class WordRunBookSettingsControl : SettingsControl
    {
        public WordRunBookSettingsControl()
        {
            InitializeComponent();
        }

        public string OutputPath
        {
            get { return outputPathTextBox.Text; }
            set { outputPathTextBox.Text = value; }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            createFileDialog.InitialDirectory = outputPathTextBox.Text;
            createFileDialog.ShowDialog();
            string oldOutputPath = OutputPath;
            OutputPath = createFileDialog.FileName;

            if (OutputPath != oldOutputPath)
                fireSettingsChanged();
        }
    }
}
