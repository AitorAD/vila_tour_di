using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    class Ingredient {

        public Ingredient(int idIngredient, string name, CategoryIngredient categoryIngredient) {
            this.idIngredient = idIngredient;
            this.name = name;
            this.category = categoryIngredient;
        }

        public Ingredient(string name, CategoryIngredient categoryIngredient) {
            this.name = name;
            this.category = categoryIngredient;
        }

        public Ingredient() {
            
        }


        public int idIngredient { get; set; }
        public string name { get; set; }
        public CategoryIngredient category { get; set; }

        public override string ToString() {
            return $"Ingredient: {{ Id: {idIngredient}, Name: \"{name}\", Category: {category?.name ?? "None"} }}";
        }
    }
}