using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Tvn.Cosine.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MoveThumb.xaml
    /// </summary>
    public partial class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            InitializeComponent();
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Control designerItem = DataContext as Control;

                if (designerItem != null)
                {
                    double left = System.Windows.Controls.Canvas.GetLeft(designerItem);
                    double top = System.Windows.Controls.Canvas.GetTop(designerItem);

                    System.Windows.Controls.Canvas.SetLeft(designerItem, left + e.HorizontalChange);
                    System.Windows.Controls.Canvas.SetTop(designerItem, top + e.VerticalChange);
                }
            }
        }
    }
}
