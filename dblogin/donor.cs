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
    public partial class donor : Form
    {
       
        OracleConnection con= new OracleConnection(setting.CONNECTION_STRING);
        public donor()
        {
            InitializeComponent();
            con.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void btnadddonor_Click(object sender, EventArgs e)
        {
            string text_Box1 = textBox1.Text;
            string text_Box2 = textBox2.Text;
            string text_Box3 = textBox3.Text;
            DateTime dateTime_Picker1 = dateTimePicker1.Value;
            string text_Box4 = textBox4.Text;
            string text_Box5 = textBox5.Text;




            if (string.IsNullOrEmpty(text_Box1) || string.IsNullOrEmpty(text_Box2) || string.IsNullOrEmpty(text_Box3)
              || string.IsNullOrEmpty(text_Box4) || string.IsNullOrEmpty(text_Box5))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }

            string query = "INSERT INTO DONOR (DONOR_ID, NAME,PHONE_NO,BLOOD_TYPE,DONATED_BAGS,LAST_DONATION_DATE)" +
                " VALUES (:DonorId,:Name,:PhnNum,:Bloodtype,:Donatedbag,:lastdonationdate)";

            try
            {
              

                    using (OracleCommand command = new OracleCommand(query, con))
                    {
                        command.Parameters.Add(":DonorId", text_Box1);
                        command.Parameters.Add(":Name", text_Box2);
                        command.Parameters.Add(":PhnNum", text_Box3);
                        command.Parameters.Add(":Bloodtype", text_Box4);
                        command.Parameters.Add(":Donatedbag", text_Box5);

                        command.Parameters.Add(":lastdonationdate", dateTime_Picker1);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record saved successfully.");
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save record.");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {

                    string sqlAll = "SELECT * FROM USMAN.DONOR";
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

                    OracleParameter DonorIdParam = new OracleParameter(":DONORID", OracleDbType.Varchar2);
                    DonorIdParam.Value = textBox6.Text;

                    string sql = "SELECT * FROM USMAN.DONOR WHERE BLOOD_TYPE = :BLOODTYPE";
                    OracleDataAdapter adp = new OracleDataAdapter(sql, con);


                    adp.SelectCommand.Parameters.Add(DonorIdParam);

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            

            try
            {
                string DonorId = textBox6.Text;
                string query = "DELETE FROM DONOR WHERE DONOR_ID = :DonorId";

                using (OracleCommand command1 = new OracleCommand(query, con))
                {
                    command1.Parameters.Add(":DONOR_ID", DonorId);

                    command1.ExecuteNonQuery();
                }

                MessageBox.Show("Data deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void donor_Load(object sender, EventArgs e)
        {

        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                    string updateQuery = "UPDATE DONOR SET NAME = :value1, PHONE_NO = :value2, BLOOD_TYPE = :value3, DONATED_BAGS = :value4, LAST_DONATION_DATE = :value5 WHERE DONOR_ID = :value6";

                    using (OracleCommand command = new OracleCommand(updateQuery, con))
                    {
                        command.Parameters.Add(":value1", OracleDbType.Varchar2).Value = textBox2.Text;
                        command.Parameters.Add(":value2", OracleDbType.Varchar2).Value = textBox3.Text;
                        command.Parameters.Add(":value3", OracleDbType.Varchar2).Value = textBox4.Text;
                        command.Parameters.Add(":value4", OracleDbType.Varchar2).Value = textBox5.Text;
                        command.Parameters.Add(":value5", OracleDbType.Date).Value = DateTime.Now; 
                        command.Parameters.Add(":value6", OracleDbType.Varchar2).Value = textBox1.Text;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row modified successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows modified. Make sure the row exists and the provided values are different from the current ones.");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
