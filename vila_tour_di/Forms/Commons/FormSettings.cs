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

namespace vila_tour_di.Forms.Commons {
    public partial class FormSettings : Form {
        public FormSettings() {
            InitializeComponent();
            txtUrl.Text = Config.baseURL; // Cargar la URL actual al abrir el formulario
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            string nuevaUrl = txtUrl.Text.Trim();

            if (!string.IsNullOrWhiteSpace(nuevaUrl)) {
                Config.SetBaseUrl(nuevaUrl);
                MessageBox.Show("URL guardada correctamente", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar el formulario después de guardar
            } else {
                MessageBox.Show("Por favor, introduce una URL válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
