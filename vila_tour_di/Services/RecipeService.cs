using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di.Services {
    class RecipeService {

        private static string baseUrl = "http://127.0.0.1:8080/recipes";

        public static List<Recipe> GetAllRecipes() {
            return ApiService.Get<List<Recipe>>(baseUrl);
        }

        public static Recipe GetRecipeById(int idRecipe) {
            string url = $"{baseUrl}/{idRecipe}";
            return ApiService.GetById<Recipe>(baseUrl, idRecipe);
        }

        // Crear una nueva receta
        public static bool AddRecipe(Recipe recipe) {
            var response = ApiService.Post(baseUrl, recipe);
            return ApiService.HandleResponse(response, "Receta creada correctamente", "Error al crear la receta");
        }

        // Actualizar receta
        public static bool UpdateRecipe(Recipe recipe, Recipe newRecipe) {
            string url = $"{baseUrl}/{recipe.id}";
            var response =  ApiService.Put(url, newRecipe);
            return ApiService.HandleResponse(response, "Receta editada correctamente", "Error al editar la receta");
        }

        // Eliminar receta
        public static bool DeleteRecipe(int id) {
            var response = ApiService.Delete($"{baseUrl}/{id}");
            return ApiService.HandleResponse(response, "Receta eliminada correctamente", "Error al eliminar la receta");
        }
        
    }
}
