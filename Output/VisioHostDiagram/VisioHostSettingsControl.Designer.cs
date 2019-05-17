using System.Windows.Forms;

namespace CfgDoc.Output.VisioHostDiagram
{
	partial class VisioHostSettingsControl : SettingsControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.UsUnitsRadio = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MetricUnitsRadio = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.applicationCheckBox = new System.Windows.Forms.CheckBox();
			this.applicationTextBox = new System.Windows.Forms.TextBox();
			this.hostCheckBox = new System.Windows.Forms.CheckBox();
			this.hostTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// UsUnitsRadio
			// 
			this.UsUnitsRadio.Location = new System.Drawing.Point(6, 19);
			this.UsUnitsRadio.Name = "UsUnitsRadio";
			this.UsUnitsRadio.Size = new System.Drawing.Size(133, 24);
			this.UsUnitsRadio.TabIndex = 0;
			this.UsUnitsRadio.TabStop = true;
			this.UsUnitsRadio.Text = "US";
			this.UsUnitsRadio.UseVisualStyleBackColor = true;
			this.UsUnitsRadio.CheckedChanged += new System.EventHandler(this.UsUnitsRadioCheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.MetricUnitsRadio);
			this.groupBox1.Controls.Add(this.UsUnitsRadio);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(379, 90);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Diagram measurement units";
			// 
			// MetricUnitsRadio
			// 
			this.MetricUnitsRadio.Location = new System.Drawing.Point(6, 49);
			this.MetricUnitsRadio.Name = "MetricUnitsRadio";
			this.MetricUnitsRadio.Size = new System.Drawing.Size(133, 24);
			this.MetricUnitsRadio.TabIndex = 1;
			this.MetricUnitsRadio.TabStop = true;
			this.MetricUnitsRadio.Text = "Metric";
			this.MetricUnitsRadio.UseVisualStyleBackColor = true;
			this.MetricUnitsRadio.CheckedChanged += new System.EventHandler(this.MetricUnitsRadioCheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.applicationCheckBox);
			this.groupBox2.Controls.Add(this.applicationTextBox);
			this.groupBox2.Controls.Add(this.hostCheckBox);
			this.groupBox2.Controls.Add(this.hostTextBox);
			this.groupBox2.Location = new System.Drawing.Point(3, 99);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(385, 200);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Shapes\' text";
			// 
			// applicationCheckBox
			// 
			this.applicationCheckBox.Location = new System.Drawing.Point(6, 106);
			this.applicationCheckBox.Name = "applicationCheckBox";
			this.applicationCheckBox.Size = new System.Drawing.Size(177, 24);
			this.applicationCheckBox.TabIndex = 3;
			this.applicationCheckBox.Text = "Include applications list";
			this.applicationCheckBox.UseVisualStyleBackColor = true;
			this.applicationCheckBox.CheckedChanged += new System.EventHandler(this.ApplicationCheckBoxCheckedChanged);
			// 
			// applicationTextBox
			// 
			this.applicationTextBox.Location = new System.Drawing.Point(33, 136);
			this.applicationTextBox.Multiline = true;
			this.applicationTextBox.Name = "applicationTextBox";
			this.applicationTextBox.Size = new System.Drawing.Size(346, 50);
			this.applicationTextBox.TabIndex = 2;
			this.applicationTextBox.TextChanged += new System.EventHandler(this.ApplicationTextBoxTextChanged);
			// 
			// hostCheckBox
			// 
			this.hostCheckBox.Location = new System.Drawing.Point(6, 19);
			this.hostCheckBox.Name = "hostCheckBox";
			this.hostCheckBox.Size = new System.Drawing.Size(177, 24);
			this.hostCheckBox.TabIndex = 1;
			this.hostCheckBox.Text = "Include host description";
			this.hostCheckBox.UseVisualStyleBackColor = true;
			this.hostCheckBox.CheckedChanged += new System.EventHandler(this.HostCheckBoxCheckedChanged);
			// 
			// hostTextBox
			// 
			this.hostTextBox.Location = new System.Drawing.Point(33, 49);
			this.hostTextBox.Multiline = true;
			this.hostTextBox.Name = "hostTextBox";
			this.hostTextBox.Size = new System.Drawing.Size(346, 50);
			this.hostTextBox.TabIndex = 0;
			this.hostTextBox.TextChanged += new System.EventHandler(this.HostTextBoxTextChanged);
			// 
			// VisioHostSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "VisioHostSettingsControl";
			this.Size = new System.Drawing.Size(391, 309);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox applicationCheckBox;
		private System.Windows.Forms.CheckBox hostCheckBox;
		private System.Windows.Forms.TextBox applicationTextBox;
		private System.Windows.Forms.TextBox hostTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton UsUnitsRadio;
		private System.Windows.Forms.RadioButton MetricUnitsRadio;
		private System.Windows.Forms.GroupBox groupBox1;
		
		void UsUnitsRadioCheckedChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}
		
		void MetricUnitsRadioCheckedChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}

		void HostCheckBoxCheckedChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}
		
		void ApplicationCheckBoxCheckedChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}
		
		void HostTextBoxTextChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}
		
		void ApplicationTextBoxTextChanged(object sender, System.EventArgs e) {
			fireSettingsChanged();
		}
	}
}
