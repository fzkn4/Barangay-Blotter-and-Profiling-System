using MySqlConnector;
using System.Configuration;

namespace Barangay_blotter
{
    public partial class About : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public About()
        {
            InitializeComponent();
            get_official_details();
        }

        //kani nga function ang mo-pasud ug image padung sa database. 
        private void update_offiical()
        {
            MemoryStream ms = new MemoryStream();
            picture_official.Image.Save(ms, picture_official.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlConnection conn1 = new MySqlConnection(con);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "update brgy_officials set fname=@fname, lname=@lname, brgy_position=@position, img=@img where brgy_official_id=@id";
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Form1.official_id;
                cmd.Parameters.Add("@fname", MySqlDbType.String).Value = fname.Text;
                cmd.Parameters.Add("@lname", MySqlDbType.String).Value = lname.Text;
                cmd.Parameters.Add("@position", MySqlDbType.String).Value = position.Text;
                cmd.Parameters.Add("@img", MySqlDbType.MediumBlob).Value = img;     //diri dapat ang datatype kay parehas sa datatype sa imong database. Sa akoa kay MediumBlob 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successful.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            this.Close();
        }

        private void register_Click(object sender, EventArgs e)
        {
            unselect_img();
            update_offiical();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            unselect_img();
            browse_img();
        }

        //kani nga function ang mo-kuha ug img gikan sa local files
        private void browse_img()
        {
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picture_official.Image = Image.FromFile(open.FileName);
                picture_official.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void picture_official_DoubleClick(object sender, EventArgs e)
        {
            browse_img();
        }

        private void picture_official_Click(object sender, EventArgs e)
        {
            picture_official.ShadowDecoration.Enabled = true;
        }
        private void unselect_img()
        {
            picture_official.ShadowDecoration.Enabled = false;
        }

        private void fname_Click(object sender, EventArgs e)
        {
            unselect_img();
        }

        private void lname_Click(object sender, EventArgs e)
        {
            unselect_img();
        }

        private void position_Click(object sender, EventArgs e)
        {
            unselect_img();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void get_official_details()
        {
            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT fname, lname, brgy_position from brgy_officials where brgy_official_id="+ Form1.official_id+"";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    fname.Text = dr["fname"].ToString();
                    lname.Text = dr["lname"].ToString();
                    position.Text = dr["brgy_position"].ToString();

                }
                con1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
