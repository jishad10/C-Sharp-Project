using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class RFID : Form
    {
        private SerialPort serialPort;// dont tuch it 3333333333333333333
        private List<string> receivedLines = new List<string>();
        public RFID()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            InitializeSerialPort();
        }
        private void InitializeSerialPort()// dont tuch it 3333333333333333333
        {
            serialPort = new SerialPort("COM3", 9600);
            serialPort.DataReceived += serialPort1_DataReceived;
            serialPort.ErrorReceived += serialPort1_ErrorReceived;
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening serial port: " + ex.Message);
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)// dont tuch
        {
            if (e.EventType == SerialData.Chars)
            {
                try
                {
                    string data = serialPort.ReadExisting();
                    receivedLines.Add(data);
                    textBox1.Invoke(new Action(() =>
                    {
                        textBox1.Clear();
                        for (int i = 0; i < receivedLines.Count; i++)
                        {
                            textBox1.AppendText($"[{i + 1}] {receivedLines[i]}" + Environment.NewLine);
                        }
                    }));

                    UpdateTextBoxCount();

                    // Check if the received data is "1"
                    if (data.Trim() == "1")
                    {
                        // Update UI to show "100"
                        textBoxCount.Invoke(new Action(() => textBoxCount.Text = "100"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading data from serial port: " + ex.Message);
                }
            }
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
            }
            textBoxCount.Invoke(new Action(() => textBoxCount.Text = lineCount.ToString()));
        }
       
        private void Backbtn_Click(object sender, EventArgs e)
        {
           this.Hide();
           Billing billing = new Billing();
           billing.Show();
        }

        private void RFID_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void RFID_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            //textBoxCount
        }
    }
}
