using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormIngredient : Form {
        private DataTable originalDatatable;

        public FormIngredient() {
            InitializeComponent();
            // Cargar los datos y almacenar la tabla
            originalDatatable = LoadIngredientsData();
            guna2DataGridView1.DataSource = originalDatatable;
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.AutoResizeColumnHeadersHeight();
            guna2DataGridView1.AutoResizeColumns();
        }

        // Carga los Ingredientes
        public DataTable LoadIngredientsData() {
            
            DataTable table = new DataTable();
                // Definimos las columnas
                table.Columns.Add("ID", typeof(long));  // Usar long para ID
                table.Columns.Add("Nombre");
                table.Columns.Add("Categoria");

            List<Ingredient> ingredients = IngredientService.GetIngredients();

            // Agregamos los users a la tabla
            foreach (var ingredient in ingredients) {
                table.Rows.Add(ingredient.idIngredient, ingredient.name, ingredient.category);
            }

            return table;
        }

        public void LoadIngredientsInDataGridView() {
            DataTable ingredientsTable = LoadIngredientsData(); // Llamamos a LoadIngredients para obtener el DataTable

            // Asignamos el DataTable al DataGridView
            guna2DataGridView1.DataSource = ingredientsTable;

            // Para asegurar que el DataGridView se actualiza, puedes forzar la actualización del control
            guna2DataGridView1.Refresh();
        }

        // Añadir Ingrediente
        private void guna2Button1_Click(object sender, EventArgs e) {
            FormAddEditIngredient formAddIng = new FormAddEditIngredient();
            formAddIng.Owner = this; // Establecer el formulario principal como propietario
            formAddIng.StartPosition = FormStartPosition.CenterParent;
            formAddIng.ShowDialog();
            LoadIngredientsInDataGridView();
        }

        // Editar Ingrediente
        private void btnEditIngredient_Click(object sender, EventArgs e) {
            
        }

        private void btnCategoryIngredient_Click(object sender, EventArgs e) {
            FormCategoriesIngredient formCategories = new FormCategoriesIngredient();
            formCategories.StartPosition = FormStartPosition.CenterParent;
            formCategories.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            // Verificar si hay una fila seleccionada
            if (guna2DataGridView1.SelectedRows.Count > 0) {
                var selectedRow = guna2DataGridView1.SelectedRows[0];

                // Obtener el ID del ingrediente seleccionado
                int idIngredient = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                // Confirmar eliminación
                var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este ingrediente?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);

            } else {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
            guna2DataGridView1.DataSource = LoadIngredientsData();
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            Dispose();
        }


    }
}
