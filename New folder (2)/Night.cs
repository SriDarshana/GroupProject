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
    public partial class Night : Form
    {
        public Night(string q , string f)
        {
            InitializeComponent();
            fill_textBox();
            fill_combo();
            label35.Text = q;
            label37.Text = f;
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
                    label6.Text = tctno.ToString();

                    double t = Double.Parse(label6.Text) + 1;

                    label6.Text =  t.ToString();

                    int tctno1 = myReader.GetInt32(0);
                    label12.Text = tctno1.ToString();

                    double t1 = Double.Parse(label12.Text) + 2;

                    label12.Text =  t1.ToString();

                    int tctno2 = myReader.GetInt32(0);
                    label18.Text = tctno2.ToString();

                    double t2 = Double.Parse(label18.Text) + 3;

                    label18.Text = t2.ToString();

                    int tctno3 = myReader.GetInt32(0);
                    label24.Text = tctno3.ToString();

                    double t3 = Double.Parse(label24.Text) + 4;

                    label24.Text =  t3.ToString();

                    int tctno4 = myReader.GetInt32(0);
                    label30.Text = tctno4.ToString();

                    double t4 = Double.Parse(label30.Text) + 5;

                    label30.Text =  t4.ToString();




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
                    comboBox1.Items.Add(empi);

                    String empi1 = myReader.GetString(0);
                    comboBox2.Items.Add(empi1);

                    String empi2 = myReader.GetString(0);
                    comboBox3.Items.Add(empi2);

                    String empi3 = myReader.GetString(0);
                    comboBox4.Items.Add(empi3);

                    String empi4 = myReader.GetString(0);
                    comboBox5.Items.Add(empi4);



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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string empi = comboBox1.Text;




                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from emp where empid='" + empi + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string empil = my.GetString(1);
                    string empij = my.GetString(2);

                    textBox1.Text = empil + " " + empij;


                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string empi = comboBox3.Text;




                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from emp where empid='" + empi + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string empil = my.GetString(1);
                    string empij = my.GetString(2);

                    textBox3.Text = empil + " " + empij;


                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string empi = comboBox4.Text;




                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from emp where empid='" + empi + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string empil = my.GetString(1);
                    string empij = my.GetString(2);

                    textBox4.Text = empil + " " + empij;


                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string empi = comboBox5.Text;




                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from emp where empid='" + empi + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string empil = my.GetString(1);
                    string empij = my.GetString(2);

                    textBox5.Text = empil + " " + empij;


                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string workid = label6.Text;
            string workplace = groupBox1.Text;
            string date = dateTimePicker1.Text;
            string session = label5.Text;
            string empno = comboBox1.Text;
            string empname = textBox1.Text;





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

        private void button3_Click(object sender, EventArgs e)
        {
            string workid = label12.Text;
            string workplace = groupBox2.Text;
            string date = dateTimePicker1.Text;
            string session = label5.Text;
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

        private void button6_Click(object sender, EventArgs e)
        {
            string workid = label18.Text;
            string workplace = groupBox3.Text;
            string date = dateTimePicker1.Text;
            string session = label5.Text;
            string empno = comboBox3.Text;
            string empname = textBox3.Text;





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

        private void button7_Click(object sender, EventArgs e)
        {
            string workid = label24.Text;
            string workplace = groupBox4.Text;
            string date = dateTimePicker1.Text;
            string session = label5.Text;
            string empno = comboBox4.Text;
            string empname = textBox4.Text;





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

        private void button10_Click(object sender, EventArgs e)
        {
            string workid = label30.Text;
            string workplace = groupBox5.Text;
            string date = dateTimePicker1.Text;
            string session = label5.Text;
            string empno = comboBox5.Text;
            string empname = textBox5.Text;





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

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assignworks asi = new Assignworks(label35.Text, label37.Text);
            asi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.ResetText();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox3.ResetText();
            textBox3.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox4.ResetText();
            textBox4.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox5.ResetText();
            textBox5.Clear();
        }

        private void Night_Load(object sender, EventArgs e)
        {

        }
    }
}
