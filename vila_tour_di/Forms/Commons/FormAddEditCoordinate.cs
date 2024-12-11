using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di
{
    public partial class FormAddEditCoordinate : Form
    {
        private Coordinate initialLocation = new Coordinate("Ies Marcos Zaragoza", 38.504719, -0.240991);
        private Coordinate currentCoordinate;
        private bool isEditable;
        private GMapMarker marker;

        public Coordinate CurrentCoordinate => currentCoordinate;

        public FormAddEditCoordinate()
        {
            InitializeComponent();
            isEditable = true;
            currentCoordinate = null;
            loadMap(initialLocation, isEditable);
            lblLat.Text = initialLocation.latitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
            lblLon.Text = initialLocation.longitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
            lblTitle.Text = "Añadir ubicación";
        }

        public FormAddEditCoordinate(Coordinate coordinate, bool editable)
        {
            InitializeComponent();
            isEditable = editable;
            currentCoordinate = coordinate;

            loadMap(coordinate, isEditable);
            txtName.Text = coordinate.name;
            lblLat.Text = coordinate.latitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
            lblLon.Text = coordinate.longitude.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
            lblTitle.Text = editable ? "Editar ubicación" : "Detalles ubicación";

            if (!editable)
            {
                txtName.Enabled = false;
                btnSave.Enabled = false;
            }
        }


        private void loadMap(Coordinate coordinate, bool editable)
        {
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.Position = new GMap.NET.PointLatLng(coordinate.latitude, coordinate.longitude);
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 15;
            gMapControl1.DragButton = MouseButtons.Left;

            marker = new GMarkerGoogle(new PointLatLng(coordinate.latitude, coordinate.longitude), GMarkerGoogleType.red_dot);
            var markersOverlay = new GMapOverlay("markers");
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);

            if (editable)
            {
                gMapControl1.OnPositionChanged += gMapControl1_OnPositionChanged;
            }
        }

        private void gMapControl1_OnPositionChanged(PointLatLng point)
        {
            lblLat.Text = point.Lat.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
            lblLon.Text = point.Lng.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double lat = Double.Parse(lblLat.Text, System.Globalization.CultureInfo.InvariantCulture);
            double lon = Double.Parse(lblLon.Text, System.Globalization.CultureInfo.InvariantCulture);

            if (currentCoordinate == null)
            {
                Coordinate coordinate = new Coordinate(txtName.Text, lat, lon);
                var res = CoordinateService.AddCoordinate(coordinate);

                if (res.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string jsonResponse = res.Content.ReadAsStringAsync().Result;

                    try
                    {
                        currentCoordinate = System.Text.Json.JsonSerializer.Deserialize<Coordinate>(jsonResponse);

                        DialogResult = DialogResult.OK;
                        Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar la respuesta: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Error al añadir la coordenada. Código de estado: {res.StatusCode}");
                }
            }



            else
            {
                currentCoordinate.name = txtName.Text;
                currentCoordinate.latitude = lat;
                currentCoordinate.longitude = lon;
                if (CoordinateService.UpdateCoordinate(currentCoordinate))
                {
                    MessageBox.Show("Coordenada actualizada correctamente.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la coordenada.");
                }

            }
        }


    }
}
