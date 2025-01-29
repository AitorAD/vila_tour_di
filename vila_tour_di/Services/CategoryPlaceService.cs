using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Services {
    class CategoryPlaceService {

        private static string baseUrl = Config.baseURL + "categoriesPlace";

        // Obtener todas las categorías de lugares
        public static List<CategoryPlace> GetCategoriesPlaces() {
            return ApiService.Get<List<CategoryPlace>>(baseUrl) ?? new List<CategoryPlace>();
        }

        // Crear una nueva categoría de lugar
        public static bool AddCategoryPlace(CategoryPlace categoryPlace) {
            var response = ApiService.Post(baseUrl, categoryPlace);
            return ApiService.HandleResponse(response, "Categoría de lugar añadida correctamente.", "Error al añadir categoría de lugar");
        }

        // Actualizar una categoría de lugar
        public static bool UpdateCategoryPlace(CategoryPlace categoryPlace, CategoryPlace newCategoryPlace) {
            var response = ApiService.Put($"{baseUrl}/{categoryPlace.id}", newCategoryPlace);
            return ApiService.HandleResponse(response, "Categoría de lugar actualizada correctamente.", "Error al actualizar categoría de lugar");
        }

        // Eliminar una categoría de lugar
        public static bool DeleteCategoryPlace(int categoryPlaceId) {
            var response = ApiService.Delete($"{baseUrl}/{categoryPlaceId}");
            return ApiService.HandleResponse(response, "Categoría de lugar eliminada correctamente.", "Error al eliminar categoría de lugar");
        }
    }
}
