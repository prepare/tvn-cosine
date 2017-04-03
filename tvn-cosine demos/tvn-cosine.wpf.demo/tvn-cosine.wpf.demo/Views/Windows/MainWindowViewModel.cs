using Leptonica;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Tvn.Cosine.Data;
using Tvn.Cosine.Wpf.Views.UserControls;

namespace Tvn.Cosine.Wpf.Demo.Views.Windows
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            ApplicationName = "tvn-cosine Wpf Application";
            ImagePath = @"C:\Temp\6.jpg";
            Zones = new ObservableCollection<Zone>();
            SetDrawingMode = new DelegateCommand<object>(setDrawingMode);
            CutZones = new DelegateCommand(cutZones);
        }

        public DelegateCommand<object> SetDrawingMode { get; }
        public DelegateCommand CutZones { get; }

        private void cutZones()
        {
            CutImagePath = string.Empty;
            var newImagePath = ImagePath.Replace(".jpg", "__.jpg");
            var drawing = new Leptonica.Drawing.PixDrawing();
            using (var pix = new Pix(ImagePath))
            {
                using (Boxa boxa = new Boxa(Zones.Count))
                {
                    foreach (var zone in Zones)
                    {
                        boxa.AddBox(new Box((int)zone.X, (int)zone.Y, (int)zone.ActualWidth, (int)zone.ActualHeight));
                    }

                    int height = (int)(Zones.Max(z => z.Y + z.Height) - Zones.Min(z => z.Y));
                    int width = (int)(Zones.Max(z => z.X + z.Width) - Zones.Min(z => z.X));

                    using (var newPix = new Pix(pix.Width, pix.Height, pix.Depth))
                    {
                        using (var mask = new Pix(pix.Width, pix.Height, 1))
                        {
                            drawing.MaskBoxa(mask, mask, boxa, GraphicPixelSetting.SET_PIXELS);
                            if (!drawing.CombineMaskedGeneral(newPix, pix, mask, 0, 0))
                            {
                                throw new Exception("Could not mask");
                            }
                        }

                        newPix.Save(newImagePath, ImageFileFormat.JFIF_JPEG);
                        CutImagePath = newImagePath;
                    }
                }
            }
        }

        private string cutImagePath;
        public string CutImagePath
        {
            get { return cutImagePath; }
            set { SetProperty(ref cutImagePath, value); }
        }

        private void setDrawingMode(object drawingMode)
        {
            if (drawingMode != null)
            {
                int id;
                if (int.TryParse(drawingMode.ToString(), out id))
                {
                    if (Enum.IsDefined(typeof(CanvasDrawingMode), (int)id))
                    {
                        CanvasDrawingMode = (CanvasDrawingMode)id;
                    }
                }
                return;
            }

            CanvasDrawingMode = CanvasDrawingMode.NONE;
        }

        private CanvasDrawingMode canvasDrawingMode;
        public CanvasDrawingMode CanvasDrawingMode
        {
            get { return canvasDrawingMode; }
            set { SetProperty(ref canvasDrawingMode, value); }
        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }
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
