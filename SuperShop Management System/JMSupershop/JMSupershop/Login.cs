using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");


        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM JMTbuser WHERE UName = @UName AND UPassword = @UPassword", con);
                cmd.Parameters.AddWithValue("@UName", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@UPassword", TextBox_Password.Text);
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
                    Dashbord da = new Dashbord();
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

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Forget forget = new Forget();
            forget.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Rag forget = new Rag();
            forget.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coustomer forget = new Coustomer();
            forget.Show();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emp forget = new Emp();
            forget.Show();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Forget forget = new Forget();
            forget.Show();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Rag forget = new Rag();
            forget.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//textBox1
            if(checkBox1.Checked)
            {
                TextBox_Password.UseSystemPasswordChar = false;
            }
            else
            {
                TextBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
