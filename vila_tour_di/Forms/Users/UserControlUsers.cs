using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Net.Http;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class UserControlUsers : UserControl {
        private DataTable originalDataTable;  // Para almacenar los datos originales sin filtrar
        private List<User> users;  // Lista original de usuarios

        public UserControlUsers() {
            InitializeComponent();

            // Cargar los datos y almacenar una copia sin filtrar
            users = LoadUsersData();
            originalDataTable = LoadUsersDataTable(users);
            gunaDataGridViewUsers.DataSource = originalDataTable;
            gunaDataGridViewUsers.AutoGenerateColumns = true;
            gunaDataGridViewUsers.AutoResizeColumnHeadersHeight();
            gunaDataGridViewUsers.AutoResizeColumns();
            loadCategories();
        }

        public List<User> LoadUsersData() {
            string apiUrl = "http://127.0.0.1:8080/users"; // Ajusta tu URL
            string token = Config.currentToken;

            List<User> userList = new List<User>();

            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la petición
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializarla
                        userList = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
                    } else {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return userList;
        }

        private DataTable LoadUsersDataTable(List<User> usersList) {
            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Usuario");
            table.Columns.Add("Email");
            table.Columns.Add("Rol");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellidos");

            // Agregar los usuarios a la tabla
            foreach (var user in usersList) {
                table.Rows.Add(user.id, user.username, user.email, user.role, user.name, user.surname);
            }

            return table;
        }

        private void loadCategories() {
            List<string> categories = new List<string>
            {
                "Usuario",
                "Email",
                "Rol",
                "Nombre",
                "Apellidos"
            };

            comboBoxCategories.Items.Clear();
            comboBoxCategories.Items.Add("Todos");
            foreach (var category in categories) {
                comboBoxCategories.Items.Add(category);
            }

            comboBoxCategories.SelectedIndex = 0;  // "Todos" por defecto
        }

        private void filterUsers() {
            string selectedCategory = comboBoxCategories.SelectedItem.ToString();
            string searchText = textBoxSearch.Text.ToLower();

            List<User> filteredUsers = users;

            if (selectedCategory != "Todos") {
                switch (selectedCategory) {
                    case "Usuario":
                        filteredUsers = users.Where(u => u.username.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Email":
                        filteredUsers = users.Where(u => u.email.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Rol":
                        filteredUsers = users.Where(u => u.role.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Nombre":
                        filteredUsers = users.Where(u => u.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Apellidos":
                        filteredUsers = users.Where(u => u.surname.ToLower().Contains(searchText)).ToList();
                        break;
                }
            }

            originalDataTable = LoadUsersDataTable(filteredUsers);
            gunaDataGridViewUsers.DataSource = originalDataTable;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            filterUsers();
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e) {
            filterUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e) {
            FormAddEditUser formAddUser = new FormAddEditUser();
            formAddUser.StartPosition = FormStartPosition.CenterParent;
            formAddUser.ShowDialog();

            // Recargar los datos después de añadir un usuario
            users = LoadUsersData();
            originalDataTable = LoadUsersDataTable(users);
            gunaDataGridViewUsers.DataSource = originalDataTable;
        }

        private void btnEditUser_Click(object sender, EventArgs e) {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0) {

                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];

                // Atributos
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/users/{id}";
                // Aquí iría la lógica para editar el usuario
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e) {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar a {selectedRow.Cells["Nombre"].Value}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes) {
                    if (UserService.DeleteUser(userId)) {
                        // Recargar los datos después de eliminar un usuario
                        users = LoadUsersData();
                        originalDataTable = LoadUsersDataTable(users);
                        gunaDataGridViewUsers.DataSource = originalDataTable;
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ningún usuario para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetailsUser_Click(object sender, EventArgs e) {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0) {

                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                User user = new User {
                    id = userId,
                    username = selectedRow.Cells["Usuario"].Value.ToString(),
                    email = selectedRow.Cells["Email"].Value.ToString(),
                    role = selectedRow.Cells["Rol"].Value.ToString(),
                    name = selectedRow.Cells["Nombre"].Value.ToString(),
                    surname = selectedRow.Cells["Apellidos"].Value.ToString()
                };

                // Pasar el usuario al formulario en modo no editable
                FormAddEditUser formDetails = new FormAddEditUser(user, false);
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            } else {
                MessageBox.Show("No se ha seleccionado ningún usuario para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gunaDataGridViewUsers_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (gunaDataGridViewUsers.CurrentRow != null && gunaDataGridViewUsers.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int userId = Convert.ToInt32(gunaDataGridViewUsers.CurrentRow.Cells["Id"].Value);

                // Obtener el usuario usando el servicio
                User selectedUser = UserService.GetUserById(userId);

                // Crear una instancia del formulario para agregar/editar usuarios
                FormAddEditUser formAddEditUser = new FormAddEditUser(selectedUser, false);

                // Mostrar el formulario
                formAddEditUser.ShowDialog(); // Mostrar como formulario modal
            }
        }
    }
}
