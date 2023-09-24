using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace JMSupershop
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }
        int Key = 0;
        private void Clear()
        {
            SupplierIDtxt.Text = "";
            snametxt.Text = "";
            semailtxt.Text = "";
            sphone1txt.Text = "";
            sphone2txt.Text = "";
            Pquantitytxt.Text = "";
            PIdstxt.Text = "";
            saddresstxt.Text = "";
            Key = 0;

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //Database

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords1()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbProducts_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridViewC.DataSource = dt;// show the data 
        }
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbSupplier_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridView.DataSource = dt;// show the data 
        }
        private void insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbSupplier_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SName", snametxt.Text);
                    cmd.Parameters.AddWithValue("@SEmail", semailtxt.Text);
                    cmd.Parameters.AddWithValue("@SPhone1", sphone1txt.Text);
                    cmd.Parameters.AddWithValue("@SPhone2", sphone2txt.Text);
                    cmd.Parameters.AddWithValue("@PQuantity", int.Parse(Pquantitytxt.Text));
                    cmd.Parameters.AddWithValue("@PID", PIdstxt.Text);
                    cmd.Parameters.AddWithValue("@SAddress", saddresstxt.Text);
                    cmd.Parameters.AddWithValue("@SDate", DateTime.Parse(DateTimePicker.Text));

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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            { //Supplier_Update
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbSupplier_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SID", int.Parse(SupplierIDtxt.Text));
                    cmd.Parameters.AddWithValue("@SName", snametxt.Text);
                    cmd.Parameters.AddWithValue("@SEmail", semailtxt.Text);
                    cmd.Parameters.AddWithValue("@SPhone1", sphone1txt.Text);
                    cmd.Parameters.AddWithValue("@SPhone2", sphone2txt.Text);
                    cmd.Parameters.AddWithValue("@PQuantity", int.Parse(Pquantitytxt.Text));
                    cmd.Parameters.AddWithValue("@PID", PIdstxt.Text);
                    cmd.Parameters.AddWithValue("@SAddress", saddresstxt.Text);
                    cmd.Parameters.AddWithValue("@SDate", DateTime.Parse(DateTimePicker.Text));
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SupplierIDtxt.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbSupplier_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SID", int.Parse(SupplierIDtxt.Text));


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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                SupplierIDtxt.Text = row.Cells[0].Value.ToString();
                snametxt.Text = row.Cells[1].Value.ToString();
                semailtxt.Text = row.Cells[2].Value.ToString();
                sphone1txt.Text = row.Cells[3].Value.ToString();
                sphone2txt.Text = row.Cells[4].Value.ToString();
                Pquantitytxt.Text = row.Cells[5].Value.ToString();
                PIdstxt.Text = row.Cells[6].Value.ToString();
                saddresstxt.Text = row.Cells[7].Value.ToString();
                DateTimePicker.Text = row.Cells[8].Value.ToString();


                if (snametxt.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords1();
        }

        private void SupplierIDtxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                con.Open();
                //JMTbProducts_Delete
                // Execute the query and populate the DataGridView
                SqlCommand cmd = new SqlCommand("Select * from JMTbProducts where EPId=@EPId", con);
                cmd.Parameters.AddWithValue("@EPId", int.Parse(guna2TextBox1.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewC.DataSource = dt;
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
    }
}
