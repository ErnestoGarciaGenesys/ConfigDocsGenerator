using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CfgDoc.Output.Html
{
    public partial class HtmlSettingsControl : CfgDoc.SettingsControl
    {
        public string OutputPath
        {
            get { return outputPathTextBox.Text; }
            set { outputPathTextBox.Text = value; }
        }

        public string DiagramFilePath
        {
            get { return diagramPathTextBox.Text; }
            set { diagramPathTextBox.Text = value; }
        }

        new public string CompanyName
        {
            get { return companyNameTextBox.Text; }
            set { companyNameTextBox.Text = value; }
        }

        public string ProjectId
        {
            get { return projectIdTextBox.Text; }
            set { projectIdTextBox.Text = value; }
        }

        public string ProjectName
        {
            get { return projectNameTextBox.Text; }
            set { projectNameTextBox.Text = value; }
        }

        public string AuthorName
        {
            get { return authorNameTextBox.Text; }
            set { authorNameTextBox.Text = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }
       
        public HtmlSettingsControl()
        {
            InitializeComponent();
        }

        private void browseForOutputPathButton_Click(object sender, EventArgs e)
        {
            outputPathBrowserDialog.SelectedPath = outputPathTextBox.Text;
            outputPathBrowserDialog.ShowDialog();
            outputPathTextBox.Text = outputPathBrowserDialog.SelectedPath;
        }

        private void browseForDiagramButton_Click(object sender, EventArgs e)
        {
            diagramFileDialog.FileName = diagramPathTextBox.Text;
            diagramFileDialog.ShowDialog();
            diagramPathTextBox.Text = diagramFileDialog.FileName;
        }

        private void outputPathTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void companyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void projectIdTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void authorNameTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void diagramPathTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            fireSettingsChanged();
        }
    }
}

