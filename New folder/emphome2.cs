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
    public partial class emphome2 : Form
    {
        public emphome2(String tt , String nn)
        {
            InitializeComponent();
            label2.Text = tt;
            label4.Text = nn;
        }

        private void emphome2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewworks vi = new viewworks(label2.Text, label4.Text);
            vi.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "admin")
            { 

                this.Hide();
                h Hm = new h(label2.Text, label4.Text);
                Hm.ShowDialog();


            }
            else
            {

                this.Hide();
                Home Hm = new Home(label2.Text, label4.Text);
                Hm.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            empmgt emp = new empmgt(label2.Text, label4.Text);
            emp.ShowDialog();
        }
    }
}
