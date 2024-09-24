namespace QLCHDT
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl = new Sunny.UI.UITabControl();
            this.avaNhanVien = new Sunny.UI.UIAvatar();
            this.lblTenDangNhap = new Sunny.UI.UILabel();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Header.Controls.Add(this.uiImageButton1);
            this.Header.Controls.Add(this.lblTenDangNhap);
            this.Header.Controls.Add(this.avaNhanVien);
            this.Header.FillColor = System.Drawing.Color.Transparent;
            this.Header.FillColor2 = System.Drawing.Color.Transparent;
            this.Header.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(0, 40);
            this.Header.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.Header.Size = new System.Drawing.Size(1151, 94);
            // 
            // Aside
            // 
            this.Aside.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aside.ForeColor = System.Drawing.Color.White;
            this.Aside.Location = new System.Drawing.Point(0, 134);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.ScrollBarColor = System.Drawing.Color.Gainsboro;
            this.Aside.SelectedColor = System.Drawing.Color.Black;
            this.Aside.SelectedColor2 = System.Drawing.Color.SlateGray;
            this.Aside.SelectedForeColor = System.Drawing.Color.LightSkyBlue;
            this.Aside.SelectedHighColor = System.Drawing.Color.LightSkyBlue;
            this.Aside.Size = new System.Drawing.Size(377, 470);
            this.Aside.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Aside_NodeMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Verdana", 12F);
            this.tabControl.ItemSize = new System.Drawing.Size(150, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.MainPage = "";
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1151, 564);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            this.tabControl.TipsFont = new System.Drawing.Font("Verdana", 9F);
            // 
            // avaNhanVien
            // 
            this.avaNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.avaNhanVien.ContextMenuStrip = this.contextMenuStrip1;
            this.avaNhanVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.avaNhanVien.FillColor = System.Drawing.Color.Transparent;
            this.avaNhanVien.Font = new System.Drawing.Font("Verdana", 12F);
            this.avaNhanVien.ForeColor = System.Drawing.Color.RoyalBlue;
            this.avaNhanVien.Location = new System.Drawing.Point(1076, 0);
            this.avaNhanVien.MinimumSize = new System.Drawing.Size(1, 1);
            this.avaNhanVien.Name = "avaNhanVien";
            this.avaNhanVien.Size = new System.Drawing.Size(60, 79);
            this.avaNhanVien.TabIndex = 0;
            this.avaNhanVien.Text = "uiAvatar1";
            this.avaNhanVien.Click += new System.EventHandler(this.avaNhanVien_Click);
            this.avaNhanVien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.avaNhanVien_MouseClick);
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.White;
            this.lblTenDangNhap.Location = new System.Drawing.Point(594, 0);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(482, 79);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Xin chào!";
            this.lblTenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiImageButton1.Font = new System.Drawing.Font("Verdana", 12F);
            this.uiImageButton1.Image = global::QLCHDT.Properties.Resources.logo2;
            this.uiImageButton1.Location = new System.Drawing.Point(15, 0);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(96, 79);
            this.uiImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiImageButton1.TabIndex = 2;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = null;
            this.uiImageButton1.Click += new System.EventHandler(this.uiImageButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 37);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1151, 604);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.RectColor = System.Drawing.Color.DarkOrange;
            this.Text = "CỬA HÀNG ĐIỆN TỬ";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.Color.CornflowerBlue;
            this.TitleFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleHeight = 40;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 1151, 604);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITabControl tabControl;
        private Sunny.UI.UIAvatar avaNhanVien;
        private Sunny.UI.UILabel lblTenDangNhap;
        private Sunny.UI.UIImageButton uiImageButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

