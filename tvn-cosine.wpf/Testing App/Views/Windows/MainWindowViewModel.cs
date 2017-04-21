using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tvn.Cosine.Data;
using Tvn.Cosine.Wpf.Views.UserControls;

namespace Testing_App.Views.Windows
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            ApplicationName = "tvn-cosine Wpf Application";
            ImagePath = @"C:\Temp\6.jpg";
            SetDrawingMode = new DelegateCommand<object>(setDrawingMode);
        }

        public DelegateCommand<object> SetDrawingMode { get; }

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
                    if (Enum.IsDefined(typeof(CANVAS_DRAWING_MODE), id))
                    {
                        CanvasDrawingMode = (CANVAS_DRAWING_MODE)id;
                    }
                }
                return;
            }

            CanvasDrawingMode = CANVAS_DRAWING_MODE.NONE;
        }

        private IEnumerable<IZone> zones;
        public IEnumerable<IZone> Zones
        {
            get { return zones; }
            set { SetProperty(ref zones, value); }
        }

        private CANVAS_DRAWING_MODE canvasDrawingMode;
        public CANVAS_DRAWING_MODE CanvasDrawingMode
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
