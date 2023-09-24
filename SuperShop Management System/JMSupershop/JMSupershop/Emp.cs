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
    public partial class Emp : Form
    {
        public Emp()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login forget = new Login();
            forget.Show();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM JMTbEmployee WHERE EName = @EName AND EPassword = @EPassword", con);
                cmd.Parameters.AddWithValue("@EName", textBox1.Text);
                cmd.Parameters.AddWithValue("@EPassword", textBox2.Text);
                con.Open();   //tblForgotPass this is you are table
                DataTable dt = new DataTable();
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    Billing da = new Billing("Emp");
                    da.Show();
                }
                else
                {
                    MessageBox.Show("Login not possible for incorrect username and password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close(); // Always close the database connection when done.
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
