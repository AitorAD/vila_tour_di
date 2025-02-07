using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;
using vila_tour_di.Forms.Commons;
using vila_tour_di.Forms.Places;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class UserControlPlaces : UserControl {
        private DataTable originalDataTable;
        List<Place> places = PlaceService.GetAllPlaces();
        public UserControlPlaces() {
            InitializeComponent();

            originalDataTable = loadPlacesData();
            gunaDataGridViewPlaces.DataSource = originalDataTable;
            gunaDataGridViewPlaces.AutoGenerateColumns = true;
            gunaDataGridViewPlaces.AutoResizeColumnHeadersHeight();
            gunaDataGridViewPlaces.AutoResizeColumns();
        }

        public DataTable loadPlacesData() { 
            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Puntuación media");
            table.Columns.Add("Creación");
            table.Columns.Add("Última modificación");
            table.Columns.Add("Categoría");
            table.Columns.Add("Creador");

            foreach(var place in places) {
                table.Rows.Add(
                    place.id,
                    place.name,
                    place.averageScore,
                    place.creationDate,
                    place.lastModificationDate,
                    place.categoryPlace,
                    place.creator
                );
            }
            return table;
        }

        private void loadPlacesInGridView() {
            DataTable placesTable = loadPlacesData();
            gunaDataGridViewPlaces.DataSource = placesTable;
            gunaDataGridViewPlaces.Refresh();
        }


        private void btnAdd_Click(object sender, EventArgs e) {
            FormAddEditPlace formAddPlace = new FormAddEditPlace();
            formAddPlace.StartPosition = FormStartPosition.CenterParent;
            formAddPlace.ShowDialog();
            loadPlacesInGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = gunaDataGridViewPlaces.SelectedRows[0];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {

                    Place selectedPlace = PlaceService.GetPlaceById(id);

                    FormAddEditPlace editForm = new FormAddEditPlace(selectedPlace, true);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    editForm.ShowDialog();
                } else {
                    MessageBox.Show("No se pudo obtener el ID del lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Debe seleccionar una lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormReport formReports = new FormReport(places);
            formReports.StartPosition = FormStartPosition.CenterParent;
            formReports.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];

                // Obtener el ID del ingrediente seleccionado
                int id = int.Parse(selectedRow.Cells["ID"].Value.ToString());

                // Confirmar eliminación
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este lugar?\n\n" +
                    "Esta acción no se puede deshacer y eliminará permanentemente el lugar seleccionado de la lista.\n\n" +
                    "Presiona 'Sí' para confirmar o 'No' para cancelar.",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirmResult == DialogResult.Yes) {
                    PlaceService.DeletePlace(id);
                    gunaDataGridViewPlaces.DataSource = loadPlacesData();
                }

            } else {
                MessageBox.Show("No se ha seleccionado ninguna lugar");
            }
        }

        private void btnCategoriesPlace_Click(object sender, EventArgs e)
        {
            FormCategoryPlace formCategories = new FormCategoryPlace();
            formCategories.StartPosition = FormStartPosition.CenterParent;
            formCategories.ShowDialog();
        }

        private void gunaDataGridViewPlaces_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (gunaDataGridViewPlaces.CurrentRow != null && gunaDataGridViewPlaces.CurrentRow.Index >= 0) {
                // Obtener la receta asociada a la fila seleccionada
                int placeId = Convert.ToInt32(gunaDataGridViewPlaces.CurrentRow.Cells["Id"].Value);

                // Obtener la receta usando el servicio
                Place selectedPlace = PlaceService.GetPlaceById(placeId);

                // Crear una instancia del formulario para agregar/editar recetas
                FormAddEditPlace formAddEditPlace = new FormAddEditPlace(selectedPlace, false);

                // Mostrar el formulario
                formAddEditPlace.ShowDialog(); // Mostrar como formulario modal
            }
        }
    }
}
