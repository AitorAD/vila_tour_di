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

        public UserControlUsers() {
            InitializeComponent();

            // Cargar los datos y almacenar una copia sin filtrar
            originalDataTable = LoadUsersData();
            gunaDataGridViewUsers.DataSource = originalDataTable;
            gunaDataGridViewUsers.AutoGenerateColumns = true;
            gunaDataGridViewUsers.AutoResizeColumnHeadersHeight();
            gunaDataGridViewUsers.AutoResizeColumns();
        }

        public DataTable LoadUsersData() {

            string apiUrl = "http://127.0.0.1:8080/users"; // Ajusta tu URL
            string token = Config.currentToken;

            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Usuario");
            table.Columns.Add("Email");
            table.Columns.Add("Rol");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellidos");

            using (HttpClient client = new HttpClient()) {
                try {
                    // Agregar el token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la peticion
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode) {
                        // Leer la respuesta
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializarla
                        var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                        // Agregamos los users a la tabla
                        foreach (var user in users) {
                            table.Rows.Add(user.id, user.username, user.email, user.role, user.name, user.surname);
                        }
                    } else {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return table;
        }

        private void btnAddUser_Click(object sender, EventArgs e) {
            FormAddEditUser formAddUser = new FormAddEditUser();
            formAddUser.StartPosition = FormStartPosition.CenterParent;
            formAddUser.ShowDialog();

            originalDataTable = LoadUsersData();
            gunaDataGridViewUsers.DataSource = originalDataTable;
        }

        private void btnEditUser_Click(object sender, EventArgs e) {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];
                // Atributos
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                User user = UserService.GetUserById(id);

                FormAddEditUser formAddEditUser = new FormAddEditUser(user, true);
                formAddEditUser.StartPosition = FormStartPosition.CenterParent;
                formAddEditUser.ShowDialog();
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
                        // Recargar los datos y actualizar la vista
                        originalDataTable = LoadUsersData();
                        gunaDataGridViewUsers.DataSource = originalDataTable;
                    } else {
                        MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    surname = selectedRow.Cells["Apellidos"].Value.ToString(),
                    // profilePicture = selectedRow.Cells["ProfilePicture"].Value.ToString()
                };

                // Pasar el usuario al formulario en modo no editable
                FormAddEditUser formDetails = new FormAddEditUser(user, false);
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            } else {
                MessageBox.Show("No se ha seleccionado ningún usuario para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
