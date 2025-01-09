using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vila_tour_di.Models;

namespace vila_tour_di.Services {
    class RouteService {

        private static string baseUrl = "http://127.0.0.1:8080/routes";

        public static List<Route> GetAllRoutes() {
            return ApiService.Get<List<Route>>(baseUrl);
        }

        public static Route GetRouteById(int idRoute) {
            string url = $"{baseUrl}/{idRoute}";
            return ApiService.GetById<Route>(baseUrl, idRoute);
        }

        public static bool AddRoute(Route route) {
            var response = ApiService.Post(baseUrl, route);
            return ApiService.HandleResponse(response, "Ruta creada correctamente", "Error al crear la receta");
        }

        public static bool UpdateRoute(Route route, Route newRoute) {
            string url = $"{baseUrl}/{route.idRoute}";
            var response = ApiService.Put(url, newRoute);
            return ApiService.HandleResponse(response, "Ruta editada correctamente", "Error al editar la ruta");

        }

        public static bool DeleteRoute(int id) {
            var response = ApiService.Delete($"{baseUrl}/{id}");
            return ApiService.HandleResponse(response, "Ruta eliminada correctamente", "Error al eliminar la ruta");
        }
    }
}
