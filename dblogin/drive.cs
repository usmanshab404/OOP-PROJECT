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
    public partial class drive : Form
    {
        OracleConnection con=new OracleConnection(setting.CONNECTION_STRING);
        public drive()
        {
            InitializeComponent();
            con.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h=new Home();
            h.Show();
            this.Hide();
        }

        private void btnadddrive_Click(object sender, EventArgs e)
        {
            try
            {
                string DRIVE_ID = textBox1.Text;
                string BLOOD_BAGS = textBox3.Text;
                string LOCATION = textBox2.Text;
                DateTime DRIVE_DATE = dateTimePicker1.Value;

                
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (OracleCommand command = new OracleCommand("insert into DRIVE(DRIVE_ID, BLOOD_BAGS, LOCATION, DRIVE_DATE) " +
                    "values(:DRIVE_ID, :BLOOD_BAGS, :LOCATION, :DRIVE_DATE)", con))
                {
                    command.Parameters.Add(":DRIVE_ID", DRIVE_ID);
                    command.Parameters.Add(":BLOOD_BAGS", BLOOD_BAGS);
                    command.Parameters.Add(":LOCATION", LOCATION);
                    command.Parameters.Add(":DRIVE_DATE", DRIVE_DATE);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {

                    string sqlAll = "SELECT * FROM USMAN.DRIVE";
                    OracleDataAdapter adpAll = new OracleDataAdapter(sqlAll, con);
                    DataSet dsAll = new DataSet();
                    adpAll.Fill(dsAll);
                    if (dsAll.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dsAll.Tables[0];
                        MessageBox.Show("All data retrieved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data found.");
                    }
                }
                else
                {

                    OracleParameter DRIVEIdParam = new OracleParameter(":DRIVE_ID", OracleDbType.Varchar2);
                    DRIVEIdParam.Value = textBox4.Text;

                    string sql = "SELECT * FROM USMAN.DRIVE WHERE DRIVE_ID = :DRIVE_ID";
                    OracleDataAdapter adp = new OracleDataAdapter(sql, con);


                    adp.SelectCommand.Parameters.Add(DRIVEIdParam);

                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                        MessageBox.Show("Data retrieved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data found for the specified screening ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
