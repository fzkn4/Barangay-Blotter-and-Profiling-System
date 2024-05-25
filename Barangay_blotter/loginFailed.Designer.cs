namespace Barangay_blotter
{
    partial class loginFailed
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginFailed));
            offical_display = new Label();
            confirm = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // offical_display
            // 
            offical_display.BackColor = Color.Transparent;
            offical_display.Font = new Font("Microsoft Tai Le", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            offical_display.ForeColor = Color.FromArgb(69, 69, 69);
            offical_display.Location = new Point(0, 10);
            offical_display.Name = "offical_display";
            offical_display.Size = new Size(244, 75);
            offical_display.TabIndex = 36;
            offical_display.Text = "Login failed! Please try again.";
            offical_display.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirm
            // 
            confirm.Animated = true;
            confirm.BorderColor = Color.FromArgb(167, 30, 52);
            confirm.BorderRadius = 4;
            confirm.BorderThickness = 1;
            confirm.CheckedState.FillColor = Color.FromArgb(206, 90, 103);
            confirm.CheckedState.ForeColor = Color.White;
            confirm.CustomizableEdges = customizableEdges1;
            confirm.DisabledState.BorderColor = Color.DarkGray;
            confirm.DisabledState.CustomBorderColor = Color.DarkGray;
            confirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            confirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            confirm.FillColor = Color.FromArgb(167, 30, 52);
            confirm.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            confirm.ForeColor = Color.FromArgb(252, 245, 237);
            confirm.HoverState.FillColor = Color.FromArgb(252, 245, 237);
            confirm.HoverState.ForeColor = Color.FromArgb(167, 30, 52);
            confirm.Location = new Point(79, 72);
            confirm.Name = "confirm";
            confirm.PressedColor = Color.White;
            confirm.PressedDepth = 20;
            confirm.ShadowDecoration.CustomizableEdges = customizableEdges2;
            confirm.Size = new Size(83, 32);
            confirm.TabIndex = 95;
            confirm.Text = "Confirm";
            confirm.Click += confirm_Click;
            // 
            // loginFailed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 245, 237);
            ClientSize = new Size(243, 122);
            Controls.Add(confirm);
            Controls.Add(offical_display);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "loginFailed";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Failed";
            ResumeLayout(false);
        }

        #endregion

        private Label offical_display;
        private Guna.UI2.WinForms.Guna2Button confirm;
    }
}