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
            imageSlider = new Forms.Commons.ImageSlider();
            loadCoordinates();
            if (selectedFestival != null) {
                txtBoxName.Text = selectedFestival.name;
                txtBoxDesciption.Text = selectedFestival.description;
                DateTimePickerStart.Value = selectedFestival.startDate;
                DateTimePickerFinal.Value = selectedFestival.endDate;
                comboBoxCoordinates.SelectedValue = selectedFestival.coordinate.id;

                foreach (Models.Image image in selectedFestival.images) {
                    Console.WriteLine(image);
                }
                imageSlider.images = selectedFestival.images;

                // pictureBoxFestival.Image = Utils.Utils.Base64ToImage(selectedFestival.images.FirstOrDefault().path);

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
            btnAddImage.Enabled = isEditing;
            btnAddCoordinate.Enabled = isEditing;
            btnAddFestival.Enabled = isEditing;
        }

        private void btnAddFestival_Click(object sender, EventArgs e) {
            string name = txtBoxName.Text;
            string description = txtBoxDesciption.Text;
            DateTime startDate = DateTimePickerStart.Value; // Obtiene la fecha y la hora. Mirar que el formato sea valido.
            DateTime endDate = DateTimePickerFinal.Value; // Obtiene la fecha y la hora. Mirar que el formato sea valido.
            User creator = Config.currentUser;
            Coordinate coordinate = (Coordinate) comboBoxCoordinates.SelectedItem; // TODO: Asignar una coordenada

            Festival newFestival = new Festival(name, description, startDate, endDate, creator, coordinate);

            string base64Image = "null";
            /*
            if (pictureBoxFestival.Image != null && pictureBoxFestival.Tag != null) {
                string filePath = pictureBoxFestival.Tag.ToString();
                base64Image = Utils.Utils.ConvertImageToBase64(filePath);
                Console.WriteLine(base64Image);
            }
            */

            if (isEditing) {
                newFestival.creator = selectedFestival.creator; // Modifico el creador para que no se asigne uno nuevo
                if (FestivalService.UpdateFestival(selectedFestival.id, newFestival)) {
                    Dispose();
                }
            } else {
                var response = FestivalService.AddFestival(newFestival); // Almaceno la respuesta ya que esta devuelve el festival entero con su id ya asignado.
                
                if (response.IsSuccessStatusCode) {
                    ApiService.HandleResponse(response, "Festival creado correctamente.", "Error al crear el festival");
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    Festival createdFestival = JsonConvert.DeserializeObject<Festival>(jsonResponse);

                    Models.Image image = new Models.Image(base64Image, createdFestival);
                    ImageService.AddImage(image);

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

        private void btnAddImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Selecciona una imagen de perfil";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;

                    // Cargar la imagen en el PictureBox
                    // pictureBoxFestival.SizeMode = PictureBoxSizeMode.StretchImage;
                    // pictureBoxFestival.Image = System.Drawing.Image.FromFile(selectedFilePath);
                    // pictureBoxFestival.Tag = selectedFilePath;

                }
            }
        }

    }
}
