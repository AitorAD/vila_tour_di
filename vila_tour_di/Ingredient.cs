using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    class Ingredient {
        private string type;

        public Ingredient(int idIngredient, string name, string type) {
            this.idIngredient = idIngredient;
            this.name = name;
            this.type = type;
        }

        public Ingredient() {
            
        }


        public int idIngredient { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }
}