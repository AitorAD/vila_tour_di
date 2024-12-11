using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di
{
    public partial class FormAddEditPlace : Form
    {
        private Place _currentPlace;
        private bool edit;
        private bool creating;
        private Coordinate currentCoordinate;

        public FormAddEditPlace()
        {
            InitializeComponent();
            comboCategory.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = "Añadir lugar de interés";
            creating = true;
            currentCoordinate = null;
        }

        public FormAddEditPlace(Place place, bool editable)
        {
            InitializeComponent();
            edit = editable;
            creating = false;
            comboCategory.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = editable ? "Editar lugar de interés" : "Detalles del lugar de interés";
            _currentPlace = place;

            txtName.Text = place.name;
            comboCategory.SelectedItem = place.categoryPlace;
            txtDescription.Text = place.description;
            lblCreationDate.Text = "Fecha de creación: " + place.creationDate;
            lblLastModificationDate.Text = "Última modificación: " + place.lastModificationDate;
            currentCoordinate = place.coordinate;

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
            string apiUrl = "http://127.0.0.1:8080/categoriesPlace";
            string token = Config.currentToken;

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
            FormAddEditCoordinate formAddEditCoordinate = currentCoordinate == null
                ? new FormAddEditCoordinate()
                : new FormAddEditCoordinate(currentCoordinate, true);

            formAddEditCoordinate.StartPosition = FormStartPosition.CenterScreen;
            var result = formAddEditCoordinate.ShowDialog();

            if (result == DialogResult.OK)
            {
                currentCoordinate = formAddEditCoordinate.CurrentCoordinate;
            }
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

        private void btnAddPlace_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtName.Text)) {
                MessageBox.Show("El nombre del lugar es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboCategory.SelectedItem == null) {
                MessageBox.Show("Debe seleccionar una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentCoordinate == null) {
                MessageBox.Show("Debe establecer la ubicación del lugar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear un nuevo objeto Place
            var newPlace = new Place {
                name = txtName.Text.Trim(),
                categoryPlace = (CategoryPlace)comboCategory.SelectedItem,
                description = txtDescription.Text.Trim(),
                coordinate = currentCoordinate,
                creationDate = DateTime.Now,
                lastModificationDate = DateTime.Now,
                imagensPaths = imgPlace.Image != null ? ConvertImageToBase64(imgPlace.ImageLocation) : null
            };

            // Formatear las fechas al formato ISO 8601 compatible con LocalDateTime
            var formattedPlace = new {
                newPlace.name,
                newPlace.description,
                newPlace.imagensPaths,
                newPlace.coordinate,
                creationDate = newPlace.creationDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                lastModificationDate = newPlace.lastModificationDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                newPlace.categoryPlaceId
            };

            // Serializar y enviar a la API
            string json = JsonConvert.SerializeObject(formattedPlace);

            using (HttpClient client = new HttpClient()) {
                try {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Config.currentToken);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("http://127.0.0.1:8080/places", content).Result;

                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Lugar añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    } else {
                        MessageBox.Show($"Error al añadir el lugar: {response.StatusCode} - {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al enviar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
