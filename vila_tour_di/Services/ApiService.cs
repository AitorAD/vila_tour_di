using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di.Services {
    class ApiService {

        static string token = AppState.JwtData.Token;

        public static T Get<T>(string apiUrl) where T : new() {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token al encabezado
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Realizar la petición
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta y deserializarla
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(jsonResponse);
                    } else {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return default(T); // Retorna el valor predeterminado si ocurre un error
        }

        public static HttpResponseMessage Post(string apiUrl, string jsonData) {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token al encabezado
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Crear el contenido de la solicitud
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST
                    return client.PostAsync(apiUrl, content).Result;
                } catch (Exception ex) {
                    MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public static HttpResponseMessage Put(string apiUrl, string jsonData) {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token al encabezado
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Crear el contenido de la solicitud
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Realizar la solicitud PUT
                    return client.PutAsync(apiUrl, content).Result;
                } catch (Exception ex) {
                    MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public static HttpResponseMessage Delete(string apiUrl) {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token al encabezado
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Realizar la solicitud DELETE
                    return client.DeleteAsync(apiUrl).Result;
                } catch (Exception ex) {
                    MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

    }
}
