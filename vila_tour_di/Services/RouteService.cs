using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vila_tour_di.Models;

namespace vila_tour_di.Services {
    class RouteService {

        private static string baseUrl = Config.baseURL + "routes";

        public static List<RouteVilaTour> GetAllRoutes() {
            return ApiService.Get<List<RouteVilaTour>>(baseUrl);
        }

        public static RouteVilaTour GetRouteById(int idRoute) {
            string url = $"{baseUrl}/{idRoute}";
            return ApiService.GetById<RouteVilaTour>(baseUrl, idRoute);
        }

        public static bool AddRoute(RouteVilaTour route) {
            var response = ApiService.Post(baseUrl, route);
            return ApiService.HandleResponse(response, "Ruta creada correctamente", "Error al crear la receta");
        }

        public static bool UpdateRoute(RouteVilaTour route, RouteVilaTour newRoute) {
            string url = $"{baseUrl}/{route.id}";
            var response = ApiService.Put(url, newRoute);
            return ApiService.HandleResponse(response, "Ruta editada correctamente", "Error al editar la ruta");

        }

        public static bool DeleteRoute(int id) {
            var response = ApiService.Delete($"{baseUrl}/{id}");
            return ApiService.HandleResponse(response, "Ruta eliminada correctamente", "Error al eliminar la ruta");
        }
    }
}
