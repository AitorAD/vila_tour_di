using ClientRESTAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class UserControlPlaces : UserControl {
        private DataTable originalDataTable;
        public UserControlPlaces() {
            InitializeComponent();

            originalDataTable = LoadPlacesData();
            gunaDataGridViewPlaces.DataSource = originalDataTable;
            gunaDataGridViewPlaces.AutoGenerateColumns = true;
            gunaDataGridViewPlaces.AutoResizeColumnHeadersHeight();
            gunaDataGridViewPlaces.AutoResizeColumns();
        }

        public DataTable LoadPlacesData()
        {
            string apiUrl = "http://127.0.0.1:8080/users"; // Ajusta tu URL
            string token = AppState.JwtData.Token;

            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Descripción");
            table.Columns.Add("Puntuación media");
            table.Columns.Add("Creación");
            table.Columns.Add("Última modificación");
            table.Columns.Add("Categoría");
            table.Columns.Add("Creador");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Agregar el token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Hacer la peticion
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializarla
                        var places = JsonConvert.DeserializeObject<List<Place>>(jsonResponse);

                        // Agregamos los users a la tabla
                        foreach (var place in places)
                        {
                            table.Rows.Add(place.id, place.name, place.description, place.averageScore, place.creationDate, place.lastModificationDate, place.categoryPlace, place.creator);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error al obtener los datos: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return table;
        }


        private void btnAdd_Click(object sender, EventArgs e) {
            FormAddPlace formAddPlace = new FormAddPlace();
            formAddPlace.StartPosition = FormStartPosition.CenterParent;
            formAddPlace.ShowDialog();

            originalDataTable = LoadPlacesData();
            gunaDataGridViewPlaces.DataSource = originalDataTable;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0)
            {

                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];

                // Atributos
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/users/{id}";
                var client = new RestClient(apiUrl, "GET");
                string jsonResponse = client.GetItem();


                User user = null;
                if (jsonResponse != null)
                {
                    try
                    {
                        user = JsonConvert.DeserializeObject<User>(jsonResponse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los datos");
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddUser formEditUser = new FormAddUser(user, true);
                formEditUser.StartPosition = FormStartPosition.CenterParent;
                formEditUser.ShowDialog();
                originalDataTable = LoadPlacesData();
                gunaDataGridViewPlaces.DataSource = originalDataTable;
            }
            else
            {
                MessageBox.Show("No se ha selecionado nigún usuario");
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];
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
                        originalDataTable = LoadPlacesData();
                        gunaDataGridViewPlaces.DataSource = originalDataTable;
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
    }
}
