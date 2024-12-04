using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace vila_tour_di.Services {
    class CategoryIngredientService {

        public static List<CategoryIngredient> GetCategoriesIngredient() {
            string apiUrl = "http://127.0.0.1:8080/categories";
            return ApiService.Get<List<CategoryIngredient>>(apiUrl) ?? new List<CategoryIngredient>();
        }

        public static bool AddCategory(string categoryName) {
            // Creamos la nueva categoría
            CategoryIngredient newCat = new CategoryIngredient(categoryName);

            // Serializar la categoría a formato JSON
            string jsonData = JsonSerializer.Serialize(newCat);

            // Url endpoint de la API
            string url = "http://127.0.0.1:8080/categories";

            // Llamar al servicio de la API para realizar la solicitud POST
            var response = ApiService.Post(url, jsonData);

            if (response != null && response.IsSuccessStatusCode) {
                MessageBox.Show("Categoría creada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else {
                // Verificamos el error
                string errorResponse = response?.Content.ReadAsStringAsync().Result ?? string.Empty;
                if (errorResponse.Contains("\"errorCode\":101")) {
                    MessageBox.Show("Categoría ya existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show($"Error al crear categoría: {response?.StatusCode} - {response?.ReasonPhrase}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public static bool UpdateCategory(int categoryId, string categoryName) {
            // Crear el objeto con los datos actualizados
            CategoryIngredient updatedCat = new CategoryIngredient {
                id = categoryId,
                name = categoryName
            };

            // Serializar el objeto a JSON
            string jsonData = JsonSerializer.Serialize(updatedCat);

            // Configurar la URL para el endpoint de actualización (incluye el ID en la URL)
            string url = $"http://127.0.0.1:8080/categories/{categoryId}";

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

        public static bool DeleteCategory(int categoryId) {
            // Configurar la URL para el endpoint de eliminación (incluye el ID en la URL)
            string url = $"http://127.0.0.1:8080/categories/{categoryId}";

            // Llamar al servicio de la API para realizar la solicitud DELETE
            var response = ApiService.Delete(url);

            if (response != null && response.IsSuccessStatusCode) {
                MessageBox.Show("Categoría eliminada exitosamente.");
                return true;
            } else {
                MessageBox.Show($"Error al eliminar categoría. Error: {response?.StatusCode} - {response?.ReasonPhrase}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
