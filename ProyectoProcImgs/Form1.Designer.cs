
namespace ProyectoProcImgs
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btn_Home = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnCloseChildForm);
            this.panelMenu.Controls.Add(this.lblTitle);
            this.panelMenu.Controls.Add(this.btn_Home);
            this.panelMenu.Controls.Add(this.btnHistogram);
            this.panelMenu.Controls.Add(this.btnFiltros);
            this.panelMenu.Controls.Add(this.btnCamera);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1092, 77);
            this.panelMenu.TabIndex = 0;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseChildForm.BackgroundImage")));
            this.btnCloseChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseChildForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCloseChildForm.Location = new System.Drawing.Point(932, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(80, 77);
            this.btnCloseChildForm.TabIndex = 6;
            this.btnCloseChildForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCloseChildForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(693, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 31);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Inicio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Home
            // 
            this.btn_Home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Home.BackgroundImage")));
            this.btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Home.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Home.FlatAppearance.BorderSize = 0;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Home.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Home.Location = new System.Drawing.Point(1012, 0);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(80, 77);
            this.btn_Home.TabIndex = 4;
            this.btn_Home.Text = "Inicio";
            this.btn_Home.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Home.UseVisualStyleBackColor = true;
            // 
            // btnHistogram
            // 
            this.btnHistogram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistogram.BackgroundImage")));
            this.btnHistogram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHistogram.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHistogram.FlatAppearance.BorderSize = 0;
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistogram.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHistogram.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHistogram.Location = new System.Drawing.Point(384, 0);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(124, 77);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histograma";
            this.btnHistogram.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistogram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click_1);
            // 
            // btnFiltros
            // 
            this.btnFiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltros.BackgroundImage")));
            this.btnFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltros.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFiltros.FlatAppearance.BorderSize = 0;
            this.btnFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltros.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFiltros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFiltros.Location = new System.Drawing.Point(260, 0);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(124, 77);
            this.btnFiltros.TabIndex = 2;
            this.btnFiltros.Text = "Filtros";
            this.btnFiltros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFiltros.UseVisualStyleBackColor = true;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCamera.BackgroundImage")));
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCamera.Location = new System.Drawing.Point(136, 0);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(124, 77);
            this.btnCamera.TabIndex = 1;
            this.btnCamera.Text = "Cámara";
            this.btnCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click_1);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(136, 77);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "MultiCam Media";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(0, 77);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1092, 573);
            this.panelDesktopPane.TabIndex = 1;
            this.panelDesktopPane.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPane_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1092, 650);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelMenu);
            this.Name = "FormMain";
            this.Text = "MultiCam Media";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button btnCloseChildForm;
    }
}

