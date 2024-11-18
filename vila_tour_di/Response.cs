using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Response {
    public ErrorDetails error { get; set; }

    public class ErrorDetails {
        public long errorCode { get; set; }
        public string message { get; set; }
    }
}