using ClientRESTAPI;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace vila_tour_di {
    public partial class FormAddIngrediente : Form {
        bool isEditing = false;
        int idIng;
        string nameIng;
        CategoryIngredient catIng;


        // Constructor para agregar un ingrediente
        public FormAddIngrediente() {
            InitializeComponent();
            labelTitle.Text = "Añadir ingrediente";
            
            LoadCategoriesIngredientsData();

            this.FormClosed += FormAddIngrediente_FormClosed; // Suscribirse al evento FormClosed
        }

        public FormAddIngrediente(int id, string name, CategoryIngredient category) {
            InitializeComponent();

            isEditing = true;

            LoadCategoriesIngredientsData();
            labelTitle.Text = "Editar ingrediente";
            idIng = id;
            nameIng = name;
            catIng = category;

            // Asignar los valores de nombre y categoría al TextBox y ComboBox
            guna2TextBoxName.Text = nameIng; // Nombre del ingrediente

            // Seleccionar el tipo de categoria actual en el ComboBox
            if (category != null) {
                guna2ComboBoxCategory.SelectedValue = catIng.id;
            }

            this.Text = "Editar ingrediente";

            this.FormClosed += FormAddIngrediente_FormClosed; // Suscribirse al evento FormClosed
        }

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            // Obtener los datos del formulario
            string name = guna2TextBoxName.Text;
            CategoryIngredient category = guna2ComboBoxCategory.SelectedItem as CategoryIngredient;
            
            if (isEditing) {

                // Crear un objeto con los datos actualizados
                Ingredient updatedIngredient = new Ingredient(idIng, name, category);

                
                // Serializar el objeto newIngredient a JSON
                string jsonData = JsonSerializer.Serialize(updatedIngredient);

                // Configurar la URL para el endpoint de PUT con el ID correspondiente
                string url = $"http://127.0.0.1:8080/ingredients/{idIng}";
                RestClient restClient = new RestClient(url, "PUT");

                // Realizar la solicitud PUT usando el método putItem en el RestClient
                string response = restClient.PutItem(jsonData);

                // Verificar la respuesta
                if (response == jsonData) {
                    MessageBox.Show("Ingrediente editado correctamente.",
                        "Editado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    Dispose();
                } else {
                    MessageBox.Show("Problema al editar el ingrediente. No editada.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            } else {
                // Crear el objeto Ingredient
                Ingredient newIngredient = new Ingredient(name: name, categoryIngredient: category);


                string jsonData = JsonSerializer.Serialize(newIngredient);
                string res = string.Empty;

                // Estamos agregando un nuevo ingrediente
                string url = "http://127.0.0.1:8080/ingredients";
                RestClient r = new RestClient(url, "POST");
                res = r.PostItem(jsonData);  // Realizamos un POST para agregar el ingrediente
                Console.WriteLine("RESPUESTA: " + res);

                if (res.Contains("\"errorCode\":101")) {
                    MessageBox.Show("Ingrediente ya existente",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                Dispose();
            }

        }

        private void LoadCategoriesIngredientsData() {
            string apiUrl = "http://127.0.0.1:8080/categories"; // Ajusta tu URL
            string token = AppState.JwtData.Token; // Obtener el token desde AppState

            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token al encabezado de autorización
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la solicitud GET
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta como cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la respuesta JSON a una lista de categorías
                        var categoryIngredients = JsonConvert.DeserializeObject<List<CategoryIngredient>>(jsonResponse);

                        // Configurar el ComboBox con los datos obtenidos
                        guna2ComboBoxCategory.DataSource = categoryIngredients;
                        guna2ComboBoxCategory.DisplayMember = "name"; // Propiedad que se mostrará
                        guna2ComboBoxCategory.ValueMember = "id"; // Propiedad usada como valor
                    } else {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
                }
            }
        }

        // Función para traducir el enum y devolver una lista de objetos
        private List<IngredientTypeTranslation> GetIngredientTypeTranslations() {
            return new List<IngredientTypeTranslation> {
                new IngredientTypeTranslation { Type = IngredientType.FRUITS_AND_VEGETABLES, Translation = "Frutas y Verduras" },
                new IngredientTypeTranslation { Type = IngredientType.MEAT_AND_POULTRY, Translation = "Carnes y Aves" },
                new IngredientTypeTranslation { Type = IngredientType.FISH_AND_SEAFOOD, Translation = "Pescados y Mariscos" },
                new IngredientTypeTranslation { Type = IngredientType.DAIRY, Translation = "Lácteos" },
                new IngredientTypeTranslation { Type = IngredientType.GRAINS_AND_CEREALS, Translation = "Cereales y Granos" },
                new IngredientTypeTranslation { Type = IngredientType.SPICES_AND_HERBS, Translation = "Especias y Hierbas" },
                new IngredientTypeTranslation { Type = IngredientType.LEGUMES, Translation = "Legumbres" },
                new IngredientTypeTranslation { Type = IngredientType.OILS_AND_FATS, Translation = "Aceites y Grasas" },
                new IngredientTypeTranslation { Type = IngredientType.SWEETENERS, Translation = "Endulzantes" },
                new IngredientTypeTranslation { Type = IngredientType.BEVERAGES, Translation = "Bebidas" }
            };
        }

        // Clase para almacenar el valor original y su traducción
        private class IngredientTypeTranslation {
            public IngredientType Type { get; set; }
            public string Translation { get; set; }
        }

        public enum IngredientType {
            FRUITS_AND_VEGETABLES,
            MEAT_AND_POULTRY,
            FISH_AND_SEAFOOD,
            DAIRY,
            GRAINS_AND_CEREALS,
            SPICES_AND_HERBS,
            LEGUMES,
            NUTS_AND_SEEDS,
            OILS_AND_FATS,
            SWEETENERS,
            BEVERAGES
        }
        private void FormAddIngrediente_FormClosed(object sender, FormClosedEventArgs e) {
            // Cuando el formulario se cierra, recarga los ingredientes en el formulario principal
            if (this.Owner != null) {
                var mainForm = this.Owner as FormIngredient;
                if (mainForm != null) {
                    mainForm.LoadIngredientsInDataGridView(); // Recargar los ingredientes
                }
            }
        }
    }
    
}
