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
        public string Type { get; set; }
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public override string ToString() {
            return $"JwtResponse [Token={Token}, Type={Type}, Id={Id}, Username={Username}, Email={Email}, Role={Role}]";
        }
    }

}
