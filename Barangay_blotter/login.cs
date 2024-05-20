using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Barangay_blotter
{
    public partial class login : Form
    {
        public static string name;
        public static string user_position;

        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public login()
        {
            InitializeComponent();
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            validate_login();
        }

        private void validate_login()
        {
            MySqlConnection connauj = new MySqlConnection(con);
            connauj.Open();
            try
            {

                MySqlCommand Comauj = new MySqlCommand() { Connection = connauj, CommandText = "select * from users where username='" + username.Text + "' and password='" + password.Text + "'" };
                MySqlDataReader readerauj = Comauj.ExecuteReader();
                if (readerauj.Read())
                {
                    name = readerauj["first_name"].ToString() + " " + readerauj["last_name"].ToString();
                    user_position = readerauj["position"].ToString();
                    Form1 mainpage = new Form1();
                    mainpage.Show();
                    this.Hide();
                    clear();

                }
                else
                {
                    loginFailed window = new loginFailed();
                    window.ShowDialog();

                }
                connauj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void register_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm();
            register.Show();
            this.Hide();
        }

        private void input_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validate_login();
            }
        }

        private void clear()
        {
            username.Clear();
            password.Clear();
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
    }
}
