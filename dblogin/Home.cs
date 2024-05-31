using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dblogin
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnscreening_Click(object sender, EventArgs e)
        {
            screening s = new screening();
            s.Show();
            this.Hide();

        }

        private void btndonor_Click(object sender, EventArgs e)
        {
            donor d = new donor();
            d.Show();
            this.Hide();
        }

        private void btnreceiver_Click(object sender, EventArgs e)
        {
            receiver r= new receiver();
            r.Show();
            this.Hide();
        }

        private void btnblood_Click(object sender, EventArgs e)
        {
            blood b = new blood();
            b.Show();
            this.Hide();
        }

        private void btndrive_Click(object sender, EventArgs e)
        {
            drive drive = new drive();
            drive.Show();
            this.Hide();
        }
    }
}
