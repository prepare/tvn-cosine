using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Zone.xaml
    /// </summary>
    public partial class Zone : ContentControl
    {
        public Zone()
        {
            InitializeComponent(); 
        }

        #region Fill 
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", 
                typeof(Brush), 
                typeof(Zone), 
                new PropertyMetadata(Brushes.Gray, fill_PropertyChanged));

        private static void fill_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var zone = d as Zone;
            zone.rectangle.Fill = e.NewValue as Brush;
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
