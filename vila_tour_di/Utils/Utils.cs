using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace vila_tour_di.Utils {
    public class Utils {
        public static string ConvertImageToBase64(string filePath) {
            try {
                using (Image image = Image.FromFile(filePath))
                using (MemoryStream ms = new MemoryStream()) {
                    // Guardar la imagen en un MemoryStream como PNG
                    image.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    // Convertir los bytes a una cadena Base64
                    return Convert.ToBase64String(imageBytes);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir la imagen a Base64: " + ex.Message);
                return null;
            }
        }

        public static Image Base64ToImage(string base64String) {
            try {
                if (string.IsNullOrEmpty(base64String)) return null;
                var imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes)) {
                    return Image.FromStream(ms);
                }
            } catch (FormatException ex) {
                MessageBox.Show("La imagen base64 tiene un formato incorrecto: " + ex.Message);
                return null;
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir Base64 a imagen: " + ex.Message);
                return null;
            }
        }
    }
}
