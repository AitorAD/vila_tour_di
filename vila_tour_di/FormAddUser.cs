using ClientRESTAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di
{
    public partial class FormAddUser : Form
    {
        private User _currentUser; // Campo para almacenar el usuario actual

        public FormAddUser()
        {
            InitializeComponent();
            ComboBoxRol.DataSource = Enum.GetValues(typeof(RoleType));
            labelTitle.Text = "Añadir usuario";
        }

        public FormAddUser(User user, bool editable)
        {
            InitializeComponent();
            ComboBoxRol.DataSource = Enum.GetValues(typeof(RoleType));
            labelTitle.Text = editable ? "Editar usuario" : "Detalles del usuario";

            _currentUser = user; // Almacenar el usuario en el campo privado

            // Rellenar los campos con los datos del usuario
            TextBoxUserName.Text = user.username;
            TextBoxeEmail.Text = user.email;
            ComboBoxRol.SelectedItem = Enum.Parse(typeof(RoleType), user.role);
            TextBoxName.Text = user.name;
            TextBoxSurname.Text = user.surname;

            if (user.profilePicture != null)
            {
                // Convertir la imagen base64 a Image y cargarla en el PictureBox
                profilePicBox.Image = Base64ToImage(user.profilePicture);
                profilePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            // Deshabilitar campos si no es editable
            if (!editable)
            {
                TextBoxUserName.ReadOnly = true;
                TextBoxeEmail.ReadOnly = true;
                ComboBoxRol.Enabled = false;
                TextBoxName.ReadOnly = true;
                TextBoxSurname.ReadOnly = true;
                btnAddImage.Enabled = false;
                btnAddUser.Enabled = false;
            }
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Obtener los datos actualizados
            string username = TextBoxUserName.Text;
            string email = TextBoxeEmail.Text;
            string password = "1234"; // Puede ser vacío o un campo no editable
            string role = ComboBoxRol.Text;
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;

            // Convertir la imagen a base64
            string profilePicture = "null";
            if (profilePicBox.Image != null && profilePicBox.Tag != null)
            {
                string filePath = profilePicBox.Tag.ToString();
                profilePicture = ConvertImageToBase64(filePath);
            }

            string url = "http://127.0.0.1:8080/users";

            RestClient client;
            string datos;
            string resultado;

            if (labelTitle.Text == "Editar usuario" && _currentUser != null)
            {
                // Enviar actualización (PUT)
                client = new RestClient($"{url}/{_currentUser.id}", "PUT");
                datos = "{" +
                    $"\"username\": \"{username}\", " +
                    $"\"email\": \"{email}\", " +
                    $"\"password\": \"{password}\", " +
                    $"\"role\": \"{role}\", " +
                    $"\"name\": \"{name}\", " +
                    $"\"surname\": \"{surname}\", " +
                    $"\"profilePicture\": \"{profilePicture}\"" +
                "}";
                resultado = client.PutItem(datos);

                if (resultado.Contains("name"))
                {
                    MessageBox.Show("Usuario editado con éxito.");
                }
                else
                {
                    MessageBox.Show("Error al editar el usuario.");
                }
            }
            else
            {
                // Crear nuevo usuario (POST)
                client = new RestClient(url, "POST");
                datos = "{" +
                    $"\"username\": \"{username}\", " +
                    $"\"email\": \"{email}\", " +
                    $"\"password\": \"{password}\", " +
                    $"\"role\": \"{role}\", " +
                    $"\"name\": \"{name}\", " +
                    $"\"surname\": \"{surname}\", " +
                    $"\"profilePicture\": \"{profilePicture}\"" +
                "}";
                resultado = client.PostItem(datos);

                if (resultado.Contains("name")) // Ajusta esta condición según el formato de la respuesta del servidor
                {
                    MessageBox.Show("Usuario añadido con éxito.");
                }
                else
                {
                    MessageBox.Show("Error al añadir el usuario.");
                }
            }

            Dispose();
        }


        private string ConvertImageToBase64(string filePath)
        {
            try
            {
                using (Image image = Image.FromFile(filePath))
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guardar la imagen en un MemoryStream como PNG
                    image.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    // Convertir los bytes a una cadena Base64
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir la imagen a Base64: " + ex.Message);
                return null;
            }
        }

        private Image Base64ToImage(string base64String)
        {
            try
            {
                if (string.IsNullOrEmpty(base64String)) return null;
                var imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("La imagen base64 tiene un formato incorrecto: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir Base64 a imagen: " + ex.Message);
                return null;
            }
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Selecciona una imagen de perfil";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Cargar la imagen en el PictureBox
                    profilePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    profilePicBox.Image = Image.FromFile(selectedFilePath);
                    profilePicBox.Tag = selectedFilePath;
                }
            }
        }

        public enum RoleType
        {
            USER,
            ADMIN,
            EDITOR
        }
    }
}
