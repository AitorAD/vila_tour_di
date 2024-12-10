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

namespace vila_tour_di {
    public partial class UserControlFestivals : UserControl {
        private DataTable originalDataTable;
        public UserControlFestivals() {
            InitializeComponent();

            originalDataTable = loadFestivalsData();
            gunaDataGridViewFestivals.DataSource = originalDataTable;
            gunaDataGridViewFestivals.AutoGenerateColumns = true;
            gunaDataGridViewFestivals.AutoResizeColumnHeadersHeight();
            gunaDataGridViewFestivals.AutoResizeColumns();
        }

        private void btnAddFestival_Click(object sender, EventArgs e) {
            FormAddEditFestival formAddFestival = new FormAddEditFestival();
            formAddFestival.StartPosition = FormStartPosition.CenterScreen;
            formAddFestival.ShowDialog();
        }

        private DataTable loadFestivalsData() {
            DataTable table = new DataTable();

            // Definimos las columnas
            table.Columns.Add("ID", typeof(long));  // Usar long para ID
            table.Columns.Add("Nombre");

            List<Festival> festivals = FestivalService.GetAllFestivals();

            // Agregamos los users a la tabla
            foreach (var festival in festivals) {
                table.Rows.Add(festival.id, festival.name);
            }

            return table;
        }
    }
}
