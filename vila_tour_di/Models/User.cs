using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    public class User
    {

        public User() { }
        public User(string username, string email, string password, string role, string name, string surname, string profilePicture) {
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = role;
            this.name = name;
            this.surname = surname;
            this.profilePicture = profilePicture;
        }

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