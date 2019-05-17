/*
 * Created by SharpDevelop.
 * User: egarcia
 * Date: 3/10/2006
 * Time: 1:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CfgDoc
{
	partial class MainForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.generateButton = new System.Windows.Forms.Button();
            this.openInputFileButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.openInputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outputSettingsButton = new System.Windows.Forms.Button();
            this.OutputCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.showLogButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(11, 154);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(183, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate!";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButtonClick);
            // 
            // openInputFileButton
            // 
            this.openInputFileButton.Location = new System.Drawing.Point(299, 31);
            this.openInputFileButton.Name = "openInputFileButton";
            this.openInputFileButton.Size = new System.Drawing.Size(79, 23);
            this.openInputFileButton.TabIndex = 2;
            this.openInputFileButton.Text = "Open...";
            this.openInputFileButton.UseVisualStyleBackColor = true;
            this.openInputFileButton.Click += new System.EventHandler(this.OpenInputFileButtonClick);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(9, 33);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(284, 20);
            this.inputFileTextBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.outputSettingsButton);
            this.groupBox1.Controls.Add(this.OutputCombo);
            this.groupBox1.Location = new System.Drawing.Point(11, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Type";
            // 
            // outputSettingsButton
            // 
            this.outputSettingsButton.Location = new System.Drawing.Point(299, 31);
            this.outputSettingsButton.Name = "outputSettingsButton";
            this.outputSettingsButton.Size = new System.Drawing.Size(78, 23);
            this.outputSettingsButton.TabIndex = 2;
            this.outputSettingsButton.Text = "Settings...";
            this.outputSettingsButton.UseVisualStyleBackColor = true;
            this.outputSettingsButton.Click += new System.EventHandler(this.OutputSettingsButtonClick);
            // 
            // OutputCombo
            // 
            this.OutputCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputCombo.FormattingEnabled = true;
            this.OutputCombo.Location = new System.Drawing.Point(9, 33);
            this.OutputCombo.Name = "OutputCombo";
            this.OutputCombo.Size = new System.Drawing.Size(284, 21);
            this.OutputCombo.TabIndex = 0;
            this.OutputCombo.SelectedIndexChanged += new System.EventHandler(this.OutputComboSelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.inputFileTextBox);
            this.groupBox2.Controls.Add(this.openInputFileButton);
            this.groupBox2.Location = new System.Drawing.Point(11, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 65);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Configuration Export file";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(310, 154);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(85, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Exit";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // showLogButton
            // 
            this.showLogButton.Location = new System.Drawing.Point(200, 154);
            this.showLogButton.Name = "showLogButton";
            this.showLogButton.Size = new System.Drawing.Size(104, 23);
            this.showLogButton.TabIndex = 6;
            this.showLogButton.Text = "Show process...";
            this.showLogButton.UseVisualStyleBackColor = true;
            this.showLogButton.Click += new System.EventHandler(this.showLogButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 191);
            this.Controls.Add(this.showLogButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generateButton);
            this.Name = "MainForm";
            this.Text = "Genesys Configuration Documentation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button outputSettingsButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ComboBox OutputCombo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog openInputFileDialog;
		private System.Windows.Forms.Button generateButton;
		private System.Windows.Forms.Button openInputFileButton;
		private System.Windows.Forms.TextBox inputFileTextBox;
		
		void OpenInputFileButtonClick(object sender, System.EventArgs e) {
			if(openInputFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				inputFileTextBox.Text = openInputFileDialog.FileName;
			}
		}
		
		void closeButtonClick(object sender, System.EventArgs e) {
			this.Close();
		}

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showLogButton;
	}
}
