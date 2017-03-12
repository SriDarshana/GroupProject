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
using MySql.Data.MySqlClient;



namespace train
{
    public partial class gatepassreprt : Form
    {

        ReportDocument cry = new ReportDocument();
        private string p1;
        private string p2;
        private string p3;
        

        public gatepassreprt(string p1, string p2, string p3, String tt)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            
            label1.Text = p3;
            label4.Text = tt;

           
        }
        void passpara(){
            CrystalReport3 ob = new CrystalReport3();
            ob.SetParameterValue("start", p1);
            crystalReportViewer1.ReportSource = ob;

            crystalReportViewer1.Refresh();
        
        }
      

        
        

        private void gatepassreprt_Load(object sender, EventArgs e)
        {

            try
            {
               

                string gatepassno = label1.Text;
                string trainid = label4.Text;

                cry.Load(@"G:\3rd year 2nd semester\Group project\train\train\CrystalReport3.rpt");
                string myConnection = "SERVER=db4free.net;PORT=3306;DATABASE=train123;UID=trainmgt;PWD=tds123";
                MySqlConnection mycon = new MySqlConnection(myConnection);
                MySqlCommand cbb = new MySqlCommand("select itemID,itemname,quantity from gatepass where gatepassno='" + gatepassno + "' ", mycon);
                MySqlCommand cbb1 = new MySqlCommand("select gatepassno from gatepass", mycon);
                

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
                cry.SetParameterValue("gpno", gatepassno);
                cry.SetParameterValue("trainid", trainid);
                crystalReportViewer1.ReportSource = cry;

                crystalReportViewer1.Refresh();
                

            }

                



            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
