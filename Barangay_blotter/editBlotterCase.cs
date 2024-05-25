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
            get_resident_details();
            option.Items.Add("AM");
            option.Items.Add("PM");
            option.Text = "AM";
        }


        private void get_resident_details()
        {
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT * from blotter where caseID=" + Form1.blotter_id + "";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    set_name_credentials(dr["complainant_name"].ToString(), complainant_fname, complainant_lname);
                    set_name_credentials(dr["respondent_name"].ToString(), respondent_fname, responder_lname);
                    complainant_address.Text = dr["complainant_address"].ToString();
                    blotter_date.Value = Convert.ToDateTime(dr["blotter_date"].ToString());
                    blotter_date.Value = Convert.ToDateTime(dr["blotter_time"].ToString());
                    blotter_description.Text = dr["blotter_description"].ToString();
                    timeBreaker(dr["blotter_time"].ToString());

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
            wholename = wholename.Trim(' ');
            string[] carry = wholename.Split(',');
            fname.Text = carry[1];
            lname.Text = carry[0];
        }


        private void update_resident_data()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "update blotter set complainant_name=@complainant_name, complainant_address=@complainant_address, complainant_bday=@complainant_bday, respondent_name=@respondent_name, blotter_description=@blotter_description, blotter_date=@blotter_date, blotter_time=@blotter_time where caseID=" + Form1.blotter_id + "";
                cmd.Parameters.Add("@complainant_name", MySqlDbType.String).Value = first_letter_capital(complainant_lname.Text) + ", " + first_letter_capital(complainant_fname.Text);
                cmd.Parameters.Add("@complainant_address", MySqlDbType.String).Value = complainant_address.Text;
                cmd.Parameters.Add("@complainant_bday", MySqlDbType.Date).Value = complainant_bday.Value;
                cmd.Parameters.Add("@respondent_name", MySqlDbType.String).Value = first_letter_capital(responder_lname.Text) + ", " + first_letter_capital(respondent_fname.Text);
                cmd.Parameters.Add("@blotter_description", MySqlDbType.String).Value = blotter_description.Text;
                cmd.Parameters.Add("@blotter_date", MySqlDbType.DateTime).Value = blotter_date.Value;
                cmd.Parameters.Add("@blotter_time", MySqlDbType.DateTime).Value = Convert.ToDateTime(time_format(hour.Value.ToString(), minutes.Value.ToString(), option.Text));
                cmd.ExecuteNonQuery();


                MessageBox.Show("Blotter recorded.");
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
        private string time_format(string h, string m, string type)
        {
            if (type == "AM")
            {
                return h + ":" + m + ":00";
            }
            else if (type == "PM")
            {
                int carry = Convert.ToInt32(h);
                h = (carry + 12).ToString();
                return h + ":" + m + ":00";
            }
            return "";
        }

        private void timeBreaker(string time)
        {
            if ((Convert.ToInt32(time[0].ToString() + time[1].ToString())) > 12)
            {
                hour.Value = (Convert.ToInt32(time[0].ToString() + time[1].ToString())) - 12;
            }
            else
            {
                hour.Value = (Convert.ToInt32(time[0].ToString() + time[1].ToString()));

            }
            minutes.Value = Convert.ToInt32(time[3].ToString() + time[4].ToString());
        }

        private void blotter_confirm_Click_1(object sender, EventArgs e)
        {
            update_resident_data();
        }
    }
}
