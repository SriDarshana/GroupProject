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
    public partial class empmgt : Form
    {
        public empmgt(String sta , String log)
        {
            InitializeComponent();
            fill_grid();
            label4.Text = sta;
            label5.Text = log;

        }

        void fill_grid()
        {

            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emp";
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




        private void button1_Click(object sender, EventArgs e)
        {

            if (label5.Text == "admin")
            {

                this.Hide();
                emphome rpt = new emphome(label4.Text, label5.Text);
                rpt.ShowDialog();


            }
            else
            {

                this.Hide();
                emphome2 rpt = new emphome2(label4.Text, label5.Text);
                rpt.ShowDialog();

            }
            
            
            
            
            
            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                //dataGridView1.Rows.Add();
                string empid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string firstname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string lastname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string address = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string dob = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string gender = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string status = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string position = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string etfno = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                string tp = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();




                cmd.CommandText = "update emp set empid='" + empid + "',firstname='" + firstname + "',lastname='" + lastname + "', address='" + address + "',dob='" + dob + "',gender='" + gender + "',status='" + status + "',position='" + position + "',etfno='"+etfno+"',tp='"+tp+"' where empid='" + empid + "';";
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Successfully Updated!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnector().getConnection();
            try
            {
                con.Open();
                SqlCommand cmd2 = con.CreateCommand();
                string y = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "delete from emp where empid='" + y + "' ;";
                int b = cmd2.ExecuteNonQuery();

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new addemp().ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
