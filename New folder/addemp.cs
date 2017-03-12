using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace train
{
    public partial class addemp : Form
    {
        public addemp()
        {
            InitializeComponent();
        }

        public string getgender()
        {
            if (radioButton1.Checked)
            {
                return "Male";
            }
            else if (radioButton2.Checked)
            {
                return "Female";
            }
            else
                return "None";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string empid = textBox1.Text;
            string firstname = textBox2.Text;
            string lastname = textBox3.Text;
            string address = textBox4.Text;
            string dob = dateTimePicker1.Text;
            string gender = getgender();
            string status = comboBox1.Text;
            string position = textBox5.Text;
            string etfno = textBox6.Text;
            string tp = textBox8.Text;

            //string susername = textBox4.Text;

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into emp (empid,firstname,lastname,address,dob,gender,status,position,etfno,tp) values('"+empid+"','" + firstname + "','" + lastname + "','" + address + "','"+dob+"','" + gender + "','" + status + "','" + position + "','" + etfno + "','" + tp + "')";
                int b = cmd2.ExecuteNonQuery();


                if (b > 0)
                {
                    MessageBox.Show("Successfully Registered!!!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Registration Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            new empmgt().ShowDialog();
            this.Close();*/
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
