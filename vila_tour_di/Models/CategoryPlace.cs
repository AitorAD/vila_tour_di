using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di
{
    public class CategoryPlace
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Place> places { get; set; }

        public CategoryPlace(string name)
        {
            this.name = name;
        }

        public CategoryPlace(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public CategoryPlace() { }
    }
}
