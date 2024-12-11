using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di
{
    public class Festival
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public User creator { get; set; }
        public Coordinate coordinate { get; set; }

        public Festival() { }

        public Festival(string name, string description, DateTime startDate, DateTime endDate, User creator, Coordinate coordinate) {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.creator = creator;
            this.coordinate = coordinate;
        }
    }
}
