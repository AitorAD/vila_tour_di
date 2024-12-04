using GMap.NET;
using GMap.NET.MapProviders;
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
    public partial class FormAddEditCoordinate : Form
    {

        private Coordinate initialLocation = new Coordinate("Ies Marcos Zaragoza", 38.504719,-0.240991); 
        public FormAddEditCoordinate()
        {
            InitializeComponent();
            loadMap();
        }

        public FormAddEditCoordinate(Coordinate coordinate)
        {
            InitializeComponent();
            loadMap(coordinate);
        }

        private void loadMap( Coordinate coordinate)
        {
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.Position = new GMap.NET.PointLatLng(coordinate.latitude, coordinate.longitude);
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 15;
            gMapControl1.DragButton = MouseButtons.Left;
        }

        private void loadMap()
        {
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.Position = new GMap.NET.PointLatLng(initialLocation.latitude, initialLocation.longitude);
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 15;
            gMapControl1.DragButton = MouseButtons.Left;
        }

    }
}
