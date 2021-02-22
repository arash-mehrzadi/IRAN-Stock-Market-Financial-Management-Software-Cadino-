using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadino_trade
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            introanimation.Enabled = false;
            btnEnter.Visible = true;
            btnExit.Visible = true;
            timer1.Enabled = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            for(int a=0;a<=100;a++)
            {
                System.Threading.Thread.Sleep(10);
                //this.Opacity = 100 - a;
                this.Height = 352 - (3*a);
                //this.Width = 330 - (3 * a);
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //FormLoad frm = new FormLoad();
            //bunifuFormFadeTransition1.Delay = 2000;
            //bunifuFormFadeTransition1.HideAsyc(frm, true);
            Application.Exit();
        }
    }
}
