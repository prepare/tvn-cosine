using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ResizeThumb.xaml
    /// </summary>
    public partial class ResizeThumb : Thumb
    {
        public ResizeThumb()
        {
            InitializeComponent();
        }

        private void thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Control designerItem = DataContext as Control;

            if (designerItem != null)
            {
                double deltaVertical, deltaHorizontal;

                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        deltaVertical = System.Math.Min(-e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                        designerItem.Height -= deltaVertical;
                        break;
                    case VerticalAlignment.Top:
                        deltaVertical = System.Math.Min(e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                        System.Windows.Controls.Canvas.SetTop(designerItem, 
                            System.Windows.Controls.Canvas.GetTop(designerItem) + deltaVertical);
                        designerItem.Height -= deltaVertical;
                        break;
                    default:
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        deltaHorizontal = System.Math.Min(e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                        System.Windows.Controls.Canvas.SetLeft(designerItem, 
                            System.Windows.Controls.Canvas.GetLeft(designerItem) + deltaHorizontal);
                        designerItem.Width -= deltaHorizontal;
                        break;
                    case HorizontalAlignment.Right:
                        deltaHorizontal = System.Math.Min(-e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                        designerItem.Width -= deltaHorizontal;
                        break;
                    default:
                        break;
                }
            }

            e.Handled = true;
        }
    }
}
