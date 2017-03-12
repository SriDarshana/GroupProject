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
    public partial class adminhome : Form
    {
        public adminhome( String qq)
        {
            InitializeComponent();
            label2.Text = qq;
            label4.Text = "admin";
        }

        private void adminhome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            h Hm = new h(label2.Text, label4.Text);
            Hm.ShowDialog();
        }
    }
}
