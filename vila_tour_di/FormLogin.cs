using System;
using ClientRESTAPI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace vila_tour_di {
    public partial class FormLogin : Form {
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

        private void btnEntrar_Click(object sender, EventArgs e) {
            FormManagement managementForm;

            string username = txtUsername.Text;
            string apiUrl = $"http://127.0.0.1:8080/users/username?username={username}";
            var client = new RestClient(apiUrl, "GET");
            string jsonResponse = client.GetItem();

            if (jsonResponse != null)
            {
                try
                {
                    var user = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                    if (user[0].password.Equals(txtPassword.Text))
                    {
                        if (user[0].role.Equals("ADMIN") || user[0].role.Equals("EDITOR")){
                            managementForm = new FormManagement(user[0].role, user[0].name);
                            managementForm.Show();
                            this.Hide();
                        } else
                        {
                            MessageBox.Show("Usuario sin acceso, contacte con un administrador", "Acceso Denegado",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            else
            {
                MessageBox.Show("No se pudieron obtener los datos");
            }
        }

    }
}
