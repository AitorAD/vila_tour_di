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
    public partial class FormRedactor : BaseForm {

        public FormRedactor() {
            InitializeComponent();
        }

        public void LoadUserControl(UserControl newControl) {
            panel1.Controls.Clear();

            newControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(newControl);
        }

        private void button1_Click(object sender, EventArgs e) {
            LoadUserControl(new panelLugares());
        }

        private void button2_Click(object sender, EventArgs e) {
            LoadUserControl(new panelFiestas());
        }

        private void button3_Click(object sender, EventArgs e) {
            LoadUserControl(new panelRecetas());
        }

        private void button4_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
