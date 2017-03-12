using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace train
{
    public partial class gatepass : Form
    {
        public gatepass(String uu , String ee)
        {
            InitializeComponent();
            fill_textBox();
            label10.Text = uu;
            label12.Text = ee;
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

                    string trainid = myReader.GetString(0);
                    comboBox1.Items.Add(trainid);



                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }



        void fill_grid()
        {
            string gatepassno= textBox1.Text;

            string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
            MySqlConnection mycon = new MySqlConnection(myConnection);
            MySqlCommand cmdDtabase = new MySqlCommand("select itemid,itemname,quantity from gatepass where gatepassno='"+gatepassno+"'",mycon);


            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDtabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);


                comboBox4.ResetText();
                textBox2.Clear();
                textBox3.Clear();

            }
            catch (Exception ex) {


                MessageBox.Show(ex.Message);
            
            }



            }




        void fill_textBox()
        {


            try
            {
            string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
            MySqlConnection mycon = new MySqlConnection(myConnection);
            string Query = "select gatepassno from gatepass ORDER BY gatepassno ASC";
           
            MySqlCommand SelectCommand = new MySqlCommand(Query,mycon);
            MySqlDataReader myReader;
            mycon.Open();
           
           
                myReader = SelectCommand.ExecuteReader();
                


                while (myReader.Read())
                {

                    int gatepassno = myReader.GetInt32(0);
                    textBox1.Text = gatepassno.ToString();

                    double t = Double.Parse(textBox1.Text) + 1;

                    textBox1.Text = t.ToString();



                }





            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gatepassno= textBox1.Text;
            string date =  dateTimePicker1.Text;
            string trainID = comboBox1.Text;
            string start = comboBox2.Text;
            string destination = comboBox3.Text;
            string itemID = textBox2.Text;
            string itemname = comboBox4.Text;
            string quantity = textBox3.Text;


            string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
            string Query = "insert into gatepass (gatepassno,date,trainID,start,destination,itemID,itemname,quantity) values('"+gatepassno+"','"+date+"','"+trainID+"','"+start+"','"+destination+"','"+itemID+"','"+itemname+"','"+quantity+"');";
            MySqlConnection mycon = new MySqlConnection(myConnection);
            MySqlCommand SelectCommand = new MySqlCommand(Query,mycon);
            try { 
            
            MySqlDataReader myReader;
            mycon.Open();
            myReader = SelectCommand.ExecuteReader();
            MessageBox.Show("Saved");
            fill_grid();
            while (myReader.Read()) { 
            
            }
            
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            
            ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new gatepassreprt(comboBox2.Text,comboBox3.Text, textBox1.Text,comboBox1.Text).ShowDialog();

            /*gatepassreprt yp = new gatepassreprt(textBox1.Text,comboBox2.Text,comboBox3.Text);
            CrystalReport3 cr = new CrystalReport3();
            TextObject text = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
            text.Text = comboBox2.Text;
            yp.crystalReportViewer1.ReportSource = cr;*/

       
     
           /* gatepassreprt mn = new gatepassreprt(textBox1.Text);
            mn.ShowDialog();*/
        }

        private void gatepass_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            checkgp sth = new checkgp(label10.Text, label12.Text);
            sth.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fill_textBox();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            dataGridView1.DataSource = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string gpno = textBox1.Text;
            string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
            string y = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string Query = "delete from gatepass where gatepassno='"+gpno+"' and itemid='" + y + "';";
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand SelectCommand = new MySqlCommand(Query, con);
            try
            {
                con.Open();
                
                
               ;
                int b = SelectCommand.ExecuteNonQuery();

                if (b > 0)
                {
                    MessageBox.Show("Successfully Deleted!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fill_grid();
                }
                else
                {
                    MessageBox.Show("Delete Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string gpno = textBox1.Text;
            string itemid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string itemname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string quantity = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
            string Query = "update gatepass set itemid='"+itemid+"',itemname='"+itemname+"', quantity='"+quantity+"' where gatepassno='"+gpno+"'";
            MySqlConnection con = new MySqlConnection(myConnection);
            MySqlCommand SelectCommand = new MySqlCommand(Query, con);
            try
            {
                con.Open();


                ;
                int b = SelectCommand.ExecuteNonQuery();

                if (b > 0)
                {
                    MessageBox.Show("Successfully Updated!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Update Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label12.Text == "admin")
            {

                this.Hide();
                h Hm = new h(label10.Text, label12.Text);
                Hm.ShowDialog();


            }
            else
            {

                this.Hide();
                Home Hm = new Home(label10.Text, label12.Text);
                Hm.ShowDialog();

            }
            
            
            
            
            
            
            
            
            
            
            
        }
    }
}
