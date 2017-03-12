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
    public partial class monthlyrpthome : Form
    {
        public monthlyrpthome(String tt , String ff)
        {
            InitializeComponent();
            label2.Text = tt;
            label4.Text = ff;

        }

        private void monthlyrpthome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            stmonthreprt mn = new stmonthreprt(label2.Text, label4.Text);
            mn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            stmonthoutreprt mn = new stmonthoutreprt(label2.Text, label4.Text);
            mn.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            monthly rpt = new monthly(label2.Text, label4.Text);
            rpt.ShowDialog();
        }
    }
}
