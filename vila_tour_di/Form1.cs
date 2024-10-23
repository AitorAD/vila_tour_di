using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        /*
        private void btnEntrar_Click(object sender, EventArgs e) {
            if (this.txtEmail.Text.Equals("redactor") && this.txtPassword.Text.Equals("redactor")) {
                new Form2().Show();
                this.Hide();
            } else if (this.txtEmail.Text.Equals("admin") && this.txtPassword.Text.Equals("admin")) {
                new Form2().Show();
                this.Hide();
            } else {
                MessageBox.Show("Error. Usuario o contraseña incorrectos");
            }
        }
        */

        private void Form1_Paint(object sender, PaintEventArgs e) {
            this.BackColor = Color.Empty;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(191, 79, 195, 246),
                Color.FromArgb(191, 1, 194, 169),
                45f)) {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e) {
            if (txtPassword.Text == "Password") {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e) {
            if (txtUser.Text == "User") {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtUser.Text)) {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Gray; 
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) {

        }
    }
}
