using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace train
{
    public partial class home1 : Form
    {
        public home1(String Username)
        {
            InitializeComponent();
            label2.Text = Username;
        }

       

       
       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form1 = new Form1(label2.Text);
            form1.ShowDialog();




        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            adminlogin ss = new adminlogin(label2.Text);
            ss.ShowDialog();
        }
    }
}
