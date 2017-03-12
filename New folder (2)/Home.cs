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
    public partial class Home : Form
    {
        public Home(String stat , String lg)
        {
            InitializeComponent();
            label2.Text = stat;
            label6.Text = lg;
            timer1.Start();

        }

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            emphome2 emp = new emphome2(label2.Text , label6.Text);
            emp.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            issuetkt iss = new issuetkt(label2.Text, label6.Text);
            
            iss.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            traindt sth = new traindt(label2.Text, label6.Text);
            sth.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            stockhome sth = new stockhome(label2.Text ,label6.Text);
            sth.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            sales sa = new sales(label2.Text, label6.Text);
            sa.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to log out", "logout", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialog == DialogResult.Yes)
            {



                this.Hide();
                home1 ii = new home1(label2.Text);
                ii.ShowDialog();

            }
            else
            {

                this.Activate();

            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label5.Text = dateTime.ToShortDateString();

           

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            gatepass sth = new gatepass(label2.Text, label6.Text);
            sth.ShowDialog();
        }
    }
}
