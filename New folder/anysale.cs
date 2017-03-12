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
    public partial class anysale : Form
    {
        public anysale(String tt , String uu)
        {
            InitializeComponent();
            label6.Text = tt;
            label8.Text = uu;
        }


        void fill_grid()
        {

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                string theDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string theDate1 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
               
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                
                // string fr = comboBox1.Text;
                //string to = comboBox2.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tdt where date between '" + theDate + "' and '"+theDate1+"' ";
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

                textBox2.Text = sum.ToString() + ".00";
                textBox1.Text = pa.ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);




            }
        }

        private void anysale_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            sales rpt = new sales(label6.Text, label8.Text);
            rpt.ShowDialog();
        }
    }
}
