
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace WorkTableSimulator
{
    internal static class PlateController
    {
        internal static System.Windows.Point GetCurrentPoseByAxis(UIElement element, Rectangle plate, Rectangle axis)
        {
            int plateWidth = plate.Width;
            int plateHeight = plate.Height;
            double plateX = Canvas.GetLeft(element);
            int plateY = plate.Height;
            return new System.Windows.Point();
        }
    }
}
