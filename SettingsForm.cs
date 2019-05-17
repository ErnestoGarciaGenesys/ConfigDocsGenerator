using System;
using System.Drawing;
using System.Windows.Forms;

namespace CfgDoc {
	/// <summary>
	/// This form displays a custom control on it and the typical "OK",
	/// "Apply" and "Cancel" buttons at the bottom, for the user to be able
	/// to apply changes and/or close the form.
	/// </summary>
	public partial class SettingsForm {
		public SettingsForm() {
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
		}
		
		Control settingsControl;
		/// <summary>
		/// Control displayed on the form.
		/// </summary>
		public Control SettingsControl {
			get { return settingsControl; }
			set {
				settingsControl = value;
				centralPanel.Controls.Clear();
				
				if (settingsControl != null) {
					centralPanel.Controls.Add(settingsControl);
					ClientSize = new Size(
					  Math.Max(settingsControl.Width, buttonsPanel.MinimumSize.Width),
					  settingsControl.Height + buttonsPanel.Height
					);
				}
			}
		}
		
		public delegate void ApplyChangesDelegate();		
		/// <summary>
		/// Occurs when whether the "OK" button or the "Apply" button are clicked,
		/// and only if the property SettingsChanged is true.
		/// User code should apply changes made on the settings control.
		/// 
		/// If the control is not in a proper state to apply changes and the
		/// form should keep open, user code must throw an exception.
		/// This form will then display a proper message box with the
		/// exception message.
		/// </summary>
		public event ApplyChangesDelegate ApplyChanges;
		
		
		bool settingsChanged = false;
		/// <summary>
		/// User code must put this property to true when settings have changed,
		/// in order to enable the "Apply" button and for the form to call the
		/// ApplyChanges event when either the "OK" button or the "Apply" button
		/// are clicked.
		/// </summary>
		public bool SettingsChanged {
			get { return settingsChanged; }
			set {
				settingsChanged = value;
				applyButton.Enabled = value;
			}
		}
		
		/// <summary>
		/// Easy-to-call method for setting SettingsChanged to true.
		/// </summary>
		public void makeSettingsChanged() {
			SettingsChanged = true;
		}
		
		void AcceptButtonClick(object sender, System.EventArgs e) {
			if (tryApplyChanges()) {
				applyButton.Enabled = false;
				Close();
			}
		}
		
		void ApplyButtonClick(object sender, System.EventArgs e) {
			if (tryApplyChanges()) {
				applyButton.Enabled = false;
			}
		}
		
		void CancelButtonClick(object sender, System.EventArgs e) {
			Close();
		}
		
		/// <summary>
		/// Returns true iff changes can be applied succesfully without
		/// throwing any exception.
		/// </summary>
		bool tryApplyChanges() {
			if (settingsChanged) {
				bool result;
				try {
					if (ApplyChanges != null)
						ApplyChanges();
					
					result = true;
				}
				catch (Exception e) {
					MessageBox.Show(e.Message, "Try again...",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					
					result = false;
				}
				
				return result;
			}
			else {
				return true;
			}
		}
	}
}
