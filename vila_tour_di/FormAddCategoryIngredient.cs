using ClientRESTAPI;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormAddCategoryIngredient : Form {

        bool isEditing = false;
        CategoryIngredient category; // Variable para almacenar la categoría
        string token = AppState.JwtData.Token;

        public FormAddCategoryIngredient() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR CATEGORIA";
        }

        public FormAddCategoryIngredient(CategoryIngredient category) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR CATEGORIA";

            this.category = category;

            guna2TextBoxNombreCat.Text = category.name;
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            // Obtener los datos del formulario
            string categoryName = guna2TextBoxNombreCat.Text.ToUpper();

            //Logica de editar
            if (isEditing) {
                // Crear un objeto con los datos actualizados
                CategoryIngredient updatedCat = new CategoryIngredient {
                    id = category.id,
                    name = categoryName
                };

                // Serializar el objeto a JSON
                string jsonData = JsonSerializer.Serialize(updatedCat);


                // Configurar la URL para el endpoint de actualización (incluye el ID en la URL)
                string url = $"http://127.0.0.1:8080/categories/{category.id}";

                using (HttpClient client = new HttpClient()) {
                    try {
                        // Agregamos el token al encabezado
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        // Creamos el contenido de la solicitud
                        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Realizamos la solicitud PUT
                        HttpResponseMessage response = client.PutAsync(url, content).Result;

                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Categoria editada correctamente", "Editado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show($"Problema al editar categoría. Error: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    }
                }                
            } else {
                // Creamos la categoria
                CategoryIngredient newCat = new CategoryIngredient(categoryName);

                string jsonData = JsonSerializer.Serialize(newCat);
                string res = string.Empty;

                // Agregamos una nueva categoria
                String url = "http://127.0.0.1:8080/categories";

                using (HttpClient client = new HttpClient()) {
                    try {
                        // Agregar el encabezado de autorización con el token
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        // Crear el contenido de la solicitud
                        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Realizar la solicitud POST
                        HttpResponseMessage response = client.PostAsync(url, content).Result;

                        if (response.IsSuccessStatusCode) {
                            // Mostrar un mensaje si la categoría se creó correctamente
                            MessageBox.Show("Categoría creada correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Dispose();
                        } else {
                            // Leer el contenido de la respuesta en caso de error
                            string errorResponse = response.Content.ReadAsStringAsync().Result;

                            if (errorResponse.Contains("\"errorCode\":101")) {
                                MessageBox.Show("Categoría ya existente.", "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            } else {
                                MessageBox.Show($"Error al crear categoría: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                Dispose();
            }
        }
      

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
