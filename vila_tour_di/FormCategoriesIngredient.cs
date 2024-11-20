using ClientRESTAPI;
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
            FormAddCategoryIngredient formAddCategory = new FormAddCategoryIngredient();
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
                    FormAddCategoryIngredient formAddCategory = new FormAddCategoryIngredient(category);
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

        }

        private void bttnExit_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
