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
using vila_tour_di.Forms.Recipes;
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

                // Muestra la cantidad de notificaciones
                int notification = recipes.Count(recipe => recipe.recent);
                btnBell.Text = notification > 99 ? "99+" : (notification > 0 ? notification.ToString() : null);

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

                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(recipe, true);
                formAddEditRecipe.StartPosition = FormStartPosition.CenterParent;
                formAddEditRecipe.ShowDialog();
            }
        }

        private void btnDetailsRecipe_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];

                int id = int.Parse(selectedRow.Cells["ID"].Value.ToString());

                Recipe selectedRecipe = RecipeService.GetRecipeById(id);

                FormAddEditRecipe formDetails = new FormAddEditRecipe(selectedRecipe, false);
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            } else {
                MessageBox.Show("No se ha seleccionado ninguna receta para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnBell_Click(object sender, EventArgs e) {
            FormApprove formApprove = new FormApprove(this);
            formApprove.Show();
        }
    }
}

