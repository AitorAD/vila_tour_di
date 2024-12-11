using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di {
    public partial class FormAddEditPlace : Form {
        private Place _currentPlace;
        private bool _isEditing;
        private bool _isCreating;
        private Coordinate _currentCoordinate;

        public FormAddEditPlace() {
            InitializeComponent();
            InitializeFormForCreation();
        }

        public FormAddEditPlace(Place place, bool editable) {
            InitializeComponent();
            InitializeFormForEditing(place, editable);
        }

        private void InitializeFormForCreation() {
            _currentCoordinate = null;
            labelTitle.Text = "Añadir lugar de interés";
            LoadCategoriesIntoComboBox();
        }

        private void InitializeFormForEditing(Place place, bool editable) {
            _currentPlace = place;
            _isEditing = editable;

            labelTitle.Text = editable ? "Editar lugar de interés" : "Detalles del lugar de interés";

            LoadCategoriesIntoComboBox();

            txtName.Text = place.name;
            comboCategory.SelectedItem = place.categoryPlace;
            txtDescription.Text = place.description;
            lblCreationDate.Text = "Fecha de creación: " + place.creationDate;
            lblLastModificationDate.Text = "Última modificación: " + place.lastModificationDate;
            lblNameLocation.Text = place.coordinate.name;
            _currentCoordinate = place.coordinate;

            if (!string.IsNullOrEmpty(place.imagensPaths)) {
                imgPlace.Image = Base64ToImage(place.imagensPaths);
                imgPlace.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            ConfigureFormForReadOnly(!editable);
        }


        private void ConfigureFormForReadOnly(bool isReadOnly) {
            txtName.ReadOnly = isReadOnly;
            comboCategory.Enabled = !isReadOnly;
            txtDescription.ReadOnly = isReadOnly;
            btnAddImage.Enabled = !isReadOnly;
            btnAddPlace.Enabled = !isReadOnly;
            btnLocation.Enabled = !isReadOnly;
        }

        private void LoadCategoriesIntoComboBox() {
            try {
                List<CategoryPlace> categories = CategoryPlaceService.GetCategoriesPlaces();
                comboCategory.DataSource = categories;
                comboCategory.DisplayMember = "name";
                comboCategory.ValueMember = "id";

                if (categories == null || categories.Count == 0) {
                    MessageBox.Show("No se encontraron categorías de lugares.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al cargar las categorías de lugares: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e) {
            if (_currentCoordinate != null) {
                CoordinateService.DeleteCoordinate(_currentCoordinate.id);
            }

            Close();
        }


        private void btnLocation_Click(object sender, EventArgs e) {
            FormAddEditCoordinate coordinateForm = _currentCoordinate == null
                ? new FormAddEditCoordinate()
                : new FormAddEditCoordinate(_currentCoordinate, true);

            if (coordinateForm.ShowDialog() == DialogResult.OK) {
                _currentCoordinate = coordinateForm.CurrentCoordinate;

                if (_currentCoordinate != null) {
                    lblNameLocation.Text = _currentCoordinate.name;
                }
            }
        }


        private void btnAddPlace_Click(object sender, EventArgs e) {
            if (!ValidateFormInputs())
                return;

            Place newPlace = CreatePlaceFromInputs();

            if (_isEditing) {
                UpdatePlace(newPlace);
            } else {
                AddNewPlace(newPlace);
            }
        }

        private bool ValidateFormInputs() {
            if (string.IsNullOrWhiteSpace(txtName.Text)) {
                MessageBox.Show("El nombre del lugar es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboCategory.SelectedItem == null) {
                MessageBox.Show("Debe seleccionar una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_currentCoordinate == null) {
                MessageBox.Show("Debe establecer la ubicación del lugar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Place CreatePlaceFromInputs() {
            return new Place {
                name = txtName.Text.Trim(),
                description = txtDescription.Text.Trim(),
                imagensPaths = imgPlace.Image != null ? ConvertImageToBase64(imgPlace.ImageLocation) : null,
                creationDate = _isEditing ? _currentPlace.creationDate : DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                lastModificationDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                categoryPlace = ((CategoryPlace)comboCategory.SelectedItem),
                coordinate = _currentCoordinate,
                creator = _isEditing ? _currentPlace.creator : Config.currentUser
            };
        }

        private void UpdatePlace(Place updatedPlace) {
            if (imgPlace.Image != null) {
                updatedPlace.imagensPaths = ConvertImageToBase64(imgPlace.Tag.ToString());
            }

            if (PlaceService.UpdatePlace(_currentPlace, updatedPlace)) {
                Close();
            } else {
                MessageBox.Show("Error al actualizar el lugar. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AddNewPlace(Place newPlace) {
            if (imgPlace.Image != null) {
                newPlace.imagensPaths = ConvertImageToBase64(imgPlace.Tag.ToString());
            }

            if (PlaceService.AddPlace(newPlace)) {
                DialogResult = DialogResult.OK;
                Close();
            } else {
                MessageBox.Show("Error al añadir el lugar. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string ConvertImageToBase64(string filePath) {
            try {
                Image image = Image.FromFile(filePath);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir la imagen a Base64: " + ex.Message);
                return null;
            }
        }


        private Image Base64ToImage(string base64String) {
            try {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            } catch (Exception ex) {
                MessageBox.Show("Error al convertir Base64 a imagen: " + ex.Message);
                return null;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
                openFileDialog.Title = "Selecciona una imagen de perfil";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;

                    imgPlace.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgPlace.Image = Image.FromFile(selectedFilePath);
                    imgPlace.Tag = selectedFilePath;
                }
            }
        }

    }
}