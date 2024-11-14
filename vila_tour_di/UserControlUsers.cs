using ClientRESTAPI;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class UserControlUsers : UserControl {
        private DataTable originalDataTable;  // Para almacenar los datos originales sin filtrar

        public UserControlUsers() {
            InitializeComponent();

            // Cargar los datos y almacenar una copia sin filtrar
            originalDataTable = LoadUsersData();
            gunaDataGridViewUsers.DataSource = originalDataTable;
            gunaDataGridViewUsers.AutoGenerateColumns = true;
        }

        public DataTable LoadUsersData() {
            string apiUrl = "http://127.0.0.1:8080/users"; // Ajusta tu URL
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

            DataTable table = new DataTable();

            // Definir las columnas del DataTable
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Usuario");
            table.Columns.Add("Email");
            table.Columns.Add("Rol");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellidos");

            if (jsonResponse != null) {
                try {
                    // Deserializar la respuesta JSON a una lista de usuarios
                    var usuarios = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                    // Agregar los datos de los usuarios al DataTable
                    foreach (var user in usuarios) {
                        table.Rows.Add(user.id, user.username, user.email, user.role, user.name, user.surname);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error al procesar los datos: " + ex.Message);
                }
            } else {
                MessageBox.Show("No se pudieron obtener los datos.");
            }

            return table;
        }

        private void btnAddUser_Click(object sender, EventArgs e) {
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.StartPosition = FormStartPosition.CenterParent;
            formAddUser.ShowDialog();
        }
    }
}
