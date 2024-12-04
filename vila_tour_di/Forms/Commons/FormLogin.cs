using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace vila_tour_di {
    public partial class FormLogin : Form {
        private string JwToken;

        public FormLogin() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;  // Centrar la ventana
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            // Aplicar gradiente personalizado
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(191, 79, 195, 246),  // Color inicial
                Color.FromArgb(191, 1, 194, 169),   // Color final
                45f))                              // Ángulo del gradiente
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private async void btnEntrar_Click(object sender, EventArgs e) {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string apiUrl = "http://127.0.0.1:8080/auth/login";

            var loginData = new {
                username = username,
                password = password
            };

            string jsonData = JsonConvert.SerializeObject(loginData);

            using (var client = new HttpClient()) {
                try {
                    // Enviar las credenciales
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode) {
                        // Leer el token
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<JwtResponse>(responseString);

                        JwToken = responseData.Token;

                        Console.WriteLine($"Username: {responseData.Username}");
                        Console.WriteLine($"Email: {responseData.Email}");
                        Console.WriteLine($"Contraseña: {responseData.Role}");
                        Console.WriteLine($"Token: {responseData.Token}");

                        // Verificar los roles
                        bool hasAccess = responseData.Role.Exists(role => role.Authority == "ADMIN" || role.Authority == "EDITOR");

                        if (hasAccess) {
                            FormManagement managementForm = new FormManagement(responseData);
                            managementForm.Show();
                            this.Hide();
                        } else {
                            MessageBox.Show("Usuario sin acceso, contacte con un administrador", "Acceso Denegado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show("Credenciales incorrectas, por favor verifique su usuario y contraseña.",
                                        "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Error al intentar conectarse con el servidor: {ex.Message}",
                                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
