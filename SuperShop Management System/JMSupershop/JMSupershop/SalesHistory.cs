using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace JMSupershop
{
    public partial class SalesHistory : Form
    {
        public SalesHistory()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }
        //jmbill_View
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH7TPEO\\SQLEXPRESS;Initial Catalog=JMKsupershop;Integrated Security=True");
        void LoadAllRrcords()
        {// load a imidate view or current data
            SqlCommand cmd = new SqlCommand("dbo.jmbill_View", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// Data table object
            ad.Fill(dt);
            DataGridView1.DataSource = dt;// show the data 
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        { 
            LoadAllRrcords();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //
        private void SalesHistory_Load(object sender, EventArgs e)
        {

        }
        //DataGridView1
        public class RevenueData
        {
            public int CID { get; set; }
            public int Amount { get; set; }
        }
        private List<RevenueData> GetDataFromDataGridView()
        {
            List<RevenueData> data = new List<RevenueData>();

            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                int id = Convert.ToInt32(row.Cells["CID"].Value);
                int amount = Convert.ToInt32(row.Cells["Amount"].Value);

                data.Add(new RevenueData { CID = id, Amount = amount });
            }

            return data;
        }
        Func<ChartPoint, string> LabelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        private void button5_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            List<RevenueData> data = GetDataFromDataGridView();

            foreach (var obj in data)
            {
                series.Add(new PieSeries
                {
                    Title = obj.CID.ToString(),
                    Values = new ChartValues<int> { obj.Amount },
                    DataLabels = true,
                    LabelPoint = LabelPoint
                });
            }

            pieChart1.Series = series;
        }

    }

}

