using ClientRESTAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormAddCategoryIngredient : Form {

        bool isEditing = false;
        CategoryIngredient categ; // Variable para almacenar la categoría

        public FormAddCategoryIngredient() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR CATEGORIA";
        }

        public FormAddCategoryIngredient(CategoryIngredient category) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR CATEGORIA";

            categ = category;

            guna2TextBoxNombreCat.Text = category.name;
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            // Obtener los datos del formulario
            string categoryName = guna2TextBoxNombreCat.Text.ToUpper();

            //Logica de editar
            if (isEditing) {
                // Crear un objeto con los datos actualizados
                CategoryIngredient updatedCat = new CategoryIngredient {
                    id = categ.id,
                    name = categoryName
                };

                // Serializar el objeto a JSON
                string jsonData = JsonSerializer.Serialize(updatedCat);

                // Configurar la URL para el endpoint de actualización (incluye el ID en la URL)
                string url = $"http://127.0.0.1:8080/categories/{categ.id}";
                RestClient client = new RestClient(url, "PUT");

                // Realizar la solicitud PUT
                string res = client.PutItem(jsonData);

                if (!string.IsNullOrEmpty(res)) {
                    try {
                        // Verificar si la respuesta contiene un prefijo de error
                        if (res.StartsWith("Error:")) {
                            res = res.Substring(6).Trim();
                        }

                        // Intentar deserializar la respuesta JSON
                        var responseObj = JsonSerializer.Deserialize<Response>(res);
                        Console.Write("Prueba:");
                        Console.WriteLine(responseObj);

                        if (responseObj != null && responseObj.error != null) {
                            if (responseObj.error.errorCode == 0) {
                                // Actualización exitosa
                                string successMessage = string.IsNullOrEmpty(responseObj.error.message)
                                    ? "Categoría actualizada exitosamente!"
                                    : responseObj.error.message;

                                MessageBox.Show(successMessage);
                                Console.WriteLine("Categoría actualizada exitosamente: " + res);
                            } else {
                                // Manejo de errores específicos
                                MessageBox.Show($"Error al actualizar la categoría: {responseObj.error.message}");
                                Console.WriteLine($"Error Code: {responseObj.error.errorCode}, Message: {responseObj.error.message}");
                            }
                        } else {
                            // Respuesta no válida del servidor
                            MessageBox.Show("Respuesta no válida del servidor.");
                            Console.WriteLine("Respuesta no válida del servidor.");
                        }
                    } catch (JsonException ex) {
                        // Manejo de errores de deserialización
                        MessageBox.Show($"Error al procesar la respuesta JSON: {ex.Message}");
                        Console.WriteLine($"Error al procesar la respuesta JSON: {ex.Message}");
                    }
                } else {
                    MessageBox.Show("No se pudo conectar al servidor.");
                    Console.WriteLine("No se pudo conectar al servidor.");
                }
        } else {
                // Creamos la categoria
                CategoryIngredient newCat = new CategoryIngredient(categoryName);

                string jsonData = JsonSerializer.Serialize(newCat);
                string res = string.Empty;

                // Agregamos una nueva categoria
                String url = "http://127.0.0.1:8080/categories";
                RestClient r = new RestClient(url, "POST");

                res = r.PostItem(jsonData); // Realizamos el post
                if (res != null) {
                    try {
                        // Eliminar el prefijo
                        if (res.StartsWith("Error:")) {
                            res.Substring(6).Trim();
                        }

                        // Ahora intenta deserializar el JSON después de eliminar el prefijo
                        var responseObj = JsonSerializer.Deserialize<Response>(res);
                        // Verifica si la deserialización fue exitosa
                        if (responseObj != null && responseObj.error != null) {
                            if (responseObj.error.errorCode == 0) {
                                // Caso de éxito
                                string successMessage = string.IsNullOrEmpty(responseObj.error.message)
                                    ? "Categoria agregada exitosamente!"
                                    : responseObj.error.message;

                                MessageBox.Show(successMessage);
                                Console.WriteLine("Categotia agregada exitosamente: " + res);
                            } else if (responseObj.error.errorCode == 101) {
                                // Error: El ingrediente ya existe
                                MessageBox.Show("Error: " + responseObj.error.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Console.WriteLine($"Error Code: {responseObj.error.errorCode}, Message: {responseObj.error.message}");
                            } else {
                                // Manejo de otros códigos de error
                                MessageBox.Show($"Error al agregar la categoria: {responseObj.error.message}");
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
        }

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
