using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Forms.Routes;
using vila_tour_di.Models;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class UserControlRoutes : UserControl {
        private DataTable originalDataTable;  // Para almacenar los datos originales sin filtrar
        private List<RouteVilaTour> routes;

        public UserControlRoutes() {
            InitializeComponent();
            // Cargar los datos y almacenar una copia sin filtrar
            routes = RouteService.GetAllRoutes();
            originalDataTable = LoadRoutesData(routes);
            gunaDataGridViewRoute.DataSource = originalDataTable;
            gunaDataGridViewRoute.AutoGenerateColumns = true;
            gunaDataGridViewRoute.AutoResizeColumnHeadersHeight();
            gunaDataGridViewRoute.AutoResizeColumns();
            loadCategories();
        }

        // Carga las rutas
        public DataTable LoadRoutesData(List<RouteVilaTour> routesList) {
            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(long));
            table.Columns.Add("Nombre");
            table.Columns.Add("Descripción");
            table.Columns.Add("Número de paradas");
            table.Columns.Add("Inicio");
            table.Columns.Add("Fin");

            if (routesList != null && routesList.Any()) {
                foreach (var route in routesList) {
                    table.Rows.Add(
                        route.id,
                        route.name,
                        route.description,
                        route.places != null ? route.places.LongCount() : 0,
                        route.places?.FirstOrDefault()?.name ?? "",
                        route.places?.LastOrDefault()?.name ?? ""
                    );
                }
            }

            return table;
        }

        private void loadCategories() {
            List<string> categories = new List<string>
            {
                "Nombre",
                "Descripción",
                "Número de paradas",
                "Inicio",
                "Fin"
            };

            comboBoxCategories.Items.Clear();
            comboBoxCategories.Items.Add("Todos");
            foreach (var category in categories) {
                comboBoxCategories.Items.Add(category);
            }

            comboBoxCategories.SelectedIndex = 0;  // "Todos" por defecto
        }

        private void filterRoutes() {
            string selectedCategory = comboBoxCategories.SelectedItem.ToString();
            string searchText = textBoxSearch.Text.ToLower();

            List<RouteVilaTour> filteredRoutes = routes;

            if (selectedCategory != "Todos") {
                switch (selectedCategory) {
                    case "Nombre":
                        filteredRoutes = routes.Where(r => r.name.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Descripción":
                        filteredRoutes = routes.Where(r => r.description.ToLower().Contains(searchText)).ToList();
                        break;
                    case "Número de paradas":
                        if (int.TryParse(searchText, out int stops)) {
                            filteredRoutes = routes.Where(r => r.places != null && r.places.Count == stops).ToList();
                        }
                        break;
                    case "Inicio":
                        filteredRoutes = routes.Where(r => r.places?.FirstOrDefault()?.name.ToLower().Contains(searchText) ?? false).ToList();
                        break;
                    case "Fin":
                        filteredRoutes = routes.Where(r => r.places?.LastOrDefault()?.name.ToLower().Contains(searchText) ?? false).ToList();
                        break;
                }
            }

            originalDataTable = LoadRoutesData(filteredRoutes);
            gunaDataGridViewRoute.DataSource = originalDataTable;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            filterRoutes();
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e) {
            filterRoutes();
        }

        private void loadRoutesInGridView() {
            DataTable routesTable = LoadRoutesData(routes);
            gunaDataGridViewRoute.DataSource = routesTable;
            gunaDataGridViewRoute.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            FormAddEditRoute formAddEditRoutes = new FormAddEditRoute();
            formAddEditRoutes.StartPosition = FormStartPosition.CenterParent;
            formAddEditRoutes.ShowDialog();
            loadRoutesInGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRoute.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRoute.SelectedRows[0];
                int routeID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta ruta?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes) {
                    RouteService.DeleteRoute(routeID);
                } else {
                    MessageBox.Show("No se ha seleccionado ninguna ruta para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                gunaDataGridViewRoute.DataSource = LoadRoutesData(routes);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRoute.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = gunaDataGridViewRoute.SelectedRows[0];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {

                    RouteVilaTour selectedRoute = RouteService.GetRouteById(id);

                    FormAddEditRoute editForm = new FormAddEditRoute(selectedRoute, false);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    editForm.ShowDialog();
                } else {
                    MessageBox.Show("No se pudo obtener el ID de la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Debe seleccionar una ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e) {
            if (gunaDataGridViewRoute.SelectedRows.Count > 0) {
                var selectedRow = gunaDataGridViewRoute.SelectedRows[0];

                int id = int.Parse(selectedRow.Cells["ID"].Value.ToString());

                RouteVilaTour selectedRoute = RouteService.GetRouteById(id);

                FormAddEditRoute formDetails = new FormAddEditRoute(selectedRoute, true);
                formDetails.StartPosition = FormStartPosition.CenterParent;
                formDetails.ShowDialog();
            } else {
                MessageBox.Show("No se ha seleccionado ninguna ruta para ver los detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
