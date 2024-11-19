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
            table.Columns.Add("Aprovado");
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

        private void btnIngredients_Click(object sender, EventArgs e) {
            FormIngredient formIngredient = new FormIngredient();
            formIngredient.StartPosition = FormStartPosition.CenterParent;
            formIngredient.ShowDialog();
        }

        private void buttonAddRecipe_Click(object sender, EventArgs e) {
            FormAddRecipe formAddRecipe = new FormAddRecipe();
            formAddRecipe.StartPosition = FormStartPosition.CenterParent;
            formAddRecipe.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e) {

        }
    }
}
