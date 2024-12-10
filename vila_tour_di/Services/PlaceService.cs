using System;
using System.Collections.Generic;

namespace vila_tour_di.Services {
    class PlaceService {

        private static string baseUrl = "http://127.0.0.1:8080/places";

        // Obtener todos los lugares
        public static List<Place> GetAllPlaces() {
            return ApiService.Get<List<Place>>(baseUrl) ?? new List<Place>();
        }

        // Obtener lugar por ID
        public static Place GetPlaceById(int id) {
            string url = $"{baseUrl}/{id}";
            return ApiService.GetById<Place>(baseUrl, id);
        }

        // Crear un nuevo lugar
        public static bool AddPlace(Place place) {
            var response = ApiService.Post(baseUrl, place);
            return ApiService.HandleResponse(response, "Lugar creado correctamente.", "Error al crear el lugar");
        }

        // Actualizar lugar
        public static bool UpdatePlace(Place place, Place newPlace) {
            var response = ApiService.Put($"{baseUrl}/{place.id}", newPlace);
            return ApiService.HandleResponse(response, "Lugar actualizado correctamente.", "Error al actualizar el lugar");
        }

        // Eliminar lugar
        public static bool DeletePlace(int placeId) {
            var response = ApiService.Delete($"{baseUrl}/{placeId}");
            return ApiService.HandleResponse(response, "Lugar eliminado correctamente.", "Error al eliminar el lugar");
        }
    }
}
