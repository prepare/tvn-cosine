using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tvn.Cosine.Geometry;
using Tvn.Cosine.Imaging;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Zone.xaml
    /// </summary>
    public partial class Zone : ContentControl, IPoint<double>, ISize<double>
    {
        public Zone()
        {
            InitializeComponent();
        }

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
                new PropertyMetadata(0d, x_PropertyChanged));

        private static void x_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            System.Windows.Controls.Canvas.SetLeft(zone, (double)e.NewValue);
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
                new PropertyMetadata(0d, y_PropertyChanged));

        private static void y_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            System.Windows.Controls.Canvas.SetTop(zone, (double)e.NewValue);
        }
        #endregion

        #region Fill 
        public IColor Fill
        {
            get { return (IColor)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill",
                typeof(IColor),
                typeof(Zone),
                new PropertyMetadata(null, fill_PropertyChanged));

        private static void fill_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
                new PropertyMetadata(false, zone_PropertyChanged));

        private static void zone_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            if ((bool)e.NewValue)
            {
                zone.rectangle.Opacity = 0.8;
            }
            else
            {
                zone.rectangle.Opacity = 0.4;
            }
        }

        #endregion 
    }
}
