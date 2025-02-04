using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Services {
    class FestivalService {

        private static string baseUrl = Config.baseURL + "festivals";

        // Obtener todos los festivales
        public static List<Festival> GetAllFestivals() {
            return ApiService.Get<List<Festival>>(baseUrl) ?? new List<Festival>();
        }

        // Obtener festival por ID
        public static Festival GetFestivalById(int id) {
            string url = $"{baseUrl}/{id}";
            return ApiService.GetById<Festival>(baseUrl, id);
        }

        // Crear un nuevo festival
        public static bool AddFestival(Festival festival) {
            var response = ApiService.Post(baseUrl, festival);
            return ApiService.HandleResponse(response, "Festival creado correctamente.", "Error al crear el festival");
        }

        // Actualizar festival
        public static bool UpdateFestival(int id, Festival festival) {
            var response = ApiService.Put($"{baseUrl}/{id}", festival);
            return ApiService.HandleResponse(response, "Festival actualizado correctamente.", "Error al actualizar el festival");
        }

        // Eliminar festival
        public static bool DeleteFestival(int festivalId) {
            var response = ApiService.Delete($"{baseUrl}/{festivalId}");
            return ApiService.HandleResponse(response, "Festival eliminado correctamente.", "Error al eliminar el festival");
        }
    }
}
