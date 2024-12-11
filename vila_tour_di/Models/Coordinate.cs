using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di
{
    public class Coordinate
    {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Coordinate(string name, double latitude, double longitude) {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Coordinate() { }

        public string DisplayText {
            get {
                return ToString();
            }
        }

        public override string ToString() {
            return $"{name} [{latitude}, {longitude}]";
        }
    }
}
