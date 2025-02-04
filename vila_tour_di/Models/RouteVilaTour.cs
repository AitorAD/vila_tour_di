using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Models {
    public class RouteVilaTour {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Place> places { get; set;}
        public User creator { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }

        public RouteVilaTour(string name, string description, List<Place> places, User creator) {
            this.name = name;
            this.description = description;
            this.places = places;
            this.creator = creator;
        }

        public RouteVilaTour() { }

        public override string ToString() {
            return $"ID: {id} Nombre: {name}";
         
        }
    }
}
