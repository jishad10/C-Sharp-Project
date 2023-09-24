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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace JMSupershop
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        int Key = 0;
        private void Clear()
        {

            cntxt.Text = "";
            cetxt.Text = "";

            conptxt.Text = "";
            coup.Text = "";
            caddtxt.Text = "";
            Key = 0;


        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
        //Sql database

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
       
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_View", con);
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

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;//CName,CPassword


                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);
                    cmd.Parameters.AddWithValue("@CEmail", cetxt.Text);
                    cmd.Parameters.AddWithValue("@CPassword", conptxt.Text);
                    cmd.Parameters.AddWithValue("@CPhone", coup.Text);
                    cmd.Parameters.AddWithValue("@CAddress", caddtxt.Text);

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

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            { //Supplier_Update
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CId", int.Parse(Idtxt.Text));
                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);
                    cmd.Parameters.AddWithValue("@CEmail", cetxt.Text);
                    cmd.Parameters.AddWithValue("@CPassword", conptxt.Text);
                    cmd.Parameters.AddWithValue("@CPhone", coup.Text);
                    cmd.Parameters.AddWithValue("@CAddress", caddtxt.Text);
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
            LoadAllRrcords();
        }



        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Idtxt.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbCoustomer_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CID", int.Parse(Idtxt.Text));


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


                Idtxt.Text = row.Cells[0].Value.ToString();
                cntxt.Text = row.Cells[1].Value.ToString();
                cetxt.Text = row.Cells[2].Value.ToString();
                conptxt.Text = row.Cells[3].Value.ToString();
                coup.Text = row.Cells[4].Value.ToString();
                caddtxt.Text = row.Cells[5].Value.ToString();
                if (Idtxt.Text == "")
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
