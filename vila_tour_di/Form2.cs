using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class Form2 : BaseForm {

        public Form2() {
            InitializeComponent();
        }

        public void CargarUserControl(UserControl nuevoControl) {
            panel1.Controls.Clear();

            nuevoControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(nuevoControl);
        }

        private void button1_Click(object sender, EventArgs e) {
            CargarUserControl(new panelLugares());
        }

        private void button2_Click(object sender, EventArgs e) {
            CargarUserControl(new panelFiestas());
        }

        private void button3_Click(object sender, EventArgs e) {
            CargarUserControl(new panelRecetas());
        }

        private void button4_Click(object sender, EventArgs e) {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e) {

        }
    }
}
