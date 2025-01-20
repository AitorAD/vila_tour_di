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
        public object FormAddEditRoutes { get; private set; }

        public UserControlRoutes() {
            InitializeComponent();

            loadRoutesInGridView();
            gunaDataGridViewRoute.AutoGenerateColumns = true;
            gunaDataGridViewRoute.AutoResizeColumnHeadersHeight();
            gunaDataGridViewRoute.AutoResizeColumns();
        }

        public DataTable LoadRoutesData() {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(long));
            table.Columns.Add("Nombre");
            table.Columns.Add("Numero de paradas");
            table.Columns.Add("Inicio");
            table.Columns.Add("Fin");

            List<RouteVilaTour> routes = RouteService.GetAllRoutes();

            if (routes != null && routes.Any()) {
                foreach (var route in routes) {
                    table.Rows.Add(
                        route.id,
                        route.name,
                        route.places != null ? route.places.LongCount() : 0,
                        route.places?.FirstOrDefault()?.name ?? "",
                        route.places?.LastOrDefault()?.name ?? ""
                    );
                }
            }

            return table;
        }

        private void loadRoutesInGridView() {
            DataTable routesTable = LoadRoutesData();
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
                gunaDataGridViewRoute.DataSource = LoadRoutesData();
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
