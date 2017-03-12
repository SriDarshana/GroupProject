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
    public partial class Form1 : Form
    {
        public Form1(String staname)
        {
            InitializeComponent();
            label4.Text = staname;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;


            SqlConnection con = new DBConnector().getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM login WHERE username='" + username + "' AND password='" + password + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                this.Hide();
                Home Hm = new Home(label4.Text , textBox1.Text);
                Hm.ShowDialog();



            }
            else
            {
                MessageBox.Show("Invalid login ,Try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        



    


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            home1 ii = new home1(label4.Text);
            ii.ShowDialog();
        }

      
    }
}
