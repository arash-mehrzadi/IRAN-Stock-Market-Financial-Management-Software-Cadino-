using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace cadino_trade
{
    public partial class FluctionControlForm : Form
    {
        //SqlConnection conn = new SqlConnection();
        //SqlCommand cmd1 = new SqlCommand();
        //SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //CurrencyManager cr;
        //SqlCommand c1 = new SqlCommand();
        DataTable dt = new DataTable();
        //int state;
        //string asad;
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\DataID.db; Version=3");
        SQLiteConnection scID = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\UpdateDataID.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        int txtnumlastprice = 0, txtnumendprice = 0, txtnumup = 0, txtnumdown = 0;
        int A=0 , B=0 , Y=0 , lastp = 0 , endp = 0;
        int TopRangeCounter = 0 , LowRangeCounter = 0 , IDCounter = 0;
        //Dictionary<int,Int64> CounterDic = new Dictionary<int, Int64>();
        public FluctionControlForm()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.TextBox AddNewTextBox()
        {
            System.Windows.Forms.TextBox textbox = new System.Windows.Forms.TextBox();
            textbox.Name = "txt" + B;
            //panel2.Controls.Add(textbox);
            textAdded.Insert(B, textbox);
            textbox.Top = B * 150;
            textbox.Left = 20;
            B += 1;
            return textbox;
        }
        List<TextBox> textAdded = new List<TextBox>();
        public Bunifu.UI.WinForms.BunifuRadialGauge addbunifugauge(int Drange , int Urange , int pirange)
        {
            int len = (Urange - Drange);
            int point = (pirange - Drange);
            double Result = ((double)point / (double)len)*100;
            //MessageBox.Show(Result.ToString());
            Bunifu.UI.WinForms.BunifuRadialGauge bunifugauge = new Bunifu.UI.WinForms.BunifuRadialGauge();
            bunifugauge.Name = "bunifugauge" + A;
            this.Controls.Add(bunifugauge);
            //bunifugauge.Top = A * 150;
            //bunifugauge.Left = 200;
            //Y += A * 150;
            bunifugauge.BackColor = Color.FromArgb(18, 18, 18);
            bunifugauge.Value = Convert.ToInt32(Result);
            bunifugauge.ProgressColorHigh = Color.Green;
            bunifugauge.ProgressColorLow = Color.Red;
            bunifugauge.ProgressBackColor = Color.FromArgb(0, 0, 0);
            bunifugauge.RangeLabelsColor = Color.White;
            bunifugauge.ValueLabelColor = Color.White;
            //bunifugauge.ForeColor = Color.White;
            bunifugauge.Anchor = AnchorStyles.Right;
            bunifugauge.Anchor = AnchorStyles.Top;
            //bunifugauge.Location = new Point(500, Y);
            bunifugauge.Dock = DockStyle.Right;
            A += 1;
            ProgressList.Add(bunifugauge);
            return bunifugauge;
        }
        List<Bunifu.UI.WinForms.BunifuRadialGauge> ProgressList = new List<Bunifu.UI.WinForms.BunifuRadialGauge>();
        public  System.Windows.Forms.Panel AddFluctionPanel()
        {
            System.Windows.Forms.Panel FluctionPanel = new System.Windows.Forms.Panel();
            FluctionPanel.Name = "Panel" + A;
            FluctionPanel.Dock = DockStyle.Top;
            this.Controls.Add(FluctionPanel);
            this.Controls.SetChildIndex(FluctionPanel, 0);
            FluctionPanel.Controls.Add(AddDeleteButton());
            //FluctionPanel.Controls.Add(addbunifugauge());
            FluctionPanel.Controls.Add(AddTopRangeLabel());
            FluctionPanel.Controls.Add(AddDownRangeLabel());
            FluctionPanel.Controls.Add(lastprice());
            FluctionPanel.Controls.Add(Endprice());
            FluctionPanel.Controls.Add(AddID(cmbsearchID.Text));
            string ID = find_ID(cmbsearchID.Text);
            string[] data = receivepricedata(ID);
            FluctionPanel.Controls.Add(Addtextbox("txttuprange", txtnumup, 8, 300,txtRangeUp.Text));
            txtRangeUpList.Add(Addtextbox("txttuprange", txtnumup, 8, 300, txtRangeUp.Text));
            txtnumup += 1;
            FluctionPanel.Controls.Add(Addtextbox("txtdownrange", txtnumup, 33, 300, txtRangeDown.Text));
            txtRangeDownList.Add(Addtextbox("txtdownrange", txtnumup, 33, 300, txtRangeDown.Text));
            txtnumdown += 1;
            FluctionPanel.Controls.Add(Addtextbox("txtlastprice", txtnumup, 58, 300, data[2]));
            txtnumlastprice += 1;
            FluctionPanel.Controls.Add(Addtextbox("txtendprice", txtnumup, 83, 300, data[3]));
            txtnumendprice += 1;
            FluctionPanel.Controls.Add(addbunifugauge(Int32.Parse(txtRangeDown.Text), Int32.Parse(txtRangeUp.Text), Int32.Parse(data[2])));
            FluctionPanel.Controls.Add(Stockvalue());
            FluctionPanel.BackColor = Color.FromArgb(18,18,18);
            FluctionPanel.BorderStyle = BorderStyle.FixedSingle;
            FluctionPanel.Height = 130;
            //FluctionPanel.Padding = new Padding(0, 50, 0, 0);
            //PanelAdded.Insert(0, FluctionPanel);
            //UpRangeList.Add(txtRangeUp.Text);
            //DownRangeList.Add(txtRangeDown.Text);
            PanelAdded.Add(FluctionPanel);
            IDlist.Add(Int64.Parse(ID));
            SavepanelData(ID, cmbsearchID.Text , txtRangeUp.Text, txtRangeDown.Text);
            //CounterDic.Add(A, Int64.Parse(ID));
            A += 1;
            return FluctionPanel;
        }
        List<Panel> PanelAdded = new List<Panel>();
        List<long> IDlist = new List<long>();
        //List<string> UpRangeList = new List<string>();
        //List<string> DownRangeList = new List<string>();
        List<System.Windows.Forms.TextBox> txtRangeUpList = new List<System.Windows.Forms.TextBox>();
        List<System.Windows.Forms.TextBox> txtRangeDownList = new List<System.Windows.Forms.TextBox>();

        public System.Windows.Forms.Label AddTopRangeLabel()
        {
            System.Windows.Forms.Label TopRangeLabel = new System.Windows.Forms.Label();
            TopRangeLabel.Name = "lblTopRange" + TopRangeCounter;
            this.Controls.Add(TopRangeLabel);
            TopRangeLabel.Top = 10;
            TopRangeLabel.Left = 175;
            TopRangeLabel.Text = "حد سود : ";
            TopRangeCounter += 1;
            return TopRangeLabel;
        }
        public System.Windows.Forms.Label lastprice ()
        {
            System.Windows.Forms.Label lbllastprice = new System.Windows.Forms.Label();
            lbllastprice.Name = "lbllastprice" + lastp;
            this.Controls.Add(lbllastprice);
            lbllastprice.Top = 60;
            lbllastprice.Left = 150;
            lbllastprice.Text = "آخرین قیمت :";
            lastp += 1;
            return lbllastprice;
        }
        public System.Windows.Forms.Label Endprice()
        {
            System.Windows.Forms.Label lblendprice = new System.Windows.Forms.Label();
            lblendprice.Name = "lblEndprice" + endp;
            this.Controls.Add(lblendprice);
            lblendprice.Top = 85;
            lblendprice.Left = 150;
            lblendprice.Text = "قیمت پایانی :";
            lastp += 1;
            return lblendprice;
        }
        public System.Windows.Forms.Label AddDownRangeLabel()
        {
            System.Windows.Forms.Label DownRangeLabel = new System.Windows.Forms.Label();
            DownRangeLabel.Name = "lblTopRange" + LowRangeCounter;
            this.Controls.Add(DownRangeLabel);
            DownRangeLabel.Top = 35;
            DownRangeLabel.Left = 176;
            DownRangeLabel.Text = "حد ضرر : ";
            TopRangeCounter += 1;
            return DownRangeLabel;
        }
        public System.Windows.Forms.Label Stockvalue ( string Value = "0")
        {
            System.Windows.Forms.Label lblStockValue = new Label();
            lblStockValue.Name = "lblStockValue" + A;
            this.Controls.Add(lblStockValue);
            lblStockValue.Top = 35;
            lblStockValue.Left = 17;
            lblStockValue.Text = "دارایی :" + Value;
            return lblStockValue;
        }
        public System.Windows.Forms.TextBox Addtextbox (string name ,int num , int top, int left , string value)
        {
            System.Windows.Forms.TextBox NewTextbox = new System.Windows.Forms.TextBox();
            NewTextbox.Name = "name" + num;
            this.Controls.Add(NewTextbox);
            NewTextbox.Top = top;
            NewTextbox.Left = left;
            NewTextbox.Text = value;
            if (name == "txtlastprice")
            {
                lastprivetxt.Add(NewTextbox);
            }
            if (name == "txtendprice")
            {
                Endpricetxt.Add(NewTextbox);
            }
            return NewTextbox;
        }
        List<TextBox> Endpricetxt = new List<TextBox>();
        List<TextBox> lastprivetxt = new List<TextBox>();

        public System.Windows.Forms.Label AddID(string StockName)
        {
            System.Windows.Forms.Label ID = new System.Windows.Forms.Label();
            ID.Name = "lblTopRange" + IDCounter;
            this.Controls.Add(ID);
            ID.Top = 10;
            ID.Left = 15;
            ID.Text = "ID : " + StockName;
            IDCounter += 1;
            return ID;
        }
        public  System.Windows.Forms.Button AddDeleteButton()
        {
            System.Windows.Forms.Button NewDeleteButton = new System.Windows.Forms.Button();
            NewDeleteButton.Name = "DeleteButton" + B;
            NewDeleteButton.Click += new EventHandler(DeleteButton);
            this.Controls.Add(NewDeleteButton);
            NewDeleteButton.Top = 100;
            NewDeleteButton.Left = 15;
            NewDeleteButton.Text = "Delete";
            B += 1;
            return NewDeleteButton;
        }
        private void DeleteButton(object sender , EventArgs e)
        {
            FluctionControlForm frm = new FluctionControlForm();
            
            Button btn = (sender as Button);
            string name = btn.Name;
            name = name.Replace("DeleteButton", "");
            //Control[] controls = this.Controls.Find("Panel" + name, false);
            //Panel pnl = controls[0] as Panel;
            Panel pnl = PanelAdded[int.Parse(name)];
            this.Controls.Remove(pnl);
            Deletepanels.Add(int.Parse(name));
            DeletepanelData(IDlist[int.Parse(name)].ToString());
            //MessageBox.Show(btn.Name);
            //CounterDic.Remove(int.Parse(name));
            
            //this.Controls.Remove(pnl);
            //////foreach (Panel pnl in frm.Controls.Find("Panel" + name, true))
            //////{
            //////    pnl.Visible = false;
            //////    if (pnl.Name == "Panel" + name)
            //////    {
            //////        //this.Controls.Remove(pnl);
            //////        //pnl.Controls.Remove(pnl);
            //////        pnl.Visible = false;
            //////    }
            //////}

            //MessageBox.Show(name);
        }
        List<int> Deletepanels = new List<int>();

        private void FluctionControlForm_Load(object sender, EventArgs e)
        {
            SetComboboxData();
            LoadSavePanel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (A == 0)
            {
                //Do_Nothing
            }
            else
            {
                //for (int c = 0; c <= A; c++)
                //{
                //    foreach (int deleted in Deletepanels)
                //    {
                //        if (deleted == c)
                //        {
                //            //Do_nothing
                //        }
                //        else
                //        {
                //            long ID = IDlist[c];
                //            string[] data = receivepricedata(ID.ToString());
                //            TextBox txtEnd = Endpricetxt[c];
                //            TextBox txtLast = lastprivetxt[c];
                //            txtEnd.Text = "0";
                //            txtLast.Text = data[2];
                //        }
                //    }
                for (int c = 0; c < IDlist.Count; c++)
                {
                    long ID = IDlist[c];
                    string[] data = receivepricedata(ID.ToString());
                    TextBox txtEnd = Endpricetxt[c];
                    TextBox txtLast = lastprivetxt[c];
                    txtEnd.Text = data[3];
                    txtLast.Text = data[2];
                    int Urange = int.Parse(txtRangeUpList[c].Text);
                    int Drange = int.Parse(txtRangeDownList[c].Text);
                    int pirange = int.Parse(data[2]);
                    int len = (Urange - Drange);
                    int point = (pirange - Drange);
                    double Result = ((double)point / (double)len) * 100;
                    ProgressList[c].Value = Convert.ToInt32(Result);
                }

            }
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            //Application.DoEvents();
            ////--var url = "http://tsetmc.ir/Loader.aspx?ParTree=151311&i=44891482026867833";
            //var url = "http://www.tsetmc.com/tsev2/data/instinfodata.aspx?i=35425587644337450&c=27";
            //var page = GetPage(url);
            //string[] Array = page.Split(',');
            ////--var classId = "box6 h80";
            ////var regex = new Regex("<div class=\"" + classId + "\">\\s*(?<price>[^\\<\\s]*)\\s*</div>", RegexOptions.IgnoreCase);
            ////--var regex = new Regex("<td id=d04 class>\\s*(?<price>[^\\<\\s]*)\\s*</td>", RegexOptions.IgnoreCase);
            ////--var match = regex.Match(page);
            ////--MessageBox.Show(match.Groups["price"].Value);
            ////--MessageBox.Show(page);
            ////label1.Text = (match.Success) ? match.Groups["price"].Value : "Not found!";
            //findids();
            //for (int c=1 ; c<CounterDic.Count() ; c++)
            //{
            //    MessageBox.Show(CounterDic[c].ToString());
            //}
            //MessageBox.Show(CounterDic.Count().ToString());
            //for (int c = 0; c < Deletepanels.Count(); c++)
            //{
            //    MessageBox.Show(Deletepanels[c].ToString());
            //}
            //MessageBox.Show(IDlist.Count.ToString());
            //MessageBox.Show(DownRangeList[0]);
            //MessageBox.Show(txtRangeDownList[0].Text);
            LoadSavePanel();
        }


        private static string GetPage(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = new CookieContainer();
                request.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
                WebResponse wres = request.GetResponse();
                Stream s = wres.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string html = sr.ReadToEnd();
                return html;
            }
            catch
            {
                return "not connected";
            }
            //////var request = (HttpWebRequest)WebRequest.Create(url);
            //////request.CookieContainer = new CookieContainer();
            //--request.Proxy = WebRequest.DefaultWebProxy;
            //--request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
            //--request.ProtocolVersion = HttpVersion.Version10;
            //--request.Accept = "*/*";
            //--request.ContentType = "text/html";
            //--request.ContentLength = 0;
            //using (var response = (HttpWebResponse)request.GetResponse())
            //{
            //    var stream = response.GetResponseStream();
            //    if (stream == null)
            //    {
            //        return string.Empty;
            //    }
            //    using (var reader = new StreamReader(stream))
            //    {
            //        return reader.ReadToEnd();
            //    }
            //}
            //////request.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            //////WebResponse wres = request.GetResponse();
            //////Stream s = wres.GetResponseStream();
            //////StreamReader sr = new StreamReader(s);
            //////string html = sr.ReadToEnd();
            //////return html; 
        }
             

        private void txtRangeUp_Click(object sender, EventArgs e)
        {
            txtRangeUp.Text = "";
        }

        private void txtRangeDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtRangeDown_MouseClick(object sender, MouseEventArgs e)
        {
            txtRangeDown.Text = "";
        }

        private void txtRangeUp_MouseClick(object sender, MouseEventArgs e)
        {
            txtRangeUp.Text = "";
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //Panel newpanel = new Panel();
            //newpanel.BackColor = Color.Red;
            //newpanel.Dock = DockStyle.Top;
            //FluctionControlForm FCF = new FluctionControlForm();
            //int counter = FCF.Controls.OfType<Panel>().ToList().Count ;
            //string panelTag = "panel" + counter.ToString();
            //MessageBox.Show(panelTag);
            //newpanel.Name = panelTag;
            //this.Controls.Add(newpanel);
            //this.Controls.SetChildIndex(newpanel, 0);
            //Bunifu.Framework.UI.BunifuFlatButton deletebutton = new Bunifu.Framework.UI.BunifuFlatButton();
            //deletebutton.Location = new Point(4, 40);
            //deletebutton.Click += new EventHandler(deletebutton_Click);
            //newpanel.Controls.Add(deletebutton);
            ////Bunifu.Framework.UI.BunifuGauge FluctionRaneg = new Bunifu.Framework.UI.BunifuGauge();
            //FluctionRaneg.Dock = DockStyle.Right;
            ////this.Controls.SetChildIndex(panel2, 0);
            ////panel2.Controls.Add(FluctionRaneg);
            //-* AddNewTextBox();
            //-* addbunifugauge();
            AddFluctionPanel();
            //find_ID(cmbsearchID.Text);
            //SetComboboxData();
            //AddDeleteButton();
        }
        //private void deletebutton_Click(object sender ,EventArgs e)
        //{
        //    Bunifu.Framework.UI.BunifuFlatButton deletebutton = (sender as Bunifu.Framework.UI.BunifuFlatButton);
        //    FluctionControlForm FCF = new FluctionControlForm();
        //    //FCF.Controls.Remove(FCF.Controls.Find());
        //    int counter = FCF.Controls.OfType<Panel>().ToList().Count;
        //    MessageBox.Show(counter.ToString());
        //}
        public void SetComboboxData()
        {
            scm.CommandText = "select name from DataID";
            scm.Connection = scID;
            sda.SelectCommand = scm;
            ds.Clear();
            sda.Fill(ds, "T1");
            int count = ds.Tables[0].Rows.Count;
            for (int i = 1; i < count; i++)
            {
                cmbsearchID.Items.Add(ds.Tables[0].Rows[i][0]);
            }
            //cmbsearchID.DataBindings.Add("text", ds, "T1.Name");
            //string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", @"D:\Cadino_trade_App\cadino_trade\bin\Debug\Datafilelist.xls");
            //string query = String.Format("select * from [دیده بان بازار$]");
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet);
            //DataRow datarowdelete = dataSet.Tables[0].Rows[0];
            //datarowdelete.Delete();
            //dataSet.Tables[0].AcceptChanges();
            //DataTable dt = dataSet.Tables.Add();
            ////List<DataRow> list = dataSet.Tables[0].AsEnumerable().ToList();
            ////MessageBox.Show(list.ToString());
            ////cmbsearchID.Items.Add(dataSet.Tables[0].Rows[3][10]);
            //int count = dataSet.Tables[0].Rows.Count;
            //for (int i = 1; i < count; i++)
            //{
            //    cmbsearchID.Items.Add(dataSet.Tables[0].Rows[i][0]);
            //}
            ////cmbsearchID.Items.Add(dataSet.Tables[0].Rows[1][0]);
        }
        public string find_ID(string Name)
        {
            scm.CommandText = "select id from DataID where Name = '" + Name+"'";
            scm.Connection = scID;
            scm.Connection.Close();
            scm.Connection.Open();
            sda.SelectCommand = scm;
            string ID = scm.ExecuteScalar().ToString();
            return ID;
        }
        public string[] receivepricedata(string ID)
        {        
            
            Application.DoEvents();
            //--var url = "http://tsetmc.ir/Loader.aspx?ParTree=151311&i=44891482026867833";
            var url = "http://www.tsetmc.com/tsev2/data/instinfodata.aspx?i="+ID+"&c=27";
            var page = GetPage(url);
            if(page=="not connected")
            {
                string[] n = { "0", "0", "0", "0", "0", "0" };
                return n;
            }
            else
            {
                string[] Array = page.Split(',');
                return Array;
            }
            //////string[] Array = page.Split(',');
            //////return Array;
            //--var classId = "box6 h80";
            //var regex = new Regex("<div class=\"" + classId + "\">\\s*(?<price>[^\\<\\s]*)\\s*</div>", RegexOptions.IgnoreCase);
            //--var regex = new Regex("<td id=d04 class>\\s*(?<price>[^\\<\\s]*)\\s*</td>", RegexOptions.IgnoreCase);
            //--var match = regex.Match(page);
            //--MessageBox.Show(match.Groups["price"].Value);
            //--MessageBox.Show(page);
            //label1.Text = (match.Success) ? match.Groups["price"].Value : "Not found!";
            //Regex rx = new Regex(@"InstrumentID='([\w\d]*)|$',");
        }    
        public void findids()
        {
            Application.DoEvents();
            var url = "http://tsetmc.com/tsev2/data/MarketWatchPlus.aspx";
            var input = GetPage(url);
            input.ToString();
            Regex rx = new Regex(@"\d{15,20}");
            MatchCollection matchauthors = rx.Matches(input);
            MessageBox.Show(matchauthors[3].Value.ToString());
            //var urlname = "";
            //Regex rxname = new Regex(@"LVal18AFC='([\D]*)',");
            //MatchCollection matchname = rxname.Matches(input);
            //MessageBox.Show(matchname[3].Value.ToString());

        }
        public void SavepanelData (string ID , string Name , string RangeUp , string RangeDown)
        {
            scm.Connection = sc;
            scm.CommandText = ("select count(*) from PanelInfo where StockID like '" + ID + "'");
            scm.Connection.Close();
            scm.Connection.Open();
            sda.SelectCommand = scm;
            string Result = scm.ExecuteScalar().ToString();
            int IDCounter = Convert.ToInt32(Result);
            if(IDCounter == 0)
            {
                scm.CommandText = ("insert into PanelInfo values ('" + RangeUp + "','" + RangeDown + "','" + ID + "','"+ Name +"','0')");
                scm.ExecuteNonQuery();
            }
        }
        public void DeletepanelData(string ID)
        {
            scm.Connection = sc;
            scm.CommandText = ("delete from PanelInfo where StockID = '"+ID+"'");
            scm.Connection.Close();
            scm.Connection.Open();
            scm.ExecuteNonQuery();
        }
        public void LoadSavePanel ()
        {
            //scm.CommandText = ("select count(*) from PanelInfo");
            //scm.Connection.Close();
            //scm.Connection.Open();
            //int counter = Convert.ToInt32(scm.ExecuteScalar().ToString());           
            //if(counter>0)
            //{

            //}
            scm.CommandText = ("select * from PanelInfo");
            scm.Connection = sc;
            sda.SelectCommand = scm;
            dt.Clear();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                //name = dr["StockName"].ToString();
                //MessageBox.Show(name);
                System.Windows.Forms.Panel FluctionPanel = new System.Windows.Forms.Panel();
                FluctionPanel.Name = "Panel" + A;
                FluctionPanel.Dock = DockStyle.Top;
                this.Controls.Add(FluctionPanel);
                this.Controls.SetChildIndex(FluctionPanel, 0);
                FluctionPanel.Controls.Add(AddDeleteButton());
                //FluctionPanel.Controls.Add(addbunifugauge());
                FluctionPanel.Controls.Add(AddTopRangeLabel());
                FluctionPanel.Controls.Add(AddDownRangeLabel());
                FluctionPanel.Controls.Add(lastprice());
                FluctionPanel.Controls.Add(Endprice());
                FluctionPanel.Controls.Add(AddID(dr["StockName"].ToString()));
                string FID = find_ID(dr["StockName"].ToString());
                string[] data = receivepricedata(FID);
                FluctionPanel.Controls.Add(Addtextbox("txttuprange", txtnumup, 8, 300, dr["RangeUp"].ToString()));
                txtRangeUpList.Add(Addtextbox("txttuprange", txtnumup, 8, 300, dr["RangeUp"].ToString()));
                txtnumup += 1;
                FluctionPanel.Controls.Add(Addtextbox("txtdownrange", txtnumup, 33, 300, dr["RaneDown"].ToString()));
                txtRangeDownList.Add(Addtextbox("txtdownrange", txtnumup, 33, 300, dr["RaneDown"].ToString()));
                txtnumdown += 1;
                FluctionPanel.Controls.Add(Addtextbox("txtlastprice", txtnumup, 58, 300, data[2]));
                txtnumlastprice += 1;
                FluctionPanel.Controls.Add(Addtextbox("txtendprice", txtnumup, 83, 300, data[3]));
                txtnumendprice += 1;
                FluctionPanel.Controls.Add(addbunifugauge(Int32.Parse(dr["RaneDown"].ToString()), Int32.Parse(dr["RangeUp"].ToString()), Int32.Parse(data[2])));
                FluctionPanel.BackColor = Color.FromArgb(18, 18, 18);
                FluctionPanel.BorderStyle = BorderStyle.FixedSingle;
                FluctionPanel.Height = 130;
                PanelAdded.Add(FluctionPanel);
                IDlist.Add(Int64.Parse(FID));
                SavepanelData(FID, cmbsearchID.Text, txtRangeUp.Text, txtRangeDown.Text);
            }
            
        }
    }
}
