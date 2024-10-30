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
    public partial class FormAddIngredient : BaseForm {
        public FormAddIngredient() {
            InitializeComponent();

            // Limpiar el campo de nombre
            textBoxNameIng.Text = string.Empty;

            // Seleccionar el primer tipo de ingrediente en el ComboBox
            //comboBoxTypeIng.SelectedIndex = 0;
        }

        public FormAddIngredient(string name, string type) {
            InitializeComponent();

            // Asignar el nombre del ingrediente
            textBoxNameIng.Text = name;

            // Buscar el índice del tipo de ingrediente en el ComboBox
            int index = comboBoxTypeIng.Items.IndexOf(type);

            // Si el tipo existe en el ComboBox, seleccionarlo; si no, dejar el primer valor
            comboBoxTypeIng.SelectedIndex = (index >= 0) ? index : 0;
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void buttonAddIng_Click(object sender, EventArgs e)
        {

        }
    }
}
