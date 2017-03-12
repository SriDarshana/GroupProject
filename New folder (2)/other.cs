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
    public partial class other : Form
    {
        public other()
        {
            InitializeComponent();
            fill_combo();
            fill_textBox();
        }


        void fill_textBox()
        {

            SqlConnection con = new DBConnector().getConnection();

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select workid from works";


            try
            {
                SqlDataReader myReader = cmd2.ExecuteReader();


                while (myReader.Read())
                {

                    int tctno = myReader.GetInt32(0);
                    label7.Text = tctno.ToString();

                    double t = Double.Parse(label7.Text) + 1;

                    label7.Text = "W"+ t.ToString();

                  



                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }
        void fill_combo()
        {

            SqlConnection con = new DBConnector().getConnection();

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from emp";


            try
            {
                SqlDataReader myReader = cmd2.ExecuteReader();


                while (myReader.Read())
                {

                    String empi = myReader.GetString(0);
                    comboBox2.Items.Add(empi);

                    

                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string empi = comboBox2.Text;




                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from emp where empid='" + empi + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string empil = my.GetString(1);
                    string empij = my.GetString(2);

                    textBox2.Text = empil + " " + empij;


                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string workid = label7.Text;
            string workplace = textBox1.Text;
            string date = dateTimePicker1.Text;
            string session = comboBox1.Text;
            string empno = comboBox2.Text;
            string empname = textBox2.Text;





            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into works (workid,workingplace,date,session,empno,empname) values('" + workid + "','" + workplace + "','" + date + "','" + session + "','" + empno + "','" + empname + "')";
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
    }
}
