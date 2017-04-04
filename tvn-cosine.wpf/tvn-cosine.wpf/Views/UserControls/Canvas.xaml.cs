﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tvn.Cosine.Data;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Canvas.xaml
    /// </summary>
    public partial class Canvas : UserControl
    {
        private Zone newZoneToDraw;
        private Point startingPointToDraw;
        private bool isCapturedToDraw;

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
                new FrameworkPropertyMetadata(null, backgroundImagePath_PropertChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

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

            canvas.CanvasWidth = canvas.itemsControl.Width;
            canvas.CanvasHeight = canvas.itemsControl.Height;
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
        public ObservableCollection<IZone> Zones
        {
            get { return (ObservableCollection<IZone>)GetValue(ZonesProperty); }
            set { SetValue(ZonesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Zones.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZonesProperty =
            DependencyProperty.Register("Zones",
                typeof(ObservableCollection<IZone>),
                typeof(Canvas),
                new FrameworkPropertyMetadata(null, zones_PropertChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void zones_PropertChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = d as Canvas;

            canvas.itemsControl.ItemsSource = e.NewValue as ObservableCollection<Zone>;
        }
        #endregion

        #region DrawingMode  
        public CanvasDrawingMode DrawingMode
        {
            get { return (CanvasDrawingMode)GetValue(DrawingModeProperty); }
            set { SetValue(DrawingModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawingMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawingModeProperty =
            DependencyProperty.Register("DrawingMode",
                typeof(CanvasDrawingMode),
                typeof(Canvas),
                new FrameworkPropertyMetadata(CanvasDrawingMode.NONE)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });
        #endregion

        #region Deleting of Zones
        private void deleteZones()
        {
            var area = new Rect(newZoneToDraw.X,
                                newZoneToDraw.Y,
                                newZoneToDraw.Width,
                                newZoneToDraw.Height);

            Zones.Remove(newZoneToDraw);
            foreach (var zone in Zones.ToList())
            {
                var zoneArea = new Rect(zone.X,
                                    zone.Y,
                                    zone.Width,
                                    zone.Height);
                if (area.IntersectsWith(zoneArea))
                {
                    Zones.Remove(zone);
                }
            }
        }
        #endregion

        #region Mouse Actions 
        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isCapturedToDraw = false;
            if (DrawingMode == CanvasDrawingMode.DELETE)
            {
                deleteZones();
            }

            DrawingMode = CanvasDrawingMode.NONE;
            Mouse.Capture(null);
        }

        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DrawingMode > 0)
            {
                Mouse.Capture(itemsControl);
                isCapturedToDraw = true;
                startingPointToDraw = Mouse.GetPosition(itemsControl);
                newZoneToDraw = new Zone()
                {
                    X = startingPointToDraw.X,
                    Y = startingPointToDraw.Y,
                    FillColor = Imaging.Color.Red,
                    Order = 0,
                    ZoneType = DrawingMode.ToString()
                };
                Zones.Add(newZoneToDraw);
            }
            else
            {
                Mouse.Capture(itemsControl);
                var point = Mouse.GetPosition(itemsControl);
                foreach (var zone in Zones)
                {
                    var zoneArea = new Rect(zone.X,
                                        zone.Y,
                                        zone.Width,
                                        zone.Height);

                    if (zoneArea.Contains(point))
                    {
                        zone.IsSelected = true;
                    }
                    else
                    {
                        if (!Keyboard.IsKeyDown(Key.LeftCtrl))
                        {
                            zone.IsSelected = false;
                        }
                    }
                }
            }
        }

        private void itemsControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isCapturedToDraw)
            {
                var point = Mouse.GetPosition(itemsControl);
                newZoneToDraw.X = System.Math.Min(point.X, startingPointToDraw.X);
                newZoneToDraw.Y = System.Math.Min(point.Y, startingPointToDraw.Y);
                newZoneToDraw.Width = System.Math.Max(point.X, startingPointToDraw.X) - newZoneToDraw.X;
                newZoneToDraw.Height = System.Math.Max(point.Y, startingPointToDraw.Y) - newZoneToDraw.Y;
            }
        }
        #endregion

        #region Canvas Width  
        public double CanvasWidth
        {
            get { return (double)GetValue(ParentVisualWidthProperty); }
            set { SetValue(ParentVisualWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentVisualWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentVisualWidthProperty =
            DependencyProperty.Register("CanvasWidth",
                typeof(double),
                typeof(Canvas),
                new FrameworkPropertyMetadata(0d)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });
        #endregion

        #region Canvas Height
        public double CanvasHeight
        {
            get { return (double)GetValue(ParentVisualHeightProperty); }
            set { SetValue(ParentVisualHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentVisualHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentVisualHeightProperty =
            DependencyProperty.Register("CanvasHeight",
                typeof(double),
                typeof(Canvas),
                new FrameworkPropertyMetadata(0d)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var canvas = sender as Canvas;

            canvas.CanvasWidth = canvas.itemsControl.Width;
            canvas.CanvasHeight = canvas.itemsControl.Height;
        }
        #endregion

        private void UserControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                foreach (var zone in Zones.ToList())
                {
                    if (zone.IsSelected)
                    {
                        Zones.Remove(zone);
                    }
                }
            }
        }
    }
}
