using Guna.UI2.WinForms;
using MySqlConnector;
using System.Configuration;
using System.Globalization;

namespace Barangay_blotter
{
    public partial class editBlotterCase : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public editBlotterCase()
        {
            InitializeComponent();

            blotter_status.Items.Add("Active");
            blotter_status.Items.Add("Settled");
            blotter_status.Items.Add("Unresolved");
            get_resident_details();
        }


        private void get_resident_details()
        {
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT complainant_name, respondent_name, victim_name, schedule_date, blotter_description, blotter_status from blotter where caseID=" + Form1.blotter_id + "";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    set_name_credentials(dr["complainant_name"].ToString(), complainant_fname, complainant_lname);
                    set_name_credentials(dr["respondent_name"].ToString(), respondent_fname, responder_lname);
                    set_name_credentials(dr["victim_name"].ToString(), victim_fname, victim_lname);
                    blotter_schedule.Value = DateTime.Parse(dr["schedule_date"].ToString());
                    blotter_description.Text = dr["blotter_description"].ToString();
                    blotter_status.Text = dr["blotter_status"].ToString();

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void set_name_credentials(string wholename, Guna2TextBox fname, Guna2TextBox lname)
        {
            string[] carry = wholename.Split(',');
            fname.Text = carry[0];
            lname.Text = carry[1];
        }


        private void update_resident_data()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "update blotter set complainant_name=@complainant_name, respondent_name=@respondent_name, victim_name=@victim_name, schedule_date=@schedule_date, blotter_description=@blotter_description, blotter_status=@blotter_status where caseID=" + Form1.blotter_id + "";
                cmd.Parameters.Add("@complainant_name", MySqlDbType.String).Value = first_letter_capital(complainant_lname.Text) + ", " + first_letter_capital(complainant_fname.Text);
                cmd.Parameters.Add("@respondent_name", MySqlDbType.String).Value = first_letter_capital(responder_lname.Text) + ", " + first_letter_capital(respondent_fname.Text);
                cmd.Parameters.Add("@victim_name", MySqlDbType.String).Value = first_letter_capital(victim_lname.Text) + ", " + first_letter_capital(victim_fname.Text);
                cmd.Parameters.Add("@schedule_date", MySqlDbType.DateTime).Value = blotter_schedule.Value;
                cmd.Parameters.Add("@blotter_status", MySqlDbType.String).Value = blotter_status.Text;
                cmd.Parameters.Add("@blotter_description", MySqlDbType.String).Value = blotter_description.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully.");
                Form1 main_page = new Form1();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            this.Close();
        }

        private void blotter_confirm_Click(object sender, EventArgs e)
        {
            update_resident_data();
        }
        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

    }
}
