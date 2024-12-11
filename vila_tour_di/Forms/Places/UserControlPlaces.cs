using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;
using vila_tour_di.Services;
using vila_tour_di.Forms.Places;

namespace vila_tour_di {
    public partial class UserControlPlaces : UserControl {
        private DataTable originalDataTable;
        private string jsonResponse;

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
            string apiUrl = "http://127.0.0.1:8080/places"; // Ajusta tu URL
            string token = Config.currentToken;

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
                            table.Rows.Add(place.id, place.name, place.description, place.averageScore, place.creationDate, place.lastModificationDate, place.categoryPlace?.name ?? "Sin asignar", place.creator.name);
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
            FormAddEditPlace formAddPlace = new FormAddEditPlace();
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

                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/places/{id}";
                string token = Config.currentToken;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            jsonResponse = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            MessageBox.Show("Error en la solicitud: " + response.ReasonPhrase, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Place place = null;
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    try
                    {
                        place = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los datos: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddEditPlace formAddEditPlace = new FormAddEditPlace(place, true);
                formAddEditPlace.StartPosition = FormStartPosition.CenterParent;
                formAddEditPlace.ShowDialog();
                originalDataTable = LoadPlacesData();
                gunaDataGridViewPlaces.DataSource = originalDataTable;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún lugar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/places/{id}";
                string token = Config.currentToken;
                string jsonResponse = null;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            jsonResponse = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            MessageBox.Show("Error en la solicitud: " + response.ReasonPhrase, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Place place = null;
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    try
                    {
                        place = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los datos: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddEditPlace formDetails = new FormAddEditPlace(place, false); // Modo no editable
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún lugar para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0)
            {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este lugar?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    string apiUrl = $"http://127.0.0.1:8080/places/{id}"; // URL con el ID del lugar
                    string token = Config.currentToken;

                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                            HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Lugar eliminado correctamente", "Información",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                originalDataTable = LoadPlacesData();
                                gunaDataGridViewPlaces.DataSource = originalDataTable;
                            }
                            else
                            {
                                MessageBox.Show($"Error al eliminar el lugar: {response.StatusCode} - {response.ReasonPhrase}", "Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún lugar para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCategoriesPlace_Click(object sender, EventArgs e)
        {
            FormCategoryPlace formCategories = new FormCategoryPlace();
            formCategories.StartPosition = FormStartPosition.CenterParent;
            formCategories.ShowDialog();
        }
    }
}
