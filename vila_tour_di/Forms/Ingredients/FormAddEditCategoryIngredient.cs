using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormAddEditCategoryIngredient : Form {

        bool isEditing = false;
        CategoryIngredient category;

        public FormAddEditCategoryIngredient() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR CATEGORIA";
        }

        public FormAddEditCategoryIngredient(CategoryIngredient category) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR CATEGORIA";

            this.category = category;

            guna2TextBoxNombreCat.Text = category.name;
        }

        private void bttbAddCatIngredient_Click_1(object sender, EventArgs e) {
            // Obtener los datos del formulario
            string categoryName = guna2TextBoxNombreCat.Text.ToUpper();

            //Logica de editar
            if (isEditing) {
                int categoryId = category.id;
                MessageBox.Show($"¿Está seguro de querer editar la categoria {category.name}", "Editar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (true) {
                    bool success = CategoryIngredientService.UpdateCategory(categoryId, categoryName);
                    if (success) 
                        Dispose();
                    }
                } else {
                    bool success = CategoryIngredientService.AddCategory(categoryName);
                    if (success) {
                        Dispose();
                    }
                }
        }

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
    
}
