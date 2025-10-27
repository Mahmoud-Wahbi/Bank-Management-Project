using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UI.Properties; // Assuming your resources are here

namespace UI
{
    public partial class ucHideShowPassword : UserControl
    {
        // Internal state: True if the password TEXT IS HIDDEN (showing '*')
        public bool _isPasswordHidden = true;

        // Public property to read the state from outside
        public bool IsPasswordHidden => _isPasswordHidden;
        public PictureBox pbEyeImage => pbHideShowPassword;

        // Define the custom event ---
        public event EventHandler ToggleStateChanged;
        // End event definition ---

        public ucHideShowPassword()
        {
            InitializeComponent();
            // --- CHANGE 1: Set the initial image ---
            // Start with the icon that INDICATES clicking will SHOW the password (e.g., open eye)
            pbHideShowPassword.Image = Resources.ShowPasswordWhite;
            this.BackColor = Color.Transparent;
        }

        private void pbHideShowPassword_Click(object sender, EventArgs e)
        {
            // 1. Toggle the internal state first
            _isPasswordHidden = !_isPasswordHidden;

            // 2. Update the image based on the NEW state
            if (_isPasswordHidden)
            {
                // If the password IS NOW HIDDEN, show the 'Show' icon (open eye) again
                pbHideShowPassword.Image = Resources.ShowPasswordWhite;
            }
            else
            {
                // If the password IS NOW VISIBLE, show the 'Hide' icon (closed eye)
                pbHideShowPassword.Image = Resources.HidePasswordWhite; // Make sure this is your 'closed eye' icon
            }

            // 3. Raise the event AFTER the state changes ---
            OnToggleStateChanged(EventArgs.Empty);
            // End raise event ---
        }

        // Helper method to safely raise the event
        protected virtual void OnToggleStateChanged(EventArgs e)
        {
            ToggleStateChanged?.Invoke(this, e);
        }
    }
}