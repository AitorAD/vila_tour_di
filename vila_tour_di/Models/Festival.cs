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
        public string imagensPaths { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int creatorId { get; set; }
        public User creator { get; set; }
        public int coordinateId { get; set; }
        public Coordinate coordinate { get; set; }

        public Festival(string name, string description, string imagensPaths, double averageScore, DateTime creationDate, DateTime lastModificationDate, DateTime startDate, DateTime endDate, int creatorId, User creator, int coordinateId, Coordinate coordinate)
        {
            this.name = name;
            this.description = description;
            this.imagensPaths = imagensPaths;
            this.averageScore = averageScore;
            this.creationDate = creationDate;
            this.lastModificationDate = lastModificationDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.creatorId = creatorId;
            this.creator = creator;
            this.coordinateId = coordinateId;
            this.coordinate = coordinate;
        }

        public Festival() { }
    }
}
