using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barangay_blotter
{
    public partial class loginFailed : Form
    {
        public loginFailed()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
