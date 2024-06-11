namespace WorkTableSimulator
{
    internal class Axis : ChangeNotifier
    {
        private AxisType _AxisName;
        private ContentLabel _ContLabel;
        private int _MinPose;
        private int _MaxPose;
        private int _CurrPose;
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;

        public ContentLabel ContLabel
        {
            get { return _ContLabel; }
            set { _ContLabel = value; OnPropertyChanged(nameof(ContLabel)); }
        }
        public AxisType AxisName
        {
            get { return _AxisName; }
            set { _AxisName = value; OnPropertyChanged(nameof(AxisName)); ContLabel.Content = value.ToString(); }
        }

        public int MinPose
        {
            get { return _MinPose; }
            set { _MinPose = value; OnPropertyChanged(nameof(MinPose)); }
        }
        
        public int MaxPose
        {
            get { return _MaxPose; }
            set { _MaxPose = value; OnPropertyChanged(nameof(MaxPose)); }
        }
        
        public int CurrPose
        {
            get { return _CurrPose; }
            set { _CurrPose = value; OnPropertyChanged(nameof(CurrPose)); }
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

        public Axis() { ContLabel = new ContentLabel(); }


    }
}
