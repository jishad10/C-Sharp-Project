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
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void Clear()
        {

            dmntxt.Text = "";
            dmptxt.Text = "";
            DateTimePicker.Text = "";
            bitxt.Text = "";
            CIdtxt.Text = "";
            cntxt.Text = "";
            cptxt.Text = "";
            catxt.Text = "";
            dmidtxt.Text = "";
            Key = 0;

        }

        private void btnclar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords2()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridView1.DataSource = dt;// show the data

        }
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbDelivery_View", con);
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

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbDelivery_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DMName", dmntxt.Text);
                    cmd.Parameters.AddWithValue("@DMPhone", dmptxt.Text);
                    cmd.Parameters.AddWithValue("@DDate", DateTime.Parse(DateTimePicker.Text));
                    cmd.Parameters.AddWithValue("@billid", int.Parse(bitxt.Text));
                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);
                    cmd.Parameters.AddWithValue("@CPhone", cptxt.Text);
                    cmd.Parameters.AddWithValue("@CAddress", catxt.Text);
                    cmd.Parameters.AddWithValue("@CID", int.Parse(CIdtxt.Text));

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

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbDelivery_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DMId", dmidtxt.Text);
                    cmd.Parameters.AddWithValue("@DMName", dmntxt.Text);
                    cmd.Parameters.AddWithValue("@DMPhone", dmptxt.Text);
                    cmd.Parameters.AddWithValue("@DDate", DateTime.Parse(DateTimePicker.Text));
                    cmd.Parameters.AddWithValue("@billid", int.Parse(bitxt.Text));
                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);
                    cmd.Parameters.AddWithValue("@CPhone", cptxt.Text);
                    cmd.Parameters.AddWithValue("@CAddress", catxt.Text);
                    cmd.Parameters.AddWithValue("@CID", int.Parse(CIdtxt.Text));
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
            if (string.IsNullOrEmpty(dmidtxt.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbDelivery_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DMId", int.Parse(dmidtxt.Text));


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

        int stock = 0;
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];


                dmidtxt.Text = row.Cells[0].Value.ToString();
                dmntxt.Text = row.Cells[1].Value.ToString();
                dmptxt.Text = row.Cells[2].Value.ToString();
                DateTimePicker.Text = row.Cells[3].Value.ToString();
                bitxt.Text = row.Cells[4].Value.ToString();
                CIdtxt.Text = row.Cells[8].Value.ToString();
                cntxt.Text = row.Cells[5].Value.ToString();
                cptxt.Text = row.Cells[6].Value.ToString();
                catxt.Text = row.Cells[7].Value.ToString();



                if (dmidtxt.Text == "")
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                CIdtxt.Text = row.Cells[0].Value.ToString();
                cntxt.Text = row.Cells[1].Value.ToString();
                cptxt.Text = row.Cells[4].Value.ToString();
                catxt.Text = row.Cells[5].Value.ToString();


                if (dmidtxt.Text == "")
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords2();
        }
    }
}
