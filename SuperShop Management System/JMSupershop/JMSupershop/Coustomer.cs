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
    public partial class Coustomer : Form
    {
        public Coustomer()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM JMTbCoustomer WHERE CName = @CName AND CPassword = @CPassword", con);
                cmd.Parameters.AddWithValue("@CName", textBox1.Text);
                cmd.Parameters.AddWithValue("@CPassword", textBox2.Text);
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
                    StockandReport da = new StockandReport("Coustomer");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
