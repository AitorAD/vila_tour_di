using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FormAddEditPlace()
        {
            InitializeComponent();
            comboBoxCategoryPlace.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = "Añadir lugar de interés";
        }

        public FormAddEditPlace(Place place, bool editable)
        {
            InitializeComponent();
            comboBoxCategoryPlace.DataSource = LoadCategoriesPlacesData();
            labelTitle.Text = editable ? "Editar lugar" : "Detalles del lugar";

            _currentPlace = place;

        }

        private List<CategoryIngredient> LoadCategoriesPlacesData()
        {
            string apiUrl = "http://127.0.0.1:8080/categoriesPlace"; // Ajusta tu URL
            string token = AppState.JwtData.Token; // Obtener el token desde AppState

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Agregar el token al encabezado de autorización
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la solicitud GET
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta como cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la respuesta JSON a una lista de categorías
                        return JsonConvert.DeserializeObject<List<CategoryIngredient>>(jsonResponse);

                        
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /*FormAddEditCoordinate formAddEditCoordinate = new FormAddEditCoordinate();
            formAddEditCoordinate.StartPosition = FormStartPosition.CenterScreen;
            formAddEditCoordinate.Show();*/
        }
    }
}
