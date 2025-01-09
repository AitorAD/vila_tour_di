using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using vila_tour_di.Models;
using vila_tour_di.Services;

namespace vila_tour_di.Forms.Routes {
    public partial class FormAddEditRoute : Form {
        bool isEditing = false;
        private Route _selectedRoute;
        public FormAddEditRoute() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR RUTA";
            LoadPlacesComboBox();
            this.FormClosed += FormAddEditRoute_FormClosed;
        }

        public FormAddEditRoute(Route route, bool showDetails) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR RUTA";
            _selectedRoute = route;

            //Asignar los valores
            guna2TextBoxName.Text = route.name;

            //Seleccionar los lugares de la ruta cargada
            if (route.places != null) {
                listBoxLugares.Items.Clear();
                foreach (var place in route.places) {
                    listBoxLugares.Items.Add(place);
                }
            }

            this.Text = "Editar Ruta";

            if (showDetails) {
                guna2TextBoxName.Enabled = false;
                btnAddIPlace.Enabled = false;
                btnDeletePlace.Enabled = false;
                btnAddRoute.Enabled = false;
            }
            LoadPlacesComboBox();
            this.FormClosed += FormAddEditRoute_FormClosed;
        }

        private void LoadPlacesComboBox() {
            guna2ComboBoxPlaces.Items.Clear();

            List<Place> places = PlaceService.GetAllPlaces();

            guna2ComboBoxPlaces.DisplayMember = "name";
            guna2ComboBoxPlaces.ValueMember = "id";
            listBoxLugares.DisplayMember = "name";

            foreach (var place in places) {
                guna2ComboBoxPlaces.Items.Add(place);
            }
        }


        private void btnAddRoute_Click(object sender, EventArgs e) {
            //Obtener los datos
            string name = guna2TextBoxName.Text;
            List<Place> places = new List<Place>();
            User creator = Config.currentUser;

            // Recorrer el combobox
            foreach(var item in listBoxLugares.Items) {
                if(item is Place place) {
                    places.Add(place);
                }
            }

            Route newRoute = new Route(name, places, creator);

            if (isEditing) {
                newRoute.creationDate = _selectedRoute.creationDate;
                newRoute.creator = _selectedRoute.creator;
                RouteService.UpdateRoute(_selectedRoute, newRoute);
                Dispose();
            } else {
                newRoute.creator = Config.currentUser;
                RouteService.AddRoute(newRoute);
                Dispose();
            }
        }

        private void btnAddIPlace_Click(object sender, EventArgs e) {
            var selectedPlace = guna2ComboBoxPlaces.SelectedItem as Place;

            if(selectedPlace != null && listBoxLugares.Items.Cast<Place>().Any(place => place.name.Equals(selectedPlace.name))) {
                MessageBox.Show("Error. Lugar repetido",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            } else if (selectedPlace != null) {
                listBoxLugares.Items.Add(selectedPlace);
            } else {
                MessageBox.Show("Error. Seleciona un Ingrediente",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnDeletePlace_Click(object sender, EventArgs e) {
            // Verifica si hay un elemento seleccionado
            if (listBoxLugares.SelectedItem != null) {
                // Elimina el elemento seleccionado
                listBoxLugares.Items.Remove(listBoxLugares.SelectedItem);
            } else {
                // Mensaje si no hay ningún elemento seleccionado
                MessageBox.Show("Por favor, selecciona un lugar para eliminar.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void FormAddEditRoute_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.Owner is FormIngredient mainForm) {
                mainForm.LoadIngredientsInDataGridView();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void gMapControl_Load(object sender, EventArgs e) {

        }
    }
}
