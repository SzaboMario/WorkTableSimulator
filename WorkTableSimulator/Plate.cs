
using System.Windows.Shapes;

namespace WorkTableSimulator
{
    internal class Plate : ChangeNotifier
    {
        //Plate
        private Rectangle _PlateRectangle;
        public Rectangle PlateRectangle
        {
            get { return _PlateRectangle; }
            set { _PlateRectangle = value; OnPropertyChanged(nameof(PlateRectangle)); }
        }

        private int _TargetPose;
        public int TargetPose
        {
            get { return _TargetPose; }
            set { _TargetPose = value; OnPropertyChanged(nameof(TargetPose)); }
        }

        private int _CurrentPose;
        public int CurrentPose
        {
            get { return _CurrentPose; }
            set { _CurrentPose = value; OnPropertyChanged(nameof(CurrentPose)); }
        }

        public Plate() { }
    }
}
