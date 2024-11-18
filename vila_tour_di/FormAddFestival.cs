using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di
{
    public partial class FormAddFestival : Form
    {
        public FormAddFestival()
        {
            InitializeComponent();
        }

        private void btnSearchImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos (*.*)|*.*";
            openFileDialog1.Title = "Selecciona una imagen";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBoxPath.Text = openFileDialog1.FileName;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
