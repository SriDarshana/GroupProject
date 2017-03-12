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
    public partial class salesrpthome : Form
    {
        public salesrpthome(String tt , String rr )
        {
            InitializeComponent();
            label2.Text = tt;
            label4.Text = rr;

        }

        private void salesrpthome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dsalrpt Hm = new dsalrpt(label2.Text, label4.Text);
            Hm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
             sales sal = new sales(label2.Text, label4.Text);
            sal.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            othersalrpt sal = new othersalrpt(label2.Text, label4.Text);
            sal.ShowDialog();
        }
    }
}
