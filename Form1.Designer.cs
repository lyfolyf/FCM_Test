
namespace FCM_Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSocket = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSerPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCam = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.加载图片 = new System.Windows.Forms.ToolStripButton();
            this.上一张 = new System.Windows.Forms.ToolStripButton();
            this.下一张 = new System.Windows.Forms.ToolStripButton();
            this.ComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.运行 = new System.Windows.Forms.ToolStripButton();
            this.AI加载 = new System.Windows.Forms.ToolStripButton();
            this.AI运行 = new System.Windows.Forms.ToolStripButton();
            this.hW = new HalconDotNet.HWindowControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Y";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "X";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "面积(m^2)";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "状态";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // tsslTime
            // 
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(2, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslSocket
            // 
            this.tsslSocket.Name = "tsslSocket";
            this.tsslSocket.Size = new System.Drawing.Size(84, 20);
            this.tsslSocket.Text = "上位机通信";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // tsslSerPort
            // 
            this.tsslSerPort.Name = "tsslSerPort";
            this.tsslSerPort.Size = new System.Drawing.Size(69, 20);
            this.tsslSerPort.Text = "串口状态";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tsslCam
            // 
            this.tsslCam.Name = "tsslCam";
            this.tsslCam.Size = new System.Drawing.Size(69, 20);
            this.tsslCam.Text = "相机状态";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCam,
            this.toolStripStatusLabel2,
            this.tsslSerPort,
            this.toolStripStatusLabel4,
            this.tsslSocket,
            this.toolStripStatusLabel1,
            this.tsslTime});
            this.statusStrip1.Location = new System.Drawing.Point(-642, 767);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(270, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(204, 434);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(204, 325);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载图片,
            this.上一张,
            this.下一张,
            this.ComboBox1,
            this.运行,
            this.AI加载,
            this.AI运行});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1231, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 加载图片
            // 
            this.加载图片.Image = ((System.Drawing.Image)(resources.GetObject("加载图片.Image")));
            this.加载图片.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.加载图片.Name = "加载图片";
            this.加载图片.Size = new System.Drawing.Size(93, 25);
            this.加载图片.Text = "图片加载";
            this.加载图片.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // 上一张
            // 
            this.上一张.Image = ((System.Drawing.Image)(resources.GetObject("上一张.Image")));
            this.上一张.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.上一张.Name = "上一张";
            this.上一张.Size = new System.Drawing.Size(78, 25);
            this.上一张.Text = "上一张";
            this.上一张.Click += new System.EventHandler(this.上一张_Click);
            // 
            // 下一张
            // 
            this.下一张.Image = ((System.Drawing.Image)(resources.GetObject("下一张.Image")));
            this.下一张.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.下一张.Name = "下一张";
            this.下一张.Size = new System.Drawing.Size(78, 25);
            this.下一张.Text = "下一张";
            this.下一张.Click += new System.EventHandler(this.下一张_Click);
            // 
            // ComboBox1
            // 
            this.ComboBox1.Items.AddRange(new object[] {
            "FCMdamage",
            "FCMdeviation",
            "FCMdiscoloration"});
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(121, 28);
            this.ComboBox1.Click += new System.EventHandler(this.ComboBox1_Click);
            // 
            // 运行
            // 
            this.运行.Image = ((System.Drawing.Image)(resources.GetObject("运行.Image")));
            this.运行.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.运行.Name = "运行";
            this.运行.Size = new System.Drawing.Size(63, 25);
            this.运行.Text = "运行";
            this.运行.Click += new System.EventHandler(this.运行_Click);
            // 
            // AI加载
            // 
            this.AI加载.Image = ((System.Drawing.Image)(resources.GetObject("AI加载.Image")));
            this.AI加载.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AI加载.Name = "AI加载";
            this.AI加载.Size = new System.Drawing.Size(78, 25);
            this.AI加载.Text = "AI加载";
            this.AI加载.Click += new System.EventHandler(this.AI加载_Click);
            // 
            // AI运行
            // 
            this.AI运行.Image = ((System.Drawing.Image)(resources.GetObject("AI运行.Image")));
            this.AI运行.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AI运行.Name = "AI运行";
            this.AI运行.Size = new System.Drawing.Size(48, 25);
            this.AI运行.Text = "AI";
            this.AI运行.Click += new System.EventHandler(this.AI运行_Click);
            // 
            // hW
            // 
            this.hW.BackColor = System.Drawing.Color.Black;
            this.hW.BorderColor = System.Drawing.Color.Black;
            this.hW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW.Location = new System.Drawing.Point(0, 0);
            this.hW.Margin = new System.Windows.Forms.Padding(4);
            this.hW.Name = "hW";
            this.hW.Size = new System.Drawing.Size(1023, 763);
            this.hW.TabIndex = 1;
            this.hW.WindowSize = new System.Drawing.Size(1023, 763);
            this.hW.Resize += new System.EventHandler(this.hW_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hW);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1231, 763);
            this.splitContainer1.SplitterDistance = 1023;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbLog);
            this.splitContainer2.Size = new System.Drawing.Size(204, 763);
            this.splitContainer2.SplitterDistance = 434;
            this.splitContainer2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 791);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "FCM/BCM缺陷检测";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslSocket;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsslSerPort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 加载图片;
        private System.Windows.Forms.ToolStripButton 上一张;
        private System.Windows.Forms.ToolStripButton 下一张;
        private System.Windows.Forms.ToolStripButton 运行;
        private System.Windows.Forms.ToolStripButton AI加载;
        private System.Windows.Forms.ToolStripButton AI运行;
        private HalconDotNet.HWindowControl hW;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripComboBox ComboBox1;
    }
}

