using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }
        public Dashbord(String user) // for entry
        {
            InitializeComponent();

            
            
        }

        private void Userbtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            User u = new User();
            u.Show();
        }

        private void Supplierbtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supplier SU = new Supplier();
            SU.Show();
        }

        private void Productbtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product SU = new Product();
            SU.Show();
        }

        private void Employeebtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee SU = new Employee();
            SU.Show();
        }

        private void Deliverybtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery SU = new Delivery();
            SU.Show();
        }

        private void Customerbtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer SU = new Customer();
            SU.Show();
        }

        private void Salebtu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing SU = new Billing();
            SU.Show();
        }

        private void StockandReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockandReport SU = new StockandReport();
            SU.Show();
        }

        private void Mapbut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Maps SU = new Maps();
            SU.Show();
        }

        private void QRandBarbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            QRCodeBarCodeGenerator SU = new QRCodeBarCodeGenerator();
            SU.Show();
        }

        private void SalesHbtu_Click(object sender, EventArgs e)
        { this.Hide();
            SalesHistory SU = new SalesHistory();
            SU.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
        }

        private void Dashbord_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //Song
        string[] paths, files;

        private void listBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[listBoxSong.SelectedIndex];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();

        }

        private void AddMusicbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd .ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 files = ofd.SafeFileNames;
                 paths = ofd.FileNames;

                for (int i = 0; i<files.Length; i++)
                {
                    listBoxSong.Items.Add(files[i]);
                }
            }
        }
    }
}
