using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using vila_tour_di.Services;

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

            DataTable table = new DataTable();

                // Definimos las columnas de la tabla
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Nombre");

            List<CategoryIngredient> categories = CategoryIngredientService.GetCategoriesIngredient();

            foreach (var category in categories) {
                table.Rows.Add(category.id, category.name);
            }
            return table;
        }

        public void LoadCategoriesInDataGridView() {
            DataTable categoriesTable = loadCategoriesData();
            guna2DataGridViewCATING.DataSource = categoriesTable;
            guna2DataGridViewCATING.Refresh();
        }

        private void bttnAddCategoryIngredient_Click(object sender, EventArgs e) {
            FormAddEditCategoryIngredient formAddCategory = new FormAddEditCategoryIngredient();
            formAddCategory.StartPosition = FormStartPosition.CenterParent;
            formAddCategory.ShowDialog();
            LoadCategoriesInDataGridView();

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
                    LoadCategoriesInDataGridView();
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

                    // Llamar al método de eliminación en CategoryService
                    bool success = CategoryIngredientService.DeleteCategory(id);

                    if (success) {
                        // Actualizar la vista de las categorías
                        guna2DataGridViewCATING.DataSource = loadCategoriesData();
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
        }

        private void bttnExit_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
