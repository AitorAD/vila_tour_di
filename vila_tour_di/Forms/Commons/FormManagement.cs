using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormManagement : Form {
        private Guna2Button currentButton;
        private Guna2Button lastButton;
        private Size originalSize;
        private Point originalLocation;
        private bool isLoggingOut = false;

        public FormManagement() {
            InitializeComponent();
            ValidaRol();
            lblWelcome.Text = ("Bienvenido/a: " + Config.currentUser.name);
        }

        private void ValidaRol() {
            if (Config.currentUser.role == "EDITOR") {
                btnUsers.Visible = false; 
            } else if (Config.currentUser.role == "ADMIN") {
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
                lastButton.Size = originalSize;
                lastButton.Location = originalLocation;
            }

            if (button != null) {
                button.ForeColor = Color.Black;
                button.FillColor = Color.White;
                originalSize = button.Size;
                originalLocation = button.Location;

                // Aplica los cambios al botón actual
                button.ForeColor = Color.Black;
                button.FillColor = Color.White;
                button.Size = new Size(150, 50);
                button.Location = new Point(sidePanel.Width+10 - button.Width, button.Location.Y);
            }

            lastButton = button;
        }

        private void btnPlaces_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new UserControlPlaces());
        }

        private void btnFestivals_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new UserControlFestivals());

        }

        private void btnRecipes_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new UserControlRecipes());

        }

        private void btnUsers_Click(object sender, EventArgs e) {
            ChangeButtonColor(sender as Guna2Button);
            LoadUserControl(new UserControlUsers());

        }

        private void btnLogOut_Click(object sender, EventArgs e) {
            isLoggingOut = true;

            Config.currentToken = null;
            Config.currentUser = null;

            FormLogin loginForm = new FormLogin();
            loginForm.Show();

            this.Close();
        }

        private void FormManagement_FormClosing(object sender, FormClosingEventArgs e) {
            if (!isLoggingOut && (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall)) {
                Application.Exit();
            }
        }

    }
}
