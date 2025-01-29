using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace vila_tour_di.Services {
    public static class Config {
        public static User currentUser;
        public static string currentToken;
        public static string baseURL;

        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        static Config() {
            LoadBaseUrl(); // Se ejecuta solo cuando la clase es usada por primera vez
        }

        private static void LoadBaseUrl() {
            try {
                Console.WriteLine($"📂 Buscando archivo en: {configFilePath}");

                if (File.Exists(configFilePath)) {
                    string json = File.ReadAllText(configFilePath);
                    Console.WriteLine($"📖 Contenido del JSON leído: {json}");

                    JObject config = JObject.Parse(json);
                    string url = config["BaseUrl"]?.ToString();

                    if (!string.IsNullOrEmpty(url)) {
                        baseURL = url;
                        Console.WriteLine($"✅ URL cargada correctamente: {baseURL}");
                        return;
                    } else {
                        Console.WriteLine("⚠️ La clave 'BaseUrl' está vacía o no existe.");
                    }
                } else {
                    Console.WriteLine("⚠️ Archivo config.json no encontrado. Se usará la URL por defecto.");
                }
            } catch (Exception ex) {
                Console.WriteLine($"❌ Error al leer la configuración: {ex.Message}");
            }

            baseURL = "http://127.0.0.1:8080";
            Console.WriteLine($"🔁 Usando BaseUrl por defecto: {baseURL}");
        }

        public static void SetBaseUrl(string nuevaUrl) {
            SaveBaseUrl(nuevaUrl);
            baseURL = nuevaUrl; // Actualizar la variable en memoria
        }

        private static void SaveBaseUrl(string url) {
            try {
                JObject config = new JObject {
                    ["BaseUrl"] = url
                };

                File.WriteAllText(configFilePath, config.ToString());
                Console.WriteLine("✅ Configuración guardada correctamente.");
            } catch (Exception ex) {
                Console.WriteLine($"❌ Error al guardar la configuración: {ex.Message}");
            }
        }
    }
}
