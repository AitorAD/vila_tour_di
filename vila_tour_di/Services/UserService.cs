using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di.Services {
    public class UserService {
        static string endPoint = Config.baseURL + "users";

        // Obtener todos los usuarios
        public static List<User> GetAllUsers() {
            return ApiService.Get<List<User>>(endPoint);
        }

        // Obtener un usuario por ID
        public static User GetUserById(int idUser) {
            string url = $"{endPoint}/{idUser}";
            return ApiService.GetById<User>(endPoint, idUser);
        }

        // Crear un nuevo usuario
        public static bool AddUser(User user) {
            var response = ApiService.Post(endPoint, user);
            return ApiService.HandleResponse(response, "Usuario creado correctamente", "Error al crear el usuario");
        }

        // Actualizar un usuario
        public static bool UpdateUser(int id, User user) {
            string url = $"{endPoint}/{id}";
            var response = ApiService.Put(url, user);
            return ApiService.HandleResponse(response, "Usuario editado correctamente", "Error al editar el usuario");
        }

        // Eliminar un usuario
        public static bool DeleteUser(int id) {
            var response = ApiService.Delete($"{endPoint}/{id}");
            return ApiService.HandleResponse(response, "Usuario eliminado correctamente", "Error al eliminar el usuario");
        }
    }
}