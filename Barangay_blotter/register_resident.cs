using MySqlConnector;
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

namespace Barangay_blotter
{
    public partial class register_resident : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public register_resident()
        {
            InitializeComponent();
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            resident_status.Items.Add("Single");
            resident_status.Items.Add("Married");

            purokName.Items.Add("Malipayon");
            purokName.Items.Add("Madasigon");
            purokName.Items.Add("Malambuon");
            purokName.Items.Add("Mahigalaon");
            purokName.Items.Add("Matinahuron");
            purokName.Items.Add("Makiangayon");
            purokName.Items.Add("Matahum");
            purokName.Items.Add("Makugihum");
            purokName.Items.Add("Masidlakon");
            purokName.Items.Add("Mauswagon");
            purokName.Items.Add("Matinabangon");
            purokName.Items.Add("Madanihon");

        }

        private void register_Click(object sender, EventArgs e)
        {
            add_resident();
        }

        private void add_resident()
        {


            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO residents(residentID, fname, mname, lname, age, birthdate, gender, status, purok, zone, voter_status, osy_status, religion)VALUES(" + setResidentID() + ", @fname,@mname, @lname, @age, @bday, @gender, @status, @purok, @zone, @voter_status, @osy_status, @religion)";
                cmd.Parameters.Add("@fname", MySqlDbType.String).Value = first_letter_capital(fname.Text);
                cmd.Parameters.Add("@mname", MySqlDbType.String).Value = first_letter_capital(mname.Text);
                cmd.Parameters.Add("@lname", MySqlDbType.String).Value = first_letter_capital(lname.Text);
                cmd.Parameters.Add("@age", MySqlDbType.Int32).Value = GetAge(resident_date_add.Value);
                cmd.Parameters.Add("@bday", MySqlDbType.Date).Value = resident_date_add.Value;
                cmd.Parameters.Add("@gender", MySqlDbType.String).Value = gender.Text;
                cmd.Parameters.Add("@status", MySqlDbType.String).Value = resident_status.Text;
                cmd.Parameters.Add("@purok", MySqlDbType.String).Value = purokName.Text;
                cmd.Parameters.Add("@zone", MySqlDbType.Int32).Value = Convert.ToInt32(zone.Text);
                cmd.Parameters.Add("@voter_status", MySqlDbType.String).Value = (voter_active.Checked) ? "Y" : "N";
                cmd.Parameters.Add("@osy_status", MySqlDbType.String).Value = (osy_yes.Checked) ? "Y" : "N";
                cmd.Parameters.Add("@religion", MySqlDbType.String).Value = religion.Text;

                cmd.ExecuteNonQuery();


                MessageBox.Show("Registered Successfully.");
                Form1 main_page = new Form1();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            this.Close();
        }

        private int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;
            return age;
        }

        private int setResidentID()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT MAX(residentID) as maxID from residents";
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
            return id+=1;

        }

        private void voter_active_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void osy_certificate()
        {
           
        }

        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
