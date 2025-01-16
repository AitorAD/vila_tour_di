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
            labelTitle.Text = "AÑADIR LUGAR DE INTERÉS";
            LoadCategoriesIntoComboBox();
        }

        private void InitializeFormForEditing(Place place, bool editable) {
            _currentPlace = place;
            _isEditing = editable;

            labelTitle.Text = editable ? "EDITAR LUGAR DE INTERÉS" : "DETALLES DEL LUGAR DE INTERÉS";

            LoadCategoriesIntoComboBox();

            txtName.Text = place.name;
            comboCategory.SelectedItem = place.categoryPlace;
            txtDescription.Text = place.description;
            lblCreationDate.Text = "Fecha de creación: " + place.creationDate;
            lblLastModificationDate.Text = "Última modificación: " + place.lastModificationDate;
            lblNameLocation.Text = place.coordinate.name;
            _currentCoordinate = place.coordinate;

            // Cargar imágenes asociadas al lugar
            if ((imageSlider.images = ImageService.GetImagesByArticle(place))?.Count > 0) {
                imageSlider.article = place;
                imageSlider.LoadImage();
            }

            ConfigureFormForReadOnly(!editable);
            imageSlider.setStatusButtons(_isEditing);
        }

        private void ConfigureFormForReadOnly(bool isReadOnly) {
            txtName.ReadOnly = isReadOnly;
            comboCategory.Enabled = !isReadOnly;
            txtDescription.ReadOnly = isReadOnly;
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
            if (_currentCoordinate != null && !_isEditing) {
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
            Console.WriteLine(newPlace);

            if (_isEditing) {
                newPlace.creator = _currentPlace.creator; // Modifico el creador para que no se asigne uno nuevo
                ImageService.DeleteAllByArticle(_currentPlace); // Elimino todas las imagenes asociadas a este articulo para despues agregar los cambios correspondientes
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
            imageSlider.images.ForEach(image => image.id = null);
            return new Place {
                name = txtName.Text.Trim(),
                description = txtDescription.Text.Trim(),
                creationDate = _isEditing ? _currentPlace.creationDate : DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                lastModificationDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                categoryPlace = ((CategoryPlace)comboCategory.SelectedItem),
                coordinate = _currentCoordinate,
                creator = _isEditing ? _currentPlace.creator : Config.currentUser,
                images = imageSlider.images
            };
        }

        private void UpdatePlace(Place updatedPlace) {
            if (PlaceService.UpdatePlace(_currentPlace, updatedPlace)) {
                Dispose();
            } else {
                MessageBox.Show("Error al actualizar el lugar. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewPlace(Place newPlace) {
            var response = PlaceService.AddPlace(newPlace);
            if (response.IsSuccessStatusCode) {

                ApiService.HandleResponse(response, "Lugar de interés creado correctamente.", "Error al crear el lugar de interés.");
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                Place createdPlace = JsonConvert.DeserializeObject<Place>(jsonResponse);

                // Verificar si hay imágenes antes de intentar añadirlas
                if (imageSlider.images != null && imageSlider.images.Count > 0) {
                    imageSlider.images.ForEach(image => ImageService.AddImage(new Models.Image(image.path, createdPlace)));
                }
                Dispose();
            } else {
                MessageBox.Show("Error al añadir el lugar. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
