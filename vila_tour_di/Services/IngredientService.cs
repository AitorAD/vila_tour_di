using System;
using System.Collections.Generic;


namespace vila_tour_di.Services {
    class IngredientService {
        public static List<Ingredient> GetIngredients() {
            string apiUrl = "http://127.0.0.1:8080/ingredients";
            return ApiService.Get<List<Ingredient>>(apiUrl) ?? new List<Ingredient>();
        }




    }
}
