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
    public partial class panelRecipes : UserControl {
        public panelRecipes() {
            InitializeComponent();
        }

        private void buttonIngredients_Click(object sender, EventArgs e) {
            // TODO menu ingredientes 
            formIngredient formIngredientDialog = new formIngredient();

            formIngredientDialog.StartPosition = FormStartPosition.CenterParent;

            formIngredientDialog.ShowDialog();
        }

        private void buttonAddRecipe_Click(object sender, EventArgs e) {
            // Mostar ventana de añadir receta
        }

        private void buttonModRecipe_Click(object sender, EventArgs e) {
            // Modificar receta selecionada
        }

        private void buttonSeeRecipe_Click(object sender, EventArgs e) {
            // Ver receta seleccionada
        }
        private void buttonDelRecipe_Click(object sender, EventArgs e) {
            // TODO Elimiar receta selecionada
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

    }
}
