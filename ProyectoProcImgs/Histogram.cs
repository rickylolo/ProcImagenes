using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
    }
}
