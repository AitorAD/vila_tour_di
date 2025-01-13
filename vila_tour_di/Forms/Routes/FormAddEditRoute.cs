using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using vila_tour_di.Models;
using vila_tour_di.Services;

namespace vila_tour_di.Forms.Routes {
    public partial class FormAddEditRoute : Form {
        bool isEditing = false;
        private RouteVilaTour _selectedRoute;
        private GMapOverlay routesOverlay;
        private GMapOverlay markersOverlay;

        public FormAddEditRoute() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR RUTA";
            LoadPlacesComboBox();
            InitializeMap();
        }

        public FormAddEditRoute(RouteVilaTour route, bool showDetails) : this() {
            isEditing = true;
            labelTitle.Text = "EDITAR RUTA";
            _selectedRoute = route;

            guna2TextBoxName.Text = route.name;

            if (route.places != null) {
                listBoxLugares.Items.Clear();
                foreach (var place in route.places) {
                    listBoxLugares.Items.Add(place.name);
                }
            }

            if (showDetails) {
                labelTitle.Text = "DETALLES RUTA";
                guna2TextBoxName.Enabled = false;
                btnAddPlace.Enabled = false;
                btnDeletePlace.Enabled = false;
                btnAddRoute.Enabled = false;
            }
            UpdateMapRoute();

        }

        private void LoadPlacesComboBox() {
            guna2ComboBoxPlaces.Items.Clear();
            var places = PlaceService.GetAllPlaces();
            guna2ComboBoxPlaces.DisplayMember = "name";
            guna2ComboBoxPlaces.ValueMember = "id";

            foreach (var place in places) {
                guna2ComboBoxPlaces.Items.Add(place);
            }
        }

        private void InitializeMap() {
            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl.Position = new PointLatLng(38.508688, -0.232521); // Coordenadas iniciales
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 15;
            gMapControl.DragButton = MouseButtons.Left;

            routesOverlay = new GMapOverlay("routes");
            markersOverlay = new GMapOverlay("markers");
            gMapControl.Overlays.Add(routesOverlay);
            gMapControl.Overlays.Add(markersOverlay);
            gMapControl.ShowCenter = false;
        }

        private void UpdateMapRoute() {
            routesOverlay.Routes.Clear();
            markersOverlay.Markers.Clear();

            var points = new List<PointLatLng>();
            var places = PlaceService.GetAllPlaces();

            // Obtener las coordenadas de los lugares seleccionados
            foreach (string placeName in listBoxLugares.Items) {
                var place = places.FirstOrDefault(p => p.name == placeName);
                if (place != null) {
                    var point = new PointLatLng(place.coordinate.latitude, place.coordinate.longitude);
                    points.Add(point);

                    // Añadir marcador para cada lugar
                    var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                    marker.ToolTipText = place.name;
                    markersOverlay.Markers.Add(marker);
                }
            }

            // Si hay al menos dos puntos, calcular la ruta que pase por todos
            if (points.Count > 1) {
                for (int i = 0; i < points.Count - 1; i++) {
                    var routeSegment = GMapProviders.OpenStreetMap.GetRoute(points[i], points[i + 1], false, true, 15);
                    if (routeSegment != null) {
                        var gmapRoute = new GMapRoute(routeSegment.Points, $"Ruta de {i} a {i + 1}");
                        gmapRoute.Stroke = new Pen(Color.Red, 3);
                        routesOverlay.Routes.Add(gmapRoute);
                    }
                }
            }

            // Centrar el mapa en el primer punto si existe
            if (points.Any()) {
                gMapControl.Position = points[0];
            }

            // Actualizar el control del mapa
            gMapControl.Refresh();
        }



        private void btnAddIPlace_Click(object sender, EventArgs e) {
            var selectedPlace = guna2ComboBoxPlaces.SelectedItem as Place;
            if (selectedPlace != null && listBoxLugares.Items.Cast<string>().Any(name => name.Equals(selectedPlace.name))) {
                MessageBox.Show("Error. Lugar repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (selectedPlace != null) {
                listBoxLugares.Items.Add(selectedPlace.name); // Añadir solo el nombre
                UpdateMapRoute();
            } else {
                MessageBox.Show("Error. Selecciona un lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletePlace_Click(object sender, EventArgs e) {
            if (listBoxLugares.SelectedItem != null) {
                listBoxLugares.Items.Remove(listBoxLugares.SelectedItem);
                UpdateMapRoute();
            } else {
                MessageBox.Show("Por favor, selecciona un lugar para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddRoute_Click(object sender, EventArgs e) {
            string name = guna2TextBoxName.Text;
            var places = listBoxLugares.Items.Cast<string>()
                           .Select(placeName => PlaceService.GetAllPlaces().FirstOrDefault(p => p.name == placeName))
                           .Where(place => place != null)
                           .ToList();
            User creator = Config.currentUser;

            if (string.IsNullOrEmpty(name)) {
                MessageBox.Show("Por favor, ingrese un nombre para la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (places.Count == 0) {
                MessageBox.Show("Por favor, añada al menos un lugar a la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newRoute = new RouteVilaTour(name, places, creator);

            if (isEditing) {
                newRoute.creationDate = _selectedRoute.creationDate;
                newRoute.creator = _selectedRoute.creator;
                RouteService.UpdateRoute(_selectedRoute, newRoute);
            } else {
                RouteService.AddRoute(newRoute);
            }

            Dispose();
        }

        private void btnCloseForm_Click_1(object sender, EventArgs e) {
            Dispose();
        }
    }
}
