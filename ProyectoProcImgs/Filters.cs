﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProcImgs
{
    public partial class Filters : Form
    {
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
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar archivo: " + ex.Message);
            }
        }

        // SELECCIONAR FILTRO
        private void button3_Click(object sender, EventArgs e)
        {
            switch (cmbFiltros.SelectedIndex)
            {
                case 0: // Blanco y Negro
                    AplicarFiltroBlancoYNegro();
                    break;
                case 1: // Negativo
                    AplicarFiltroNegativo();
                    break;
                case 2: // Sepia
                    AplicarFiltroSepia();
                    break;

            }
        }


        // FILTRO BLANCO Y NEGRO
        private void AplicarFiltroBlancoYNegro()
        {
            if (pictureBox1.Image != null)
            {
                Image imagenOriginal = pictureBox1.Image;
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
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

                pictureBox2.Image = imagenGrises;
            }
        }
        // FILTRO NEGATIVO
        private void AplicarFiltroNegativo()
        {
            if (pictureBox1.Image != null)
            {
                Image imagenOriginal = pictureBox1.Image;
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
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


                pictureBox2.Image = imagenNegativa;
            }
        }
        // FILTRO SEPIA
        private void AplicarFiltroSepia()
        {
            if (pictureBox1.Image != null)
            {
                Image imagenOriginal = pictureBox1.Image;
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
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



                pictureBox2.Image = imagenSepia;
            }
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
    }
}
