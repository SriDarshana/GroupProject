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
    public partial class shedule : Form
    {
        public shedule()
        {
            InitializeComponent();
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
                cmd.CommandText = "select * from tshedule where Start='" + comboBox1.Text + "' and en='"+comboBox2.Text+"'";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            new Home().ShowDialog();
            this.Close();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
