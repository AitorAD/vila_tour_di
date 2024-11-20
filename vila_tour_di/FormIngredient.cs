using ClientRESTAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormIngredient : Form {
        private DataTable originalDatatable;

        public FormIngredient() {
            InitializeComponent();
            // Cargar los datos y almacenar la tabla
            originalDatatable = LoadIngredients();
            guna2DataGridView1.DataSource = originalDatatable;
            guna2DataGridView1.AutoGenerateColumns = true;
        }

        // Carga los Ingredientes
        public DataTable LoadIngredients() {
            Console.WriteLine("Recargando los ingredientes...");
            string apiUrl = "http://127.0.0.1:8080/ingredients";
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(long));  // Usar long para ID
            table.Columns.Add("Nombre");
            table.Columns.Add("Categoria");

            if (jsonResponse != null) {
                try {
                    var ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse);
                    
                    foreach (var ingredient in ingredients) {
                        table.Rows.Add(ingredient.idIngredient, ingredient.name, ingredient.category?.name ?? "None");
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar los datos");
                }
            } else {
                MessageBox.Show("No se pudieron obtener los datos");
            }
            Console.WriteLine(jsonResponse); // Para verificar cómo llega la respuesta.
            return table;
        }

        public void LoadIngredientsInDataGridView() {
            DataTable ingredientsTable = LoadIngredients(); // Llamamos a LoadIngredients para obtener el DataTable

            // Asignamos el DataTable al DataGridView
            guna2DataGridView1.DataSource = ingredientsTable;

            // Para asegurar que el DataGridView se actualiza, puedes forzar la actualización del control
            guna2DataGridView1.Refresh();
        }

        // Añadir Ingrediente
        private void guna2Button1_Click(object sender, EventArgs e) {
            FormAddIngrediente formAddIng = new FormAddIngrediente();
            formAddIng.Owner = this; // Establecer el formulario principal como propietario
            formAddIng.StartPosition = FormStartPosition.CenterParent;
            formAddIng.ShowDialog();
            LoadIngredientsInDataGridView();
        }

        // Editar Ingrediente
        private void btnEditIngredient_Click(object sender, EventArgs e) {
            // Aqui hay que cargar un ingrediente, el que esta selecionado
            if (guna2DataGridView1.SelectedRows.Count > 0) {

                var selectedRow = guna2DataGridView1.SelectedRows[0];

                int idIngredient = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);
                string name = selectedRow.Cells["Nombre"].Value.ToString();

                string category_string = selectedRow.Cells["Categoria"].Value.ToString();



                string apiUrl = "http://127.0.0.1:8080/categories";
                var client = new RestClient(apiUrl, "GET");
                string jsonResponse = client.GetItem();

                CategoryIngredient newCategory = null;
                if (jsonResponse != null) {
                    try {
                        var categories = JsonConvert.DeserializeObject<List<CategoryIngredient>>(jsonResponse);

                        if (category_string != "None") {
                            foreach (var category in categories) {
                                if (category_string == category.name) {
                                    newCategory = category;
                                }
                             
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Error al procesar los datos");
                    }
                } else {
                    MessageBox.Show("No se pudieron obtener los datos");
                }
                FormAddIngrediente formAddIng = new FormAddIngrediente(idIngredient, name, newCategory);
                formAddIng.StartPosition = FormStartPosition.CenterParent;
                formAddIng.Owner = this; // Establecer el formulario principal como propietarIO
                formAddIng.ShowDialog();
                LoadIngredientsInDataGridView();
            } else {
                MessageBox.Show("No se ha selecionado nigun ingrediente");
            }
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

                if (confirmResult == DialogResult.Yes) {
                    // Crear la URL para el DELETE con el ID del ingrediente
                    string url = $"http://127.0.0.1:8080/ingredients/{idIngredient}";
                    RestClient client = new RestClient(url, "DELETE");

                    // Realizar la solicitud DELETE
                    string response = client.DeleteItem();  // Método DELETE en RestClient, pero si tienes un método específico usa client.deleteItem()

                    // Verificar la respuesta y actualizar el DataGridView si fue exitoso
                    if (!string.IsNullOrEmpty(response)) {
                        MessageBox.Show("Ingrediente eliminado exitosamente.");
                        LoadIngredients(); // Llama a un método que recargue los datos en el DataGridView
                    } else {
                        MessageBox.Show("Error al eliminar el ingrediente.");
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
            guna2DataGridView1.DataSource = LoadIngredients();
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            Dispose();
        }


    }
}
