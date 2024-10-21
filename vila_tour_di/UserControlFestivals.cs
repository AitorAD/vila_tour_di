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
    public partial class panelFiestas : UserControl {
        public panelFiestas() {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\dam_lco\Documents\GitHub\vila_tour_di\Resources\magnifier.png"); // Cargar la imagens
        }

        private void buttonAddFiesta_Click(object sender, EventArgs e) {
            // TODO implementar añadir fiesta
        }

        private void buttonModdFiesta_Click(object sender, EventArgs e) {
            // TODO implementar modificar fieta seleccionada en la tabla
        }

        private void buttonSeeFiesta_Click(object sender, EventArgs e) {
            // TODO ver fyt seleccionada
        }

        private void buttonDelFiesta_Click(object sender, EventArgs e) {
            // TODO eliminar fyt seleccionada
        }
    }
}
