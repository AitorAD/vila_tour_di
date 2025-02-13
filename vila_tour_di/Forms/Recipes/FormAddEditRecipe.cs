using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormAddEditRecipe : Form {
        private bool _isEditing = false;
        private Recipe _selectedRecipe;

        public FormAddEditRecipe() {
            InitializeComponent();
            setValuesToForm();
            labelTitle.Text = "AÑADIR RECETA";
        }

        public FormAddEditRecipe(Recipe recipe, bool isEditing) {
            InitializeComponent();
            this._isEditing = isEditing;
            _selectedRecipe = recipe;
            setValuesToForm();
            setStatusToForm();
        }

        private void setValuesToForm() {
            LoadIngredientsComboBox();
            if (_selectedRecipe != null) {
                guna2TextBoxName.Text = _selectedRecipe.name;
                guna2TextBoxDescription.Text = _selectedRecipe.description;
                guna2ImageCheckBoxApproved.Checked = _selectedRecipe.approved;

                // Utilizar el mismo slider de imágenes que en Festival
                if ((imageSlider.images = ImageService.GetImagesByArticle(_selectedRecipe))?.Count > 0) {
                    imageSlider.article = _selectedRecipe;
                    imageSlider.LoadImage();
                }

                // Seleccionar los ingredientes actuales en la lista
                if (_selectedRecipe.ingredients != null) {
                    listBoxIngredients.Items.Clear(); // Limpiar los ítems actuales
                    foreach (var ingredient in _selectedRecipe.ingredients) {
                        listBoxIngredients.Items.Add(ingredient); // Agregar cada ingrediente
                    }
                }
            }
        }

        private void setStatusToForm() {
            string titleText = _isEditing ? "EDITAR" : "DETALLES";
            titleText += " RECETA";
            labelTitle.Text = titleText;

            guna2TextBoxName.Enabled = _isEditing;
            guna2TextBoxDescription.Enabled = _isEditing;
            btnAddIngredient.Enabled = _isEditing;
            imageSlider.setStatusButtons(_isEditing);
            btnDeleteIngredient.Enabled = _isEditing;
            btnAddRecipe.Enabled = _isEditing;
            guna2ImageCheckBoxApproved.Enabled = _isEditing;
        }

        private void LoadIngredientsComboBox() {
            guna2ComboBoxIngredients.Items.Clear();
            List<Ingredient> ingredients = IngredientService.GetIngredients();

            // Lista para almacenar el texto máximo
            List<string> itemTexts = new List<string>();

            // Ordenamos los ingredientes por categoría
            var groupedIngredients = ingredients.GroupBy(i => i.category.name);
            foreach (var group in groupedIngredients) {
                // Agregamos la categoría como un "encabezado"
                CategoryIngredient categoryItem = new CategoryIngredient(group.Key);
                guna2ComboBoxIngredients.Items.Add("---" + categoryItem.name.ToUpper() + "---");
                itemTexts.Add("---" + categoryItem.name.ToUpper() + "---");

                // Agregamos los ingredientes de esta categoría
                foreach (var ingredient in group) {
                    guna2ComboBoxIngredients.Items.Add(ingredient);
                    itemTexts.Add(ingredient.name);
                }
            }

            // Configuramos el ComboBox para dibujar los elementos manualmente
            guna2ComboBoxIngredients.DrawMode = DrawMode.OwnerDrawVariable;

            // Ajustamos el tamaño del ComboBox cuando se despliega
            guna2ComboBoxIngredients.DropDown += (sender, e) => AdjustDropDownWidth(itemTexts);
        }

        // No funciona, pero bueno, se le quiere
        private void guna2ComboBoxIngredients_SelectedIndexChanged(object sender, EventArgs e) {
            if (guna2ComboBoxIngredients.SelectedItem.ToString().StartsWith("---")) {
                this.BeginInvoke((MethodInvoker)delegate {
                    guna2ComboBoxIngredients.SelectedItem = -1;
                });
            }
        }

        private void AdjustDropDownWidth(List<string> texts) {
            int maxWidth = GetMaxTextWidth(texts);
            guna2ComboBoxIngredients.DropDownWidth = maxWidth + 50; // 50 es para margen extra
        }

        private int GetMaxTextWidth(List<string> texts) {
            int maxWidth = 0;

            using (Graphics g = guna2ComboBoxIngredients.CreateGraphics()) {
                foreach (var text in texts) {
                    SizeF size = g.MeasureString(text, guna2ComboBoxIngredients.Font);
                    if (size.Width > maxWidth) {
                        maxWidth = (int)size.Width;
                    }
                }
            }
            return maxWidth;
        }

        private void btnAddRecipe_Click(object sender, EventArgs e) {
            // Obtener datos
            string name = guna2TextBoxName.Text;
            string description = guna2TextBoxDescription.Text;
            bool approved = guna2ImageCheckBoxApproved.Checked;
            bool recent = false;
            List<Ingredient> ingredients = new List<Ingredient>();
            User creator = Config.currentUser;

            foreach (var item in listBoxIngredients.Items) {
                if (item is Ingredient ingredient) {
                    ingredients.Add(ingredient);
                }
            }

            imageSlider.images.ForEach(i => i.id = null);

            // Crear la nueva receta
            Recipe newRecipe = new Recipe(name, description, approved, recent, ingredients, creator, imageSlider.images);

            if (_isEditing) {
                newRecipe.creator = _selectedRecipe.creator;
                newRecipe.creationDate = _selectedRecipe.creationDate;
                ImageService.DeleteAllByArticle(_selectedRecipe); // Elimino todas las imagenes asociadas a este articulo para despues agregar los cambios correspondientes
                RecipeService.UpdateRecipe(_selectedRecipe, newRecipe);
                Dispose();
            } else {
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
