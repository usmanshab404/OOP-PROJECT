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
    public partial class screening : Form
    {
        String ConString = "Data Source=XE;User Id=usman;Password=usman123;";

        OracleConnection con = new OracleConnection(setting.CONNECTION_STRING);
        public screening()
        {
            InitializeComponent();
            con.Open();
        }

        private void btnaddscreening_Click(object sender, EventArgs e)
        {
            try
            {
                string SCREENING_ID = textBox1.Text;
                
                string BLOOD_GROUP = textBox3.Text;
                DateTime SCREENING_DATE = dateTimePicker1.Value;

                using (OracleCommand command = new OracleCommand("insert into SCREENING(SCREENING_ID,  SCREENING_DATE, BLOOD_GROUP) " +
                    "values(:SCREENINGID, :SCREENINGDATE, :BLOODGROUP)", con))
                {
                    command.Parameters.Add(":SCREENINGID", SCREENING_ID);
                    command.Parameters.Add(":SCREENINGDATE", SCREENING_DATE);
                    command.Parameters.Add(":BLOODGROUP", BLOOD_GROUP);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {

                    string sqlAll = "SELECT * FROM USMAN.SCREENING";
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

                    OracleParameter screeningIdParam = new OracleParameter(":SCREENINGID", OracleDbType.Varchar2);
                    screeningIdParam.Value = textBox4.Text;

                    string sql = "SELECT * FROM USMAN.SCREENING WHERE BLOOD_GROUP = :BLOODGROUP";
                    OracleDataAdapter adp = new OracleDataAdapter(sql, con);


                    adp.SelectCommand.Parameters.Add(screeningIdParam);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void screening_Load(object sender, EventArgs e)
        {

        }
    }
}
