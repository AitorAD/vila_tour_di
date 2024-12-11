using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using vila_tour_di.Converters;

namespace vila_tour_di.Services {
    class ApiService {

        static string token = Config.currentToken;

        public static T Get<T>(string apiUrl) where T : new() {
            using (HttpClient client = new HttpClient()) {
                try {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Configurar el deserializador con el convertidor personalizado
                        var settings = new JsonSerializerSettings {
                            Converters = new List<JsonConverter> { new ArticleConverter() }
                        };
                        return JsonConvert.DeserializeObject<T>(jsonResponse, settings);
                    } else {
                        HandleError(response);
                    }
                } catch (Exception ex) {
                    ShowException(ex);
                }
            }
            return default(T);
        }

        public static T GetById<T>(string baseUrl, int id) where T : new() {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Construir la URL completa para la solicitud
                    string url = $"{baseUrl}/{id}";
                    // Agregar encabezado de autorización
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    // Realizar la solicitud GET
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta y deserializarla en un objeto de tipo T
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Configurar el deserializador con el convertidor personalizado
                        var settings = new JsonSerializerSettings {
                            Converters = new List<JsonConverter> { new ArticleConverter() }
                        };

                        return JsonConvert.DeserializeObject<T>(jsonResponse, settings);
                    } else {
                        // Si la respuesta no es exitosa, manejar el error
                        HandleError(response);
                    }
                } catch (Exception ex) {
                    // Mostrar cualquier excepción que ocurra
                    ShowException(ex);
                }
            }

            // Retornar el valor por defecto si algo falla
            return default(T);
        }


        public static HttpResponseMessage Post<T>(string apiUrl, T data) {
            return SendData(apiUrl, data, HttpMethod.Post);
        }

        public static HttpResponseMessage Put<T>(string apiUrl, T data) {
            return SendData(apiUrl, data, HttpMethod.Put);
        }

        public static HttpResponseMessage Delete(string apiUrl) {
            using (HttpClient client = new HttpClient()) {
                try {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    return client.DeleteAsync(apiUrl).Result;
                } catch (Exception ex) {
                    ShowException(ex);
                    return null;
                }
            }
        }

        private static HttpResponseMessage SendData<T>(string apiUrl, T data, HttpMethod method) {
            using (HttpClient client = new HttpClient()) {
                try {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    string jsonData = JsonConvert.SerializeObject(data);
                    Console.WriteLine(jsonData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var request = new HttpRequestMessage(method, apiUrl) { Content = content };
                    return client.SendAsync(request).Result;
                } catch (Exception ex) {
                    ShowException(ex);
                    return null;
                }
            }
        }

        public static bool HandleResponse(HttpResponseMessage response, string successMessage, string errorMessage) {
            if (response != null && response.IsSuccessStatusCode) {
                MessageBox.Show(successMessage, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } else {
                ApiService.HandleError(response);
                return false;
            }
        }

        public static void HandleError(HttpResponseMessage response) {
            MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowException(Exception ex) {
            MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}

