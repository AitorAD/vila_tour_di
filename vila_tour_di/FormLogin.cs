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
    public partial class FormLogin : BaseForm {
        public FormLogin() {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e) {
            if (this.txtEmail.Text.Equals("redactor") && this.txtPassword.Text.Equals("redactor")) {
                new FormRedactor().Show();
                this.Hide();
            } else if (this.txtEmail.Text.Equals("admin") && this.txtPassword.Text.Equals("admin")) {
                new FormAdmin().Show();
                this.Hide();
            } else {
                MessageBox.Show("Error. Usuario o contraseña incorrectos");
            }
        }
    }
}
