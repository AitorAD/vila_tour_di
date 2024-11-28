using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace vila_tour_di {
    public class JwtResponse {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Role> Role { get; set; }
    }

    public class Role {
        public string Authority { get; set; }
    }
}
