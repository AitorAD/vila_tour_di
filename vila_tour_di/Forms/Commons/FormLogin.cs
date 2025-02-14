using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using vila_tour_di.Services;
using vila_tour_di.Forms.Commons;
using System.Diagnostics;

namespace vila_tour_di {
    public partial class FormLogin : Form {
        private string JwToken;

        public FormLogin() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;  // Centrar la ventana
            this.KeyPreview = true;  // Permite que el formulario capture eventos de teclado
            this.KeyDown += new KeyEventHandler(FormLogin_KeyDown);  // Suscribirse al evento KeyDown
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                gunaBtnEntrar_Click(sender, e);  // Llamar al método del botón
            }
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

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing) {
                Application.Exit();
            }
        }

        private async void gunaBtnEntrar_Click(object sender, EventArgs e)  {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string apiUrl = Config.baseURL + "auth/login";

            var loginData = new {
                username = username,
                password = password
            };

            string jsonData = JsonConvert.SerializeObject(loginData);

            using (var client = new HttpClient()) {
                try {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode) {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<JwtResponse>(responseString);

                        JwToken = responseData.Token;

                        bool hasAccess = (responseData.Role == "ADMIN" || responseData.Role == "EDITOR");

                        if (hasAccess) {
                            Config.currentToken = responseData.Token;
                            Config.currentUser = UserService.GetUserById((int)responseData.Id);
                            FormManagement managementForm = new FormManagement();
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

        private void btnSettings_Click(object sender, EventArgs e) {
            FormSettings formSettings = new FormSettings();
            formSettings.StartPosition = FormStartPosition.CenterParent;
            formSettings.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e) {
            string rutaArchivo = @"C:\Users\dam_ada\Desktop\proyecto\vila_tour_di\vila_tour_di\Help\VilaTour.pdf";  // Ruta completa del archivo
            Process.Start("explorer", rutaArchivo);
        }
    }
}
