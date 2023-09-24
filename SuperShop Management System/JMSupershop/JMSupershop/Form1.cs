using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPos += 1;
            Myprogress.Value = startPos;
            label2.Text = startPos + "%";
            if (Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }

        }

        private void Myprogress_Click(object sender, EventArgs e)
        {
            // Change the color of the progress bar to blue
            //Myprogress.SetState(1); // SetState(1) corresponds to "Error" state, which can be customized
            //Myprogress.BackColor = Color.Blue;
            //Myprogress.ForeColor = Color.White;
        }
    }
}
