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
using System.Data.SqlClient;

namespace train
{
    public partial class dsalrpt : Form
    {

        ReportDocument cry = new ReportDocument();
        public dsalrpt(String ii , String ee)
        {
            InitializeComponent();
            label3.Text = ii;
            label5.Text = ee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Text;

                cry.Load(@"G:\3rd year 2nd semester\Group project\train\train\CrystalReport4.rpt");
                SqlConnection con = new DBConnector().getConnection();
                SqlCommand cmd = con.CreateCommand();

                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select date,trainid,tcktno,start,des,price,passe from tdt where  date='" + date + "'";
                SqlDataAdapter sda = new SqlDataAdapter();
                // sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand = cmd;
                DataSet st = new System.Data.DataSet();
                sda.Fill(st, "Tickets");
               
                cry.SetDataSource(st);
                cry.SetParameterValue("date", date);
                crystalReportViewer1.ReportSource = cry;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            
            }
        }

        private void dsalrpt_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesrpthome rpt = new salesrpthome(label3.Text, label5.Text);
            rpt.ShowDialog();
        }
    }
}
