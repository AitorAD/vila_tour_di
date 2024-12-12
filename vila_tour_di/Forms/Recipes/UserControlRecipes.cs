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
using vila_tour_di.Services;

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
            string token = Config.currentToken;

            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Descripción");
            table.Columns.Add("P. Media");
            table.Columns.Add("Aprobado");
            table.Columns.Add("Ingredientes");
            table.Columns.Add("Creador");
            table.Columns.Add("Fecha de creación");
            table.Columns.Add("Última modificación");

            try {
                var recipes = RecipeService.GetAllRecipes();

                foreach(var recipe in recipes) {
                    string ingredients = string.Join(", ", recipe.ingredients.Select(i => i.name));
                    table.Rows.Add(recipe.id, recipe.name, recipe.description, recipe.averageScore, recipe.approved, ingredients, recipe.creator.name, recipe.creationDate, recipe.lastModificationDate);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al procesar la solicitud: " + ex.Message, "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
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
            LoadRecipesData();
        }

        private void btnEditRecipe_Click(object sender, EventArgs e) {
            if(gunaDataGridViewRecipes.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                Recipe recipe = RecipeService.GetRecipeById(id);

                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(recipe, false);
                formAddEditRecipe.StartPosition = FormStartPosition.CenterParent;
                formAddEditRecipe.ShowDialog();
            }
        }

        private void btnDetailsRecipe_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];
                try {
                    int recipeId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    string name = selectedRow.Cells["Nombre"]?.Value?.ToString() ?? "Sin nombre";
                    string description = selectedRow.Cells["Descripción"]?.Value?.ToString() ?? "Sin descripción";
                    double averageScore = selectedRow.Cells["P. Media"].Value != null
                        ? Convert.ToDouble(selectedRow.Cells["P. Media"].Value)
                        : 0.0;
                    DateTime creationDate = selectedRow.Cells["Fecha de creación"].Value != null
                        ? Convert.ToDateTime(selectedRow.Cells["Fecha de creación"].Value)
                        : DateTime.MinValue;
                    DateTime lastModificationDate = selectedRow.Cells["Última modificación"].Value != null
                        ? Convert.ToDateTime(selectedRow.Cells["Última modificación"].Value)
                        : DateTime.MinValue;
                    bool approved = selectedRow.Cells["Aprobado"].Value != null
                        ? Convert.ToBoolean(selectedRow.Cells["Aprobado"].Value)
                        : false;

                    // Crear la instancia de Recipe
                    Recipe recipe = new Recipe {
                        id = recipeId,
                        name = name,
                        description = description,
                        averageScore = averageScore,
                        creationDate = creationDate,
                        lastModificationDate = lastModificationDate,
                        approved = approved,
                    };

                    // Abrir el formulario de detalles en modo no editable
                    FormAddEditRecipe formDetails = new FormAddEditRecipe(recipe, true);
                    formDetails.StartPosition = FormStartPosition.CenterParent;
                    formDetails.ShowDialog();
                } catch (Exception ex) {
                    MessageBox.Show($"Ocurrió un error al cargar los detalles de la receta: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("No se ha seleccionado ninguna receta para ver los detalles.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    RecipeService.DeleteRecipe(recipeId);
                } else {
                    MessageBox.Show("No se ha seleccionado ninguna receta para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                gunaDataGridViewRecipes.DataSource = LoadRecipesData();
            }
        }
    }
}

