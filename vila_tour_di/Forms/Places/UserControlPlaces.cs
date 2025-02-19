using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            originalDataTable = loadPlacesData(places);
            gunaDataGridViewPlaces.DataSource = originalDataTable;
            gunaDataGridViewPlaces.AutoGenerateColumns = true;
            gunaDataGridViewPlaces.AutoResizeColumnHeadersHeight();
            gunaDataGridViewPlaces.AutoResizeColumns();
            loadCategories();
        }

        public DataTable loadPlacesData(List<Place> placesList) {
            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Puntuación media");
            table.Columns.Add("Creación");
            table.Columns.Add("Última modificación");
            table.Columns.Add("Categoría");
            table.Columns.Add("Creador");

            foreach (var place in placesList) {
                table.Rows.Add(
                    place.id,
                    place.name,
                    place.averageScore,
                    place.creationDate,
                    place.lastModificationDate,
                    place.categoryPlace.name,
                    place.creator.username
                );
            }
            return table;
        }

        private void loadPlacesInGridView(List<Place> filteredPlaces) {
            DataTable placesTable = loadPlacesData(filteredPlaces);
            gunaDataGridViewPlaces.DataSource = placesTable;
            gunaDataGridViewPlaces.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            FormAddEditPlace formAddPlace = new FormAddEditPlace();
            formAddPlace.StartPosition = FormStartPosition.CenterParent;
            formAddPlace.ShowDialog();
            loadPlacesInGridView(places);
        }

        private void btnEdit_Click(object sender, EventArgs e) {
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
                MessageBox.Show("Debe seleccionar un lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e) {
            FormReport formReports = new FormReport(places);
            formReports.StartPosition = FormStartPosition.CenterParent;
            formReports.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            // Verificar si hay una fila seleccionada
            if (gunaDataGridViewPlaces.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewPlaces.SelectedRows[0];

                // Obtener el ID del lugar seleccionado
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
                    gunaDataGridViewPlaces.DataSource = loadPlacesData(places);
                }

            } else {
                MessageBox.Show("No se ha seleccionado ningún lugar");
            }
        }

        private void btnCategoriesPlace_Click(object sender, EventArgs e) {
            FormCategoryPlace formCategories = new FormCategoryPlace();
            formCategories.StartPosition = FormStartPosition.CenterParent;
            formCategories.ShowDialog();
        }

        private void gunaDataGridViewPlaces_MouseDoubleClick(object sender, MouseEventArgs e) {
            // Verificar si se hizo doble clic en una fila válida
            if (gunaDataGridViewPlaces.CurrentRow != null && gunaDataGridViewPlaces.CurrentRow.Index >= 0) {
                // Obtener el lugar asociado a la fila seleccionada
                int placeId = Convert.ToInt32(gunaDataGridViewPlaces.CurrentRow.Cells["Id"].Value);

                // Obtener el lugar usando el servicio
                Place selectedPlace = PlaceService.GetPlaceById(placeId);

                // Crear una instancia del formulario para agregar/editar lugares
                FormAddEditPlace formAddEditPlace = new FormAddEditPlace(selectedPlace, false);

                // Mostrar el formulario
                formAddEditPlace.ShowDialog(); // Mostrar como formulario modal
            }
        }

        // Método para filtrar lugares
        private void filterPlaces() {
            string selectedCategory = comboBoxCategories.SelectedItem.ToString();
            string searchText = textBoxSearch.Text.ToLower();

            List<Place> filteredPlaces = places;

            if (selectedCategory != "Todos") {
                switch (selectedCategory) {
                    case "Nombre":
                        filteredPlaces = places.Where(p => p.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Categoría":
                        filteredPlaces = places.Where(p => p.categoryPlace.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Creador":
                        filteredPlaces = places.Where(p => p.creator.name.ToLower().Contains(searchText)).ToList();
                        break;
                }
            }

            // Actualizar la vista de datos con los lugares filtrados
            loadPlacesInGridView(filteredPlaces);
        }

        // Método que se ejecuta cuando cambia el texto del cuadro de búsqueda
        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            filterPlaces();
        }

        // Método que se ejecuta cuando cambia la categoría seleccionada
        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e) {
            filterPlaces();
        }

        // Cargar categorías en el ComboBox
        private void loadCategories() {
            List<string> categories = new List<string>
            {
                "Todos",  // Para mostrar todos los lugares sin filtro
                "Nombre",
                "Categoría",
                "Creador"
            };

            comboBoxCategories.Items.Clear();
            foreach (var category in categories) {
                comboBoxCategories.Items.Add(category);
            }

            comboBoxCategories.SelectedIndex = 0;  // "Todos" por defecto
        }
    }
}
