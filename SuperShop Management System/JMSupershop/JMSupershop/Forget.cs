using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Forget : Form
    {
        string OTPCode;
        public static string to;
        public Forget()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login forget = new Login();
            forget.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            OTPCode = rand.Next(100000, 999999).ToString();

            MailMessage message = new MailMessage();
            to = guna2TextBox2.Text;
            from = "kjoy70422@gmail.com";
            pass = "uczemucxcwzkrszz";

            messageBody = "Your Reset OTP Code is " + OTPCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Forgot password code ";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("code send successFu11y");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (OTPCode == guna2TextBox1.Text)
            {
                to = guna2TextBox2.Text;
                Changepass cp = new Changepass();
                this.Hide();
                cp.Show();

            }
            else
            {
                MessageBox.Show("Wrong code");
            }
        }
    }
}
