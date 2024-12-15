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

namespace vila_tour_di.Forms.Places
{
    public partial class FormAddEditCategoryPlace : Form
    {
        bool isEditing = false;
        CategoryPlace category;

        public FormAddEditCategoryPlace()
        {
            InitializeComponent();
            lblTitle.Text = "Añadir categoría";
        }

        public FormAddEditCategoryPlace(CategoryPlace category)
        {
            isEditing = true;
            InitializeComponent();
            lblTitle.Text = "Editar categoría";
            this.category = category;

            txtName.Text = category.name;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtName.Text.ToUpper();
            

            if (isEditing)
            {
                CategoryPlace newCategory = new CategoryPlace(category.id, categoryName);
                MessageBox.Show($"¿Está seguro de querer editar la categoria {category.name}", "Editar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (true)
                {
                    bool success = CategoryPlaceService.UpdateCategoryPlace(category, newCategory);
                    if (success)
                        Dispose();
                }
            }
            else
            {
                bool success = CategoryPlaceService.AddCategoryPlace(new CategoryPlace (categoryName));
                if (success)
                {
                    Dispose();
                }
            }
        }
    }
}
