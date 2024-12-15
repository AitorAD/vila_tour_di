using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Forms.Commons;
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

            // Utilizar el mismo slider de imágenes que en Festival
            if ((imageSlider.images = ImageService.GetImagesByArticle(recipe))?.Count > 0) {
                imageSlider.article = recipe;
                imageSlider.LoadImage();
            }

            // Seleccionar los ingredientes actuales en la lista
            if (recipe.ingredients != null) {
                listBoxIngredients.Items.Clear(); // Limpiar los ítems actuales
                foreach (var ingredient in recipe.ingredients) {
                    listBoxIngredients.Items.Add(ingredient); // Agregar cada ingrediente
                }
            }

            this.Text = "Editar receta";

            if (showDetails) {
                guna2TextBoxName.Enabled = false;
                guna2TextBoxDescription.Enabled = false;
                btnAddIngredient.Enabled = false;
                btnDeleteIngredient.Enabled = false;
                btnAddRecipe.Enabled = false;
                guna2ImageCheckBoxApproved.Enabled = false;
           
            }
            imageSlider.setStatusButtons(isEditing);
            LoadIngredientsComboBox();
            this.FormClosed += FormAddEditRecipe_FormClosed;
        }

        private void LoadIngredientsComboBox() {
            guna2ComboBoxIngredients.Items.Clear();

            List<Ingredient> ingredients = IngredientService.GetIngredients();

            foreach (var ingredient in ingredients) {
                guna2ComboBoxIngredients.Items.Add(ingredient);
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
                if (item is Ingredient ingredient) {
                    ingredients.Add(ingredient);
                }
            }

            // Convertir las imágenes a base64 usando el nuevo control de imágenes
            List<string> imagePaths = imageSlider.images.Select(img => img.path).ToList();
            string image = JsonConvert.SerializeObject(imagePaths);

            Recipe newRecipe = new Recipe(name, description, image, approved, recent, ingredients, creator);

            if (isEditing) {
                newRecipe.creationDate = _selectedRecipe.creationDate;
                newRecipe.creator = _selectedRecipe.creator;
                RecipeService.UpdateRecipe(_selectedRecipe, newRecipe);
                Dispose();
            } else {
                newRecipe.creator = Config.currentUser;
                Console.WriteLine(newRecipe);
                RecipeService.AddRecipe(newRecipe);
                Dispose();
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e) {
            var selectedIngredient = guna2ComboBoxIngredients.SelectedItem as Ingredient;

            if (selectedIngredient != null && listBoxIngredients.Items.Cast<Ingredient>().Any(ingredient => ingredient.name.Equals(selectedIngredient.name))) {
                MessageBox.Show("Error. Ingrediente repetido",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            } else if (selectedIngredient != null) {
                listBoxIngredients.Items.Add(selectedIngredient);
            } else {
                MessageBox.Show("Error. Selecciona un Ingrediente",
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
