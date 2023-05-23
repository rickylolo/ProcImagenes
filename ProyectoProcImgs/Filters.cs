
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ProyectoProcImgs
{
    public partial class Filters : Form
    {

        bool isImagen = true;

        public Filters()
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
            label2.ForeColor = ThemeColor.PrimaryColor;
        }
        private void Filters_Load(object sender, EventArgs e)
        {
            LoadTheme();
            CargarFiltros();
        }


        // SELECCIONAR FILTRO
        private void button3_Click(object sender, EventArgs e)
        {
            switch (cmbFiltros.SelectedIndex)
            {
                case 0: // Blanco y Negro
                    if (isImagen)
                    {
                        if (pictureBox1.Image != null)
                        {
                            Bitmap bitmap = new Bitmap(pictureBox1.Image);
                            pictureBox2.Image = AplicarFiltroBlancoYNegro(bitmap);
                        }
                    }
                    else
                    {

                    }
                    break;
                case 1: // Negativo
                    if (isImagen)
                    {
                        if (pictureBox1.Image != null)
                        {
                            Bitmap bitmap = new Bitmap(pictureBox1.Image);
                            pictureBox2.Image = AplicarFiltroNegativo(bitmap);
                        }
                    }
                    else
                    {

                    }
                    break;
                case 2: // Sepia
                    if (isImagen)
                    {
                        if (pictureBox1.Image != null)
                        {
                            Bitmap bitmap = new Bitmap(pictureBox1.Image);
                            pictureBox2.Image = AplicarFiltroSepia(bitmap);
                        }
                    }
                    else
                    {
                       
        

                    }
                    break;

            }
        }





        // FILTRO BLANCO Y NEGRO
        private Bitmap AplicarFiltroBlancoYNegro(Bitmap bitmap)
        {

                Bitmap imagenGrises = new Bitmap(bitmap.Width, bitmap.Height);

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);

                        int promedio = (pixel.R + pixel.G + pixel.B) / 3;

                        Color nuevoPixel = Color.FromArgb(promedio, promedio, promedio);

                        imagenGrises.SetPixel(x, y, nuevoPixel);
                    }
                }

                return imagenGrises;
            
        }
        // FILTRO NEGATIVO
        private Bitmap AplicarFiltroNegativo(Bitmap bitmap)
        {        
                Bitmap imagenNegativa = new Bitmap(bitmap.Width, bitmap.Height);


                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);

                        int r = 255 - pixel.R;
                        int g = 255 - pixel.G;
                        int b = 255 - pixel.B;

                        Color nuevoPixel = Color.FromArgb(r, g, b);

                        imagenNegativa.SetPixel(x, y, nuevoPixel);
                    }
                }


                return imagenNegativa;
            
        }
        // FILTRO SEPIA
        private Bitmap AplicarFiltroSepia(Bitmap bitmap)
        {

 
                Bitmap imagenSepia = new Bitmap(bitmap.Width, bitmap.Height);



                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);

                        int r = pixel.R;
                        int g = pixel.G;
                        int b = pixel.B;

                        int nuevoR = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                        int nuevoG = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                        int nuevoB = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                        // Los valores de cada componente no deben superar el valor máximo de 255.
                        nuevoR = nuevoR > 255 ? 255 : nuevoR;
                        nuevoG = nuevoG > 255 ? 255 : nuevoG;
                        nuevoB = nuevoB > 255 ? 255 : nuevoB;

                        Color nuevoPixel = Color.FromArgb(nuevoR, nuevoG, nuevoB);

                        imagenSepia.SetPixel(x, y, nuevoPixel);
                    }
                }



                return imagenSepia;
            
        }


        private void CargarFiltros()
        {
            cmbFiltros.Items.Add("Blanco y Negro");
            cmbFiltros.Items.Add("Negativo");
            cmbFiltros.Items.Add("Sepia");
        }


        //GUARDAR IMAGEN
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Image imagen = pictureBox2.Image;

                SaveFileDialog cuadroGuardar = new SaveFileDialog();
                cuadroGuardar.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                cuadroGuardar.Title = "Guardar imagen";
                cuadroGuardar.ShowDialog();

                if (cuadroGuardar.FileName != "")
                {
                    switch (cuadroGuardar.FilterIndex)
                    {
                        case 1:
                            imagen.Save(cuadroGuardar.FileName, ImageFormat.Png);
                            break;
                        case 2:
                            imagen.Save(cuadroGuardar.FileName, ImageFormat.Jpeg);
                            break;
                        case 3:
                            imagen.Save(cuadroGuardar.FileName, ImageFormat.Jpeg);
                            break;
                    }
                }
            }
        }


        //CARGAR IMAGEN
        private void button1_Click(object sender, EventArgs e)
        {
            isImagen = true;
            miVideo.Hide();
            miVideoFiltro.Hide();
            pictureBox1.Show();
            pictureBox2.Show();
            if (miVideo.IsRunning)
            {
                miVideo.SignalToStop();
                miVideo.WaitForStop();
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*";
            openFileDialog1.Title = "Seleccionar imagen";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar archivo: " + ex.Message);
            }
        }

        //CARGAR VIDEO
        private void button4_Click(object sender, EventArgs e)
        {
            isImagen = false;
            pictureBox1.Hide();
            pictureBox2.Hide();
            miVideo.Show();
            miVideoFiltro.Show();
      


            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "Archivos de video|*.mp4";
            openFileDialog2.Title = "Seleccionar video";

            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {                          
                    if (miVideo != null && miVideo.IsRunning)
                    {
                        miVideo.SignalToStop();
                        miVideo.WaitForStop();
              
                    }               
                    FileVideoSource fileSource = new FileVideoSource(openFileDialog2.FileName);
                    miVideo.VideoSource = fileSource;
                    miVideo.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar archivo: " + ex.Message);
            }
        }


        private void miVideo_Click(object sender, EventArgs e)
        {

        }
        Bitmap imagenFiltrada;
        private void miVideo_NewFrame_1(object sender, ref Bitmap image)
        {
         

            if (image != null && !isImagen)
            {
             // TO DO
                imagenFiltrada = image;

                //imagenFiltrada = AplicarFiltroNegativo(image);

                miVideoFiltro.BackgroundImage = imagenFiltrada;
            }
        }

        private void Filters_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (miVideo.VideoSource != null)
            {
                miVideo.SignalToStop();
                miVideo.WaitForStop();
            }
            if (miVideoFiltro.VideoSource != null)
            {
                miVideoFiltro.SignalToStop();
                miVideoFiltro.WaitForStop();
            }

        }
    }
}
