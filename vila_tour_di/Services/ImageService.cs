using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using vila_tour_di.Models;

namespace vila_tour_di.Services {
    class ImageService {
        private static string baseUrl = "http://127.0.0.1:8080/images";

        public static List<Image> GetImages() {
            return ApiService.Get<List<Image>>(baseUrl) ?? new List<Image>();
        }

        public static List<Image> GetImagesByArticle(Article article) {
            return ApiService.Get<List<Image>>($"{baseUrl}/{article.id}") ?? new List<Image>();
        }

        public static Image GetImageById(int id) {
            string url = $"{baseUrl}/{id}";
            return ApiService.GetById<Image>(baseUrl, id);
        }

        public static bool AddImage(Image image) {
            var response = ApiService.Post(baseUrl, image);
            return ApiService.HandleResponse(response, "Imagen creada correctamente.", "Error al crear la imagen");
        }

        public static bool UpdateImage(int id, Image image) {
            var response = ApiService.Put($"{baseUrl}/{id}", image);
            return ApiService.HandleResponse(response, "Image actualizada correctamente.", "Error al actualizar la imagen");
        }

        public static bool DeleteImage(int imageId) {
            var response = ApiService.Delete($"{baseUrl}/{imageId}");
            return ApiService.HandleResponse(response, "Imagen eliminada correctamente.", "Error al eliminar la imagen");
        }
    }
}
