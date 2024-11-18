using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    public class User {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string profilePicture { get; set; }
        public string password { get; set; }
    }
}


/*
   {
        "id": 1,
        "username": "omarllinares",
        "email": "email@gmail.com",
        "role": "USER",
        "name": "omar",
        "surname": "llinares",
        "profilePicture": null,
        "reviews": []
    }*/
