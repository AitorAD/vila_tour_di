using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using vila_tour_di.Models;

namespace vila_tour_di {
    public class Recipe : Article // Hereda de la clase Article
    {
        public double averageScore { get; set; }
        public bool approved { get; set; }
        public bool recent { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public User creator { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }

        public Recipe() : base() { }

        public Recipe(string name, string description, bool approved, bool recent, List<Ingredient> ingredients, User creator, List<Image> images) : base() {
            this.name = name;
            this.description = description;
            this.approved = approved;
            this.recent = recent;
            this.ingredients = ingredients;
            this.creator = creator;
            this.images = images;
        }
        public override string ToString() {
            return $"ID: {id}\n" +
                   $"Name: {name}\n" +
                   $"Description: {description}\n" +
                   $"Average Score: {averageScore}\n" +
                   $"Creation Date: {creationDate.ToString("yyyy-MM-dd")}\n" +
                   $"Last Modification Date: {lastModificationDate.ToString("yyyy-MM-dd")}\n" +
                   $"Approved: {approved}\n" +
                   $"Recent: {recent}\n" +
                   $"Creator: {creator?.ToString() ?? "Unknown"}\n" +
                   $"Ingredients: {string.Join(", ", ingredients?.Select(i => i.ToString()) ?? new List<string>())}";
        }
    }
}
