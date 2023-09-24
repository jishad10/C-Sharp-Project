using JMSupershop.Properties;
using System;
using System.Collections;
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
    public partial class StockandReport : Form
    {
        public StockandReport()
        {
            InitializeComponent();
           
               
        }
        public StockandReport(String user) // for entry
        {
            InitializeComponent();

            if (user == "Coustomer")
            {
                backbtn.Hide();
                guna2CircleButton1.Show();
            }
            
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { LoadAllRrcords(); }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.B2;

            pictureBox2.Image = Resources.B1;
            pictureBox3.Image = Resources.B1;
            pictureBox4.Image = Resources.B1;
            pictureBox5.Image = Resources.B1;

            lbl_ratings.Text = "1";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.B2;
            pictureBox2.Image = Resources.B2;

            pictureBox3.Image = Resources.B1;
            pictureBox4.Image = Resources.B1;
            pictureBox5.Image = Resources.B1;

            lbl_ratings.Text = "2";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Resources.B2;
            pictureBox2.Image = Resources.B2;
            pictureBox3.Image = Resources.B2;

            pictureBox4.Image = Resources.B1;
            pictureBox5.Image = Resources.B1;

            lbl_ratings.Text = "3";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.B2;
            pictureBox2.Image = Resources.B2;
            pictureBox3.Image = Resources.B2;
            pictureBox4.Image = Resources.B2;

            pictureBox5.Image = Resources.B1;

            lbl_ratings.Text = "4";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.B2;
            pictureBox2.Image = Resources.B2;
            pictureBox3.Image = Resources.B2;
            pictureBox4.Image = Resources.B2;
            pictureBox5.Image = Resources.B2;

            lbl_ratings.Text = "5";
        }

        private void Clear()
        {
            lbl_ratings.Text = "";
            textBox1.Text = "";
            Idtxt.Text = "";
            cntxt.Text = "";
            guna2TextBox1.Text = "";

            Key = 0;

        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");

        void LoadAllRrcords2()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            DataGridView2.DataSource = dt;// show the data

        }
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbReating_View", con);
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

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbReating_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RComment", textBox1.Text);
                    cmd.Parameters.AddWithValue("@RReating", int.Parse(lbl_ratings.Text));
                    cmd.Parameters.AddWithValue("@CID", int.Parse(Idtxt.Text));
                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);


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
            LoadAllRrcords();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords2();
        }

        private void Idtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                con.Open();

                // Execute the query and populate the DataGridView
                SqlCommand cmd = new SqlCommand("Select * from JMTbCoustomer where CId=@CId", con);
                cmd.Parameters.AddWithValue("@CId", int.Parse(Idtxt.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection (whether an exception occurred or not)
                con.Close();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                con.Open();

                // Execute the query and populate the DataGridView
                SqlCommand cmd = new SqlCommand("Select * from JMTbReating where RID=@RID", con);
                cmd.Parameters.AddWithValue("@RID", int.Parse(guna2TextBox1.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection (whether an exception occurred or not)
                con.Close();
            }
        }
        int stock = 0, Key = 0;

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView2.Rows[e.RowIndex];

               
                cntxt.Text = row.Cells[1].Value.ToString();
                if (Idtxt.Text == "")
                {
                    stock = 0;
                    Key = 0;
                }
                else
                {
                    stock = Convert.ToInt32(row.Cells[4].Value.ToString());//quentity
                    Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }
    }
}
