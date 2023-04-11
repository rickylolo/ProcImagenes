using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProcImgs
{
    public partial class Histogram : Form
    {
        public Histogram()
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
        private void Histogram_Load(object sender, EventArgs e)
        {
            LoadTheme();
            CargarFiltros();
            pictureBoxFiltro.Hide();
        }

        private void AplicarFiltroBlancoYNegro()
        {
            if (pictureBoxOriginal.Image != null)
            {
                Image imagenOriginal = pictureBoxOriginal.Image;
                Bitmap bitmap = new Bitmap(pictureBoxOriginal.Image);
                Bitmap imagenGrises = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    for (int x = 0; x < imagenOriginal.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);

                        int promedio = (pixel.R + pixel.G + pixel.B) / 3;

                        Color nuevoPixel = Color.FromArgb(promedio, promedio, promedio);

                        imagenGrises.SetPixel(x, y, nuevoPixel);
                    }
                }

                pictureBoxFiltro.Image = imagenGrises;
            }
        }

        private void AplicarFiltroNegativo()
        {
            if (pictureBoxOriginal.Image != null)
            {
                Image imagenOriginal = pictureBoxOriginal.Image;
                Bitmap bitmap = new Bitmap(pictureBoxOriginal.Image);
                Bitmap imagenNegativa = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);


                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    for (int x = 0; x < imagenOriginal.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);

                        int r = 255 - pixel.R;
                        int g = 255 - pixel.G;
                        int b = 255 - pixel.B;

                        Color nuevoPixel = Color.FromArgb(r, g, b);

                        imagenNegativa.SetPixel(x, y, nuevoPixel);
                    }
                }


                pictureBoxFiltro.Image = imagenNegativa;
            }
        }

        private void AplicarFiltroSepia()
        {
            if (pictureBoxOriginal.Image != null)
            {
                Image imagenOriginal = pictureBoxOriginal.Image;
                Bitmap bitmap = new Bitmap(pictureBoxOriginal.Image);
                Bitmap imagenSepia = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);



                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    for (int x = 0; x < imagenOriginal.Width; x++)
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



                pictureBoxFiltro.Image = imagenSepia;

            }
        }

        private void ImagenOriginal()
        {
            if (pictureBoxOriginal.Image != null)
            {
                Image imagenOriginal = pictureBoxOriginal.Image;
                pictureBoxFiltro.Image = imagenOriginal;
            }
        }


        private void CrearHistograma()
        {
            if (pictureBoxFiltro.Image != null)
            {
                Bitmap bitmap = new Bitmap(pictureBoxFiltro.Image);

                int[] histogram = new int[256 * 3];
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        histogram[pixel.R]++;
                        histogram[256 + pixel.G]++;
                        histogram[512 + pixel.B]++;
                    }
                }


                int maxHistogram = histogram.Max();
                int maxRedHistogram = histogram.Skip(0).Take(256).Max();
                int maxGreenHistogram = histogram.Skip(256).Take(256).Max();
                int maxBlueHistogram = histogram.Skip(512).Take(256).Max();


                Bitmap rgbBitmap = new Bitmap(256, 100);
                Bitmap redBitmap = new Bitmap(256, 100);
                Bitmap greenBitmap = new Bitmap(256, 100);
                Bitmap blueBitmap = new Bitmap(256, 100);
                for (int x = 0; x < 256; x++)
                {
                    int rgbValue = (int)(histogram[x] / (double)maxHistogram * 100);
                    int redValue = (int)(histogram[x] / (double)maxRedHistogram * 100);
                    int greenValue = (int)(histogram[256 + x] / (double)maxGreenHistogram * 100);
                    int blueValue = (int)(histogram[512 + x] / (double)maxBlueHistogram * 100);
                    for (int y = 99; y >= 100 - rgbValue; y--)
                    {
                        rgbBitmap.SetPixel(x, y, Color.White);
                    }
                    for (int y = 99; y >= 100 - redValue; y--)
                    {
                        redBitmap.SetPixel(x, y, Color.Red);
                    }
                    for (int y = 99; y >= 100 - greenValue; y--)
                    {
                        greenBitmap.SetPixel(x, y, Color.Green);
                    }
                    for (int y = 99; y >= 100 - blueValue; y--)
                    {
                        blueBitmap.SetPixel(x, y, Color.Blue);
                    }
                }


                pictureBoxRGB.BackColor = Color.Black;
                pictureBoxR.BackColor = Color.Black;
                pictureBoxG.BackColor = Color.Black;
                pictureBoxB.BackColor = Color.Black;
                pictureBoxRGB.Image = rgbBitmap;
                pictureBoxR.Image = redBitmap;
                pictureBoxG.Image = greenBitmap;
                pictureBoxB.Image = blueBitmap;




            }
        }





            private void CargarFiltros()
        {
            cmbFiltros.Items.Add("Original");
            cmbFiltros.Items.Add("Blanco y Negro");
            cmbFiltros.Items.Add("Negativo");
            cmbFiltros.Items.Add("Sepia");
        }

        // SELECCIONAR FILTRO
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBoxOriginal.Image != null)
            {

       
            pictureBoxOriginal.Hide();
            pictureBoxFiltro.Show();
            switch (cmbFiltros.SelectedIndex)
            {
               case 0: // Original
                    ImagenOriginal();
                    break;
               case 1: // Blanco y Negro
                    AplicarFiltroBlancoYNegro();
                    break;
               case 2: // Negativo
                    AplicarFiltroNegativo();
                    break;
               case 3: // Sepia
                    AplicarFiltroSepia();
                    break;

            }

            CrearHistograma();
            }
        }
        //CARGAR IMAGEN
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*";
            openFileDialog1.Title = "Seleccionar imagen";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxOriginal.Image = new Bitmap(openFileDialog1.FileName);
                    pictureBoxOriginal.Show();
                    pictureBoxFiltro.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar archivo: " + ex.Message);
            }
        }
    }
}
