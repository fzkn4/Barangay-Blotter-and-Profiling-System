using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Barangay_blotter
{
    public partial class registerForm : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public registerForm()
        {
            InitializeComponent();
            mismatch.Visible = false;
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }

        private void register_user()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO users(accountID, username, password, first_name, middle_name, last_name, position)VALUES(" + setAccountID() + ", @username, @password, @fname,@mname, @lname, @position)";
                cmd.Parameters.Add("@fname", MySqlDbType.String).Value = first_letter_capital(fname.Text);
                cmd.Parameters.Add("@mname", MySqlDbType.String).Value = first_letter_capital(mname.Text);
                cmd.Parameters.Add("@lname", MySqlDbType.String).Value = first_letter_capital(lname.Text);
                cmd.Parameters.Add("@position", MySqlDbType.String).Value = first_letter_capital(position.Text);
                cmd.Parameters.Add("@username", MySqlDbType.String).Value = username.Text;
                cmd.Parameters.Add("@password", MySqlDbType.String).Value = password.Text;
                cmd.ExecuteNonQuery();


                MessageBox.Show("Account registered successful.");
                clearTextfields();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();

        }

        private int setAccountID()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(accountID) as accounts from users";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("accounts");

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id++;

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            clearTextfields();
        }
        private void clearTextfields()
        {
            fname.Clear();
            mname.Clear();
            lname.Clear();
            position.Clear();
            username.Clear();
            password.Clear();
            confirm_password.Clear();
        }

        private void register_Click(object sender, EventArgs e)
        {
            register_user();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void confirm_password_TextChanged(object sender, EventArgs e)
        {
            if (confirm_password.Text.Length > 0 && password.Text.Length > 0)
            {
                if (password.Text != confirm_password.Text)
                {
                    mismatch.Visible = true;
                }
                else
                {
                    mismatch.Visible = false;
                }
            }
            else
            {
                mismatch.Visible = false;
            }
        }
    }
}
