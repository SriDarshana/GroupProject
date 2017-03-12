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
using CrystalDecisions.CrystalReports.Engine;

namespace train
{
    public partial class checkgp : Form
    {

        ReportDocument cry = new ReportDocument();
        public checkgp(String hh , String uu)
        {
            InitializeComponent();
            label6.Text = hh;
            label8.Text = uu;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Text;
                string tid = comboBox1.Text;
                string p1 = comboBox2.Text;
                string p2 = comboBox3.Text;
                string gatepassno = label1.Text;

                cry.Load(@"G:\3rd year 2nd semester\Group project\train\train\CrystalReport8.rpt");
                string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
                MySqlConnection mycon = new MySqlConnection(myConnection);
                MySqlCommand cbb = new MySqlCommand("select itemID,itemname,quantity from gatepass where date='" + date + "' and trainid='" + tid + "' and start='" + p1 + "' and destination='" + p2 + "' ", mycon);
                


                mycon.Open();
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select * from stockout where  month='" + month + "' and year='" + year + "' ";
                MySqlDataAdapter sda = new MySqlDataAdapter();
                // sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand = cbb;
                DataSet st = new System.Data.DataSet();
                sda.Fill(st, "Gatepass");
                cry.SetDataSource(st);
                cry.SetParameterValue("start", p1);
                cry.SetParameterValue("dest", p2);
                crystalReportViewer1.ReportSource = cry;

                crystalReportViewer1.Refresh();
            }catch(Exception ex){

                MessageBox.Show(ex.Message);
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            gatepass sth = new gatepass(label6.Text, label8.Text);
            sth.ShowDialog();
        }
    }
}
