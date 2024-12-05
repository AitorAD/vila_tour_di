using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;


namespace vila_tour_di.Services {
    class IngredientService {

        private static string baseUrl = "http://127.0.0.1:8080/ingredients";

        public static List<Ingredient> GetIngredients() {
            return ApiService.Get<List<Ingredient>>(baseUrl) ?? new List<Ingredient>();
        }

        public static Ingredient GetIngredientById(int ingredientId) {
            return ApiService.GetById<Ingredient>(baseUrl, ingredientId) ?? new Ingredient();
        }

        public static bool AddIngredient(string name, CategoryIngredient category) {
            var ingredient = new Ingredient {name = name, category = category};
            var response = ApiService.Post(baseUrl, ingredient);
            return ApiService.HandleResponse(response, "Ingrediente creado correctamente.", "Error al crear ingrediente");
        }

        public static bool UpdateIngredient(int ingredientId, string name, CategoryIngredient category) {
            var updatedIngredient = new Ingredient {idIngredient = ingredientId, name = name, category = category};
            var response = ApiService.Put($"{baseUrl}/{ingredientId}", updatedIngredient);
            return ApiService.HandleResponse(response, "Ingrediente actualizado correctamente.", "Error al actualizar ingrediente");
        }

        public static bool DeleteIngredient(int ingredientId) {
            var response = ApiService.Delete($"{baseUrl}/{ingredientId}");
            return ApiService.HandleResponse(response, "Ingrediente eliminado correctamente.", "Error al eliminar ingrediente");
        }
    }
}
