using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Models {
    public abstract class Article {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
    }
}
