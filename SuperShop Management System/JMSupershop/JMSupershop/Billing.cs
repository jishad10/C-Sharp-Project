using AForge.Video;
using AForge.Video.DirectShow;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace JMSupershop
{
    public partial class Billing : Form
    {
       

        /*                            Ardino                 */
        private SerialPort serialPort;// dont tuch it 3333333333333333333
        private List<string> receivedLines = new List<string>();// dont tuch it 3333333333333333333


        public Billing()
        {
            InitializeComponent();
           DataGridView1.CellClick += DataGridView1_CellContentClick;
           bpitxt.TextChanged += bpitxt_TextChanged;

            LoadAllRrcords();
           
            timer1.Interval = 1000;
            timer1.Start();
            InitializeSerialPort();
        }
        public Billing(String user) // for entry
        {
            InitializeComponent();
            if (user == "Emp")
            {
                Backbtn.Hide();
                logout.Show();

            }

        }
        // video 1
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void InitializeSerialPort()// dont tuch it 3333333333333333333
        {
            try
            {
                serialPort = new SerialPort("COM3", 9600);
                // ... your code ...
                Console.WriteLine("Serial port initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing serial port: " + ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)// dont tuch
        {
            if (e.EventType == SerialData.Chars)
            {
                try
                {
                    string data = serialPort.ReadExisting();
                    // Process the received RFID data
                    ProcessRFIDData(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading data from serial port: " + ex.Message);
                }
            }
        }
        private void ProcessRFIDData(string data)
        {
            // Here, you can implement the logic to handle the received RFID data.
            // This method is where you would interpret the data format and take appropriate actions.
            // For example, you might update a UI element or trigger some other functionality.
            // You can use Invoke to update UI controls from this non-UI thread if needed.
            Invoke(new Action(() =>
            {
                // Update UI or perform actions based on RFID data
                textBox2.Text = data;
            }));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            serialPort?.Dispose();
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)// dont tuch     
        {
            Console.WriteLine("Serial port error: " + e.EventType.ToString());
        }

        private void UpdateTextBoxCount()//dont tuch
        {
            int lineCount = 0;


            for (int i = 0; i < receivedLines.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(receivedLines[i]))
                {
                    lineCount++;
                }
            }////////////////////////////////////////////////////////////////////////////////////////
            textBox2.Invoke(new Action(() => textBox2.Text = lineCount.ToString()));
        }
        private void timer1_Tick(object sender, EventArgs e)//dont tuch
        {
            try
            {
                serialPort.Write("count=0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing data to serial port: " + ex.Message);
            }

        }
        /*                                         video                           */
        private void timer1_Tick_1(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Billing_Load(object sender, EventArgs e)
        {//222222222222222222222222222222222222222222222222222222
            //textBoxDiscount.Text = b.textBoxCount.Text;
            // Video 2
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cboCamera.Items.Add(device.Name);
                cboCamera.SelectedIndex = 0;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                bpitxt.Invoke(new MethodInvoker(delegate ()
                {
                    bpitxt.Text = result.ToString();
                }));
            }
            pictureBox.Image = bitmap;

        }

        private void Billing_FormClosing_1(object sender, FormClosingEventArgs e)
        {
           
            if (videoCaptureDevice == null)
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            }

            if (!videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
                videoCaptureDevice = null; // Set to null to release the device resources
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }
        //BillDGV
        //Totalbill
        private void DG()
        {
            BillDGV.Show();
        }
        private void Reset()
        {
            bpitxt.Text = "";
            pntxt.Text = "";
            pptxt.Text = "";
            qtxt.Text = "";
            BillDGV.Text = "";

        }
        private void resetbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        // Data base============================================================================================================================
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords() // clearJMTbProducts
        {
            con.Open();
            string query = "select * from JMTbProducts";
            SqlDataAdapter s = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(s);
            var ds = new DataSet();
            s.Fill(ds);
            DataGridView1.DataSource = ds.Tables[0];
            con.Close();

            //BillDGV
        }
        int n = 0, GrdTotal = 0, Amount;
        private void activeordbtn_Click(object sender, EventArgs e)
        {
            if (qtxt.Text == "" || Convert.ToInt32(qtxt.Text) > stock || pntxt.Text == "")
            {
                MessageBox.Show("Enter Quantity");
            }
            else
            {
                int total = Convert.ToInt32(qtxt.Text) * Convert.ToInt32(pptxt.Text);
                float discount = string.IsNullOrEmpty(textBoxDiscount.Text) ? 0 : float.Parse(textBoxDiscount.Text);
                float discountedTotal = total - discount;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = pntxt.Text;
                newRow.Cells[2].Value = pptxt.Text;
                newRow.Cells[3].Value = qtxt.Text;
                newRow.Cells[4].Value = (int)discountedTotal; ;
                BillDGV.Rows.Add(newRow);
               
                GrdTotal = GrdTotal + (int)discountedTotal; // Update the total with discounted total
                Amount = GrdTotal;
                Totalbill.Text = " " + GrdTotal;

                // ADiscount.Text = Val(Totalbill.Text) - Val(textBoxDiscount.Text);
               // ADiscount.Text = (float.Parse(Totalbill.Text) - float.Parse(textBoxDiscount.Text)).ToString();
                n++;
                //paidtxt.Text = Totalbill.Text;
                UpdateItem();
                Reset();
            }
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //When click datagridview show in text box
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex];

                pntxt.Text = row.Cells[1].Value.ToString();
                pptxt.Text = row.Cells[2].Value.ToString();
                if (pntxt.Text == "")
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
        string EName = "Ename";
        int EId = 1;
        private void printbtn_Click(object sender, EventArgs e)
        {
            if (cntxt.Text == ""|| citxt.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                try
                {
                    con.Open();
                    // SqlCommand cmd = new SqlCommand("insert into jmbill values( '" + EId + "','" + EName + "','" + citxt.Text + "','" + cntxt.Text + "'," + Amount + ")", con);
                    SqlCommand cmd = new SqlCommand("INSERT INTO jmbill (EId, EName, CID, CName, Amount) " +
                                  "VALUES (@EId, @EName, @CID, @CName, @Amount)", con);
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cmd.Parameters.AddWithValue("@EName", EName);
                    cmd.Parameters.AddWithValue("@CID", int.Parse(citxt.Text));
                    cmd.Parameters.AddWithValue("@CName", cntxt.Text);
                    float discount = string.IsNullOrEmpty(textBoxDiscount.Text) ? 0 : float.Parse(textBoxDiscount.Text);
                    float totalAmountWithDiscount = Amount - discount;
                    cmd.Parameters.AddWithValue("@Amount", totalAmountWithDiscount);
                    

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully");
                    con.Close();
                    LoadAllRrcords();

                    // Print the document
                     PrintDocument printDoc = new PrintDocument();
                     printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                     printPreviewDialog1.Document = printDoc;

                     if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                     {
                         printDoc.Print();
                     }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            //LoadAllRrcords();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            DG();
        }

        private void bpitxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                con.Open();

                // Execute the query and populate the DataGridView
                SqlCommand cmd = new SqlCommand("Select * from JMTbProducts where EPId=@EPId", con);
                cmd.Parameters.AddWithValue("@EPId", int.Parse(bpitxt.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGridView1.DataSource = dt;
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            // compleat the coad
            // Define the fonts
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12);

            // Define positions
            float titleX = e.MarginBounds.Left;
            float titleY = e.MarginBounds.Top;
            float textX = e.MarginBounds.Left;
            float textY = titleY + titleFont.Height + 20;

            // Draw the title
            e.Graphics.DrawString("Billing Report", titleFont, Brushes.Black, titleX, titleY);

            // Draw the content
            string billContent = "Customer ID: " + citxt.Text + "\n" +
                                 "Client Name: " + cntxt.Text + "\n" +
                                 "Total Amount: " + Amount.ToString() + "\n" +
                                 "Date: " + DateTime.Now.ToString();
            // Include the discount information
            float discount = string.IsNullOrEmpty(textBoxDiscount.Text) ? 0 : float.Parse(textBoxDiscount.Text);
            billContent += "Discount: " + discount.ToString() + "\n";

            // Calculate the total amount after discount
            float totalAmountAfterDiscount = Amount - discount;
            billContent += "Total Amount after Discount: " + totalAmountAfterDiscount.ToString() + "\n";

            billContent += "Date: " + DateTime.Now.ToString();
            e.Graphics.DrawString(billContent, regularFont, Brushes.Black, textX, textY);
        }

        

        int stock = 0, Key = 0;

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void search1btn_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            //textBoxDiscount
        }

        private void Totalbill_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ADiscount_Click(object sender, EventArgs e)
        {
            //(float.Parse(Totalbill.Text) - float.Parse(textBoxDiscount.Text)).ToString();
        }

        private void Showbtn_Click(object sender, EventArgs e)
        {
            ADiscount.Text = (float.Parse(Totalbill.Text) - float.Parse(textBoxDiscount.Text)).ToString();
        }

        private void Reset2()
        {
            citxt.Text = "";
            cntxt.Text = "";
     
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset2();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RFID rfid = new RFID();
            rfid.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
          //  textBoxDiscount.Text = b.textBoxCount.Text;
        }

        private void paidtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                remaintext.Text = (float.Parse(amounttxt.Text) - float.Parse(paidtxt.Text)).ToString();
               
            }
            catch { }

        }

        private void UpdateItem()
        {
            try
            {
                int newQty = stock - Convert.ToInt32(qtxt.Text);
                con.Open();
                string query = "Update JMTbProducts set PQuentity =" + newQty + " where EPId=" + Key + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Updated Successfully");
                con.Close();
                LoadAllRrcords();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }






        //private DataTable Search(string searchText){ }
        private void bpitxt_KeyUp(object sender, KeyEventArgs e)
        {
           
        }


        

    }
}
