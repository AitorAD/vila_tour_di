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
    public partial class FormIngredient : BaseForm {
        public FormIngredient() {
            InitializeComponent();
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e) {
            FormAddIngredient formAddIng = new FormAddIngredient();
            formAddIng.StartPosition = FormStartPosition.CenterParent;
            formAddIng.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void buttonModIngredient_Click(object sender, EventArgs e) {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView1.CurrentRow != null) {
                // Obtener los datos del ingrediente seleccionado
                DataGridViewRow row = dataGridView1.CurrentRow;
                string name = row.Cells["Name"].Value.ToString();
                string type = row.Cells["Type"].Value.ToString();

                // Crear una nueva instancia de FormAddIng para modificar
                FormAddIngredient formAdd = new FormAddIngredient(name, type);
                formAdd.ShowDialog();  // Mostrar de manera modal
            } else {
                MessageBox.Show("Selecciona un ingrediente para modificar.");
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView1.CurrentRow != null) {
                /* Obtener los datos del ingrediente seleccionado
               DataGridViewRow row = dataGridView1.CurrentRow;
               string nombre = row.Cells["Name"].Value.ToString;

                var confirmResult = MessageBox.Show($"¿Estás seguro de eliminar {nombre}",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);
               
               if (confirmResult == DialogResult.Yes) {
                    dataGridView1.Rows.Remove(row);
                    MessageBox.Show($"El ingrediente '{nombre}' ha sido eliminado.");
                } */
            } else {
                MessageBox.Show("Selecciona un ingrediente para modificar.");
            }
        }
    }
}
