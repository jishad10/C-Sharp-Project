namespace JMSupershop
{
    partial class Dashbord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashbord));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.AddMusicbutton = new Guna.UI2.WinForms.Guna2Button();
            this.listBoxSong = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Productbtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Userbtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Employeebtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Deliverybtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Salebtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Customerbtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.SalesHbtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.QRandBarbtn = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Mapbut = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.StockandReport = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.Supplierbtu = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(704, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 54);
            this.label1.TabIndex = 38;
            this.label1.Text = "00:00:00";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1383, 23);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(103, 45);
            this.guna2Button1.TabIndex = 39;
            this.guna2Button1.Text = "Log out";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(935, 269);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 411);
            this.panel4.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel1.Controls.Add(this.AddMusicbutton);
            this.panel1.Controls.Add(this.listBoxSong);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 375);
            this.panel1.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 75);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(270, 192);
            this.axWindowsMediaPlayer1.TabIndex = 66;
            // 
            // AddMusicbutton
            // 
            this.AddMusicbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AddMusicbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddMusicbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddMusicbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddMusicbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddMusicbutton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AddMusicbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddMusicbutton.ForeColor = System.Drawing.Color.White;
            this.AddMusicbutton.Location = new System.Drawing.Point(395, 324);
            this.AddMusicbutton.Name = "AddMusicbutton";
            this.AddMusicbutton.Size = new System.Drawing.Size(128, 35);
            this.AddMusicbutton.TabIndex = 65;
            this.AddMusicbutton.Text = "Add Music";
            this.AddMusicbutton.Click += new System.EventHandler(this.AddMusicbutton_Click);
            // 
            // listBoxSong
            // 
            this.listBoxSong.FormattingEnabled = true;
            this.listBoxSong.ItemHeight = 16;
            this.listBoxSong.Location = new System.Drawing.Point(395, 75);
            this.listBoxSong.Name = "listBoxSong";
            this.listBoxSong.Size = new System.Drawing.Size(128, 244);
            this.listBoxSong.TabIndex = 1;
            this.listBoxSong.SelectedIndexChanged += new System.EventHandler(this.listBoxSong_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 59);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Music Player";
            // 
            // Productbtu
            // 
            this.Productbtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Productbtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Productbtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Productbtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Productbtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Productbtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Productbtu.FillColor = System.Drawing.Color.Green;
            this.Productbtu.FillColor2 = System.Drawing.Color.Green;
            this.Productbtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Productbtu.ForeColor = System.Drawing.Color.White;
            this.Productbtu.Image = global::JMSupershop.Properties.Resources.icons8_product_100;
            this.Productbtu.ImageSize = new System.Drawing.Size(60, 60);
            this.Productbtu.Location = new System.Drawing.Point(18, 541);
            this.Productbtu.Name = "Productbtu";
            this.Productbtu.Size = new System.Drawing.Size(214, 139);
            this.Productbtu.TabIndex = 37;
            this.Productbtu.Text = "Product";
            this.Productbtu.Click += new System.EventHandler(this.Productbtu_Click);
            // 
            // Userbtu
            // 
            this.Userbtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Userbtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Userbtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Userbtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Userbtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Userbtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Userbtu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Userbtu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Userbtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Userbtu.ForeColor = System.Drawing.Color.White;
            this.Userbtu.Image = global::JMSupershop.Properties.Resources.icons8_user_100;
            this.Userbtu.ImageSize = new System.Drawing.Size(70, 70);
            this.Userbtu.Location = new System.Drawing.Point(18, 269);
            this.Userbtu.Name = "Userbtu";
            this.Userbtu.Size = new System.Drawing.Size(214, 154);
            this.Userbtu.TabIndex = 25;
            this.Userbtu.Text = "User";
            this.Userbtu.Click += new System.EventHandler(this.Userbtu_Click);
            // 
            // Employeebtu
            // 
            this.Employeebtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Employeebtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Employeebtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Employeebtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Employeebtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Employeebtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Employeebtu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Employeebtu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Employeebtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Employeebtu.ForeColor = System.Drawing.Color.White;
            this.Employeebtu.Image = global::JMSupershop.Properties.Resources.icons8_employee_96;
            this.Employeebtu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Employeebtu.ImageSize = new System.Drawing.Size(60, 60);
            this.Employeebtu.Location = new System.Drawing.Point(238, 269);
            this.Employeebtu.Name = "Employeebtu";
            this.Employeebtu.Size = new System.Drawing.Size(422, 154);
            this.Employeebtu.TabIndex = 26;
            this.Employeebtu.Text = "Employee";
            this.Employeebtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Employeebtu.Click += new System.EventHandler(this.Employeebtu_Click);
            // 
            // Deliverybtu
            // 
            this.Deliverybtu.BorderColor = System.Drawing.Color.Gray;
            this.Deliverybtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Deliverybtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Deliverybtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Deliverybtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Deliverybtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Deliverybtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Deliverybtu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Deliverybtu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Deliverybtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Deliverybtu.ForeColor = System.Drawing.Color.White;
            this.Deliverybtu.Image = global::JMSupershop.Properties.Resources.icons8_delivery_100;
            this.Deliverybtu.ImageSize = new System.Drawing.Size(60, 60);
            this.Deliverybtu.Location = new System.Drawing.Point(238, 429);
            this.Deliverybtu.Name = "Deliverybtu";
            this.Deliverybtu.Size = new System.Drawing.Size(221, 106);
            this.Deliverybtu.TabIndex = 27;
            this.Deliverybtu.Text = "Delivery";
            this.Deliverybtu.Click += new System.EventHandler(this.Deliverybtu_Click);
            // 
            // Salebtu
            // 
            this.Salebtu.BorderColor = System.Drawing.Color.Gray;
            this.Salebtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salebtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Salebtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Salebtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Salebtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Salebtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Salebtu.FillColor = System.Drawing.Color.SeaGreen;
            this.Salebtu.FillColor2 = System.Drawing.Color.SeaGreen;
            this.Salebtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Salebtu.ForeColor = System.Drawing.Color.White;
            this.Salebtu.Image = global::JMSupershop.Properties.Resources.icons8_bill_100;
            this.Salebtu.ImageSize = new System.Drawing.Size(60, 60);
            this.Salebtu.Location = new System.Drawing.Point(238, 541);
            this.Salebtu.Name = "Salebtu";
            this.Salebtu.Size = new System.Drawing.Size(221, 139);
            this.Salebtu.TabIndex = 28;
            this.Salebtu.Text = "Bill";
            this.Salebtu.Click += new System.EventHandler(this.Salebtu_Click);
            // 
            // Customerbtu
            // 
            this.Customerbtu.BorderColor = System.Drawing.Color.Gray;
            this.Customerbtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Customerbtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Customerbtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Customerbtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Customerbtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Customerbtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Customerbtu.FillColor = System.Drawing.Color.Gray;
            this.Customerbtu.FillColor2 = System.Drawing.Color.Gray;
            this.Customerbtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Customerbtu.ForeColor = System.Drawing.Color.White;
            this.Customerbtu.Image = global::JMSupershop.Properties.Resources.icons8_user_100__1_;
            this.Customerbtu.ImageSize = new System.Drawing.Size(40, 40);
            this.Customerbtu.Location = new System.Drawing.Point(465, 429);
            this.Customerbtu.Name = "Customerbtu";
            this.Customerbtu.Size = new System.Drawing.Size(195, 106);
            this.Customerbtu.TabIndex = 30;
            this.Customerbtu.Text = "Customer";
            this.Customerbtu.Click += new System.EventHandler(this.Customerbtu_Click);
            // 
            // SalesHbtu
            // 
            this.SalesHbtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SalesHbtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SalesHbtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SalesHbtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SalesHbtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SalesHbtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SalesHbtu.FillColor = System.Drawing.Color.Olive;
            this.SalesHbtu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SalesHbtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.SalesHbtu.ForeColor = System.Drawing.Color.White;
            this.SalesHbtu.Image = global::JMSupershop.Properties.Resources.icons8_sales_100;
            this.SalesHbtu.ImageSize = new System.Drawing.Size(50, 50);
            this.SalesHbtu.Location = new System.Drawing.Point(666, 429);
            this.SalesHbtu.Name = "SalesHbtu";
            this.SalesHbtu.Size = new System.Drawing.Size(262, 106);
            this.SalesHbtu.TabIndex = 31;
            this.SalesHbtu.Text = "Sales History";
            this.SalesHbtu.Click += new System.EventHandler(this.SalesHbtu_Click);
            // 
            // QRandBarbtn
            // 
            this.QRandBarbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QRandBarbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.QRandBarbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.QRandBarbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.QRandBarbtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.QRandBarbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.QRandBarbtn.FillColor = System.Drawing.Color.DarkCyan;
            this.QRandBarbtn.FillColor2 = System.Drawing.Color.DarkCyan;
            this.QRandBarbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.QRandBarbtn.ForeColor = System.Drawing.Color.White;
            this.QRandBarbtn.Image = global::JMSupershop.Properties.Resources.icons8_qr_code_64;
            this.QRandBarbtn.ImageSize = new System.Drawing.Size(60, 60);
            this.QRandBarbtn.Location = new System.Drawing.Point(465, 541);
            this.QRandBarbtn.Name = "QRandBarbtn";
            this.QRandBarbtn.Size = new System.Drawing.Size(195, 139);
            this.QRandBarbtn.TabIndex = 32;
            this.QRandBarbtn.Text = "QR and Bar Code";
            this.QRandBarbtn.Click += new System.EventHandler(this.QRandBarbtn_Click);
            // 
            // Mapbut
            // 
            this.Mapbut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mapbut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Mapbut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Mapbut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Mapbut.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Mapbut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Mapbut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Mapbut.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Mapbut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Mapbut.ForeColor = System.Drawing.Color.White;
            this.Mapbut.Image = global::JMSupershop.Properties.Resources.icons8_map_marker_100;
            this.Mapbut.ImageSize = new System.Drawing.Size(60, 60);
            this.Mapbut.Location = new System.Drawing.Point(666, 541);
            this.Mapbut.Name = "Mapbut";
            this.Mapbut.Size = new System.Drawing.Size(262, 139);
            this.Mapbut.TabIndex = 33;
            this.Mapbut.Text = "Maps";
            this.Mapbut.Click += new System.EventHandler(this.Mapbut_Click);
            // 
            // StockandReport
            // 
            this.StockandReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StockandReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.StockandReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.StockandReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.StockandReport.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.StockandReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.StockandReport.FillColor = System.Drawing.Color.Gray;
            this.StockandReport.FillColor2 = System.Drawing.Color.Gray;
            this.StockandReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.StockandReport.ForeColor = System.Drawing.Color.White;
            this.StockandReport.Image = global::JMSupershop.Properties.Resources.icons8_stock_60;
            this.StockandReport.ImageSize = new System.Drawing.Size(60, 60);
            this.StockandReport.Location = new System.Drawing.Point(666, 269);
            this.StockandReport.Name = "StockandReport";
            this.StockandReport.Size = new System.Drawing.Size(262, 154);
            this.StockandReport.TabIndex = 34;
            this.StockandReport.Text = "Customer Reating";
            this.StockandReport.Click += new System.EventHandler(this.StockandReport_Click);
            // 
            // Supplierbtu
            // 
            this.Supplierbtu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Supplierbtu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Supplierbtu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Supplierbtu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Supplierbtu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Supplierbtu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Supplierbtu.FillColor = System.Drawing.Color.Black;
            this.Supplierbtu.FillColor2 = System.Drawing.Color.Black;
            this.Supplierbtu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.Supplierbtu.ForeColor = System.Drawing.Color.White;
            this.Supplierbtu.Image = global::JMSupershop.Properties.Resources.icons8_provider_100__1_;
            this.Supplierbtu.ImageSize = new System.Drawing.Size(40, 40);
            this.Supplierbtu.Location = new System.Drawing.Point(18, 429);
            this.Supplierbtu.Name = "Supplierbtu";
            this.Supplierbtu.Size = new System.Drawing.Size(214, 106);
            this.Supplierbtu.TabIndex = 35;
            this.Supplierbtu.Text = "Supplier";
            this.Supplierbtu.Click += new System.EventHandler(this.Supplierbtu_Click);
            // 
            // Dashbord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1663, 819);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Productbtu);
            this.Controls.Add(this.Userbtu);
            this.Controls.Add(this.Employeebtu);
            this.Controls.Add(this.Deliverybtu);
            this.Controls.Add(this.Salebtu);
            this.Controls.Add(this.Customerbtu);
            this.Controls.Add(this.SalesHbtu);
            this.Controls.Add(this.QRandBarbtn);
            this.Controls.Add(this.Mapbut);
            this.Controls.Add(this.StockandReport);
            this.Controls.Add(this.Supplierbtu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashbord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashbord";
            this.Load += new System.EventHandler(this.Dashbord_Load);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientTileButton Productbtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Supplierbtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Mapbut;
        private Guna.UI2.WinForms.Guna2GradientTileButton QRandBarbtn;
        private Guna.UI2.WinForms.Guna2GradientTileButton SalesHbtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Customerbtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Salebtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Deliverybtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Employeebtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton Userbtu;
        private Guna.UI2.WinForms.Guna2GradientTileButton StockandReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button AddMusicbutton;
        private System.Windows.Forms.ListBox listBoxSong;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}