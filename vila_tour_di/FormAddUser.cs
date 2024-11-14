using ClientRESTAPI;
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
    public partial class FormAddUser : Form {
        public FormAddUser() {
            InitializeComponent();
            ComboBoxRol.DataSource = Enum.GetValues(typeof(RoleType));
        }

        private void btnAddUser_Click(object sender, EventArgs e) {
            /*
             * Aqui se obtienen los datos y se genera el JSON que se envia
             */

            String username = TextBoxUserName.Text;
            String email = TextBoxeEmail.Text;
            String password = "1234";
            String role = ComboBoxRol.Text;
            String name = TextBoxUserName.Text;
            String surname = TextBoxUserName.Text;
            String profilePicture = "null";



            String url = "http://127.0.0.1:8080/users";

            RestClient r = new RestClient(url, "POST");

            string datos = "{" +
                "\"username\": \"" + username + "\", " +
                "\"email\": \"" + email + "\", " +
                "\"password\": \"" + password + "\", " +
                "\"role\": \"" + role + "\", " +
                "\"name\": \"" + name + "\", " +
                "\"surname\": \"" + surname + "\", " +
                "\"profilePicture\": \"" + profilePicture + "\", " +
                "\"reviews\": []" +
            "}";


            String res = r.PostItem(datos);

            MessageBox.Show("Resultado: " + res);
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            Dispose();
        }

        public enum RoleType {
            USER,
            ADMIN,
            EDITOR
        }
    }
}
