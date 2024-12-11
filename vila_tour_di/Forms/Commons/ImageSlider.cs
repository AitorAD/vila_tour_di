using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di.Forms.Commons {
    public partial class ImageSlider : UserControl {

        public List<Models.Image> images { get; set; } // Lista de URLs o rutas locales
        private int currentIndex = 0;   // Índice de la imagen actual

        public ImageSlider() {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage() {
            if (images != null && images.Count > 0 && currentIndex >= 0 && currentIndex < images.Count) {
                try {
                    // Convertir la imagen base64 a Image y cargarla en el PictureBox
                    pictureBox.Image = Utils.Utils.Base64ToImage(images[currentIndex].path);
                    Console.WriteLine(images[currentIndex].path);

                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    // pictureBox.Text = $"{currentIndex + 1}/{images.Count}"; // Mostrar el índice
                } catch (Exception ex) {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (currentIndex < images.Count - 1) {
                currentIndex++;
                LoadImage();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            if (currentIndex > 0) {
                currentIndex--;
                LoadImage();
            }
        }
    }
}
