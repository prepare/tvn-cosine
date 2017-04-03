using Leptonica;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel; 
using Tvn.Cosine.Wpf.Views.UserControls;

namespace Testing_App.Views.Windows
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
                        var _x = (zone.X / CanvasWidth) * pix.Width;
                        var _y = (zone.Y / CanvasHeight) * pix.Height;

                        var _width = (zone.Width / CanvasWidth) * pix.Width;
                        var _height = (zone.Height / CanvasHeight) * pix.Height;
                        boxa.AddBox(new Box((int)_x, (int)_y, (int)_width, (int)_height));
                    }
                     
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

        private double canvasWidth;
        public double CanvasWidth
        {
            get { return canvasWidth; }
            set { SetProperty(ref canvasWidth, value); }
        }

        private double canvasHeight;
        public double CanvasHeight
        {
            get { return canvasHeight; }
            set { SetProperty(ref canvasHeight, value); }
        }
    }
}
