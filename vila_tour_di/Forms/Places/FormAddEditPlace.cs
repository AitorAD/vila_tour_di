using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di
{
    public partial class FormAddEditPlace : Form
    {
        private Place _currentPlace;
        private bool edit;
        private bool creating;
        public FormAddEditPlace()
        {
            InitializeComponent();
            comboCategory.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = "Añadir lugar de interés";
            creating = true;
        }

        public FormAddEditPlace(Place place, bool editable)
        {
            InitializeComponent();
            edit = editable;
            comboCategory.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = editable ? "Editar lugar de interés" : "Detalles del lugar de interés";
            _currentPlace = place;

            txtName.Text = place.name;
            comboCategory.SelectedItem = place.categoryPlace;
            txtDescription.Text = place.description;
            lblCreationDate.Text = "Fecha de creación: " + place.creationDate;
            lblLastModificationDate.Text = "Última modificación: " + place.lastModificationDate;

            if (place.imagensPaths != null)
            {
                imgPlace.Image = Base64ToImage(place.imagensPaths);
                imgPlace.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (!editable)
            {
                txtName.ReadOnly = true;
                comboCategory.Enabled = false;
                txtDescription.ReadOnly = true;
                btnAddImage.Enabled = false;
                btnAddPlace.Enabled = false;
            }
        }


        private List<CategoryPlace> LoadCategoriesPlacesData()
        {
            string apiUrl = "http://127.0.0.1:8080/categoriesPlace"; // Ajusta tu URL
            string token = AppState.JwtData.Token; // Obtener el token desde AppState

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<List<CategoryPlace>>(jsonResponse);
                    }
                    else
                    {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
                    return null;
                }
            }
        }

        

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            FormAddEditCoordinate formAddEditCoordinate;

            if (creating)
            {
                formAddEditCoordinate = new FormAddEditCoordinate();
            } else
            {
                formAddEditCoordinate = new FormAddEditCoordinate(_currentPlace.coordinate, edit);
            }
            formAddEditCoordinate.StartPosition = FormStartPosition.CenterScreen;
            formAddEditCoordinate.Show();
        }

        private string ConvertImageToBase64(string filePath)
        {
            try
            {
                using (Image image = Image.FromFile(filePath))
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guardar la imagen en un MemoryStream como PNG
                    image.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    // Convertir los bytes a una cadena Base64
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir la imagen a Base64: " + ex.Message);
                return null;
            }
        }

        private Image Base64ToImage(string base64String)
        {
            try
            {
                if (string.IsNullOrEmpty(base64String)) return null;
                var imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("La imagen base64 tiene un formato incorrecto: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir Base64 a imagen: " + ex.Message);
                return null;
            }
        }
    }
}
