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
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

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


            if (jsonResponse != null) {
                try {
                    // Deserializar la respuesta JSON a una lista de usuarios
                    var recipes = JsonConvert.DeserializeObject<List<Recipe>>(jsonResponse);

                    Console.WriteLine(jsonResponse);
                    // Agregar los datos de los usuarios al DataTable
                    foreach (var recipe in recipes) {
                        string ingredients = recipe.ingredients?.Any() == true
                            ? string.Join(", ", recipe.ingredients.Select(i => i.name))
                            : "No ingredients";

                        table.Rows.Add(
                            recipe.id,
                            recipe.name,
                            recipe.description,
                            recipe.averageScore,
                            recipe.creationDate,
                            recipe.lastModificationDate,
                            recipe.approved,
                            ingredients
                            );

                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar los datos: " + ex.Message);
                }
            } else {
                MessageBox.Show("No se pudieron obtener los datos.");
            }

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
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {

                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];

                // Atributos
                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/recipes/{id}";
                var client = new RestClient(apiUrl, "GET");
                string jsonResponse = client.GetItem();


                Recipe recipe = null;
                if (jsonResponse != null) {
                    try {
                        recipe = JsonConvert.DeserializeObject<Recipe>(jsonResponse);
                    } catch (Exception ex) {
                        MessageBox.Show("Error al procesar los datos");
                    }
                } else {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddEditRecipe formAddRecipe = new FormAddEditRecipe(recipe, false);
                formAddRecipe.StartPosition = FormStartPosition.CenterParent;
                formAddRecipe.ShowDialog();
                LoadRecipesInDataGridView();
            } else {
                MessageBox.Show("No se ha selecionado niguna receta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetailsRecipe_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRecipes.SelectedRows.Count > 0) {

                var selectedRow = gunaDataGridViewRecipes.SelectedRows[0];

                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                string apiUrl = $"http://127.0.0.1:8080/recipes/{id}";
                var client = new RestClient(apiUrl, "GET");
                string jsonResponse = client.GetItem();


                Recipe recipe = null;
                if (jsonResponse != null) {
                    try {
                        recipe = JsonConvert.DeserializeObject<Recipe>(jsonResponse);
                    } catch (Exception ex) {
                        MessageBox.Show("Error al procesar los datos");
                    }
                } else {
                    MessageBox.Show("No se pudieron obtener los datos");
                }

                FormAddEditRecipe formAddRecipe = new FormAddEditRecipe(recipe, true);
                formAddRecipe.StartPosition = FormStartPosition.CenterParent;
                formAddRecipe.ShowDialog();
                LoadRecipesInDataGridView();
            } else {
                MessageBox.Show("No se ha selecionado niguna receta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string apiUrl = $"http://127.0.0.1:8080/recipes/{recipeId}"; // URL con el ID del usuario
                    var client = new RestClient(apiUrl, "DELETE");

                    try {
                        string response = client.DeleteItem();

                        // Verificar la respuesta
                        if (!string.IsNullOrEmpty(response)) {
                            MessageBox.Show("Receta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show("Error al eliminar la receta. Por favor, inténtalo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Recargar la lista de usuarios después de eliminar
                        originalDataTable = LoadRecipesData();
                        gunaDataGridViewRecipes.DataSource = originalDataTable;
                    } catch (Exception ex) {
                        MessageBox.Show("Ocurrió un error al intentar eliminar la receta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ninguna receta para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
