using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using vila_tour_di.Converters;

namespace vila_tour_di.Models {

    [JsonConverter(typeof(ArticleConverter))]
    public abstract class Article {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public List<Image> images { get; set; }

        public string type { get; set; }

        protected Article() {
            this.type = this.GetType().Name.ToLower();  // Asigna el nombre de la clase
        }
    }
}
