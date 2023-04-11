using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ProyectoProcImgs
{
    public partial class FaceRecog : Form
    {
        private bool availableDevices;
        private FilterInfoCollection myDevices;
        private VideoCaptureDevice myWebCam;




        CascadeClassifier faceCascade = new CascadeClassifier("C:/Users/ricky/source/repos/ProyectoProcImgs/ProcImagenes/ProyectoProcImgs/haarcascade_frontalface_alt_tree.xml");
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
                devicesCB.Text = myDevices[0].Name.ToString();
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

            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> imageByte = new Image<Bgr, byte>(bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            byte[] bytes = new byte[bitmapData.Stride * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, bytes, 0, bytes.Length);

            imageByte.Bytes = bytes;
            bitmap.UnlockBits(bitmapData);

            Rectangle[] faces = faceCascade.DetectMultiScale(imageByte, 1.1, 0);

            foreach (Rectangle face in faces)
            {
                imageByte.Draw(face, new Bgr(Color.Blue), 2);
            }

            Bitmap bitmapOutput = imageByte.ToBitmap();
            camera_pb.Image = bitmapOutput;

            int numFaces = faces.Length;
            if (lbl_rostros.InvokeRequired)
            {
                lbl_rostros.Invoke(new Action(() =>
                {
                    lbl_rostros.Text = numFaces.ToString();
                }));
            }

          
            bitmap.Dispose();
            imageByte.Dispose();
         



        }

        private void FaceRecog_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeWebCam();
        }

   
    }
}
