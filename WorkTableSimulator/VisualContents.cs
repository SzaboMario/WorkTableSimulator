
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WorkTableSimulator
{
    public class VisualContents : UIElement
    {
        public static Rectangle CreateAxis(Point position, AxisType axisType)
        {
            Position = position;
            rect = new Rectangle();
            switch (axisType)
            {
                case AxisType.X:
                    Size = new Size(100, 10);
                    Background = Brushes.Red;
                    break;
                case AxisType.Y:
                    Size = new Size(10, 100);
                    Background = Brushes.Green;
                    break;
                case AxisType.Z:
                    Size = new Size(10, 10);
                    Background = Brushes.Blue;
                    break;
            }
            rect.Width = Size.Width;
            rect.Height = Size.Height;
            rect.Fill = Background;
            return Rect;
        }
    }
}
