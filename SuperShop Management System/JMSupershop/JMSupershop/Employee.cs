using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            empnametxt.Text = "";
            EmpEmailtxt.Text = "";
            emppasstxt.Text = "";
            empphonetxt.Text = "";
            empaddtxt.Text = "";
            searchwithidtxt.Text = "";

            Key = 0;

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //Data base
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");

        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbEmployee_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridView.DataSource = dt;// show the data 
        }
        //guna2TextBox1
        private void insertbtn_Click(object sender, EventArgs e)
        {
            string location = "C:\\Users\\HP\\source\\repos\\JMSupershop\\JMSupershop\\Resources\\save barcode picture";//picture whare save
            string path = Path.Combine(location, empnametxt.Text + ".jpg");//picture
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbEmployee_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;//@EName,EPassword

                    cmd.Parameters.AddWithValue("@EName", empnametxt.Text);
                    cmd.Parameters.AddWithValue("@EEmail", EmpEmailtxt.Text);
                    cmd.Parameters.AddWithValue("@EPassword", emppasstxt.Text);
                    cmd.Parameters.AddWithValue("@EPhone", empphonetxt.Text);
                    cmd.Parameters.AddWithValue("@EAddress", empaddtxt.Text);
                    cmd.Parameters.AddWithValue("@Epic", path);
                    Image a = pictureBox.Image;//picture

                    cmd.ExecuteNonQuery();
                    a.Save(path);//picture
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

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();  // picture box
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                dialog.Filter = "(*.jpg;*.png;*.jpge)|*.jpg;*.png;*.jpge";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(dialog.FileName);
                }

            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string location = "C:\\Users\\HP\\source\\repos\\JMSupershop\\JMSupershop\\Resources\\save barcode picture";//picture whare save
            string path = Path.Combine(location, empnametxt.Text + ".jpg");//picture
            try
            { //Supplier_Update
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbEmployee_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EId", searchwithidtxt.Text);
                    cmd.Parameters.AddWithValue("@EName", empnametxt.Text);
                    cmd.Parameters.AddWithValue("@EEmail", EmpEmailtxt.Text);
                    cmd.Parameters.AddWithValue("@EPassword", emppasstxt.Text);
                    cmd.Parameters.AddWithValue("@EPhone", empphonetxt.Text);
                    cmd.Parameters.AddWithValue("@EAddress", empaddtxt.Text);
                    cmd.Parameters.AddWithValue("@Epic", path);
                    Image a = pictureBox.Image;//picture
                    cmd.ExecuteNonQuery();
                    a.Save(path);//picture
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
            if (string.IsNullOrEmpty(searchwithidtxt.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbEmployee_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EId", int.Parse(searchwithidtxt.Text));


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

                searchwithidtxt.Text = row.Cells[0].Value.ToString();
                empnametxt.Text = row.Cells[1].Value.ToString();
                EmpEmailtxt.Text = row.Cells[2].Value.ToString();
                emppasstxt.Text = row.Cells[3].Value.ToString();
                empphonetxt.Text = row.Cells[4].Value.ToString();
                empaddtxt.Text = row.Cells[5].Value.ToString();
               
                if (searchwithidtxt.Text == "")
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
