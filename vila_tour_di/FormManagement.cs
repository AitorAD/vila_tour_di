using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace vila_tour_di {
    public partial class FormManagement : Form {
        private Guna2Button currentButton;
        private Guna2Button lastButton;
        private string rol;

        public FormManagement(string rol) {
            InitializeComponent();
            this.rol = rol;
            ValidaRol();
        }

        private void ValidaRol() {
            MessageBox.Show("Rol actual: " + rol);
            if (rol == "redactor") {
                btnUsers.Visible = false; 
            } else if (rol == "admin") {
                btnUsers.Visible = true;  
            }
        }

        public void LoadUserControl(UserControl newControl) {
            mainPanel.Controls.Clear();
            newControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(newControl);
        }

        private void ChangeButtonColor(Guna2Button button) {
            if (lastButton != null) {
                lastButton.ForeColor = button.ForeColor;
                lastButton.FillColor = button.FillColor;
            }

            if (button != null) {
                button.ForeColor = Color.Black;
                button.FillColor = Color.White;
            }
            lastButton = button;
        }

        private void btnPlaces_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new panelLugares());
        }

        private void btnFestivals_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new panelFiestas());

        }

        private void btnRecipes_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new panelRecetas());

        }

        private void btnUsers_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new panelUser());

        }

        private void btnLogOut_Click(object sender, EventArgs e) {
            Close();
            new FormLogin().Show();
            // TODO hacer que se muestre la pantalla de LogIn al hacer clic en este boton
        }

        private void FormManagement_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall) {
                Application.Exit();  // Cierra completamente la aplicación
            }
        }
    }
}
