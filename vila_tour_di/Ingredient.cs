using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public class Ingredient {

        public Ingredient(int idIngredient, string name, CategoryIngredient categoryIngredient) {
            this.idIngredient = idIngredient;
            this.name = name;
            this.category = categoryIngredient;
        }

        public Ingredient(string name, CategoryIngredient categoryIngredient) {
            this.name = name;
            this.category = categoryIngredient;
        }

        public Ingredient() {
            
        }

        public int idIngredient { get; set; }
        public string name { get; set; }
        public CategoryIngredient category { get; set; }

        public override string ToString() {
            return $"{name}";
        }

        public static List<Ingredient> GetIngredients() {
            List<Ingredient> ingredients = new List<Ingredient>();
            string apiUrl = "http://127.0.0.1:8080/ingredients";
            string token = AppState.JwtData.Token;

            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la peticion
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializarla
                        ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse);
                    } else {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ingredients;
        }
    }
}