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
    public partial class dailys : Form
    {
        public dailys(String jj , String ww)
        {
            InitializeComponent();
            label5.Text = jj;
            label7.Text = ww;
        }


        void fill_grid()
        {

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                // string fr = comboBox1.Text;
                //string to = comboBox2.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tdt where date='" + dateTimePicker1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_grid();


            try
            {

                int sum = 0;
                int pa = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {

                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                    pa += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);

                }

                textBox2.Text = sum.ToString()+".00";
                textBox1.Text = pa.ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);




            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            sales yy = new sales(label5.Text, label7.Text);
            yy.ShowDialog();
            
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dailys_Load(object sender, EventArgs e)
        {

        }
    }
}
