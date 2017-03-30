using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Canvas.xaml
    /// </summary>
    public partial class Canvas : UserControl
    {
        public Canvas()
        {
            InitializeComponent();
        }

        #region BackgroundImagePath
        public string BackgroundImagePath
        {
            get { return (string)GetValue(BackgroundImagePathProperty); }
            set { SetValue(BackgroundImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundImagePathProperty =
            DependencyProperty.Register("BackgroundImagePath",
                typeof(string),
                typeof(Canvas),
                new PropertyMetadata(null, backgroundImagePath_PropertChanged));

        private static void backgroundImagePath_PropertChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = d as Canvas;
            var path = e.NewValue.ToString();

            if (System.IO.File.Exists(path))
            {
                var imageSource = new BitmapImage(new Uri(path, UriKind.Relative));
                canvas.itemsControl.Width = imageSource.Width;
                canvas.itemsControl.Height = imageSource.Height;
                canvas.itemsControlImageBrush.ImageSource = imageSource;
            }
            else
            {
                canvas.itemsControl.Width = 0;
                canvas.itemsControl.Height = 0; 
                canvas.itemsControlImageBrush.ImageSource = null;
            }
        }
        #endregion

        #region Zoom with MouseWheel and Key.LeftCtrl
        private readonly double zoomMax = 5;
        private readonly double zoomMin = 0.2;
        private readonly double zoomSpeed = 0.001;
        private double zoom = 1;

        private void itemsControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                var itemsControl = sender as ItemsControl;
                zoom += zoomSpeed * e.Delta;            // Ajust zooming speed (e.Delta = Mouse spin value )
                if (zoom < zoomMin) { zoom = zoomMin; } // Limit Min Scale
                if (zoom > zoomMax) { zoom = zoomMax; } // Limit Max Scale

                var mousePos = e.GetPosition(itemsControl);

                if (zoom > 1)
                {
                    itemsControl.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
                }
                else
                {
                    itemsControl.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size 
                }
            }
        }
        #endregion

        #region Zones
        public ObservableCollection<Zone> Zones
        {
            get { return (ObservableCollection<Zone>)GetValue(ZonesProperty); }
            set { SetValue(ZonesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Zones.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZonesProperty =
            DependencyProperty.Register("Zones",
                typeof(ObservableCollection<Zone>),
                typeof(Canvas),
                new PropertyMetadata(null, zones_PropertChanged));

        private static void zones_PropertChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = d as Canvas;

            canvas.itemsControl.ItemsSource = e.NewValue as ObservableCollection<Zone>;
        }
        #endregion
    }
}
