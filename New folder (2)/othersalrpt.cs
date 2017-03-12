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
using CrystalDecisions.CrystalReports.Engine;

namespace train
{
    public partial class othersalrpt : Form
    {
        ReportDocument cry = new ReportDocument();
        public othersalrpt(String mm , String ii)
        {
            InitializeComponent();
            label3.Text = mm;
            label5.Text = ii;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = dateTimePicker1.Text;
                string date2 = dateTimePicker2.Text;

                string theDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string theDate1 = dateTimePicker2.Value.ToString("dd/MM/yyyy");
               

                cry.Load(@"G:\3rd year 2nd semester\Group project\train\train\CrystalReport5.rpt");
                SqlConnection con = new DBConnector().getConnection();
                SqlCommand cmd = con.CreateCommand();

                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tdt where date between '" + theDate + "' and '" + theDate1 + "' ";
                SqlDataAdapter sda = new SqlDataAdapter();
                // sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand = cmd;
                DataSet st = new System.Data.DataSet();
                sda.Fill(st, "Tickets");

                cry.SetDataSource(st);
                cry.SetParameterValue("date1", date1);
                cry.SetParameterValue("date2", date2);
                crystalReportViewer1.ReportSource = cry;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesrpthome rpt = new salesrpthome(label3.Text, label5.Text);
            rpt.ShowDialog();
        }

        private void othersalrpt_Load(object sender, EventArgs e)
        {

        }
    }
}
