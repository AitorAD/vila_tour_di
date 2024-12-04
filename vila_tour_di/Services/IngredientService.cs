using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;


namespace vila_tour_di.Services {
    class IngredientService {
        public static List<Ingredient> GetIngredients() {
            string apiUrl = "http://127.0.0.1:8080/ingredients";
            return ApiService.Get<List<Ingredient>>(apiUrl) ?? new List<Ingredient>();
        }

        public static bool AddIngredient(string name, CategoryIngredient category) {
            // Creamos el ingrediente
            Ingredient ingredient = new Ingredient(name, category);

            // Serializamos el ingrediente a JSON
            string jsonData = JsonSerializer.Serialize(ingredient);

            // Url endpoint de la API
            string url = "http://127.0.0.1:8080/ingredients";

            // Llamar al servicio de la API, para realizar el Post
            var response = ApiService.Post(url, jsonData);

            if (response != null && response.IsSuccessStatusCode) {
                MessageBox.Show("Categoría creada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else {
                // Verificamos el error
                string errorResponse = response?.Content.ReadAsStringAsync().Result ?? string.Empty;
                if (errorResponse.Contains("\"errorCode\":101")) {
                    MessageBox.Show("Ingrediente ya existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show($"Error al crear el ingrediente: {response?.StatusCode} - {response?.ReasonPhrase}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public static bool UpdateIngrediente(int ingredientId, string name, CategoryIngredient category) {
            // Crear el objeto con los datos nuevos
            Ingredient updatedIngredient = new Ingredient { name = name, category = category };  

            // Serializamos el objeto a JSON
            string jsonData = JsonSerializer.Serialize(updatedIngredient);

            // Configurar la URL para el endpoint de actualización (incluye el ID en la URL)
            string url = $"http://127.0.0.1:8080/categories/{ingredientId}";

            // Llamar al servicio de la API para realizar la solicitud PUT
            var response = ApiService.Put(url, jsonData);

            if (response != null && response.IsSuccessStatusCode) {
                MessageBox.Show("Categoría editada correctamente", "Editado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else {
                MessageBox.Show($"Problema al editar categoría. Error: {response?.StatusCode} - {response?.ReasonPhrase}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
