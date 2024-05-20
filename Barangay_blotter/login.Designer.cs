namespace Barangay_blotter
{
    partial class login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            username = new Guna.UI2.WinForms.Guna2TextBox();
            sign_in = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label3 = new Label();
            password = new Guna.UI2.WinForms.Guna2TextBox();
            register = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(167, 30, 52);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(381, 84);
            guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(252, 245, 237);
            label1.Location = new Point(135, 19);
            label1.Name = "label1";
            label1.Size = new Size(118, 45);
            label1.TabIndex = 0;
            label1.Text = "Sign In";
            // 
            // username
            // 
            username.Animated = true;
            username.BorderColor = Color.FromArgb(217, 221, 226);
            username.BorderRadius = 4;
            username.BorderThickness = 2;
            username.CustomizableEdges = customizableEdges3;
            username.DefaultText = "";
            username.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            username.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            username.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            username.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            username.FocusedState.BorderColor = Color.FromArgb(206, 90, 103);
            username.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            username.HoverState.BorderColor = Color.FromArgb(125, 137, 149);
            username.Location = new Point(70, 139);
            username.Name = "username";
            username.PasswordChar = '\0';
            username.PlaceholderText = "";
            username.SelectedText = "";
            username.ShadowDecoration.CustomizableEdges = customizableEdges4;
            username.Size = new Size(239, 44);
            username.TabIndex = 1;
            // 
            // sign_in
            // 
            sign_in.Animated = true;
            sign_in.BorderColor = Color.FromArgb(167, 30, 52);
            sign_in.BorderRadius = 4;
            sign_in.BorderThickness = 1;
            sign_in.CustomizableEdges = customizableEdges5;
            sign_in.DisabledState.BorderColor = Color.DarkGray;
            sign_in.DisabledState.CustomBorderColor = Color.DarkGray;
            sign_in.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            sign_in.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            sign_in.FillColor = Color.FromArgb(252, 245, 237);
            sign_in.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            sign_in.ForeColor = Color.FromArgb(167, 30, 52);
            sign_in.HoverState.FillColor = Color.FromArgb(167, 30, 52);
            sign_in.HoverState.ForeColor = Color.FromArgb(252, 245, 237);
            sign_in.Location = new Point(70, 298);
            sign_in.Name = "sign_in";
            sign_in.ShadowDecoration.CustomizableEdges = customizableEdges6;
            sign_in.Size = new Size(108, 45);
            sign_in.TabIndex = 3;
            sign_in.Text = "Sign In";
            sign_in.Click += sign_in_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 121);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 205);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // password
            // 
            password.Animated = true;
            password.BorderColor = Color.FromArgb(217, 221, 226);
            password.BorderRadius = 4;
            password.BorderThickness = 2;
            password.CustomizableEdges = customizableEdges7;
            password.DefaultText = "";
            password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            password.FocusedState.BorderColor = Color.FromArgb(206, 90, 103);
            password.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            password.HoverState.BorderColor = Color.FromArgb(125, 137, 149);
            password.Location = new Point(70, 223);
            password.Name = "password";
            password.PasswordChar = '●';
            password.PlaceholderText = "";
            password.SelectedText = "";
            password.ShadowDecoration.CustomizableEdges = customizableEdges8;
            password.Size = new Size(239, 44);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            password.KeyDown += input_keydown;
            // 
            // register
            // 
            register.Animated = true;
            register.BorderColor = Color.FromArgb(167, 30, 52);
            register.BorderRadius = 4;
            register.BorderThickness = 1;
            register.CheckedState.FillColor = Color.FromArgb(206, 90, 103);
            register.CheckedState.ForeColor = Color.White;
            register.CustomizableEdges = customizableEdges9;
            register.DisabledState.BorderColor = Color.DarkGray;
            register.DisabledState.CustomBorderColor = Color.DarkGray;
            register.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            register.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            register.FillColor = Color.FromArgb(167, 30, 52);
            register.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            register.ForeColor = Color.FromArgb(252, 245, 237);
            register.HoverState.FillColor = Color.FromArgb(252, 245, 237);
            register.HoverState.ForeColor = Color.FromArgb(167, 30, 52);
            register.Location = new Point(201, 298);
            register.Name = "register";
            register.ShadowDecoration.CustomizableEdges = customizableEdges10;
            register.Size = new Size(108, 45);
            register.TabIndex = 4;
            register.Text = "Register";
            register.Click += register_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 245, 237);
            ClientSize = new Size(381, 401);
            Controls.Add(register);
            Controls.Add(label3);
            Controls.Add(password);
            Controls.Add(label2);
            Controls.Add(sign_in);
            Controls.Add(username);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login ";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private Guna.UI2.WinForms.Guna2Button sign_in;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2Button register;
    }
}