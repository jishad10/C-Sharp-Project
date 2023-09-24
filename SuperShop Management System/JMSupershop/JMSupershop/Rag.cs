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
    public partial class Rag : Form
    {
        public Rag()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbuser_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UName", Unametxt.Text);
                    cmd.Parameters.AddWithValue("@UEmail", Uemailtxt.Text);
                    cmd.Parameters.AddWithValue("@UPassword", Userpasstxt.Text);
                    cmd.Parameters.AddWithValue("@UPhone", Userphonetxt.Text);
                    cmd.Parameters.AddWithValue("@UAddress", Useraddresstxt.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
