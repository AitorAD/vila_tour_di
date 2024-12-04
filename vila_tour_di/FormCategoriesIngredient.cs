using ClientRESTAPI;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormCategoriesIngredient : Form {

        private DataTable originalDatatable;

        public FormCategoriesIngredient() {
            InitializeComponent();

            // Cargar los datos
            originalDatatable = loadCategoriesData();
            guna2DataGridViewCATING.DataSource = originalDatatable;
            guna2DataGridViewCATING.AutoGenerateColumns = true;
            guna2DataGridViewCATING.AutoResizeColumnHeadersHeight();
            guna2DataGridViewCATING.AutoResizeColumns();
        }

        public DataTable loadCategoriesData() {

            Console.WriteLine("Cargando categorias");

            string apiUrl = "http://127.0.0.1:8080/categories";
            string token = AppState.JwtData.Token;

            DataTable table = new DataTable();

                // Definimos las columnas de la tabla
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Nombre");

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
                        var categories = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                        // Agregamos los users a la tabla
                        foreach (var category in categories) {
                            table.Rows.Add(category.id, category.name);
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

        public void loadCategoriesInDataGridView() {
            DataTable categoriesTable = loadCategoriesData();

            guna2DataGridViewCATING.DataSource = categoriesTable;

            guna2DataGridViewCATING.Refresh();
        }

        private void bttnAddCategoryIngredient_Click(object sender, EventArgs e) {
            FormAddEditCategoryIngredient formAddCategory = new FormAddEditCategoryIngredient();
            formAddCategory.StartPosition = FormStartPosition.CenterParent;
            formAddCategory.ShowDialog();
            loadCategoriesInDataGridView();

        }

        private void btnEditCategoryIngredient_Click(object sender, EventArgs e) {
            try {
                if (guna2DataGridViewCATING.SelectedRows.Count > 0) {
                    // Obtener la fila seleccionada
                    DataGridViewRow selectedRow = guna2DataGridViewCATING.SelectedRows[0];

                    // Extraer los valores de la fila seleccionada
                    int  id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value); // Columna "ID"
                    string name = selectedRow.Cells["Nombre"].Value.ToString(); // Columna "Nombre"

                    // Crear el objeto CategoryIngredient
                    CategoryIngredient category = new CategoryIngredient {
                        id = id,
                        name = name
                    };

                    // Crear y mostrar el formulario de edición
                    FormAddEditCategoryIngredient formAddCategory = new FormAddEditCategoryIngredient(category);
                    formAddCategory.StartPosition = FormStartPosition.CenterParent;
                    formAddCategory.ShowDialog();

                    // Recargar los datos en el DataGridView después de editar
                    loadCategoriesInDataGridView();
                } else {
                    MessageBox.Show("Por favor, selecciona una categoría para editar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Ocurrió un error al intentar editar la categoría: {ex.Message}");
            }
           
        }

        private void btnDeleteCategoryIngredient_Click(object sender, EventArgs e) {
            // Verificar si hay una fila seleccionada
            if (guna2DataGridViewCATING.SelectedRows.Count > 0) {
                var selectedRow = guna2DataGridViewCATING.SelectedRows[0];

                // Obtener el ID de la categoria seleccionada
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                // Confirmar eliminación
                var confirmResult = MessageBox.Show($"¿Estás seguro de que quieres eliminar {selectedRow.Cells["Nombre"].Value}?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes) {
                    // Crear la URL para el DELETE con el ID de la categoria
                    string url = $"http://127.0.0.1:8080/categories/{id}";
                    string token = AppState.JwtData.Token;


                    try {
                        using (HttpClient client = new HttpClient()) {

                            // Agregar token al encabezado
                            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                            // Solicitud Delete
                            HttpResponseMessage response = client.DeleteAsync(url).Result;

                            // Verificar la respuesta
                            if (response.IsSuccessStatusCode) {
                                MessageBox.Show("Categoría eliminada exitosamente.");
                                guna2DataGridViewCATING.DataSource = loadCategoriesData();
                            } else {
                                MessageBox.Show($"Error al eliminar el producto: {response.StatusCode} - {response.ReasonPhrase}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    } catch (Exception ex){
                        MessageBox.Show($"Ocurrió un error al procesar la solicitud: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
            guna2DataGridViewCATING.DataSource = loadCategoriesData();
        }

        private void bttnExit_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
