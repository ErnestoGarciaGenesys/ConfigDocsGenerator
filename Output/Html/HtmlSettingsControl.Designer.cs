namespace CfgDoc.Output.Html
{
    partial class HtmlSettingsControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browseForOutputPathButton = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.projectIdTextBox = new System.Windows.Forms.TextBox();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.authorNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.diagramPathTextBox = new System.Windows.Forms.TextBox();
            this.browseForDiagramButton = new System.Windows.Forms.Button();
            this.diagramFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openOutputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputPathBrowserDialog
            // 
            this.outputPathBrowserDialog.Description = "Select the path to the folder that will contain the generated HTML pages";
            // 
            // browseForOutputPathButton
            // 
            this.browseForOutputPathButton.Location = new System.Drawing.Point(353, 19);
            this.browseForOutputPathButton.Name = "browseForOutputPathButton";
            this.browseForOutputPathButton.Size = new System.Drawing.Size(75, 23);
            this.browseForOutputPathButton.TabIndex = 1;
            this.browseForOutputPathButton.Text = "Browse...";
            this.browseForOutputPathButton.UseVisualStyleBackColor = true;
            this.browseForOutputPathButton.Click += new System.EventHandler(this.browseForOutputPathButton_Click);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(10, 19);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(337, 20);
            this.outputPathTextBox.TabIndex = 0;
            this.outputPathTextBox.TextChanged += new System.EventHandler(this.outputPathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client company name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project or contact center name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Genesys Project ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Author\'s name";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new System.Drawing.Point(166, 31);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(262, 20);
            this.companyNameTextBox.TabIndex = 10;
            this.companyNameTextBox.TextChanged += new System.EventHandler(this.companyNameTextBox_TextChanged);
            // 
            // projectIdTextBox
            // 
            this.projectIdTextBox.Location = new System.Drawing.Point(166, 57);
            this.projectIdTextBox.Name = "projectIdTextBox";
            this.projectIdTextBox.Size = new System.Drawing.Size(262, 20);
            this.projectIdTextBox.TabIndex = 11;
            this.projectIdTextBox.TextChanged += new System.EventHandler(this.projectIdTextBox_TextChanged);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(166, 83);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(262, 20);
            this.projectNameTextBox.TabIndex = 12;
            this.projectNameTextBox.TextChanged += new System.EventHandler(this.projectNameTextBox_TextChanged);
            // 
            // authorNameTextBox
            // 
            this.authorNameTextBox.Location = new System.Drawing.Point(166, 109);
            this.authorNameTextBox.Name = "authorNameTextBox";
            this.authorNameTextBox.Size = new System.Drawing.Size(262, 20);
            this.authorNameTextBox.TabIndex = 13;
            this.authorNameTextBox.TextChanged += new System.EventHandler(this.authorNameTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Optional architecture diagram to include (GIF, JPEG)";
            // 
            // diagramPathTextBox
            // 
            this.diagramPathTextBox.Location = new System.Drawing.Point(10, 193);
            this.diagramPathTextBox.Name = "diagramPathTextBox";
            this.diagramPathTextBox.Size = new System.Drawing.Size(337, 20);
            this.diagramPathTextBox.TabIndex = 20;
            this.diagramPathTextBox.TextChanged += new System.EventHandler(this.diagramPathTextBox_TextChanged);
            // 
            // browseForDiagramButton
            // 
            this.browseForDiagramButton.Location = new System.Drawing.Point(353, 191);
            this.browseForDiagramButton.Name = "browseForDiagramButton";
            this.browseForDiagramButton.Size = new System.Drawing.Size(75, 23);
            this.browseForDiagramButton.TabIndex = 21;
            this.browseForDiagramButton.Text = "Browse...";
            this.browseForDiagramButton.UseVisualStyleBackColor = true;
            this.browseForDiagramButton.Click += new System.EventHandler(this.browseForDiagramButton_Click);
            // 
            // diagramFileDialog
            // 
            this.diagramFileDialog.AddExtension = false;
            this.diagramFileDialog.FileName = "openFileDialog1";
            this.diagramFileDialog.Filter = "Image Files (*.gif; *.jpeg, *.jpg)|*.JPG;*.JPEG;*.GIF|All files (*.*)|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.companyNameTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.diagramPathTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.browseForDiagramButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.authorNameTextBox);
            this.groupBox1.Controls.Add(this.projectIdTextBox);
            this.groupBox1.Controls.Add(this.projectNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 226);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(166, 135);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(262, 20);
            this.descriptionTextBox.TabIndex = 14;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outputPathTextBox);
            this.groupBox2.Controls.Add(this.browseForOutputPathButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output folder";
            // 
            // openOutputFileDialog
            // 
            this.openOutputFileDialog.CheckFileExists = false;
            this.openOutputFileDialog.FileName = "openOutputFileDialog";
            // 
            // HtmlSettingsControl
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HtmlSettingsControl";
            this.Size = new System.Drawing.Size(444, 294);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog outputPathBrowserDialog;
        private System.Windows.Forms.Button browseForOutputPathButton;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.TextBox projectIdTextBox;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.TextBox authorNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox diagramPathTextBox;
        private System.Windows.Forms.Button browseForDiagramButton;
        private System.Windows.Forms.OpenFileDialog diagramFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.OpenFileDialog openOutputFileDialog;
    }
}
