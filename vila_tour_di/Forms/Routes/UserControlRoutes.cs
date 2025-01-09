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

            //Definimos las columnas
            table.Columns.Add("ID", typeof(long));
            table.Columns.Add("Nombre");
            table.Columns.Add("Numero de paradas");
            table.Columns.Add("Inicio");
            table.Columns.Add("Fin");

            List<Route> routes = RouteService.GetAllRoutes();

            //Agregar las rutas a l tabla
            foreach (var route in routes) {
                table.Rows.Add(
                    route.idRoute,
                    route.name,
                    route.places.LongCount(),
                    route.places.FirstOrDefault().name,
                    route.places.LastOrDefault().name
                );
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
            LoadRoutesData();
        }
    }
}
