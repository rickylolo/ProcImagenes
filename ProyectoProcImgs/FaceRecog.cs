using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace ProyectoProcImgs
{
    public partial class FaceRecog : Form
    {
        private bool availableDevices;
        private FilterInfoCollection myDevices;
        private VideoCaptureDevice myWebCam;

        public FaceRecog()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
         
        }
        private void FaceRecog_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadDevices();
        }

        public void LoadDevices()
        {
            myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(myDevices.Count > 0)
            {
                availableDevices = true;
                for (int i= 0; i < myDevices.Count; i++)           
                    devicesCB.Items.Add(myDevices[i].Name.ToString());
                devicesCB.Text = myDevices[0].ToString();
            }
            else
            {
                availableDevices = false;
            }
        }

        public void closeWebCam()
        {
            if(myWebCam!=null && myWebCam.IsRunning)
            {
                myWebCam.SignalToStop();
                myWebCam = null;
            }
        }

        private void chooseWB_Click(object sender, EventArgs e)
        {
            closeWebCam();
            int i = devicesCB.SelectedIndex;
            string videoName = myDevices[i].MonikerString;
            myWebCam = new VideoCaptureDevice(videoName);
            myWebCam.NewFrame += new NewFrameEventHandler(Capturing);
            myWebCam.Start();
        }

        private void Capturing(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            camera_pb.Image = image;
        }

        private void FaceRecog_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeWebCam();
        }
    }
}
