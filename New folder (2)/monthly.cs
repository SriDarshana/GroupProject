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
    public partial class monthly : Form
    {
        public monthly(String ee , String gg)
        {
            InitializeComponent();
            label9.Text = ee;
            label11.Text = gg;

        }


        void fill_grid()
        {

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                string month = comboBox1.Text;
                string year = comboBox2.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from st where  month='" + month + "' and  year='" + year + "'";
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
        void fill_grid10()
        {

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                string month = comboBox1.Text;
                string year = comboBox2.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from stockout where  month='" + month + "' and  year='" + year + "'";
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }


        private void button1_Click(object sender, EventArgs e)
        {
            fill_grid();
            fill_grid10();

            try
            {

                int sum = 0;
                int pa = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {

                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                   // pa += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);

                }
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {

                   // sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                     pa += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);

                }

                textBox1.Text = sum.ToString();
                textBox2.Text = pa.ToString();

                double d = Double.Parse(textBox1.Text) - Double.Parse(textBox2.Text);
                textBox3.Text = d.ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);




            }



        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            monthlyrpthome mn = new monthlyrpthome(label9.Text,label11.Text);
            mn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            streport rpt = new streport(label9.Text, label11.Text);
            rpt.ShowDialog();
        }
    }
}
