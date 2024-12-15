using Guna.UI2.WinForms.Suite;
using System;
using System.Xml.Linq;
using vila_tour_di.Models;

namespace vila_tour_di {
    public class Place : Article {
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public CategoryPlace categoryPlace { get; set; }
        public User creator { get; set; }
        public Coordinate coordinate { get; set; }

        public Place() : base() { }

        public Place(string name, string description, double averageScore, DateTime creationDate, DateTime lastModificationDate, CategoryPlace categoryPlace, User creator, Coordinate coordinate) : base() {
            this.name = name;
            this.description = description;
            this.averageScore = averageScore;
            this.creationDate = creationDate;
            this.lastModificationDate = lastModificationDate;
            this.categoryPlace = categoryPlace;
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
                   $"Category: {categoryPlace?.ToString() ?? "Unknown"}\n" +
                   $"Creator: {creator?.ToString() ?? "Unknown"}\n" +
                   $"Coordinates: {coordinate?.ToString() ?? "Unknown"}";
        }
    }
}
