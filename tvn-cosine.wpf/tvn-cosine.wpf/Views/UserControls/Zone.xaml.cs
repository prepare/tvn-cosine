using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tvn.Cosine.Data;
using Tvn.Cosine.Imaging;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Zone.xaml
    /// </summary>
    public partial class Zone : ContentControl, IZone
    {
        public Zone()
        {
            InitializeComponent();
            this.SizeChanged += Zone_SizeChanged;
        }

        private void Zone_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            XProportional = X / CanvasWidth;
            YProportional = Y / CanvasHeight;
            XProportional = Width / CanvasWidth;
            XProportional = Height / CanvasHeight;
        }

        public double XProportional { get; private set; }
        public double YProportional { get; private set; }
        public double WidthProportional { get; private set; }
        public double HeightProportional { get; private set; }
        public double CanvasWidth { get; set; }
        public double CanvasHeight { get; set; }

        #region Order
        public int Order
        {
            get { return (int)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order",
                typeof(int),
                typeof(Zone),
                new FrameworkPropertyMetadata(0, Order_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void Order_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            zone.zoneOrder.Text = e.NewValue.ToString();
        }

        #endregion

        #region ZoneType 
        public string ZoneType
        {
            get { return (string)GetValue(ZoneTypeProperty); }
            set { SetValue(ZoneTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZoneType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoneTypeProperty =
            DependencyProperty.Register("ZoneType",
                typeof(string),
                typeof(Zone),
                new FrameworkPropertyMetadata(null, ZoneType_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void ZoneType_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;

            zone.zoneType.Text = e.NewValue.ToString();
        }
        #endregion

        #region X
        public double Area
        {
            get { return Width * Height; }
        }

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X",
                typeof(double),
                typeof(Zone),
                new FrameworkPropertyMetadata(0d, X_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void X_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            System.Windows.Controls.Canvas.SetLeft(zone, (double)e.NewValue);
            zone.Zone_SizeChanged(zone, null);
        }
        #endregion

        #region Y
        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y",
                typeof(double),
                typeof(Zone),
                new FrameworkPropertyMetadata(0d, Y_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void Y_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            System.Windows.Controls.Canvas.SetTop(zone, (double)e.NewValue);
            zone.Zone_SizeChanged(zone, null);
        }
        #endregion

        #region FillColor
        public IColor FillColor
        {
            get { return (IColor)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor",
                typeof(IColor),
                typeof(Zone),
                new FrameworkPropertyMetadata(null, FillColor_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void FillColor_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            var color = e.NewValue as IColor;

            if (color != null)
            {
                var solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                zone.rectangle.Fill = solidColorBrush;
            }
            else
            {
                zone.rectangle.Fill = Brushes.Transparent;
            }
        }
        #endregion

        #region IsSelected
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected",
                typeof(bool),
                typeof(Zone),
                new FrameworkPropertyMetadata(false, IsSelected_PropertyChanged)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        private static void IsSelected_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            if ((bool)e.NewValue)
            {
                zone.rectangle.Opacity = 0.6;
            }
            else
            {
                zone.rectangle.Opacity = 0.4;
            }
        }
        #endregion 
    }
}
