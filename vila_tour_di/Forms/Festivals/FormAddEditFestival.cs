using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormAddEditFestival : Form {
        bool isEditing = false;
        Festival selectedFestival;
        public FormAddEditFestival() {
            InitializeComponent();
            setValuesToForm();
            lblTitle.Text = "A�ADIR FIESTA O TRADICI�N";
        }

        public FormAddEditFestival(Festival festival, bool isEditing) {
            InitializeComponent();
            this.isEditing = isEditing;
            selectedFestival = festival;
            setValuesToForm();
            setStatusToForm();
        }

        private void setValuesToForm() {
            loadCoordinates();
            if (selectedFestival != null) {
                txtBoxName.Text = selectedFestival.name;
                txtBoxDesciption.Text = selectedFestival.description;
                DateTimePickerStart.Value = selectedFestival.startDate;
                DateTimePickerFinal.Value = selectedFestival.endDate;
                comboBoxCoordinates.SelectedValue = selectedFestival.coordinate.id;
            }
        }

        private void setStatusToForm() {
            string titleText = isEditing ? "EDITAR" : "DETALLES";
            titleText += " FIESTA O TRADICI�N";
            lblTitle.Text = titleText;

            txtBoxName.Enabled = isEditing;
            txtBoxDesciption.Enabled = isEditing;
            DateTimePickerStart.Enabled = isEditing;
            DateTimePickerFinal.Enabled = isEditing;
            comboBoxCoordinates.Enabled = isEditing;
        }

        private void btnAddFestival_Click(object sender, EventArgs e) {
            string name = txtBoxName.Text;
            string description = txtBoxDesciption.Text;
            DateTime startDate = DateTimePickerStart.Value; // Obtiene la fecha y la hora. Mirar que el formato sea valido.
            DateTime endDate = DateTimePickerFinal.Value; // Obtiene la fecha y la hora. Mirar que el formato sea valido.
            User creator = Config.currentUser;
            Coordinate coordinate = (Coordinate) comboBoxCoordinates.SelectedItem; // TODO: Asignar una coordenada

            Festival newFestival = new Festival(name, description, startDate, endDate, creator, coordinate);

            if (isEditing) {
                newFestival.creator = selectedFestival.creator; // Modifico el creador para que no se asigne uno nuevo
                if (FestivalService.UpdateFestival(selectedFestival.id, newFestival)) {
                    Dispose();
                }
            } else {
                if (FestivalService.AddFestival(newFestival)) {
                    Dispose();
                };
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void loadCoordinates() {
            List<Coordinate> coordinates = CoordinateService.GetAllCoordinates();
            comboBoxCoordinates.DataSource = coordinates; // Lista de coordenadas cargadas
            comboBoxCoordinates.DisplayMember = "DisplayText"; // Propiedad que se muestra al usuario
            comboBoxCoordinates.ValueMember = "id";    // Propiedad que se usar� como valor

        }
    }
}
