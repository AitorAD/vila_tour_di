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
    public partial class formIngredient : Form {
        public formIngredient() {
            InitializeComponent();
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e) {
            // TODO add ingrediente
            FormAddIngredient form = new FormAddIngredient();

            form.StartPosition = FormStartPosition.CenterParent;

            form.ShowDialog();

        }

        private void buttonModIngredient_Click(object sender, EventArgs e) {
            // TODO modd ingrediente
        }

        private void buttonSeeIngredient_Click(object sender, EventArgs e) {
            // See ingrediente
        }

        private void buttonDelIngredient_Click(object sender, EventArgs e) {
            // Eliminar ingredietne
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
