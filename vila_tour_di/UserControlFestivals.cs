using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Properties;

namespace vila_tour_di {
    public partial class panelFiestas : UserControl {
        public panelFiestas() {
            InitializeComponent();
        }

        private void buttonAddFiesta_Click(object sender, EventArgs e)
        {
            FormAddFestival formAddFestival= new FormAddFestival();
            formAddFestival.StartPosition = FormStartPosition.CenterParent;
            formAddFestival.ShowDialog();
        }
    }
}
