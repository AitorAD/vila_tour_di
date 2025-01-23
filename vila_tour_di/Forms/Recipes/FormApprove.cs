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

namespace vila_tour_di.Forms.Recipes {
    public partial class FormApprove : Form {
        private UserControlRecipes _userControlRecipes;

        public FormApprove(UserControlRecipes userControlRecipes) {
            InitializeComponent();
            loadRecipesInGridView();
            _userControlRecipes = userControlRecipes;
        }

        private DataTable loadRecipesData() {
            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Descripción");
            table.Columns.Add("P. Media");
            table.Columns.Add("Aprobado");
            table.Columns.Add("Ingredientes");
            table.Columns.Add("Creador");
            table.Columns.Add("Fecha de creación");
            table.Columns.Add("Última modificación");

            List<Recipe> recipes = RecipeService.GetAllRecipes().Where(recipe => recipe.recent && !recipe.approved).ToList();

            Console.WriteLine(recipes.Count);

            // Agregamos los users a la tabla
            foreach (var recipe in recipes) {
                string ingredients = string.Join(", ", recipe.ingredients.Select(i => i.name));
                table.Rows.Add(
                    recipe.id,
                    recipe.name,
                    recipe.description,
                    recipe.averageScore,
                    recipe.approved,
                    ingredients,
                    recipe.creator.name,
                    recipe.creationDate,
                    recipe.lastModificationDate
                    );
            }

            return table;
        }

        private void loadRecipesInGridView() {
            DataTable recipesTable = loadRecipesData();
            tblUnapprovedRecipes.DataSource = recipesTable;
            tblUnapprovedRecipes.Refresh();
        }

        private void btnDetails_Click(object sender, EventArgs e) {
            if (tblUnapprovedRecipes.CurrentRow != null && tblUnapprovedRecipes.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int recipeId = Convert.ToInt32(tblUnapprovedRecipes.CurrentRow.Cells["Id"].Value);

                // Obtener la receta usando el servicio
                Recipe selectedRecipe = RecipeService.GetRecipeById(recipeId);

                // Crear una instancia del formulario para agregar/editar recetas
                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(selectedRecipe, false);

                // Mostrar el formulario
                formAddEditRecipe.ShowDialog(); // Mostrar como formulario modal
            } else {
                MessageBox.Show("Por favor, seleccione una fila antes de realizar esta acción.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e) {
            if (tblUnapprovedRecipes.CurrentRow != null && tblUnapprovedRecipes.CurrentRow.Index >= 0) {
                int recipeId = Convert.ToInt32(tblUnapprovedRecipes.CurrentRow.Cells["Id"].Value);
                Recipe selectedRecipe = RecipeService.GetRecipeById(recipeId);
                Console.WriteLine(recipeId);
                Console.WriteLine("RECETAAAA" + selectedRecipe.ToString());
                if (ApproveDisapproveRecipe(true, selectedRecipe)) {
                    MessageBox.Show("La receta se ha aprobado correctamente.",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    loadRecipesInGridView();
                } else {
                    MessageBox.Show("Ha ocurrido un error durante la operación. Por favor, inténtelo nuevamente.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            } else {
                MessageBox.Show("Por favor, seleccione una fila antes de realizar esta acción.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e) {
            if (tblUnapprovedRecipes.CurrentRow != null && tblUnapprovedRecipes.CurrentRow.Index >= 0) {
                int recipeId = Convert.ToInt32(tblUnapprovedRecipes.CurrentRow.Cells["Id"].Value);
                Recipe selectedRecipe = RecipeService.GetRecipeById(recipeId);

                if (ApproveDisapproveRecipe(false, selectedRecipe)) {
                    MessageBox.Show("La receta se ha desaprobado correctamente.",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    loadRecipesInGridView();
                } else {
                    MessageBox.Show("Ha ocurrido un error durante la operación. Por favor, inténtelo nuevamente.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            } else {
                MessageBox.Show("Por favor, seleccione una fila antes de realizar esta acción.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void tblUnapprovedRecipes_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (tblUnapprovedRecipes.CurrentRow != null && tblUnapprovedRecipes.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int recipeId = Convert.ToInt32(tblUnapprovedRecipes.CurrentRow.Cells["Id"].Value);

                // Obtener la receta usando el servicio
                Recipe selectedRecipe = RecipeService.GetRecipeById(recipeId);

                // Crear una instancia del formulario para agregar/editar recetas
                FormAddEditRecipe formAddEditRecipe = new FormAddEditRecipe(selectedRecipe, false);

                // Mostrar el formulario
                formAddEditRecipe.ShowDialog(); // Mostrar como formulario modal
            }
        }

        private bool ApproveDisapproveRecipe(bool isApproved, Recipe recipe) {
            Recipe newRecipe = recipe;
            newRecipe.approved = isApproved;
            newRecipe.recent = false;
            newRecipe.images.Clear();
            return RecipeService.UpdateRecipe(recipe, newRecipe);
        }

        private void FormApprove_FormClosed(object sender, FormClosedEventArgs e) {
            _userControlRecipes?.LoadRecipesData();
        }
    }
}
