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
    public partial class addtrain : Form
    {
        public addtrain()
        {
            InitializeComponent();
            fill_textBox();
        }




        void fill_textBox()
        {

            SqlConnection con = new DBConnector().getConnection();

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from train";


            try
            {
                SqlDataReader myReader = cmd2.ExecuteReader();

                while (myReader.Read())
                {

                    string tctno = myReader.GetString(0);
                    textBox1.Text = tctno;

                    double t = Double.Parse(textBox1.Text) + 1;

                    textBox1.Text = "00"+t.ToString();



                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string trainid = textBox1.Text;
            string tname = textBox2.Text;
            string enginecapasity = textBox3.Text;
            string noOfBox = textBox4.Text;
            string route = textBox5.Text;
            string type = textBox6.Text;
           

            //string susername = textBox4.Text;

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into train (trainid,tname,enginecapasity,noOfBox,route,type) values('" + trainid + "','" + tname + "','" + enginecapasity + "','" + noOfBox+ "','" + route + "','" + type + "')";
                int b = cmd2.ExecuteNonQuery();


                if (b > 0)
                {
                    MessageBox.Show("Successfully Saved!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Saving Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            new traindt().ShowDialog();
            this.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new tupdate().ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
