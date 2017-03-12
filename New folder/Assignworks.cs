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
    public partial class Assignworks : Form
    {
        public Assignworks(string bb , string jj)
        {
            InitializeComponent();
            label2.Text = bb;
            label4.Text = jj;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Morning mr = new Morning(label2.Text, label4.Text);
            mr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Afternoon ar = new Afternoon(label2.Text, label4.Text);
            ar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Night ni = new Night(label2.Text, label4.Text);
            ni.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            emphome ni = new emphome(label2.Text, label4.Text);
            ni.ShowDialog();
        }
    }
}
