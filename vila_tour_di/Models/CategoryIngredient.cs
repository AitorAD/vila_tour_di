using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {

    public class CategoryIngredient {

        public int id { get; set; }
        public string name { get; set; }

        public CategoryIngredient(string name) {
            this.name = name;
        }
        public CategoryIngredient() {

        }

        public override string ToString() {
            return $"{name}";
        }
    }
}
