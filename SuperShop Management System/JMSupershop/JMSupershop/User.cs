using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class User : Form 
    {
        public User()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        } 
        private void Clear()
        {
            UnaIDtxt.Text = "";
            Unametxt.Text = "";
            Uemailtxt.Text = "";
            Userpasstxt.Text = "";
            Userphonetxt.Text = "";
            Useraddresstxt.Text = "";
            Key = 0;

        }
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbuser_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridView.DataSource = dt;// show the data 
        }
        private void Insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbuser_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UName", Unametxt.Text);
                    cmd.Parameters.AddWithValue("@UEmail", Uemailtxt.Text);
                    cmd.Parameters.AddWithValue("@UPassword",Userpasstxt.Text);
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
            LoadAllRrcords(); // for view the record in dataGridView1
            // button ar current View refresh
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            //JMTbuser_Update

            try
            { //Supplier_Update
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbuser_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UID", int.Parse(UnaIDtxt.Text));
                    cmd.Parameters.AddWithValue("@UName", Unametxt.Text);
                    cmd.Parameters.AddWithValue("@UEmail", Uemailtxt.Text);
                    cmd.Parameters.AddWithValue("@UPassword", Userpasstxt.Text);
                    cmd.Parameters.AddWithValue("@UPhone", Userphonetxt.Text);
                    cmd.Parameters.AddWithValue("@UAddress", Useraddresstxt.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully Update");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            LoadAllRrcords(); // for view the record in dataGridView1

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UnaIDtxt.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbuser_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UID", int.Parse(UnaIDtxt.Text));


                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Successfully Delete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                LoadAllRrcords(); // for view the record in dataGridView1
            }
        }
        int stock = 0, Key = 0;
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];


                UnaIDtxt.Text = row.Cells[0].Value.ToString();
                Unametxt.Text = row.Cells[1].Value.ToString();
                Uemailtxt.Text = row.Cells[2].Value.ToString();
                Userpasstxt.Text = row.Cells[3].Value.ToString();
                Userphonetxt.Text = row.Cells[4].Value.ToString();
                Useraddresstxt.Text = row.Cells[5].Value.ToString();
                if (UnaIDtxt.Text == "")
                {
                    stock = 0;
                    Key = 0;
                }
                else
                {
                    //stock = Convert.ToInt32(row.Cells[4].Value.ToString());//quentity
                    //Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }
    }
}
