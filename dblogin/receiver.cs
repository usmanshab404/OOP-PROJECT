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
    public partial class receiver : Form
    {
        OracleConnection con = new OracleConnection(setting.CONNECTION_STRING);

        public receiver()
        {
            InitializeComponent();
            con.Open();
        }

        private void receiver_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void btnaddreceiver_Click(object sender, EventArgs e)
        {
            try
            {
                string text_Box1 = textBox1.Text;
            string text_Box2 = textBox2.Text;
            string text_Box3 = textBox3.Text;
            string text_Box4 = textBox4.Text;
            DateTime dateTime_Picker1 = dateTimePicker1.Value;

            if (string.IsNullOrEmpty(text_Box1) || string.IsNullOrEmpty(text_Box2) || string.IsNullOrEmpty(text_Box3)
                || string.IsNullOrEmpty(text_Box4))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }
            string query = "INSERT INTO RECEIVER (RECEIVER_ID, NAME, PHONE_NO, BLOOD_TYPE, REQUEST_DATE)" +
               " VALUES (:ReceiverId, :Name, :PhnNum, :Bloodtype, :RequestDate)";

           
               
                {                 
                    using (OracleCommand command = new OracleCommand(query, con))
                    {
                        command.Parameters.Add(":ReceiverId", OracleDbType.Varchar2).Value = text_Box1;
                        command.Parameters.Add(":Name", OracleDbType.Varchar2).Value = text_Box2;
                        command.Parameters.Add(":PhnNum", OracleDbType.Varchar2).Value = text_Box3;
                        command.Parameters.Add(":Bloodtype", OracleDbType.Varchar2).Value = text_Box4;
                        command.Parameters.Add(":RequestDate", OracleDbType.Date).Value = dateTime_Picker1;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ConString = "Data Source=XE;User Id=usman;Password=usman123;";
            using (OracleConnection connection = new OracleConnection(ConString))
            {
                string ReceiverId = textBox6.Text;
                connection.Open();
                string query;
                if (string.IsNullOrEmpty(ReceiverId))
                {
                    
                    query = "SELECT * FROM RECEIVER";
                }
                else
                {
                    
                    query = "SELECT * FROM RECEIVER WHERE RECEIVER_ID = :ReceiverId";
                }

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(ReceiverId))
                    {
                        
                        command.Parameters.Add(":ReceiverId", ReceiverId);
                    }

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["RECEIVER_ID"].Width = 150;
                        dataGridView1.Columns["NAME"].Width = 100;
                        dataGridView1.Columns["PHONE_NO"].Width = 150;
                        dataGridView1.Columns["BLOOD_TYPE"].Width = 150;
                        dataGridView1.Columns["REQUEST_DATE"].Width = 150;
                        dataGridView1.ForeColor = Color.Black;
                    }
                }
            }
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ReceiverId = textBox6.Text;
            string query = "DELETE FROM RECEIVER WHERE RECEIVER_ID = :ReceiverId";

            using (OracleCommand command1 = new OracleCommand(query, con))
            {
                command1.Parameters.Add(":RECEIVER_ID", ReceiverId);

                command1.ExecuteNonQuery();
            }

            MessageBox.Show("Data deleted successfully.");
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}
    }
}
