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
    public partial class adminlogin : Form
    {
        public adminlogin( String ii)
        {
            InitializeComponent();
            label4.Text = ii;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            SqlConnection con = new DBConnector().getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM adminlogin WHERE username='" + username + "' AND password='" + password + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                this.Hide();
                adminhome Hm = new adminhome(label4.Text);
                Hm.ShowDialog();



            }
            else
            {
                MessageBox.Show("Invalid login ,Try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }

        private void adminlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
