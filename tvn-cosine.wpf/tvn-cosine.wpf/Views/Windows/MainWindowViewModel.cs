using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Media;
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
            zone.Fill = Tvn.Cosine.Imaging.Color.Pink;
            zone.X = 430;
            zone.Y = 150;
            zone.Width = 300;
            zone.Height = 430;
            Zones.Add(zone);
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
