using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;

namespace vila_tour_di.Services {
    class CategoryIngredientService {

        private static string baseUrl = Config.baseURL + "categories";

        public static List<CategoryIngredient> GetCategoriesIngredient() {
            return ApiService.Get<List<CategoryIngredient>>(baseUrl) ?? new List<CategoryIngredient>();
        }

        public static bool AddCategory(string categoryName) {
            var newCategory = new CategoryIngredient { name = categoryName };
            var response = ApiService.Post(baseUrl, newCategory);
            return ApiService.HandleResponse(response, "Categoría creada correctamente.", "Error al crear categoría");
        }

        public static bool UpdateCategory(int categoryId, string categoryName) {
            var updatedCategory = new CategoryIngredient { id = categoryId, name = categoryName };
            var response = ApiService.Put($"{baseUrl}/{categoryId}", updatedCategory);
            return ApiService.HandleResponse(response, "Categoría actualizada correctamente.", "Error al actualizar categoría");
        }

        public static bool DeleteCategory(int categoryId) {
            var response = ApiService.Delete($"{baseUrl}/{categoryId}");
            return ApiService.HandleResponse(response, "Categoría eliminada correctamente.", "Error al eliminar categoría");
        }
    }
}
