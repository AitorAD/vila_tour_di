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
    public partial class UserControlRecipes : UserControl {
        private DataTable originalDataTable;  // Para almacenar los datos originales sin filtrar
        public UserControlRecipes() {
            InitializeComponent();

            // Cargar los datos y almacenar una copia sin filtrar
            originalDataTable = LoadRecipesData();
            gunaDataGridViewRecipes.DataSource = originalDataTable;
            gunaDataGridViewRecipes.AutoGenerateColumns = true;
            gunaDataGridViewRecipes.AutoResizeColumnHeadersHeight();
            gunaDataGridViewRecipes.AutoResizeColumns();
        }

        // Carga las recetas
        public DataTable LoadRecipesData() {
            string apiUrl = "http://127.0.0.1:8080/recipes"; // Ajusta tu URL

            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Descripción");
            table.Columns.Add("Puntuación Media");
            table.Columns.Add("Fecha de creación");
            table.Columns.Add("Última modificación");
            table.Columns.Add("Aprobado");
            table.Columns.Add("Ingredientes");


            return table;
        }

        public void LoadRecipesInDataGridView() {
            DataTable ingredientsTable = LoadRecipesData(); // Llamamos a LoadIngredients para obtener el DataTable

            // Asignamos el DataTable al DataGridView
            gunaDataGridViewRecipes.DataSource = ingredientsTable;

            // Para asegurar que el DataGridView se actualiza, puedes forzar la actualización del control
            gunaDataGridViewRecipes.Refresh();
        }

        private void btnIngredients_Click(object sender, EventArgs e) {
            FormIngredient formIngredient = new FormIngredient();
            formIngredient.StartPosition = FormStartPosition.CenterParent;
            formIngredient.ShowDialog();
        }

        private void buttonAddRecipe_Click(object sender, EventArgs e) {
            FormAddEditRecipe formAddRecipe = new FormAddEditRecipe();
            formAddRecipe.StartPosition = FormStartPosition.CenterParent;
            formAddRecipe.ShowDialog();
            LoadRecipesInDataGridView();
        }

        private void btnEditRecipe_Click(object sender, EventArgs e) {

        }

        private void btnDetailsRecipe_Click(object sender, EventArgs e) {

        }

        private void btnDeleterecipe_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];
                int recipeId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta receta?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes) {

                } else {
                    MessageBox.Show("No se ha seleccionado ninguna receta para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

