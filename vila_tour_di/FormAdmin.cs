using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di
{
    public partial class FormAdmin : BaseForm
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        public void LoadUserControl(UserControl newControl)
        {
            panel1.Controls.Clear();

            newControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(newControl);
        }

        private void btnPlaces_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelLugares());
        }

        private void btnFestivals_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelFiestas());
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelRecetas());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelUser());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
