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
    public partial class emphome : Form
    {
        public emphome(String sdd , String pp)
        {
            InitializeComponent();
            label2.Text = sdd;
            label4.Text = pp;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "admin")
            {

                this.Hide();
                h Hm = new h(label2.Text, label4.Text);
                Hm.ShowDialog();


            }
            else {

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assignworks asi = new Assignworks(label2.Text, label4.Text);
            asi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewworks vi = new viewworks(label2.Text, label4.Text);
            vi.ShowDialog();
        }
    }
}
