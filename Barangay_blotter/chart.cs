using Guna.Charts.WinForms;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Barangay_blotter
{
    internal class chart
    {
        static string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static Dictionary<string, int> map = new Dictionary<string, int>();
        

        public  static void init_map()
        {
            try
            {
                map.Add("January", 0);
                map.Add("February", 0);
                map.Add("March", 0);
                map.Add("April", 0);
                map.Add("May", 0);
                map.Add("June", 0);
                map.Add("July", 0);
                map.Add("August", 0);
                map.Add("September", 0);
                map.Add("October", 0);
                map.Add("November", 0);
                map.Add("December", 0);

            }catch(Exception ex)
            {

            }
        }
        private static void reset_map()
        {
            foreach (string key in map.Keys)
            {
                map[key] = 0;
            }
        }

        public static void init_chart(Guna.Charts.WinForms.GunaChart chart, GunaLineDataset dataset, string year)
        {
            dataset.DataPoints.Clear();
            reset_map();
            //Chart configuration 
            chart.XAxes.GridLines.Display = false;

            MySqlConnection con1 = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand();
            con1.Open();
            cmd.Connection = con1;
            try
            {
                cmd.CommandText = "SELECT date_format(blotter_date,'%M') as 'Month',  COUNT(caseID) as 'Blotters' FROM blotter WHERE year(blotter_date)=year(@year) GROUP BY year(blotter_date), month(blotter_date), date_format(blotter_date,'%M') ORDER BY year(blotter_date), month(blotter_date)";
                cmd.Parameters.Add("@year", MySqlDbType.DateTime).Value = new DateTime(Convert.ToInt32(year), 1, 1);
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    map[dr["Month"].ToString()] = Convert.ToInt32(dr["Blotters"].ToString());
                }
                con1.Close();
                foreach (string key in map.Keys)
                {
                    dataset.DataPoints.Add(key, map[key]);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);
            //An update was made to re-render the chart
            chart.Update();
        }


        private static int findValue(string search)
    {
            foreach (KeyValuePair<string, int> pair in map)
            {
                if (pair.Key == search)
                {
                    return pair.Value;
                }
            }
            return 0;
        }
    }
}
