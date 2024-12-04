using ClientRESTAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace vila_tour_di {
    public partial class FormAddEditRecipe : Form {
        bool isEditing = false;
        Recipe recipeToEdit;
        public FormAddEditRecipe() {
            InitializeComponent();
            labelTitle.Text = "Añadir receta";

            LoadIngredients();
        }

        public FormAddEditRecipe(Recipe recipe, bool showDetails) {
            InitializeComponent();

            isEditing = true;

            LoadIngredients();
            labelTitle.Text = "Editar receta";
            this.recipeToEdit = recipe;

            // Asignar los valores actuales
            guna2TextBoxName.Text = recipe.name;
            guna2TextBoxDescription.Text = recipe.description;
            guna2ImageCheckBoxApproved.Checked = recipe.approved;
            guna2PictureBox.Image = Base64ToImage(recipe.imagensPaths);
            guna2PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


            // Seleccionar los ingredientes actuales en la lista 

            if (recipe.ingredients != null) {
                listBoxIngredients.Items.Clear(); // Limpiar los ítems actuales
                foreach (var ingredient in recipe.ingredients) {
                    listBoxIngredients.Items.Add(ingredient); // Agregar cada ingrediente
                }
            }
            this.Text = "Editar ingrediente";

            if (showDetails) {
                guna2TextBoxName.Enabled = false;
                guna2TextBoxDescription.Enabled = false;
                btnAddIngredient.Enabled = false;
                btnDeleteIngredient.Enabled = false;
                btnAddRecipe.Enabled = false;
                guna2ImageCheckBoxApproved.Enabled = false;
                btnAddPhoto.Enabled = false;
            }
        }

        private Image Base64ToImage(string base64String) {
            try {
                if (string.IsNullOrEmpty(base64String)) return null;
                var imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes)) {
                    return Image.FromStream(ms);
                }
            } catch (FormatException ex) {
                MessageBox.Show("La imagen base64 tiene un formato incorrecto: " + ex.Message);
                return null;
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir Base64 a imagen: " + ex.Message);
                return null;
            }
        }

        private List<Ingredient> LoadIngredients() {
            string apiUrl = "http://127.0.0.1:8080/ingredients"; // Ajusta tu URL
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

            List<Ingredient> ingredients = new List<Ingredient>();
            if (jsonResponse != null) {
                try {
                    // Deserializar la respuesta JSON a una lista de categorias

                    ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse);


                    // Configurar el ComboBox con los datos obtenidos
                    guna2ComboBoxIngredients.DataSource = ingredients;
                    guna2ComboBoxIngredients.DisplayMember = "name"; // Propiedad que se mostrará
                    guna2ComboBoxIngredients.ValueMember = "idIngredient";
                    Console.WriteLine(jsonResponse);
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar los datos: " + ex.Message);
                }
            } else {
                MessageBox.Show("No se pudieron obtener los datos.");
            }
            return ingredients;
        }

        private void btnAddRecipe_Click(object sender, EventArgs e) {
            // Obtener datos
            string name = guna2TextBoxName.Text;
            string description = guna2TextBoxDescription.Text;
            double averageScore = 0.0;
            bool approved = guna2ImageCheckBoxApproved.Checked;
            bool recent = false;
            List<Ingredient> ingredients = new List<Ingredient>();

            // Recorrer los elementos del ListBox
            foreach (var item in listBoxIngredients.Items) {
                // Convertir cada elemento al tipo Ingredient y agregarlo a la lista
                if (item is Ingredient ingredient) {
                    ingredients.Add(ingredient);
                }
            }

            // Convertir la imagen a base64
            string image = "null";
            if (guna2PictureBox.Image != null && guna2PictureBox.Tag != null) {
                string filePath = guna2PictureBox.Tag.ToString();
                image = ConvertImageToBase64(filePath);
            }


            if (isEditing) {

            } else {
                // Crear el objeto Recipe
                Recipe newRecipe = new Recipe(name, description, image, averageScore, approved, recent, ingredients);


                string jsonData = JsonSerializer.Serialize(newRecipe);
                string res = string.Empty;

                // Estamos agregando un nuevo ingrediente
                string url = "http://127.0.0.1:8080/recipes";
                RestClient r = new RestClient(url, "POST");
                res = r.PostItem(jsonData);  // Realizamos un POST para agregar la receta
                Console.WriteLine("RESPUESTA: " + res);

                if (res.Contains("\"errorCode\":101")) {
                    MessageBox.Show("Receta ya existente",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                Dispose();
            }
        }

        private string ConvertImageToBase64(string filePath) {
            try {
                using (Image image = Image.FromFile(filePath))
                using (MemoryStream ms = new MemoryStream()) {
                    // Guardar la imagen en un MemoryStream como PNG
                    image.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    // Convertir los bytes a una cadena Base64
                    return Convert.ToBase64String(imageBytes);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir la imagen a Base64: " + ex.Message);
                return null;
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e) {
            var selectedIngredient = guna2ComboBoxIngredients.SelectedItem as Ingredient;

            if (selectedIngredient != null && listBoxIngredients.Items.Cast<Ingredient>().Any(ingredient => ingredient == selectedIngredient)) {
                MessageBox.Show("Error. Ingrediente repetido",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            } else if (selectedIngredient != null) {
                listBoxIngredients.Items.Add(selectedIngredient);
            }
        }

        private void btnDeleteIngredient_Click(object sender, EventArgs e) {
            listBoxIngredients.Items.Remove(listBoxIngredients.SelectedItem);
        }

        private void btnAddPhoto_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Selecciona una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;

                    // Cargar la imagen en el PictureBox
                    guna2PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    guna2PictureBox.Image = Image.FromFile(selectedFilePath);
                    guna2PictureBox.Tag = selectedFilePath;
                }
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e) {
            Dispose();
        }


        /*
        private void FormAddIngrediente_FormClosed(object sender, FormClosedEventArgs e) {
            // Cuando el formulario se cierra, recarga las recetas en el formulario principal
            if (this.Owner != null) {
                var mainForm = this.Owner as UserControlRecipes;
                if (mainForm != null) {
                    mainForm.LoadIngredientsInDataGridView(); // Recargar los ingredientes
                }
            }
        }
        */
    }
}
