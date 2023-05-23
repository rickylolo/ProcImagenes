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

        private bool isFormClosing = false;


        CascadeClassifier faceCascade = new CascadeClassifier("C:/Users/ricky/Documents/GitHub/ProcImagenes/ProyectoProcImgs/haarcascade_frontalface_alt2.xml");
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
                    myWebCam.WaitForStop();
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
            if (myWebCam != null && myWebCam.IsRunning)
            {

               Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> imageByte = new Image<Bgr, byte>(bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            byte[] bytes = new byte[bitmapData.Stride * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, bytes, 0, bytes.Length);

            imageByte.Bytes = bytes;
            bitmap.UnlockBits(bitmapData);

            Rectangle[] faces = faceCascade.DetectMultiScale(imageByte, 1.3, 5);

            foreach (Rectangle face in faces)
            {
                imageByte.Draw(face, new Bgr(Color.Red), 2);

            }

            Bitmap bitmapOutput = imageByte.ToBitmap();
           

          
            int numFaces = faces.Length;

                // Dibujar el número de rostros detectados
                using (Graphics graphics = Graphics.FromImage(bitmapOutput))
                {
                    using (Font font = new Font("Arial", 10, FontStyle.Bold))
                    {
                        string text = "Rostros detectados: " + numFaces;
                        Size textSize = TextRenderer.MeasureText(text, font);
                        int x = bitmapOutput.Width - textSize.Width - 10;
                        int y = bitmapOutput.Height - textSize.Height - 10;

                        graphics.DrawString(text, font, Brushes.White, x, y);
                    }
                }

                camera_pb.Image = bitmapOutput;
                bitmap.Dispose();
                imageByte.Dispose();

              

            }


        }

        private void FaceRecog_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeWebCam();

        }

        private void FaceRecog_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeWebCam();


        }
    }
}
