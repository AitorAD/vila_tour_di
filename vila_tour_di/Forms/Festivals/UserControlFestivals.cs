using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            loadCategories();
        }

        private DataTable loadFestivalsData(List<Festival> festivalsList) {
            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(long));  // Usar long para ID
            table.Columns.Add("Nombre");
            table.Columns.Add("Puntuación media");
            table.Columns.Add("Fecha Inicio");
            table.Columns.Add("Fecha Final");
            table.Columns.Add("Creador");
            table.Columns.Add("Lugar");

            // Agregamos los festivals a la tabla
            foreach (var festival in festivalsList) {
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

        private void loadFestivalsInGridView(List<Festival> festivalsList) {
            DataTable festivalsTable = loadFestivalsData(festivalsList);
            gunaDataGridViewFestivals.DataSource = festivalsTable;
            gunaDataGridViewFestivals.Refresh();
        }

        private void loadFestivalsInGridView() {
            DataTable festivalsTable = loadFestivalsData(festivals);
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
            if (gunaDataGridViewFestivals.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewFestivals.SelectedRows[0];
                int id = int.Parse(selectedRow.Cells["ID"].Value.ToString());

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
                    gunaDataGridViewFestivals.DataSource = loadFestivalsData(festivals);
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
            if (gunaDataGridViewFestivals.CurrentRow != null && gunaDataGridViewFestivals.CurrentRow.Index >= 0) {
                int festivalId = Convert.ToInt32(gunaDataGridViewFestivals.CurrentRow.Cells["Id"].Value);
                Festival selectedFestival = FestivalService.GetFestivalById(festivalId);

                FormAddEditFestival formAddEditFestival = new FormAddEditFestival(selectedFestival, false);
                formAddEditFestival.ShowDialog();
            }
        }

        private void loadCategories() {
            List<string> categories = new List<string>
            {
                "Nombre",
                "Descripción",
                "Fecha Inicio",
                "Fecha Final",
                "Creador",
                "Lugar"
            };

            comboBoxCategories.Items.Clear();
            comboBoxCategories.Items.Add("Todos");
            foreach (var category in categories) {
                comboBoxCategories.Items.Add(category);
            }

            comboBoxCategories.SelectedIndex = 0;  // "Todos" por defecto
        }

        private void filterFestivals() {
            string selectedCategory = comboBoxCategories.SelectedItem.ToString();
            string searchText = textBoxSearch.Text.ToLower();

            List<Festival> filteredFestivals = festivals;

            if (selectedCategory != "Todos") {
                switch (selectedCategory) {
                    case "Nombre":
                        filteredFestivals = festivals.Where(f => f.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Descripción":
                        filteredFestivals = festivals.Where(f => f.description.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Fecha Inicio":
                        if (DateTime.TryParse(searchText, out DateTime startDate)) {
                            filteredFestivals = festivals.Where(f => f.startDate.Date == startDate.Date).ToList();
                        }
                        break;
                    case "Fecha Final":
                        if (DateTime.TryParse(searchText, out DateTime endDate)) {
                            filteredFestivals = festivals.Where(f => f.endDate.Date == endDate.Date).ToList();
                        }
                        break;
                    case "Creador":
                        filteredFestivals = festivals.Where(f => f.creator.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Lugar":
                        filteredFestivals = festivals.Where(f => f.coordinate.name.ToLower().Contains(searchText)).ToList();
                        break;
                }
            }

            loadFestivalsInGridView(filteredFestivals);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            filterFestivals();
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e) {
            filterFestivals();
        }
    }
}
