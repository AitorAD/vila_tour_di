using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormAddEditIngredient : Form {
        bool isEditing = false;
        int idIng;
        string nameIng;
        CategoryIngredient catIng;
        string token = AppState.JwtData.Token;
        private Ingredient selectedIngredient;

        public FormAddEditIngredient() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR INGREDIENTE";
            LoadCategoriesIngredientComboBox();
            this.FormClosed += FormAddIngredient_FormClosed;
        }

        public FormAddEditIngredient(Ingredient ingredient) {
            isEditing = true;
            InitializeComponent();
            LoadCategoriesIngredientComboBox();
            labelTitle.Text = "EDITAR INGREDIENTE";
            selectedIngredient = ingredient;
            guna2TextBoxName.Text = ingredient.name;
            // Verifica que el category no sea null
            if (ingredient.category != null) {
                // Encontrar el índice de la categoría seleccionada
                for (int i = 0; i < guna2ComboBoxCategory.Items.Count; i++) {
                    var category = (CategoryIngredient)guna2ComboBoxCategory.Items[i];
                    if (category.id == ingredient.category.id) {
                        guna2ComboBoxCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
            this.FormClosed += FormAddIngredient_FormClosed;
        }

        private void LoadCategoriesIngredientComboBox() {
            guna2ComboBoxCategory.Items.Clear();

            List<CategoryIngredient> categories = CategoryIngredientService.GetCategoriesIngredient();

            foreach (var category in categories) {
                guna2ComboBoxCategory.Items.Add(category);
                guna2ComboBoxCategory.ItemsAppearance.ToString();
            }
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            string name = guna2TextBoxName.Text;
            CategoryIngredient category = guna2ComboBoxCategory.SelectedItem as CategoryIngredient;

            if (category == null) {
                MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isEditing) {
                if (IngredientService.UpdateIngredient(selectedIngredient.idIngredient, name, category)) {
                    Dispose();
                }
            } else {
                if (IngredientService.AddIngredient(name, category)) {
                    Dispose();
                };
            }
        }

        private void FormAddIngredient_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.Owner is FormIngredient mainForm) {
                mainForm.LoadIngredientsInDataGridView();
            }
        }

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
