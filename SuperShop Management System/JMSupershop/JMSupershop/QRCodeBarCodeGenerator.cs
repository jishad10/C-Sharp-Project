using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class QRCodeBarCodeGenerator : Form
    {
        bool isGeneratedQR = false;
        bool isGeneratedBarcode = false;
        public QRCodeBarCodeGenerator()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }

        private void QRCodeBarCodeGenerator_Load(object sender, EventArgs e)
        {

        }

        private void QRcodebut_Click(object sender, EventArgs e)
        {
            isGeneratedQR = true;
            QRCodePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Zen.Barcode.CodeQrBarcodeDraw qrBarcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            QRCodePictureBox.Image = qrBarcode.Draw(QRTextBox.Text, 200);

        }

        private void BarcodeBut_Click(object sender, EventArgs e)
        {
            isGeneratedBarcode = true;
            BarcodePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            BarcodePictureBox.Image = barcode.Draw(BarcodeTextBox.Text, 200);

        }

        private void savebtu_Click(object sender, EventArgs e)
        {
            if (isGeneratedQR || isGeneratedBarcode)
            {
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (isGeneratedQR)
                    {
                        QRCodePictureBox.Image.Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_QR.jpg", ImageFormat.Jpeg);
                    }

                    if (isGeneratedBarcode)
                    {
                        BarcodePictureBox.Image.Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_Barcode.jpg", ImageFormat.Jpeg);
                    }

                    MessageBox.Show("Images saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No image has been generated yet.");
            }
        }
    }
}
