namespace cadino_trade
{
    partial class FluctionControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FluctionControlForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRangeDown = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtRangeUp = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnAdd = new Bunifu.Framework.UI.BunifuThinButton2();
            this.cmbsearchID = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.txtRangeDown);
            this.panel1.Controls.Add(this.txtRangeUp);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbsearchID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 78);
            this.panel1.TabIndex = 0;
            // 
            // txtRangeDown
            // 
            this.txtRangeDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRangeDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRangeDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRangeDown.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRangeDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRangeDown.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtRangeDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(4)))), ((int)(((byte)(41)))));
            this.txtRangeDown.HintForeColor = System.Drawing.Color.Empty;
            this.txtRangeDown.HintText = "";
            this.txtRangeDown.isPassword = false;
            this.txtRangeDown.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtRangeDown.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(4)))), ((int)(((byte)(41)))));
            this.txtRangeDown.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtRangeDown.LineThickness = 3;
            this.txtRangeDown.Location = new System.Drawing.Point(221, 13);
            this.txtRangeDown.Margin = new System.Windows.Forms.Padding(4);
            this.txtRangeDown.MaxLength = 32767;
            this.txtRangeDown.Name = "txtRangeDown";
            this.txtRangeDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRangeDown.Size = new System.Drawing.Size(115, 35);
            this.txtRangeDown.TabIndex = 4;
            this.txtRangeDown.Text = "حد ضرر";
            this.txtRangeDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRangeDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangeDown_KeyPress);
            this.txtRangeDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRangeDown_MouseClick);
            // 
            // txtRangeUp
            // 
            this.txtRangeUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRangeUp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRangeUp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRangeUp.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRangeUp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRangeUp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtRangeUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(173)))), ((int)(((byte)(105)))));
            this.txtRangeUp.HintForeColor = System.Drawing.Color.Empty;
            this.txtRangeUp.HintText = "";
            this.txtRangeUp.isPassword = false;
            this.txtRangeUp.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtRangeUp.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(173)))), ((int)(((byte)(105)))));
            this.txtRangeUp.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtRangeUp.LineThickness = 3;
            this.txtRangeUp.Location = new System.Drawing.Point(344, 12);
            this.txtRangeUp.Margin = new System.Windows.Forms.Padding(4);
            this.txtRangeUp.MaxLength = 32767;
            this.txtRangeUp.Name = "txtRangeUp";
            this.txtRangeUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRangeUp.Size = new System.Drawing.Size(114, 35);
            this.txtRangeUp.TabIndex = 3;
            this.txtRangeUp.Text = "حد سود";
            this.txtRangeUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRangeUp.Click += new System.EventHandler(this.txtRangeUp_Click);
            this.txtRangeUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangeDown_KeyPress);
            this.txtRangeUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRangeUp_MouseClick);
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveBorderThickness = 1;
            this.btnAdd.ActiveCornerRadius = 20;
            this.btnAdd.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.btnAdd.ActiveForecolor = System.Drawing.Color.White;
            this.btnAdd.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.ButtonText = "افزودن";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.btnAdd.IdleBorderThickness = 1;
            this.btnAdd.IdleCornerRadius = 20;
            this.btnAdd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnAdd.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.btnAdd.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.btnAdd.Location = new System.Drawing.Point(5, 39);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // cmbsearchID
            // 
            this.cmbsearchID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbsearchID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.cmbsearchID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbsearchID.ForeColor = System.Drawing.Color.White;
            this.cmbsearchID.FormattingEnabled = true;
            this.cmbsearchID.Location = new System.Drawing.Point(465, 23);
            this.cmbsearchID.Name = "cmbsearchID";
            this.cmbsearchID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbsearchID.Size = new System.Drawing.Size(246, 24);
            this.cmbsearchID.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FluctionControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(740, 325);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FluctionControlForm";
            this.Text = "FluctionControlForm_M";
            this.Load += new System.EventHandler(this.FluctionControlForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbsearchID;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAdd;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtRangeDown;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtRangeUp;
        private System.Windows.Forms.Timer timer1;
    }
}