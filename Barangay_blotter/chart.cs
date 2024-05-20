using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Barangay_blotter
{
    internal class chart
    {

        public static void init_chart(Guna.Charts.WinForms.GunaChart chart, GunaLineDataset dataset)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec"};

            //Chart configuration 
            chart.XAxes.GridLines.Display = false;

            var r = new Random();
            for (int i = 0; i < months.Length; i++)
            {
                //random number
                int num = r.Next(10, 100);

                dataset.DataPoints.Add(months[i], num);
            }


            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }
    }
}
