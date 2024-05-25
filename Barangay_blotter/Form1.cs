using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Barangay_blotter
{
    public partial class Form1 : Form
    {
        DataSet blotter_dataset = new DataSet();
        DataTable blotter_data_table = new DataTable();
        int selected_row;
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            hidepanels();
            Home_panel.Visible = true;
            updateCounts();
            residents_table.ClearSelection();
            selected_row = -1;
            updateTable();

            account_name.Text = login.name;
            account_position.Text = login.user_position;

            update_blotter_table();
            residents_table.DataSource = search_resident();


            //ABOUT
            offical_display.Text = "BARANGAY BULATOK";
            offical_display.Visible = true;
            update_blotter_count();
            display_all_officials();

            chart.init_chart(summary_chart, line_dataset);
        }


        private void enableButtons()
        {
            home.Enabled = true;
            residents.Enabled = true;
            blotterRecords.Enabled = true;
            about.Enabled = true;
        }

        private void home_Click(object sender, EventArgs e)
        {
            offical_display.Text = "BARANGAY BULATOK";

            enableButtons();
            home.Enabled = false;
            hidepanels();
            Home_panel.Visible = true;
            offical_display.Visible = true;


        }

        private void residents_Click(object sender, EventArgs e)
        {
            offical_display.Text = "BARANGAY BULATOK";

            offical_display.Visible = true;

            enableButtons();
            residents.Enabled = false;

            hidepanels();
            resident_panel.Visible = true;

            residents_table.ClearSelection();
            resident_id = 0;
        }

        private void blotterRecords_Click(object sender, EventArgs e)
        {
            offical_display.Text = "BARANGAY BULATOK";

            offical_display.Visible = true;

            enableButtons();
            blotterRecords.Enabled = false;
            hidepanels();
            blotter_table.ClearSelection();
            blotter_panel.Visible = true;
            update_blotter_table();
        }

        private void about_Click(object sender, EventArgs e)
        {
            official_id = 0;
            offical_display.Text = "BARANGAY BULATOK OFFICIALS";
            offical_display.Visible = true;

            enableButtons();
            about.Enabled = false;
            hidepanels();
            about_panel.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void hidepanels()
        {
            Home_panel.Visible = false;
            resident_panel.Visible = false;
            blotter_panel.Visible = false;
            about_panel.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void update_residents_data()
        {

        }

        private void update_resident_Click(object sender, EventArgs e)
        {
            update_resident update = new update_resident();
            update.ShowDialog();
            updateTable();
            updateCounts();
        }

        private void add_resident_Click(object sender, EventArgs e)
        {
            register_resident register = new register_resident();
            register.ShowDialog();
            updateCounts();
        }

        private void delete_resident_Click(object sender, EventArgs e)
        {
            if (resident_id == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            switch (MessageBox.Show(this, "Are you sure you want to delete the selected row?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    delete_resident_data();

                    break;
            }
            updateCounts();
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


        private void updateTable()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("SELECT residentID as 'ID', fname as 'First Name', mname as 'Middle Name', lname as 'Last Name', age as 'Age',  birthdate as 'Birth date',  gender as 'Gender',  status as 'Status',  purok as 'Purok',  zone as 'Zone',  voter_status as 'Voter Status',  osy_status as 'OSY', religion as 'religion' from residents", con1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "residents");
                residents_table.DataSource = ds.Tables["residents"].DefaultView;
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void getMale()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as male_residents from residents where gender='Male'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("male_residents");
                    male_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getFemale()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as female_residents from residents where gender='Female'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("female_residents");
                    female_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOsy()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as osy_status from residents where osy_status='Y'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("osy_status");
                    osy_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getVoters()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as voters from residents where voter_status='Y'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("voters");
                    voter_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getNon_voters()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as non_voters from residents where voter_status='N'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("non_voters");
                    non_voter_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTotalPopulation()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(residentID) as population from residents ";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("population");
                    total_population_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateCounts()
        {
            updateTable();
            getMale();
            getFemale();
            getOsy();
            getVoters();
            getNon_voters();
            getTotalPopulation();
        }

        public static int resident_id;
        private void residents_table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            residents_table.Rows[0].Selected = false;
        }

        private void residents_table_cell_clicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (residents_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {

                    resident_id = Convert.ToInt32(residents_table.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }catch(Exception exx)
            {

            }

            
        }

        private void delete_resident_data()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "delete from residents where residentID=@residentID";
                cmd.Parameters.Add("@residentID", MySqlDbType.Int32).Value = resident_id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                updateTable();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
        }

        private void search_input_text_changed(object sender, EventArgs e)
        {
            residents_table.DataSource = search_resident();
        }

        private DataTable search_resident()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM residents WHERE fname LIKE CONCAT('%', @input, '%') OR mname LIKE CONCAT('%', @input, '%') OR lname LIKE CONCAT('%', @input, '%') OR residentID LIKE CONCAT('%', @input, '%') OR age LIKE CONCAT('%', @input, '%') OR birthdate LIKE CONCAT('%', @input, '%') OR gender LIKE CONCAT('%', @input, '%') OR status LIKE CONCAT('%', @input, '%') OR purok LIKE CONCAT('%', @input, '%') OR zone LIKE CONCAT('%', @input, '%') OR voter_status LIKE CONCAT('%', @input, '%') OR osy_status LIKE CONCAT('%', @input, '%') OR religion LIKE CONCAT('%', @input, '%') ORDER BY residentID";
                MySqlConnection conn1 = new MySqlConnection(con);
                MySqlCommand cmd;
                conn1.Open();
                cmd = conn1.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@input", MySqlDbType.String).Value = searchBox_residents.Text;
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                residents_table.DataSource = dt;
                conn1.Close();
            }
            catch (Exception e)
            {

            }


            return dt;


        }

        private void search_keyup(object sender, KeyEventArgs e)
        {
            residents_table.DataSource = search_resident();

        }

        private void add_blotter_case()
        {
            AddBlotterCase blotter = new AddBlotterCase();
            blotter.ShowDialog();

        }

        private void add_blotter_Click(object sender, EventArgs e)
        {
            add_blotter_case();
            update_blotter_table();
            update_blotter_count();
        }

        private void update_blotter_table()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("select caseID, complainant_name, complainant_address, respondent_name, blotter_description, blotter_date, TIME_FORMAT(blotter_time, '%r') as blotter_time from blotter", con1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "blotter");
                blotter_table.DataSource = ds.Tables["blotter"].DefaultView;
                blotter_dataset = ds;
                con1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void blotter_table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                blotter_table.Rows[0].Selected = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int blotter_id;
        private void blotter_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (blotter_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    try
                    {

                        blotter_id = Convert.ToInt32(blotter_table.Rows[e.RowIndex].Cells[0].Value.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            catch (Exception exx)
            {

            }
        }

        private void edit_blotter_Click(object sender, EventArgs e)
        {
            editBlotterCase editblotter = new editBlotterCase();
            editblotter.ShowDialog();
            update_blotter_count();
        }


        private void get_active_cases()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(caseID) as active from blotter where blotter_status='Active'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("active");
                    active_case_display.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void get_settled_cases()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(caseID) as settled from blotter where blotter_status='Settled'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("settled");
                    settled_case_display.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void get_total_blotter()
        {
            int id = 0;
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT COUNT(caseID) as blotter_count from blotter";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("blotter_count");
                    blotter_display_count.Text = number_formatter(id.ToString());

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void update_blotter_count()
        {
            update_blotter_table();
            get_active_cases();
            get_settled_cases();
            get_total_blotter();
        }
        private DataTable search_blotter_case()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT caseID, complainant_name, complainant_address, respondent_name, blotter_description, blotter_date, TIME_FORMAT(blotter_time, '%r') as 'blotter_time' FROM blotter WHERE complainant_name LIKE CONCAT('%', @input, '%') OR respondent_name LIKE CONCAT('%', @input, '%')  OR caseID LIKE CONCAT('%', @input, '%') OR blotter_description LIKE CONCAT('%', @input, '%') OR complainant_address LIKE CONCAT('%', @input, '%') order by caseID";
                MySqlConnection conn1 = new MySqlConnection(con);
                MySqlCommand cmd;
                conn1.Open();
                cmd = conn1.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@input", MySqlDbType.String).Value = blotter_searchbox.Text;
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                blotter_table.DataSource = dt;
                conn1.Close();
            }
            catch (Exception e)
            {

            }
            return dt;


        }

        private void blotter_searchbox_TextChanged(object sender, EventArgs e)
        {
            search_blotter_case();
        }

        private void blotter_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_blotter_data()
        {
            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "delete from blotter where caseID=@caseID";
                cmd.Parameters.Add("@caseID", MySqlDbType.Int32).Value = blotter_id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                updateTable();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
        }

        private void delete_blotter_Click(object sender, EventArgs e)
        {
            delete_blotter_data();
            update_blotter_count();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void edit_officials_Click(object sender, EventArgs e)
        {
            if (official_id > 0)
            {
                About about = new About();
                about.ShowDialog();
                official_id = 0;
                display_all_officials();
            }
            else
            {
                MessageBox.Show("Please select a Barangay Official to Edit.");
            }

        }

        private void about_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void captain_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(captain_pic, 1);
        }
        private void kagawad1_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad1_pic, 2);
        }

        private void kagawad2_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad2_pic, 3);
        }

        private void kagawad3_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad3_pic, 4);
        }

        private void kagawad4_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad4_pic, 5);
        }

        private void kagawad5_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad5_pic, 6);
        }

        private void kagawad6_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad6_pic, 7);
        }

        private void kagawad7_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(kagawad7_pic, 8);
        }

        private void secretary_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(secretary_pic, 9);
        }
        private void unselect(Guna2PictureBox img)
        {
            img.ShadowDecoration.Enabled = false;
        }

        private void selected(Guna2PictureBox img, int id)
        {
            official_id = id;
            img.ShadowDecoration.Enabled = true;
        }
        public static int official_id = 0;
        private void unselectAll()
        {
            unselect(captain_pic);
            unselect(kagawad1_pic);
            unselect(kagawad2_pic);
            unselect(kagawad3_pic);
            unselect(kagawad4_pic);
            unselect(kagawad5_pic);
            unselect(kagawad6_pic);
            unselect(kagawad7_pic);
            unselect(treasurer_pic);
            unselect(secretary_pic);
            unselect(sk_chairperson_pic);
        }

        private void treasurer_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(treasurer_pic, 10);
        }

        private void sk_chairperson_pic_Click(object sender, EventArgs e)
        {
            unselectAll();
            selected(sk_chairperson_pic, 11);
        }

        private string number_formatter(string numbers)
        {
            numbers = Regex.Replace(numbers, "[^0-9]", "");
            string formattedInput = "";
            for (int i = numbers.Length - 1, j = 1; i >= 0; i--, j++)
            {
                formattedInput = numbers[i] + formattedInput;
                if (j % 3 == 0 && i != 0)
                {
                    formattedInput = "," + formattedInput;
                }
            }

            return formattedInput;
        }

        private void about_panel_clicked(object sender, MouseEventArgs e)
        {
            unselectAll();
            official_id = 0;
        }

        //kani nga function converts byte into image and then displays kung unsa to na image gikan sa imong database.
        private void display_brgy_offical(int id, Label display_name, Guna2PictureBox img)
        {
            Byte[] ImageByte = new byte[64];
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT fname, lname, img from brgy_officials where brgy_official_id=" + id + " ";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    display_name.Text = dr["lname"].ToString() + ", " + dr["fname"].ToString();
                    ImageByte = (Byte[])(dr["img"]);    //getting the Blob value and passing into ImageByte(katong byte sa database gikan nga naka-save sa database)

                }
                if (ImageByte != null)
                {
                    // You need to convert it in bitmap to display the image
                    img.Image = ByteToImage(ImageByte);
                    img.Refresh();
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void display_all_officials()
        {
            display_brgy_offical(1, captain, captain_pic);
            display_brgy_offical(2, kagawad1, kagawad1_pic);
            display_brgy_offical(3, kagawad2, kagawad2_pic);
            display_brgy_offical(4, kagawad3, kagawad3_pic);
            display_brgy_offical(5, kagawad4, kagawad4_pic);
            display_brgy_offical(6, kagawad5, kagawad5_pic);
            display_brgy_offical(7, kagawad6, kagawad6_pic);
            display_brgy_offical(8, kagawad7, kagawad7_pic);
            display_brgy_offical(9, secretary, secretary_pic);
            display_brgy_offical(10, treasurer, treasurer_pic);
            display_brgy_offical(11, sk_chairperson, sk_chairperson_pic);
        }

        //CONVERTING BYTE (from db) TO IMAGE
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Replace "your_word_file.docx" with the path to your MS Word file
            string wordFilePath = "C:\\Users\\Fzkn4\\Music\\Fzkn4\\C isnt sharp\\Barangay_blotter\\Barangay_blotter\\resources\\OSY_certificate.docx";

            // Use the System.Diagnostics.Process class to launch MS Word
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFilePath)
            {
                UseShellExecute = true
            });
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            // Replace "your_word_file.docx" with the path to your MS Word file
            string wordFilePath = "C:\\Users\\Fzkn4\\Music\\Fzkn4\\C isnt sharp\\Barangay_blotter\\Barangay_blotter\\resources\\certificate_of_indigency.docx";

            // Use the System.Diagnostics.Process class to launch MS Word
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFilePath)
            {
                UseShellExecute = true
            });
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Replace "your_word_file.docx" with the path to your MS Word file
            string wordFilePath = "C:\\Users\\Fzkn4\\Music\\Fzkn4\\C isnt sharp\\Barangay_blotter\\Barangay_blotter\\resources\\barangay_clearance.docx";

            // Use the System.Diagnostics.Process class to launch MS Word
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(wordFilePath)
            {
                UseShellExecute = true
            });
        }

        public static List<object> GetChartBlotterData()
        {
            string query = "SELECT blotter_date, COUNT(caseID) as 'id' from blotter WHERE blotter_status = 'Active' GROUP BY caseID";
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            {
        "blotter_date", "id"
            });
            MySqlConnection conn = new MySqlConnection(con);


            MySqlCommand cmd = new MySqlCommand(query);
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                MySqlDataReader sdr = cmd.ExecuteReader();
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new
                        {
                            date = Convert.ToDateTime(sdr["blotter_date"].ToString()),
                            id = Convert.ToInt32(sdr["id"].ToString())
                        });
                    }
                }
                conn.Close();
                return chartData;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void active_case_display_Click(object sender, EventArgs e)
        {
            active_case_filter();
        }


        private void active_case_filter()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("SELECT caseID as 'Case ID', complainant_name as 'Complainant', respondent_name as 'Respondent', victim_name as 'Victim', blotter_description as 'Blotter/Incident', schedule_date as 'Schedule date', blotter_status as 'Status'  from blotter where blotter_status='Active'", con1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "blotter");
                blotter_table.DataSource = ds.Tables["blotter"].DefaultView;
                blotter_dataset = ds;
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No current active cases.");
                Console.WriteLine(e.Message);
            }
        }

        private void guna2Panel9_Click(object sender, EventArgs e)
        {
            settled_case_filter();
        }

        private void settled_case_filter()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("SELECT caseID as 'Case ID', complainant_name as 'Complainant', respondent_name as 'Respondent', victim_name as 'Victim', blotter_description as 'Blotter/Incident', schedule_date as 'Schedule date', blotter_status as 'Status'  from blotter where blotter_status='Settled'", con1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "blotter");
                blotter_table.DataSource = ds.Tables["blotter"].DefaultView;
                blotter_dataset = ds;
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No current settled cases.");
                Console.WriteLine(e.Message);
            }
        }

        private void scheduled_case_filter()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("SELECT caseID as 'Case ID', complainant_name as 'Complainant', respondent_name as 'Respondent', blotter_description as 'Blotter/Incident', schedule_date as 'Schedule date', blotter_status as 'Status'  from blotter where schedule_date>=@schedule_date", con1);
                cmd.Parameters.Add("@schedule_date", MySqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "blotter");
                blotter_table.DataSource = ds.Tables["blotter"].DefaultView;
                blotter_dataset = ds;
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No current scheduled cases.");
            }
        }
    }
}
