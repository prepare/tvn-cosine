using Prism.Mvvm;
using System.Collections.ObjectModel; 
using Tvn.Cosine.Wpf.Views.UserControls;

namespace Tvn.Cosine.Wpf.Views.Windows
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            ApplicationName = "tvn-cosine Wpf Application";
            Zones = new ObservableCollection<Zone>();


            var zone = new Zone();
            zone.FillColor = Tvn.Cosine.Imaging.Color.Pink;
            zone.Order = 232;
            zone.ZoneType = "Text";
            zone.X = 430;
            zone.Y = 150;
            zone.Width = 300;
            zone.Height = 430;
            Zones.Add(zone);


            var zone2 = new Zone();
            zone2.FillColor = Tvn.Cosine.Imaging.Color.Green;
            zone2.Order = 2;
            zone2.ZoneType = "Text";
            zone2.X = 500;
            zone2.Y = 200;
            zone2.Width = 20;
            zone2.Height = 50;
            Zones.Add(zone2);

            CanvasDrawingMode = CanvasDrawingMode.DELETE;
        }

        private CanvasDrawingMode canvasDrawingMode;
        public CanvasDrawingMode CanvasDrawingMode
        {
            get { return canvasDrawingMode; }
            set { SetProperty(ref canvasDrawingMode, value); }
        }

        private string applicationName;
        public string ApplicationName
        {
            get { return applicationName; }
            set { SetProperty(ref applicationName, value); }
        }

        private ObservableCollection<Zone> zones;
        public ObservableCollection<Zone> Zones
        {
            get { return zones; }
            set { SetProperty(ref zones, value); }
        }
    }
}
