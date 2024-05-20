using MySqlConnector;
using System.Configuration;
using System.Globalization;

namespace Barangay_blotter
{
    public partial class AddBlotterCase : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public AddBlotterCase()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void add_blotter()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO blotter(caseID, complainant_name, respondent_name, victim_name, blotter_description, blotter_status, blotter_date, schedule_date)VALUES(@caseID, @complainant_name, @respondent_name, @victim_name, @blotter_description, @blotter_status, @blotter_date, @schedule_date)";
                cmd.Parameters.Add("@caseID", MySqlDbType.Int32).Value = set_blotter_id();
                cmd.Parameters.Add("@complainant_name", MySqlDbType.String).Value = first_letter_capital(complainant_lname.Text) + ", " + first_letter_capital(complainant_fname.Text);
                cmd.Parameters.Add("@respondent_name", MySqlDbType.String).Value = first_letter_capital(responder_lname.Text) + ", " + first_letter_capital(respondent_fname.Text);
                cmd.Parameters.Add("@victim_name", MySqlDbType.String).Value = first_letter_capital(victim_lname.Text) + ", " + first_letter_capital(victim_fname.Text);
                cmd.Parameters.Add("@blotter_description", MySqlDbType.String).Value = blotter_description.Text;
                cmd.Parameters.Add("@blotter_status", MySqlDbType.String).Value = "Active";
                cmd.Parameters.Add("@blotter_date", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@schedule_date", MySqlDbType.DateTime).Value = blotter_schedule.Value;

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

        private int set_blotter_id()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT MAX(caseID) as maxID from blotter";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("maxID");

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id += 1;

        }

        private void blotter_confirm_Click(object sender, EventArgs e)
        {
            add_blotter();
        }

        private void blotter_clear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            complainant_fname.Clear();
            respondent_fname.Clear();
            victim_fname.Clear();
            complainant_lname.Clear();
            responder_lname.Clear();
            victim_lname.Clear();
            blotter_description.Clear();
        }

        private void blotter_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
