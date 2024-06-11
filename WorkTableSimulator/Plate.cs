namespace WorkTableSimulator
{
    internal class Plate : ChangeNotifier
    {
        //Plate
        private AxisType _PlateName;
        private ContentLabel _ContLabel;
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;
        private string _TargetPose;
        private int _CurrentPose;

        public ContentLabel ContLabel
        {
            get { return _ContLabel; }
            set { _ContLabel = value; OnPropertyChanged(nameof(ContLabel)); }
        }

        public AxisType PlateName
        {
            get { return _PlateName; }
            set { _PlateName = value; OnPropertyChanged(nameof(PlateName)); ContLabel.Content = value.ToString(); }
        }

        public double X
        {
            get { return _X; }
            set { ContLabel.X = _X = value; OnPropertyChanged(nameof(X)); }
        }

        public double Y
        {
            get { return _Y; }
            set { ContLabel.Y = _Y = value; OnPropertyChanged(nameof(Y)); }
        }
        public double Width
        {
            get { return _Width; }
            set { _Width = value; OnPropertyChanged(nameof(Width)); }
        }

        public double Height
        {
            get { return _Height; }
            set { _Height = value; OnPropertyChanged(nameof(Height)); }
        }

        
        public string TargetPose
        {
            get { return _TargetPose; }
            set { _TargetPose = value; OnPropertyChanged(nameof(TargetPose)); }
        }
    
        public int CurrentPose
        {
            get { return _CurrentPose; }
            set { _CurrentPose = value; OnPropertyChanged(nameof(CurrentPose)); }
        }

        public Plate() { ContLabel = new ContentLabel(); }


    }
}
