using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Models {
    public class Route {

        public int idRoute { get; set; }
        public string name { get; set; }
        public List<Place> places { get; set;}
        public User creator { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }

        public Route(string name, List<Place> places, User creator) {
            this.name = name;
            this.places = places;
            this.creator = creator;
        }

        public Route() { }

        public override string ToString() {
            return $"{name}";
        }
    }
}
