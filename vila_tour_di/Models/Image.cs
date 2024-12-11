using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace vila_tour_di.Models {
    public class Image {
        public int id { get; set; }
        public string path { get; set; }
        public Article article { get; set; }

        public Image() { }

        public Image(string path, Article article) {
            this.path = path;
            this.article = article;
        }

        public override string ToString() {
            return $"ID: {id}\n" +
                   $"Path: {path}\n" +
                   $"Article: {article}\n";
        }
    }
}
