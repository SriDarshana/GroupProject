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
    public partial class issuetkt : Form
    {
        public issuetkt(String sta, String tt)
        {
            
            InitializeComponent();
            timer1.Start();
            
            comboBox1.Text = sta;
            label20.Text = sta;
            label22.Text = tt;
            fill_combo();
           
        }

        void fill_combo()
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

                    string tid = myReader.GetString(0);
                    comboBox5.Items.Add(tid);



                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        public string paseclass()
        {
            if (radioButton1.Checked)
            {
                return "1st Class";
            }
            else if (radioButton2.Checked)
            {
                return "2nd Class";
            }
            else if (radioButton3.Checked)
            {
                return "3rd Class";

            }
            else {
                return "None";
            
            }
        }
        public string pasetype()
        {
            if (radioButton4.Checked)
            {
                return "Adult";
            }
            else if (radioButton5.Checked)
            {
                return "Child";
            }
            
            else
            {
                return "None";

            }
        }





        Font myFont = new Font("Courier New", 10);
        Font myF = new Font("Courier New", 15, FontStyle.Bold);


        void fill_textBox()
        {

            SqlConnection con = new DBConnector().getConnection();

            con.Open();
            SqlCommand cmd2 = con.CreateCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select tcktno from tdt";


            try
            {
                SqlDataReader myReader = cmd2.ExecuteReader();

               
                while (myReader.Read())
                {

                    int tctno = myReader.GetInt32(0);
                    textBox9.Text = tctno.ToString();

                    double t=Double.Parse(textBox9.Text)+1;

                    textBox9.Text = t.ToString();



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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text == "")
                {



                }
                else
                {
                    string passe = textBox1.Text;

                    double d = Double.Parse(textBox2.Text) * Double.Parse(textBox1.Text);

                    double c = d * Double.Parse(textBox3.Text);

                    double g = c + d;

                    textBox4.Text = g.ToString();
                }
            }catch(Exception ex){


                MessageBox.Show(ex.Message);
            
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            fill_textBox();
            string start = comboBox1.Text;
            string destination = comboBox2.Text;
            string Class = paseclass();
            string type = pasetype();
            string passe = textBox1.Text;
            string price = textBox4.Text;
            // string tno = textBox5.Text;


            textBox6.Text = Class;
            textBox7.Text = type;
            textBox8.Text = passe;
            //textBox9.Text = tno;
            textBox12.Text = start;
            textBox13.Text = destination;
            textBox14.Text = price;
           



            string tcktno = textBox9.Text;
            string pclass = textBox6.Text;
            string tdate = textBox10.Text;
            string ttime = textBox11.Text;
            string ptype = textBox7.Text;
            string froms = textBox12.Text;
            string tos = textBox13.Text;
            string noOfPasse = textBox8.Text;
            string Price = textBox14.Text;
            string cno = comboBox6.Text;
            string trainid = comboBox5.Text;


            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into tdt values('" + tcktno + "','" + pclass + "','" + tdate + "','" + ttime + "','" + ptype + "','" + froms + "','" + tos + "','" + noOfPasse + "','" + Price + "','" + trainid + "','" + cno + "')";
                int b = cmd2.ExecuteNonQuery();


                if (b > 0)
                {
                    /*printDialog1.Document = printDocument1;
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {

                        printDocument1.Print();




                    }*/
                    MessageBox.Show("add successfully");

                }
                else
                {
                    MessageBox.Show("Printing Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.textBox10.Text = dateTime.ToShortDateString();

            this.textBox11.Text = dateTime.ToShortTimeString();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            float fontHeight = myFont.GetHeight();
            int x = 20, y = 20;
            int offset = 40;
            e.Graphics.DrawString("Railway Department of Srilanka\n", myF, new SolidBrush(Color.Black), x, y + offset);
            offset = 2 * offset + (int)fontHeight + 5;

            e.Graphics.DrawString("TicketNo-.................." + textBox9.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("Date-......................" + textBox10.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("Time-......................" + textBox11.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("Class-....................." + textBox6.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("Type-......................" + textBox7.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("No Of Passengers-.........." + textBox8.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("From-......................" + textBox12.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("To-........................" + textBox13.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            e.Graphics.DrawString("Price-....................." + textBox14.Text, myFont, new SolidBrush(Color.Black), x, y + offset);
            offset =  offset + (int)fontHeight + 5;

            /*foreach (string str in listBox1.Items)
            {
                e.Graphics.DrawString(str, myFont, Brushes.Black, x, y + offset);
                y += 25;
                i++;

                offset = offset + (int)fontHeight + 5;
            }*/

            /*e.Graphics.DrawString("Total................................." + textBox8.Text + ".00", myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;

            e.Graphics.DrawString("Paid.................................." + textBox2.Text + ".00", myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;

            e.Graphics.DrawString("Ballence.............................." + textBox9.Text + ".00", myFont, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;
            */
            e.Graphics.DrawString("Thank You Please Come Again", myF, new SolidBrush(Color.Black), x, y + offset);
            offset = offset + (int)fontHeight + 5;

           // e.Graphics.DrawString("Samarasekara stores,Gall Raod,Weligama.", myFont, new SolidBrush(Color.Black), x, y + offset);

            //offset = offset + (int)fontHeight + 5;

            e.Graphics.DrawString("Tel-0710497136/041-4905442/0715557554", myFont, new SolidBrush(Color.Black), x, y + offset);

            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                printDocument1.Print();




            }
            else {

                MessageBox.Show("Printing Failed, Try again");
            
            
            }
            
            
            
            
            
            
            
            
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.ResetText();
                comboBox2.ResetText();
                // radioButton1.ResetText();
                //radioButton2.ResetText();
                //radioButton3.ResetText();
                //radioButton4.ResetText();
                //radioButton5.ResetText();
                textBox4.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Clear();
                

                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                //textBox10.Clear();
                //textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                //timer1.Dispose();
              
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Hm = new Home(label20.Text, label22.Text);
            Hm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void issuetkt_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string start = comboBox1.Text;
                string destination = comboBox2.Text;
                string Class = paseclass();
                string type = pasetype();



                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from Tckt where start='" + start + "' and destination='" + destination + "' and class='" + Class + "' and type='" + type + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string sprice = my.GetString(4);
                    string stax = my.GetString(5);

                    textBox2.Text = sprice;
                    textBox3.Text = stax;

                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            } 
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();



            try
            {
                con.Open();

                SqlCommand cmd2 = con.CreateCommand();

                string start = comboBox1.Text;
                string destination = comboBox2.Text;
                string Class = paseclass();
                string type = pasetype();



                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from Tckt where start='" + start + "' and destination='" + destination + "' and class='" + Class + "' and type='" + type + "'";

                SqlDataReader my = cmd2.ExecuteReader();

                while (my.Read())
                {

                    string sprice = my.GetString(4);
                    string stax = my.GetString(5);

                    textBox2.Text = sprice;
                    textBox3.Text = stax;

                }




            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }
    }
}
