using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Services
{
    class CoordinateService
    {

        private static string baseUrl = "http://127.0.0.1:8080/coordinates";

        // Obtener todas las coordenadas
        public static List<Coordinate> GetAllCoordinates()
        {
            return ApiService.Get<List<Coordinate>>(baseUrl) ?? new List<Coordinate>();
        }

        // Obtener coordenada por ID
        public static Coordinate GetCoordinateById(int id)
        {
            return ApiService.GetById<Coordinate>(baseUrl, id);
        }

        // Crear una nueva coordenada
        public static HttpResponseMessage AddCoordinate(Coordinate coordinate)
        {
            HttpResponseMessage response = ApiService.Post(baseUrl, coordinate);
            return response;
        }

        // Actualizar coordenada
        public static bool UpdateCoordinate(Coordinate coordinate)
        {
            var response = ApiService.Put($"{baseUrl}/{coordinate.id}", coordinate);
            return ApiService.HandleResponse(response, "Coordenada actualizada correctamente.", "Error al actualizar la coordenada");
        }

        // Eliminar coordenada
        public static bool DeleteCoordinate(int coordinateId)
        {
            var response = ApiService.Delete($"{baseUrl}/{coordinateId}");
            return ApiService.HandleResponse(response, "Coordenada eliminada correctamente.", "Error al eliminar la coordenada");
        }
    }
}
