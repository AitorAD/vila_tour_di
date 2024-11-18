using ClientRESTAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormAddUser : Form {
        public FormAddUser() {
            InitializeComponent();
            ComboBoxRol.DataSource = Enum.GetValues(typeof (RoleType));
            labelTitle.Text = "Añadir usuario";
        }

        public FormAddUser(User user)
        {
            InitializeComponent();
            ComboBoxRol.DataSource = Enum.GetValues(typeof(RoleType));
            labelTitle.Text = "Editar usuario";

            TextBoxUserName.Text = user.username;
            TextBoxEmail.Text = user.email;
            TextBoxName.Text = user.name;
            TextBoxSurname.Text = user.surname;

            ComboBoxRol.SelectedItem = Enum.Parse(typeof(RoleType), user.role, true);
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            /*
             * Obtiene los datos y genera el JSON que se envía
             */

            String username = TextBoxUserName.Text;
            String email = TextBoxEmail.Text;
            String password = "1234";
            String role = ComboBoxRol.Text;
            String name = TextBoxName.Text;
            String surname = TextBoxSurname.Text;

            // Convertir la imagen a Base64
            string profilePicture = "null";
            if (profilePictureBox.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    profilePictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();
                    profilePicture = Convert.ToBase64String(imageBytes);
                }
            }

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

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.png;*.jpg)|*.png;*.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                profilePictureBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
