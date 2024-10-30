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
    public partial class panelRecetas : UserControl {
        public panelRecetas() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            FormIngredient formIngredient = new FormIngredient();
            formIngredient.StartPosition = FormStartPosition.CenterParent;
            formIngredient.ShowDialog();
        }

        private void buttonAddRecipe_Click(object sender, EventArgs e)
        {
            FormAddRecipe formAddRecipe = new FormAddRecipe();
            formAddRecipe.StartPosition = FormStartPosition.CenterParent;
            formAddRecipe.ShowDialog();
        }
    }
}
