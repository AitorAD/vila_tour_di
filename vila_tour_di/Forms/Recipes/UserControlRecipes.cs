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
using vila_tour_di.Forms.Commons;
using vila_tour_di.Forms.Recipes;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class UserControlRecipes : UserControl {
        private DataTable originalDataTable;  // Para almacenar los datos originales sin filtrar
        List<Recipe> recipes = RecipeService.GetAllRecipes();

        public UserControlRecipes() {
            InitializeComponent();
            originalDataTable = LoadRecipesData();
            gunaDataGridViewRecipes.DataSource = originalDataTable;
            gunaDataGridViewRecipes.AutoGenerateColumns = true;
            gunaDataGridViewRecipes.AutoResizeColumnHeadersHeight();
            gunaDataGridViewRecipes.AutoResizeColumns();

            loadCategories();
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
                foreach (var recipe in recipes) {
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
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                Recipe recipe = RecipeService.GetRecipeById(id);

                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(recipe, true);
                formAddEditRecipe.StartPosition = FormStartPosition.CenterParent;
                formAddEditRecipe.ShowDialog();
            }
        }

        private void btnDetailsRecipe_Click(object sender, EventArgs e) {
            FormReport formReports = new FormReport(recipes);
            formReports.StartPosition = FormStartPosition.CenterParent;
            formReports.ShowDialog();
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

        private void gunaDataGridViewRecipes_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (gunaDataGridViewRecipes.CurrentRow != null && gunaDataGridViewRecipes.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int recipeId = Convert.ToInt32(gunaDataGridViewRecipes.CurrentRow.Cells["Id"].Value);

                // Obtener la receta usando el servicio
                Recipe selectedRecipe = RecipeService.GetRecipeById(recipeId);

                // Crear una instancia del formulario para agregar/editar recetas
                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(selectedRecipe, false);

                // Mostrar el formulario
                formAddEditRecipe.ShowDialog(); // Mostrar como formulario modal
            }
        }

        private void loadCategories() {
            List<string> categories = new List<string>
            {
                "Nombre",
                "Descripción",
                "P. Media",
                "Aprobado",
                "Creador"
            };

            comboBoxCategories.Items.Clear();
            comboBoxCategories.Items.Add("Todos");
            foreach (var category in categories) {
                comboBoxCategories.Items.Add(category);
            }

            comboBoxCategories.SelectedIndex = 0;  // "Todos" por defecto
        }

        // Evento cuando cambia el texto en el TextBox de búsqueda
        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            filterRecipes();
        }

        // Evento cuando cambia la categoría seleccionada en el ComboBox
        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e) {
            filterRecipes();
        }

        // Filtrar las recetas según la categoría y el texto de búsqueda
        private void filterRecipes() {
            string selectedCategory = comboBoxCategories.SelectedItem.ToString();
            string searchText = textBoxSearch.Text.ToLower();

            List<Recipe> filteredRecipes = recipes;

            if (selectedCategory != "Todos") {
                switch (selectedCategory) {
                    case "Nombre":
                        filteredRecipes = recipes.Where(r => r.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Descripción":
                        filteredRecipes = recipes.Where(r => r.description.ToLower().Contains(searchText)).ToList();
                        break;
                    case "P. Media":
                        filteredRecipes = recipes.Where(r => r.averageScore.ToString().ToLower().Contains(searchText)).ToList();
                        break;
                    case "Aprobado":
                        filteredRecipes = recipes.Where(r => r.approved.ToString().ToLower().Contains(searchText)).ToList();
                        break;
                    case "Creador":
                        filteredRecipes = recipes.Where(r => r.creator.name.ToLower().Contains(searchText)).ToList();
                        break;
                }
            }

            originalDataTable = LoadRecipesDataTable(filteredRecipes);
            gunaDataGridViewRecipes.DataSource = originalDataTable;
        }

        // Convertir la lista de recetas filtradas en un DataTable
        private DataTable LoadRecipesDataTable(List<Recipe> recipesList) {
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

            // Agregar las recetas filtradas al DataTable
            foreach (var recipe in recipesList) {
                string ingredients = string.Join(", ", recipe.ingredients.Select(i => i.name));
                table.Rows.Add(recipe.id, recipe.name, recipe.description, recipe.averageScore, recipe.approved, ingredients, recipe.creator.name, recipe.creationDate, recipe.lastModificationDate);
            }

            return table;
        }
    }
    
}
