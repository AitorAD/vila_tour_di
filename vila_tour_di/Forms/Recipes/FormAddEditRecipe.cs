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
using vila_tour_di.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace vila_tour_di {
    public partial class FormAddEditRecipe : Form {
        bool isEditing = false;
        private Recipe _selectedRecipe;
        public FormAddEditRecipe() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR RECETA";
            LoadIngredientsComboBox();
            this.FormClosed += FormAddEditRecipe_FormClosed;
        }
        public FormAddEditRecipe(Recipe recipe, bool showDetails) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR RECETA";
            _selectedRecipe = recipe;

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
            LoadIngredientsComboBox();
            this.FormClosed += FormAddEditRecipe_FormClosed;
        }

        private void LoadIngredientsComboBox() {
            guna2ComboBoxIngredients.Items.Clear();

            List<Ingredient> ingredients = IngredientService.GetIngredients();

            foreach (var ingredient in ingredients) {
                guna2ComboBoxIngredients.Items.Add(ingredient);
                guna2ComboBoxIngredients.ItemsAppearance.ToString();
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

        private void btnAddRecipe_Click(object sender, EventArgs e) {
            // Obtener datos
            string name = guna2TextBoxName.Text;
            string description = guna2TextBoxDescription.Text;
            bool approved = guna2ImageCheckBoxApproved.Checked;
            bool recent = false;
            List<Ingredient> ingredients = new List<Ingredient>();
            User creator = Config.currentUser;
           

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

            Recipe newRecipe = new Recipe(name, description, image, approved, recent, ingredients, creator);

            if (isEditing) {
                newRecipe.creationDate = _selectedRecipe.creationDate;
                newRecipe.creator = _selectedRecipe.creator;
                RecipeService.UpdateRecipe(_selectedRecipe, newRecipe);
                Dispose();
            } else {
<<<<<<< HEAD
                newRecipe.creator = Config.currentUser;
                RecipeService.AddRecipe(newRecipe);
=======
                // Crear el objeto Recipe
                Recipe newRecipe = new Recipe(name, description, image, averageScore, approved, recent, ingredients);


        
           
>>>>>>> 11b2659f2788ddd4ad506d710adc4a608cc3c4db
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

            if (selectedIngredient != null && listBoxIngredients.Items.Cast<Ingredient>().Any(ingredient => ingredient.name.Equals(selectedIngredient.name))){
                MessageBox.Show("Error. Ingrediente repetido",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            } else if (selectedIngredient != null) {
                listBoxIngredients.Items.Add(selectedIngredient);
            } else {
                MessageBox.Show("Error. Seleciona un Ingrediente",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnDeleteIngredient_Click(object sender, EventArgs e) {
            // Verifica si hay un elemento seleccionado
            if (listBoxIngredients.SelectedItem != null) {
                // Elimina el elemento seleccionado
                listBoxIngredients.Items.Remove(listBoxIngredients.SelectedItem);
            } else {
                // Mensaje si no hay ningún elemento seleccionado
                MessageBox.Show("Por favor, selecciona un ingrediente para eliminar.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
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

        private void FormAddEditRecipe_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.Owner is FormIngredient mainForm) {
                mainForm.LoadIngredientsInDataGridView();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
