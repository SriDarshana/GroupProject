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
    public partial class sales : Form
    {
        public sales(String st , String nn)
        {
            InitializeComponent();
            label2.Text = st;
            label4.Text = nn;
        }

       

      private void button3_Click_1(object sender, EventArgs e)
        {
            
          if(label4.Text=="admin"){

              this.Hide();
              h Hm = new h(label2.Text, label4.Text);
              Hm.ShowDialog();
          
          }else{

              this.Hide();
              Home Hm = new Home(label2.Text, label4.Text);
              Hm.ShowDialog();
          
          
          }
          
          
          
          
          
          
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            dailys Hm = new dailys(label2.Text, label4.Text);
        
            Hm.ShowDialog();
        }

       

        private void sales_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesrpthome rpt = new salesrpthome(label2.Text, label4.Text);
            rpt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           anysale rpt = new anysale(label2.Text, label4.Text);
            rpt.ShowDialog();

        }
    }
}
