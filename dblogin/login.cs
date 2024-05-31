using Oracle.DataAccess.Client;
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
    public partial class login : Form
    {
        public bool isLogin=false;
        public login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection(setting.CONNECTION_STRING);
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM USERS WHERE username =:pram1 AND password=:pram2 ", con);
                // parameter link
                cmd.Parameters.Add(":pram1",
                    OracleDbType.Varchar2,
                    tbuser.Text,
                    ParameterDirection.Input
                    );
                cmd.Parameters.Add(":pram2",
                    OracleDbType.Varchar2,
                    tbpassword.Text,
                    ParameterDirection.Input
                    );
                OracleDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    isLogin = true;
                    // username password correct
                    MessageBox.Show("Welcome!" + rd["username"]);
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                    
                }
                else
                {
                    //incorrect user pass
                    MessageBox.Show("Username password do not matched");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
