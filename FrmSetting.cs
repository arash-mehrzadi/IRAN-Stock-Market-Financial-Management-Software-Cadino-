using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadino_trade
{
    public partial class FrmSetting : Form
    {
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\DataID.db; Version=3");
        SQLiteConnection scU = new SQLiteConnection(@"Data Source=C:\Users\arash\Desktop\d\DataID.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtU = new DataTable();
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //scm.CommandText = "select Name,ID from DataID";
            //scm.Connection = sc;
            //sda.SelectCommand = scm;
            //sda.Fill(dt);
            //scm.CommandText = "select name,id from DataID";
            //scm.Connection = scU;
            //sda.SelectCommand = scm;
            //sda.Fill(dtU);
            //var du = dt.AsEnumerable().Union(dtU.AsEnumerable());
            //dt.Merge(dtU);
            //dataGridView1.DataSource = du;
            //--Disble--//DownloadDataset();
            try
            {
                HttpWebRequest request = WebRequest.Create(@"http://uplinks.arashmehrzadi.com/DataID.db") as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream fs = File.Create("UpdateDataID.db"))
                    {
                        response.GetResponseStream().CopyTo(fs);
                    }
                }
            }
            catch
            {
                MessageBox.Show("cant acces to server!");
            }
        }
    }
}
