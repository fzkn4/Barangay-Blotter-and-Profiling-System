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

namespace Barangay_blotter
{
    public partial class sample : Form
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public sample()
        {
            InitializeComponent();
            updateTable();
        }

        private void updateTable()
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("SELECT  date_format(blotter_date,'%M'), COUNT(caseID) FROM blotter GROUP BY year(blotter_date), month(blotter_date), date_format(blotter_date,'%M') ORDER BY year(blotter_date), month(blotter_date)", con1);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con1.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "blotter");
                table.DataSource = ds.Tables["blotter"].DefaultView;
                con1.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
