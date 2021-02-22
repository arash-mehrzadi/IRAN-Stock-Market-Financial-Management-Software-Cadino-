using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading;
using System.IO;

namespace cadino_trade
{    
    public partial class Form1 : Form
    {
        private IconButton currentbtn;
        private Panel leftborderbtn;
        private Form currentChildForm;
        public Form1()
        {
            InitializeComponent();
            leftborderbtn = new Panel();
            leftborderbtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftborderbtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //WebClient client;
        //private void btnDownload_Click(object sender, EventArgs e)
        //{
        //    //Run download file with multiple thread
        //    string url = txtUrl.Text;
        //    if (!string.IsNullOrEmpty(url))
        //    {
        //        Thread thread = new Thread(() =>
        //        {
        //            Uri uri = new Uri(url);
        //            string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
        //            client.DownloadFileAsync(uri, Application.StartupPath + "/" + fileName);
        //        });
        //        thread.Start();
        //    }
        //}
        //private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //    MessageBox.Show("Download complete !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    //Update progress bar & label
        //    Invoke(new MethodInvoker(delegate ()
        //    {
        //        progressBar.Minimum = 0;
        //        double receive = double.Parse(e.BytesReceived.ToString());
        //        double total = double.Parse(e.TotalBytesToReceive.ToString());
        //        double percentage = receive / total * 100;
        //        lblStatus.Text = $"Downloaded {string.Format("{0:0.##}", percentage)}%";
        //        progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        //    }));
        //}
        public struct RGBColors
        {
            public static Color color1 = Color.Chartreuse;
            public static Color color2 = Color.Gold;
            public static Color color3 = Color.OrangeRed;
            public static Color color4 = Color.Orchid;
            public static Color color5 = Color.CadetBlue;
            public static Color color6 = Color.MediumSpringGreen;
            public static Color color7 = Color.MediumVioletRed;

        }
        private void ActiveButton(object senderbtn, Color color)
        {
            if(senderbtn != null)
            {
                Disablebutton();
                currentbtn = (IconButton)senderbtn;
                currentbtn.BackColor = Color.FromArgb(18,18,18);
                currentbtn.ForeColor = color;
                currentbtn.TextAlign = ContentAlignment.MiddleCenter;
                currentbtn.IconColor = color;
                currentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentbtn.ImageAlign = ContentAlignment.MiddleRight;
                leftborderbtn.BackColor = color;
                leftborderbtn.Location = new Point(0, currentbtn.Location.Y);
                leftborderbtn.Visible = true;
                leftborderbtn.BringToFront();
            }
        }
        private void Disablebutton()
        {
            if(currentbtn != null)
            {
                currentbtn.BackColor = Color.FromArgb(18,18,18);
                currentbtn.ForeColor = Color.White;
                currentbtn.TextAlign = ContentAlignment.MiddleRight;
                currentbtn.IconColor = Color.White;
                currentbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentbtn.ImageAlign = ContentAlignment.MiddleRight;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (childForm == new FluctionControlForm())
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                }
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                paneldesktop.Controls.Add(childForm);
                paneldesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void FluctutionControl_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new FluctionControlForm());
        }

        private void Repo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
        }

        private void ClassicView_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            OpenChildForm(new FormFluction());
        }

        private void TechnicalView_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
        }

        private void Accounting_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
        }

        private void UserAssets_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
            OpenChildForm(new FrmSetting());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormLoad frmload = new FormLoad();
            frmload.ShowDialog();
            //bunifuFormFadeTransition1.ShowAsyc(this);
            //panelMenu.Visible = false;
            mainbarpanel.Dock = DockStyle.Top;
            //--Disble--//DownloadDataset();
            ////////////try
            ////////////{
            ////////////    HttpWebRequest request = WebRequest.Create(@"http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0") as HttpWebRequest;
            ////////////    request.AutomaticDecompression = DecompressionMethods.GZip;
            ////////////    using (WebResponse response = request.GetResponse())
            ////////////    {
            ////////////        using (Stream fs = File.Create("Datafilelist.xls"))
            ////////////        {
            ////////////            response.GetResponseStream().CopyTo(fs);
            ////////////        }
            ////////////    }
            ////////////}
            ////////////catch
            ////////////{
            ////////////    MessageBox.Show("cant acces to server!");
            ////////////}
            //HttpWebRequest request = WebRequest.Create(@"http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0") as HttpWebRequest;
            //request.AutomaticDecompression = DecompressionMethods.GZip;
            //using (WebResponse response = request.GetResponse())
            //{
            //    using (Stream fs = File.Create("excelFile.xlsx"))
            //    {
            //        response.GetResponseStream().CopyTo(fs);
            //    }
            //}
            //client = new WebClient();
            //client.DownloadProgressChanged += Client_DownloadProgressChanged;
            //client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        public void DownloadDataset()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(@"http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0") as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream fs = File.Create("Datafilelist.xls"))
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
        private void menucontrol_Click(object sender, EventArgs e)
        {
            if(menucontrol.IconChar == IconChar.Bars )
            {
                
                //panelMenu.Visible = true;
                //mainbarpanel.Dock = DockStyle.Top;
                menucontrol.IconChar = IconChar.AngleDoubleRight;
                btnSetting.Text = "تنظیمات";
                btnPocket.Text = "دارایی من";
                btnCalculation.Text = "حسابداری";
                btnTechnicalMonitor.Text = "دیده بان تکنیکال";
                btnClassicMonitor.Text = "دیده بان کلاسیک";
                btnReport.Text = "گزارش";
                btnFlunctionControl.Text = "کنترل نوسان";
                panelMenu.Size = new Size(189, 443);
                //panelMenu.Location = new Point(628, 26);
            }
            else
            {
                //panelMenu.Visible = false;
                mainbarpanel.Dock = DockStyle.Top;
                menucontrol.IconChar = IconChar.Bars;
                //iconButton2.Text = "";
                btnSetting.Text = "";
                btnPocket.Text = "";
                btnCalculation.Text = "";
                btnTechnicalMonitor.Text = "";
                btnClassicMonitor.Text = "";
                btnReport.Text = "";
                btnFlunctionControl.Text = "";
                panelMenu.Size = new Size(74, 443);
                //panelMenu.Location = new Point(741, 26);
            }
        }
        [DllImport("user32.DLL")]//, EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL")]//, EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void mainbarpanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void WebsiteLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.arashmehrzadi.com");
        }

        private void InstagramLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/arash_mehrzadi/");
            
        }

        private void EmailLink_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email : mehrzadiarash@gmail.com");
        }
    }
}
