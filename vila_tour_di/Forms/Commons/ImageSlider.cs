using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Models;
using vila_tour_di.Services;

namespace vila_tour_di.Forms.Commons {
    public partial class ImageSlider : UserControl {

        public List<Models.Image> images { get; set; } // Lista de URLs o rutas locales
        public Article article { get; set; } // Articulo al que hace referencia

        private int currentIndex = 0;   // Índice de la imagen actual

        public ImageSlider() {
            InitializeComponent();
            LoadImage();
        }

        public void setStatusButtons(bool enabled) {
            btnAddImage.Enabled = enabled;
            btnDeleteImage.Enabled = enabled;
        }

        public void LoadImage() {
            if (images == null || images.Count == 0) {
                pictureBox.Image = null;
                lblInfoImage.Text = "No Image";
                return; // No hay imágenes para cargar
            }

            if (currentIndex >= 0 && currentIndex < images.Count) {
                try {
                    pictureBox.Image = Utils.Utils.Base64ToImage(images[currentIndex].path);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    lblInfoImage.Text = $"{currentIndex + 1}/{images.Count}";
                } catch (Exception ex) {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnNext_Click(object sender, EventArgs e) {
            if (images != null) {
                if (currentIndex < images.Count - 1) {
                    currentIndex++;
                } else {
                    currentIndex = 0;
                }
                LoadImage();
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            if (images != null) {
                if (currentIndex > 0) {
                    currentIndex--;
                } else {
                    currentIndex = images.Count - 1;
                }
                LoadImage();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void btnAddImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Selecciona una imagen de perfil";

                /*
                // Código antiguo sin cambiar la calidad de la imagen
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;

                    if (selectedFilePath != null) {
                        string base64Image = Utils.Utils.ConvertImageToBase64(selectedFilePath);
                        if (images == null) {
                            images = new List<Models.Image>();
                        }
                        images.Add(new Models.Image(base64Image));
                        currentIndex = images.Count - 1;
                        LoadImage();
                    }
                }
                */

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;

                    if (selectedFilePath != null) {
                        using (System.Drawing.Image originalImage = System.Drawing.Image.FromFile(selectedFilePath)) {
                            System.Drawing.Image resizedImage = ResizeImage(originalImage, 800, 800); // Ajusta el tamaño máximo según sea necesario

                            string tempPath = System.IO.Path.GetTempFileName();
                            resizedImage.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            // Convertir a Base64 usando la nueva imagen guardada
                            string base64Image = Utils.Utils.ConvertImageToBase64(tempPath);

                            if (images == null) {
                                images = new List<Models.Image>();
                            }
                            images.Add(new Models.Image(base64Image));
                            currentIndex = images.Count - 1;
                            LoadImage();
                        }
                    }
                }

            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e) {
            if (pictureBox.Image != null) {
                if (article != null) {
                    Console.WriteLine(images[currentIndex]);
                    ImageService.DeleteImage(images[currentIndex]);
                }
                images.RemoveAt(currentIndex);
                if (currentIndex != 0) {
                    currentIndex--;
                }
                LoadImage();
                
            }
        }

        private System.Drawing.Image ResizeImage(System.Drawing.Image img, int maxWidth, int maxHeight) {
            int newWidth = img.Width;
            int newHeight = img.Height;

            if (img.Width > maxWidth || img.Height > maxHeight) {
                double ratioX = (double)maxWidth / img.Width;
                double ratioY = (double)maxHeight / img.Height;
                double ratio = Math.Min(ratioX, ratioY);

                newWidth = (int)(img.Width * ratio);
                newHeight = (int)(img.Height * ratio);
            }

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(resizedImage)) {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

    }
}
