using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Changepass : Form
    {
        string U_Email = Forget.to;
        public Changepass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == TextBox2.Text)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");


                SqlCommand cmd = new SqlCommand("UPDATE JMTbuser set UPassword = '" + TextBox2.Text + "' where UEmail = '" + U_Email + "'", conn);
                conn.Open();   //tblForgotPass this is you are table
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Password Reset Successfully..........");

            }
            else
            {
                MessageBox.Show("your password is not match so try again...........");
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login forget = new Login();
            forget.Show();
        }
    }
}
