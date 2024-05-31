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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dblogin
{
    public partial class blood : Form
    {
        String ConString = "Data Source=XE;User Id=usman;Password=usman123;";

        OracleConnection con = new OracleConnection(setting.CONNECTION_STRING);
        public blood()
        {
            InitializeComponent();
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void btnaddblood_Click(object sender, EventArgs e)
        {
            try
            {
                string BLOOD_ID = textBox1.Text.ToString();
                string BLOOD_TYPE = textBox2.Text.ToString();
                string QUANTITY = textBox3.Text.ToString();
                DateTime dateTime_Picker1 = dateTimePicker1.Value;

                string Insertsql = "insert into BLOOD(BLOOD_ID, BLOOD_TYPE, QUANTITY, EXPIRATION_DATE) " +
                    "values(:BLOODID, :BLOODTYPE, :QUANTITY, :EXPIRATIONDATE)";
                using (OracleCommand command = new OracleCommand(Insertsql, con))
                {
                    command.Parameters.Add(":BLOODID", BLOOD_ID);
                    command.Parameters.Add(":BLOODTYPE", BLOOD_TYPE);
                    command.Parameters.Add(":QUANTITY", QUANTITY);
                    command.Parameters.Add(":EXPIRATIONDATE", dateTime_Picker1);
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
                con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    
                    string sqlAll = "SELECT * FROM USMAN.BLOOD";
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
                    
                    OracleParameter bloodIdParam = new OracleParameter(":BLOOD_TYPE", OracleDbType.Varchar2);
                    bloodIdParam.Value = textBox4.Text; 

                    string sql = "SELECT * FROM USMAN.BLOOD WHERE BLOOD_TYPE = :BLOOD_TYPE";
                    OracleDataAdapter adp = new OracleDataAdapter(sql, con);

                    
                    adp.SelectCommand.Parameters.Add(bloodIdParam);

                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                        MessageBox.Show("Data retrieved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data found for the specified blood ID.");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string BLOODID = textBox4.Text;
                string query = "DELETE FROM BLOOD WHERE BLOOD_ID = :BLOODID";

                using (OracleCommand command1 = new OracleCommand(query, con))
                {
                    command1.Parameters.Add(":BLOOD_ID", BLOODID);

                    command1.ExecuteNonQuery();
                }

                MessageBox.Show("Data deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
