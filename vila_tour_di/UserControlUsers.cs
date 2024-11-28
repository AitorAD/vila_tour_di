using ClientRESTAPI;
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

        public DataTable LoadUsersData()
        {
            
            string apiUrl = "http://127.0.0.1:8080/users"; // Ajusta tu URL
            string token = AppState.JwtData.Token;

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
            FormAddUser formAddUser = new FormAddUser();
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

                string apiUrl = $"http://127.0.0.1:8080/users/{id}";
                var client = new RestClient(apiUrl, "GET");
                string jsonResponse = client.GetItem();


                User user = null;
                if (jsonResponse != null) {
                    try {
                        user = JsonConvert.DeserializeObject<User>(jsonResponse);
                    } catch (Exception ex) {
                        MessageBox.Show("Error al procesar los datos");
                    }
                } else {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddUser formEditUser = new FormAddUser(user, true);
                formEditUser.StartPosition = FormStartPosition.CenterParent;
                formEditUser.ShowDialog();
                originalDataTable = LoadUsersData();
                gunaDataGridViewUsers.DataSource = originalDataTable;
            } else {
                MessageBox.Show("No se ha selecionado nigún usuario");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    string apiUrl = $"http://127.0.0.1:8080/users/{userId}"; // URL con el ID del usuario
                    var client = new RestClient(apiUrl, "DELETE");

                    try
                    {
                        string response = client.DeleteItem();

                        // Verificar la respuesta
                        if (!string.IsNullOrEmpty(response))
                        {
                            MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el usuario. Por favor, inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Recargar la lista de usuarios después de eliminar
                        originalDataTable = LoadUsersData();
                        gunaDataGridViewUsers.DataSource = originalDataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún usuario para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetailsUser_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewUsers.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewUsers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                User user = new User
                {
                    id = userId,
                    username = selectedRow.Cells["Usuario"].Value.ToString(),
                    email = selectedRow.Cells["Email"].Value.ToString(),
                    role = selectedRow.Cells["Rol"].Value.ToString(),
                    name = selectedRow.Cells["Nombre"].Value.ToString(),
                    surname = selectedRow.Cells["Apellidos"].Value.ToString(),
                    // profilePicture = selectedRow.Cells["ProfilePicture"].Value.ToString()
                };

                // Pasar el usuario al formulario en modo no editable
                FormAddUser formDetails = new FormAddUser(user, false);
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún usuario para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
