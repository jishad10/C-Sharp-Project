using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;

namespace JMSupershop
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void BtnEncode_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter(){ Format = BarcodeFormat.CODE_128 };
            pic.Image = writer.Write(txtEncode.Text);
            // Center the image in the PictureBox
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Anchor = AnchorStyles.None;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }
        int Key = 0;
        private void Clear()
        {

            txtEncode.Text = "";
            txtpname.Text = "";
            txtpprice.Text = "";
            txtpcateg.Text = "";
            pquentity.Text = "";
            DateTimePicker.Text = "";
            SupplierIDtxt.Text = "";
            SupplierNametxt.Text = "";
            Key = 0;

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
       
        private void savebtn_Click(object sender, EventArgs e)
        {
            
            // Check if a barcode image has been generated
            if (pic.Image != null)
            {
                try
                {
                    // Get the user's desktop folder path
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    // Generate a unique filename based on seconds and milliseconds
                    string barcodeFileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_Barcode.jpg";

                    // Save the barcode image to the desktop
                    pic.Image.Save(Path.Combine(path, barcodeFileName), ImageFormat.Jpeg);

                    MessageBox.Show("Barcode image saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the barcode image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No barcode image has been generated yet.");
            }
        }
        // Data base

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbProducts_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            dataGridView.DataSource = dt;// show the data 
        }
        void LoadAllRrcords2()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.JMTbSupplier_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            DataGridView1.DataSource = dt;// show the data 
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            string location = "C:\\Users\\HP\\source\\repos\\JMSupershop\\JMSupershop\\Resources\\save barcode picture";//picture whare save
            string path = Path.Combine(location, txtpname.Text + ".jpg");//picture
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbProducts_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EPId", int.Parse(txtEncode.Text));
                    cmd.Parameters.AddWithValue("@PName", txtpname.Text);
                    cmd.Parameters.AddWithValue("@PPrice", int.Parse(txtpprice.Text));
                    cmd.Parameters.AddWithValue("@PCategories", txtpcateg.Text);
                    cmd.Parameters.AddWithValue("@PQuentity", int.Parse(pquentity.Text));
                    cmd.Parameters.AddWithValue("@PDate", DateTime.Parse(DateTimePicker.Text));
                    cmd.Parameters.AddWithValue("@SId", int.Parse(SupplierIDtxt.Text));
                    cmd.Parameters.AddWithValue("@SName", SupplierNametxt.Text);
                   cmd.Parameters.AddWithValue("@Spic", path);

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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            LoadAllRrcords();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string location = "C:\\Users\\HP\\source\\repos\\JMSupershop\\JMSupershop\\Resources\\save barcode picture";//picture whare save
            string path = Path.Combine(location, txtpname.Text + ".jpg");//picture
            try
            { //Supplier_Update
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.JMTbProducts_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EPId", int.Parse(txtEncode.Text));
                    cmd.Parameters.AddWithValue("@PName", txtpname.Text);
                    cmd.Parameters.AddWithValue("@PPrice", int.Parse(txtpprice.Text));
                    cmd.Parameters.AddWithValue("@PCategories", txtpcateg.Text);
                    cmd.Parameters.AddWithValue("@PQuentity", int.Parse(pquentity.Text));
                    cmd.Parameters.AddWithValue("@PDate", DateTime.Parse(DateTimePicker.Text));
                    cmd.Parameters.AddWithValue("@SId", int.Parse(SupplierIDtxt.Text));
                    cmd.Parameters.AddWithValue("@SName", SupplierNametxt.Text);
                    cmd.Parameters.AddWithValue("@Spic", path);
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
            if (string.IsNullOrEmpty(txtEncode.Text))
            {
                MessageBox.Show("You have not entered an ID.");
            }
            else if (MessageBox.Show("Are you Confirm to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                try
                { //SP_Product_Delete

                    using (SqlCommand cmd = new SqlCommand("dbo.JMTbProducts_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EPId", int.Parse(txtEncode.Text));


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


                txtEncode.Text = row.Cells[0].Value.ToString();
                txtpname.Text = row.Cells[1].Value.ToString();
                txtpprice.Text = row.Cells[2].Value.ToString();
                txtpcateg.Text = row.Cells[3].Value.ToString();
                pquentity.Text = row.Cells[4].Value.ToString();
                DateTimePicker.Text = row.Cells[5].Value.ToString();
                SupplierIDtxt.Text = row.Cells[6].Value.ToString();
                SupplierNametxt.Text = row.Cells[7].Value.ToString();
                if (txtEncode.Text == "")
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex];


                
                SupplierIDtxt.Text = row.Cells[0].Value.ToString();
                SupplierNametxt.Text = row.Cells[1].Value.ToString();
                if (txtEncode.Text == "")
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


