
namespace ProyectoProcImgs
{
    partial class FaceRecog
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
            this.label1 = new System.Windows.Forms.Label();
            this.camera_pb = new System.Windows.Forms.PictureBox();
            this.devicesCB = new System.Windows.Forms.ComboBox();
            this.chooseWB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.camera_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(593, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 28);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reconocimiento Facial";
            // 
            // camera_pb
            // 
            this.camera_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camera_pb.Location = new System.Drawing.Point(53, 57);
            this.camera_pb.Name = "camera_pb";
            this.camera_pb.Size = new System.Drawing.Size(1334, 551);
            this.camera_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.camera_pb.TabIndex = 17;
            this.camera_pb.TabStop = false;
            // 
            // devicesCB
            // 
            this.devicesCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesCB.FormattingEnabled = true;
            this.devicesCB.Location = new System.Drawing.Point(1052, 643);
            this.devicesCB.Name = "devicesCB";
            this.devicesCB.Size = new System.Drawing.Size(279, 23);
            this.devicesCB.TabIndex = 18;
            // 
            // chooseWB
            // 
            this.chooseWB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseWB.Location = new System.Drawing.Point(971, 643);
            this.chooseWB.Name = "chooseWB";
            this.chooseWB.Size = new System.Drawing.Size(75, 23);
            this.chooseWB.TabIndex = 19;
            this.chooseWB.Text = "Aceptar";
            this.chooseWB.UseVisualStyleBackColor = true;
            this.chooseWB.Click += new System.EventHandler(this.chooseWB_Click);
            // 
            // FaceRecog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 720);
            this.Controls.Add(this.chooseWB);
            this.Controls.Add(this.devicesCB);
            this.Controls.Add(this.camera_pb);
            this.Controls.Add(this.label1);
            this.Name = "FaceRecog";
            this.Text = "FaceRecog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FaceRecog_FormClosed);
            this.Load += new System.EventHandler(this.FaceRecog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camera_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox camera_pb;
        private System.Windows.Forms.ComboBox devicesCB;
        private System.Windows.Forms.Button chooseWB;
    }
}