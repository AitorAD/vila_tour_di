using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Models {
    class Image {
        public int id { get; set; }
        public string path { get; set; }
        public Article article { get; set; }
    }
}
