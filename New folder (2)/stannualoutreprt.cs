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
    public partial class stannualoutreprt : Form
    {

        ReportDocument cry = new ReportDocument();
        public stannualoutreprt(String oo ,String pp)
        {
            InitializeComponent();
            label3.Text = oo;
            label5.Text = pp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string year = comboBox1.Text;
            
            cry.Load(@"G:\3rd year 2nd semester\Group project\train\train\CrystalReport7.rpt");
            SqlConnection con = new DBConnector().getConnection();
            SqlCommand cmd = con.CreateCommand();

            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stockout where  year='" + year + "' ";
            SqlDataAdapter sda = new SqlDataAdapter();
            // sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand = cmd;
            DataSet st = new System.Data.DataSet();
            sda.Fill(st, "STOCKOUT");
            cry.SetDataSource(st);
            cry.SetParameterValue("year", year);
            crystalReportViewer1.ReportSource = cry;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            stannualrpthome rpt = new stannualrpthome(label3.Text, label5.Text);
            rpt.ShowDialog();
        }
    }
}
