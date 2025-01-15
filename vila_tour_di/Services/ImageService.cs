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
            return ApiService.Get<List<Image>>($"{baseUrl}/byArticle/{article.id}") ?? new List<Image>();
        }

        public static Image GetImageById(int id) {
            string url = $"{baseUrl}/{id}";
            return ApiService.GetById<Image>(baseUrl, id);
        }

        public static HttpResponseMessage AddImage(Image image) {
            return ApiService.Post(baseUrl, image);
        }

        public static bool UpdateImage(int id, Image image) {
            var response = ApiService.Put($"{baseUrl}/{id}", image);
            return ApiService.HandleResponse(response, "Imagen actualizada correctamente.", "Error al actualizar la imagen");
        }

        public static bool DeleteImage(Image image) {
            var response = ApiService.Delete($"{baseUrl}/{image.id}");
            return response.IsSuccessStatusCode;
            // return ApiService.HandleResponse(response, "Imagen eliminada correctamente.", "Error al eliminar la imagen");
        }

        public static void DeleteAllByArticle(Article article) {
            GetImagesByArticle(article).ForEach(image => DeleteImage(image));
        }
    }
}
