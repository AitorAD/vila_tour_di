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
using vila_tour_di.Utils;
using vila_tour_di.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace vila_tour_di {
    public partial class FormAddEditFestival : Form {
        bool isEditing = false;
        Festival selectedFestival;
        Coordinate currentCoordinate;
        public FormAddEditFestival() {
            InitializeComponent();
            setValuesToForm();
            lblTitle.Text = "AÑADIR FIESTA O TRADICIÓN";
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

                // Obtenemos las imagenes
                if ((imageSlider.images = ImageService.GetImagesByArticle(selectedFestival))?.Count > 0) { 
                    imageSlider.article = selectedFestival; 
                    imageSlider.LoadImage(); 
                }
            }
        }

        private void setStatusToForm() {
            string titleText = isEditing ? "EDITAR" : "DETALLES";
            titleText += " FIESTA O TRADICIÓN";
            lblTitle.Text = titleText;

            txtBoxName.Enabled = isEditing;
            txtBoxDesciption.Enabled = isEditing;
            DateTimePickerStart.Enabled = isEditing;
            DateTimePickerFinal.Enabled = isEditing;
            comboBoxCoordinates.Enabled = isEditing;
            imageSlider.setStatusButtons(isEditing);
            btnAddCoordinate.Enabled = isEditing;
            btnAddFestival.Enabled = isEditing;
        }

        private void btnAddFestival_Click(object sender, EventArgs e) {
            string name = txtBoxName.Text;
            string description = txtBoxDesciption.Text;
            DateTime startDate = DateTimePickerStart.Value;
            DateTime endDate = DateTimePickerFinal.Value; 
            User creator = Config.currentUser;
            Coordinate coordinate = (Coordinate) comboBoxCoordinates.SelectedItem;

            imageSlider.images.ForEach(image => image.id = null);
            Festival newFestival = new Festival(name, description, startDate, endDate, creator, coordinate, imageSlider.images);
            // Console.WriteLine(newFestival);

            if (isEditing) {
                newFestival.creator = selectedFestival.creator; // Modifico el creador para que no se asigne uno nuevo
                int festivalId = selectedFestival.id ?? 0; // Si id es null, asigna 0
                if (FestivalService.UpdateFestival(festivalId, newFestival)) {
                    Dispose();
                }
            } else {
                if (FestivalService.AddFestival(newFestival)) {
                    Dispose();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void loadCoordinates() {
            List<Coordinate> coordinates = CoordinateService.GetAllCoordinates();
            comboBoxCoordinates.DataSource = coordinates; // Lista de coordenadas cargadas
            comboBoxCoordinates.DisplayMember = "DisplayText"; // Propiedad que se muestra al usuario
            comboBoxCoordinates.ValueMember = "id";    // Propiedad que se usará como valor

        }

        private void btnAddCoordinate_Click(object sender, EventArgs e) {
            FormAddEditCoordinate formAddEditCoordinate = currentCoordinate == null
                ? new FormAddEditCoordinate()
                : new FormAddEditCoordinate(currentCoordinate, true);

            formAddEditCoordinate.StartPosition = FormStartPosition.CenterScreen;
            var result = formAddEditCoordinate.ShowDialog();

            if (result == DialogResult.OK) {
                currentCoordinate = formAddEditCoordinate.CurrentCoordinate;
                loadCoordinates();
            }
        }
    }
}
