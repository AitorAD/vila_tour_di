using System;
using System.IO;
using System.Net;
using System.Text;

namespace ClientRESTAPI {
    internal class RestClient {
        private String url; // URL de nuestra base de datos
        private HttpWebRequest request;

        public RestClient(String url, String tipo) {
            /*
             * Constructor que inicializa las peticiones web, requiere url y GET, POST, PUT o DELETE
             */
            this.url = url;
            this.request = (HttpWebRequest)WebRequest.Create(this.url);

            // Establecer el método de la petición según el tipo
            switch (tipo) {
                case "GET":
                    this.request.Method = "GET";
                    break;
                case "POST":
                    this.request.Method = "POST";
                    break;
                case "PUT":
                    this.request.Method = "PUT";
                    break;
                case "DELETE":
                    this.request.Method = "DELETE";
                    break;
                default:
                    this.request.Method = "GET"; // Si no se pasa un tipo válido, se usa GET
                    break;
            }

            this.request.ContentType = "application/json";
            this.request.Accept = "application/json";
        }
        public string GetItem() {
            try {
                WebResponse response = request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                    return sr.ReadToEnd(); // Devuelve la respuesta JSON como string
                }
            } catch (Exception ex) {
                // Devuelve el error en caso de fallo
                return $"Error: {ex.Message}";
            }
        }

        public string PostItem(string data) {
            try {
                // Write data to the request stream
                using (Stream strWriter = request.GetRequestStream()) {
                    if (strWriter != null) {
                        using (StreamWriter sw = new StreamWriter(strWriter, Encoding.UTF8)) {
                            sw.Write(data);
                            sw.Flush();
                        }
                    } else {
                        return "Error: Unable to write to the request stream.";
                    }

                    // Get the response from the server
                    WebResponse response = request.GetResponse();
                    using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                        return sr.ReadToEnd(); // Return the response as string
                    }
                }
            } catch (WebException ex) {
                // Handle and return the error response from the server if it fails
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream())) {
                    string errorResponse = reader.ReadToEnd();
                    return $"Error: {errorResponse}"; // Return the server error response
                }
            }
        }

        public string PutItem(string data) {
            try {
                // Specify the PUT method for the request
                this.request.Method = "PUT";

                // Write the data to the request stream
                using (Stream strWriter = request.GetRequestStream()) {
                    if (strWriter != null) {
                        using (StreamWriter sw = new StreamWriter(strWriter, Encoding.UTF8)) {
                            sw.Write(data);
                            sw.Flush();
                        }
                    } else {
                        return "Error: Unable to write to the request stream.";
                    }

                    // Get the response from the server
                    WebResponse response = request.GetResponse();
                    using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                        return sr.ReadToEnd(); // Return the response as string
                    }
                }
            } catch (WebException ex) {
                // Handle and return the error response from the server if it fails
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream())) {
                    string errorResponse = reader.ReadToEnd();
                    return $"Error: {errorResponse}"; // Return the error response
                }
            }
        }

        public string DeleteItem() {
            try {
                // Specify the DELETE method for the request
                this.request.Method = "DELETE";

                // Get the response from the server
                WebResponse response = request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                    return sr.ReadToEnd(); // Return the response as string
                }
            } catch (WebException ex) {
                // Handle and return the error response from the server if it fails
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream())) {
                    string errorResponse = reader.ReadToEnd();
                    return $"Error: {errorResponse}"; // Return the error response
                }
            }
        }
    }
}
