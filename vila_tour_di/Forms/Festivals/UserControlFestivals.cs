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
using vila_tour_di.Forms.Commons;
using vila_tour_di.Forms.Places;

namespace vila_tour_di {
    public partial class UserControlFestivals : UserControl {
        List<Festival> festivals = FestivalService.GetAllFestivals();

        public UserControlFestivals() {
            InitializeComponent();

            loadFestivalsInGridView();
            gunaDataGridViewFestivals.AutoGenerateColumns = true;
            gunaDataGridViewFestivals.AutoResizeColumnHeadersHeight();
            gunaDataGridViewFestivals.AutoResizeColumns();
        }

        private DataTable loadFestivalsData() {
            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(long));  // Usar long para ID
            table.Columns.Add("Nombre");
            table.Columns.Add("Puntuación media");
            table.Columns.Add("Fecha Inicio");
            table.Columns.Add("Fecha Final");
            table.Columns.Add("Creador");
            table.Columns.Add("Lugar");
            // TODO: Agregar nombre del sitio donde se celebra


            // Agregamos los users a la tabla
            foreach (var festival in festivals) {
                table.Rows.Add(
                    festival.id,
                    festival.name,
                    festival.averageScore,
                    festival.startDate,
                    festival.endDate,
                    festival.creator.name,
                    festival.coordinate.name
                );
            }

            return table;
        }

        private void loadFestivalsInGridView() {
            DataTable festivalsTable = loadFestivalsData();
            gunaDataGridViewFestivals.DataSource = festivalsTable;
            gunaDataGridViewFestivals.Refresh();
        }

        private void btnAddFestival_Click(object sender, EventArgs e) {
            FormAddEditFestival formAddFestival = new FormAddEditFestival();
            formAddFestival.StartPosition = FormStartPosition.CenterScreen;
            formAddFestival.ShowDialog();
            loadFestivalsInGridView();
        }

        private void btnEditFestival_Click(object sender, EventArgs e) {
            if (gunaDataGridViewFestivals.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = gunaDataGridViewFestivals.SelectedRows[0];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {

                    Festival selectedFestival = FestivalService.GetFestivalById(id);

                    FormAddEditFestival editForm = new FormAddEditFestival(selectedFestival, true);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    editForm.ShowDialog();
                } else {
                    MessageBox.Show("No se pudo obtener el ID de la fiesta o tradición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Debe seleccionar una fiesta o tradición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteFestival_Click(object sender, EventArgs e) {
            // Verificar si hay una fila seleccionada
            if (gunaDataGridViewFestivals.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewFestivals.SelectedRows[0];

                // Obtener el ID del ingrediente seleccionado
                int id = int.Parse(selectedRow.Cells["ID"].Value.ToString());

                // Confirmar eliminación
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta fiesta o tradición?\n\n" +
                    "Esta acción no se puede deshacer y eliminará permanentemente la fiesta o tradición seleccionada de la lista.\n\n" +
                    "Presiona 'Sí' para confirmar o 'No' para cancelar.",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirmResult == DialogResult.Yes) {
                    FestivalService.DeleteFestival(id);
                    gunaDataGridViewFestivals.DataSource = loadFestivalsData();
                }

            } else {
                MessageBox.Show("No se ha seleccionado ninguna fiesta o tradición");
            }
        }

        private void btnDetailsFestival_Click(object sender, EventArgs e) {
            FormReport formReports = new FormReport(festivals);
            formReports.StartPosition = FormStartPosition.CenterParent;
            formReports.ShowDialog();
        }

        private void gunaDataGridViewFestivals_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (gunaDataGridViewFestivals.CurrentRow != null && gunaDataGridViewFestivals.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int festivalId = Convert.ToInt32(gunaDataGridViewFestivals.CurrentRow.Cells["Id"].Value);

                // Obtener la receta usando el servicio
                Festival selectedFestival = FestivalService.GetFestivalById(festivalId);

                // Crear una instancia del formulario para agregar/editar recetas
                FormAddEditFestival formAddEditFestival = new FormAddEditFestival(selectedFestival, false);

                // Mostrar el formulario
                formAddEditFestival.ShowDialog(); // Mostrar como formulario modal
            }
        }
    }
}
