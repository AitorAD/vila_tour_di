using ClientRESTAPI;
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

            // Asigna los valores del enum al ComboBox
            comboBoxTypeIng.DataSource = Enum.GetValues(typeof(IngredientType));
        }

        public FormAddIngredient(string name, string type) {
            InitializeComponent();

            comboBoxTypeIng.DataSource = Enum.GetValues(typeof(IngredientType));
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            Dispose();
        }

        // Logica para añadir ingreediente
        private void buttonAddIng_Click(object sender, EventArgs e){
            /*
             * Aqui se obtienen los datos y se genera el JSON que se envia
             */

            String nameIngredient = textBoxNameIng.Text;
            String category = comboBoxTypeIng.Text;

            String url = "http://127.0.0.1:8080/ingredients";

            RestClient r = new RestClient(url, "POST");

            String datos = "{" +
                "\"name\": \"" + nameIngredient + "\", " +
                "\"category\": \"" + category + "\"" +
                "}";

            String res = r.postItem(datos);

            MessageBox.Show("Resultado: " + res);
        }

        public enum IngredientType {
            FRUITS_AND_VEGETABLES,
            MEAT_AND_POULTRY,
            FISH_AND_SEAFOOD,
            DAIRY,
            GRAINS_AND_CEREALS,
            SPICES_AND_HERBS,
            LEGUMES,
            NUTS_AND_SEEDS,
            OILS_AND_FATS,
            SWEETENERS,
            BEVERAGES
        }
    }
}
