using ClientRESTAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;
namespace vila_tour_di {
    public partial class FormAddIngrediente : Form {
        bool isEditing = false;
        int idIng;
        string nameIng;
        string catIng;


        // Constructor para agregar un ingrediente
        public FormAddIngrediente() {
            InitializeComponent();
            labelTitle.Text = "Añadir ingrediente";
            // Cargar las opciones traducidas en el ComboBox
            guna2ComboBox1.DataSource = GetIngredientTypeTranslations();
            guna2ComboBox1.DisplayMember = "Translation";  // Mostrar la traducción
            guna2ComboBox1.ValueMember = "Type";           // Usar el valor original del enum

            this.FormClosed += FormAddIngrediente_FormClosed; // Suscribirse al evento FormClosed
        }

        public FormAddIngrediente(int id, string name, string category) {
            isEditing = true;

            InitializeComponent();
            labelTitle.Text = "Editar ingrediente";
            idIng = id;
            nameIng = name;
            catIng = category;

            // Cargar las opciones traducidas en el ComboBox
            guna2ComboBox1.DataSource = GetIngredientTypeTranslations();
            guna2ComboBox1.DisplayMember = "Translation";  // Mostrar la traducción
            guna2ComboBox1.ValueMember = "Type";

            // Asignar los valores de nombre y categoría al TextBox y ComboBox
            guna2TextBox1.Text = nameIng; // Nombre del ingrediente

            // Seleccionar el tipo de ingrediente actual en el ComboBox
            guna2ComboBox1.SelectedValue = Enum.Parse(typeof(IngredientType), catIng);

            this.Text = "Editar ingrediente";

            this.FormClosed += FormAddIngrediente_FormClosed; // Suscribirse al evento FormClosed
        }

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            /*

                // Obtener los datos del formulario
                string nameIngredient = guna2TextBox1.Text;
                IngredientType categoryEnum = (IngredientType)guna2ComboBox1.SelectedValue;

                if (isEditing) {
                    // Crear el objeto IngredientOriginal
                    Ingredient originalIngredient = new Ingredient(idIng, nameIng, catIng);

                    // Crear el objeto Ingredient que será enviado en la actualización
                    Ingredient newIngredient = new Ingredient {
                        name = nameIngredient,
                        categoryIngredient = categoryEnum.ToString()
                    };

                    // Serializar el objeto newIngredient a JSON
                    string jsonBody = JsonSerializer.Serialize(newIngredient);

                    // Configurar la URL para el endpoint de PUT con el ID correspondiente
                    string url = $"http://127.0.0.1:8080/ingredients/{idIng}";
                    RestClient r = new RestClient(url, "PUT");

                    // Realizar la solicitud PUT usando el método putItem en el RestClient
                    string response = r.PutItem(jsonBody);

                    // Verificar la respuesta
                    if (!string.IsNullOrEmpty(response)) {
                        Console.WriteLine("Ingrediente actualizado exitosamente: " + response);
                        MessageBox.Show("Ingrediente actualizado");
                        Close();
                    } else {
                        MessageBox.Show("Error al actualizar el ingrediente");
                        Console.WriteLine("Error al actualizar el ingrediente.");
                        Close();
                    }
                } else {
                    // Crear el objeto Ingredient
                    Ingredient newIngredient = new Ingredient {
                        name = nameIngredient,
                        category = categoryEnum.ToString()
                    };

                    string jsonData = JsonSerializer.Serialize(newIngredient);
                    string res = string.Empty;

                    // Estamos agregando un nuevo ingrediente
                    string url = "http://127.0.0.1:8080/ingredients";
                    RestClient r = new RestClient(url, "POST");
                    res = r.PostItem(jsonData);  // Realizamos un POST para agregar el ingrediente
                    Console.WriteLine(res);
                    if (res != null) {
                        try {
                            // Eliminar el prefijo "Error: " si existe
                            if (res.StartsWith("Error:")) {
                                res = res.Substring(6).Trim(); // Elimina "Error: " (6 caracteres)
                            }

                            // Ahora intenta deserializar el JSON después de eliminar el prefijo
                            var responseObj = JsonSerializer.Deserialize<Response>(res);

                            // Verifica si la deserialización fue exitosa
                            if (responseObj != null && responseObj.error != null) {
                                if (responseObj.error.errorCode == 0) {
                                    // Caso de éxito
                                    string successMessage = string.IsNullOrEmpty(responseObj.error.message)
                                        ? "Ingrediente agregado exitosamente!"
                                        : responseObj.error.message;

                                    MessageBox.Show(successMessage);
                                    Console.WriteLine("Ingrediente agregado exitosamente: " + res);
                                } else if (responseObj.error.errorCode == 101) {
                                    // Error: El ingrediente ya existe
                                    MessageBox.Show("Error: " + responseObj.error.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Console.WriteLine($"Error Code: {responseObj.error.errorCode}, Message: {responseObj.error.message}");
                                } else {
                                    // Manejo de otros códigos de error
                                    MessageBox.Show($"Error al agregar el ingrediente: {responseObj.error.message}");
                                    Console.WriteLine($"Error Code: {responseObj.error.errorCode}, Message: {responseObj.error.message}");
                                }
                            } else {
                                // Si la deserialización falló o el objeto de error está vacío
                                MessageBox.Show("Respuesta no válida del servidor.");
                                Console.WriteLine("Respuesta no válida del servidor.");
                            }
                        } catch (JsonException ex) {
                            // Manejo de errores de deserialización JSON
                            MessageBox.Show($"Error al procesar la respuesta JSON: {ex.Message}");
                            Console.WriteLine($"Error al procesar la respuesta JSON: {ex.Message}");
                        }
                    } else {
                        MessageBox.Show("No se pudo conectar al servidor.");
                        Console.WriteLine("No se pudo conectar al servidor.");
                    }

                }
            */

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
