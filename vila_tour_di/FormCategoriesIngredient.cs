using ClientRESTAPI;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormCategoriesIngredient : Form {

        private DataTable originalDatatable;

        public FormCategoriesIngredient() {
            InitializeComponent();
            originalDatatable = loadCategories();
            guna2DataGridViewCATING.DataSource = originalDatatable;
            guna2DataGridViewCATING.AutoGenerateColumns = true;
            
        }

        public DataTable loadCategories() {
            Console.WriteLine("Cargando categorias");

            string apiUrl = "http://127.0.0.1:8080/categories";
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(long));
            table.Columns.Add("Categoria");

            if (jsonResponse != null) {
                try {
                    var categories = JsonConvert.DeserializeObject<List<CategoryIngredient>>(jsonResponse);

                    foreach (var category in categories) {
                        table.Rows.Add(category.id, category.name);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar los datos");
                }
            } else {
                MessageBox.Show("No s epudieron obtener los datos");
            }
            Console.WriteLine(jsonResponse);
            return table;
        }

        public void loadCategoriesInDataGridView() {
            DataTable categoriesTable = loadCategories();

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
                    string name = selectedRow.Cells["Categoria"].Value.ToString(); // Columna "Categoria"

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
                    MessageBox.Show("Por favor, selecciona una categoría para editar.");
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
                var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar esta categoria?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes) {
                    // Crear la URL para el DELETE con el ID de la categoria
                    string url = $"http://127.0.0.1:8080/categories/{id}";
                    RestClient client = new RestClient(url, "DELETE");

                    // Realizar la solicitud DELETE
                    string response = client.DeleteItem();  // Método DELETE en RestClient, pero si tienes un método específico usa client.deleteItem()

                    // Verificar la respuesta y actualizar el DataGridView si fue exitoso
                    if (!string.IsNullOrEmpty(response)) {
                        MessageBox.Show("Categoria eliminada exitosamente.");
                        loadCategories(); // Llama a un método que recargue los datos en el DataGridView
                    } else {
                        MessageBox.Show("Error al eliminar el ingrediente.");
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
            guna2DataGridViewCATING.DataSource = loadCategories();
        }

        private void bttnExit_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
