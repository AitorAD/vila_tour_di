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
    public partial class FormAdmin : Form
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

        private void btnAdminPlace_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelLugares());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdminTraditions_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelFiestas());
        }

        private void btnAdminRecipes_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminRoutes_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminUsers_Click(object sender, EventArgs e)
        {
            LoadUserControl(new panelUser());
        }

       
    }
}
