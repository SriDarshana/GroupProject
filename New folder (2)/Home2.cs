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
    public partial class Home2 : Form
    {
        public Home2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* this.Hide();
            new empmgt().ShowDialog();
            this.Close();*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to log out", "logout", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialog == DialogResult.Yes)
            {


                /*this.Hide();
                new Form1().ShowDialog();
                this.Close();*/

            }
            else
            {

                this.Activate();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* this.Hide();
            new sales().ShowDialog();
            this.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Home Hm = new Home(label4.Text);
            Hm.ShowDialog();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new traindt().ShowDialog();
            this.Close();
        }
    }
}
