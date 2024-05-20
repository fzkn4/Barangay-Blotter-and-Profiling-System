using Guna.UI2.WinForms;
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
    public partial class update_resident : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public update_resident()
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
                cmd.CommandText = "SELECT fname, mname, lname, birthdate, gender, status, purok, zone, voter_status, osy_status, religion from residents where residentID=" + Form1.resident_id + "";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    fname.Text = dr["fname"].ToString();
                    mname.Text = dr["mname"].ToString();
                    lname.Text = dr["lname"].ToString();
                    resident_date_add.Value = DateTime.Parse(dr["birthdate"].ToString());
                    gender.Text = dr["gender"].ToString();
                    resident_status.Text = dr["status"].ToString();
                    purokName.Text = dr["purok"].ToString();
                    zone.Text = dr["zone"].ToString();
                    if (dr["voter_status"].ToString() == "Y")
                    {
                        voter_active.Select();
                    }
                    else
                    {
                        voter_inactive.Select();

                    }
                    if (dr["osy_status"].ToString() == "Y")
                    {
                        osy_yes.Select();
                    }
                    else
                    {
                        osy_no.Select();

                    }
                    religion.Text = dr["religion"].ToString();

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void update_resident_data()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "update residents set fname=@fname, mname=@mname, lname=@lname, age=@age, birthdate=@bday, gender=@gender, status=@status, purok=@purok, zone=@zone, voter_status=@voter_status, osy_status=@osy_status, religion=@religion where residentID=@residentID";
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
                cmd.Parameters.Add("@residentID", MySqlDbType.Int32).Value = Form1.resident_id;
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

        private int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;
            return age;
        }

        private void update_Click(object sender, EventArgs e)
        {
            update_resident_data();
        }

        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
