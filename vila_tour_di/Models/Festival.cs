using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vila_tour_di.Models;

namespace vila_tour_di
{
    public class Festival : Article {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public User creator { get; set; }
        public Coordinate coordinate { get; set; }

        public Festival() : base() { }

        public Festival(string name, string description, DateTime startDate, DateTime endDate, User creator, Coordinate coordinate) : base() {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.creator = creator;
            this.coordinate = coordinate;
        }

        public override string ToString() {
            return $"ID: {id}\n" +
                   $"Name: {name}\n" +
                   $"Description: {description}\n" +
                   $"Average Score: {averageScore}\n" +
                   $"Creation Date: {creationDate.ToString("yyyy-MM-dd")}\n" +
                   $"Last Modification Date: {lastModificationDate.ToString("yyyy-MM-dd")}\n" +
                   $"Type: {type}\n" +
                   $"Start Date: {startDate.ToString("yyyy-MM-dd")}\n" +
                   $"End Date: {endDate.ToString("yyyy-MM-dd")}\n" +
                   $"Creator: {creator?.ToString() ?? "Unknown"}\n" +
                   $"Coordinates: {coordinate?.ToString() ?? "Unknown"}";
        }
    }
}
