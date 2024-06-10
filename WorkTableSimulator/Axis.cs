namespace WorkTableSimulator
{
    internal class Axis : ChangeNotifier
    {
        private AxisType _AxisName;
        private int _MinPose;
        private int _MaxPose;
        private int _CurrPose;
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;

        //private int _YMinPose;
        //private int _YMaxPose;
        //private int _YCurrPose;
        //private uint _YAxisX;
        //private uint _YAxisY;
        //private uint _YAxisWidth;
        //private uint _YAxisHeight;

        //private int _ZMinPose;
        //private int _ZMaxPose;
        //private int _ZCurrPose;
        //private uint _ZAxisX;
        //private uint _ZAxisY;
        //private uint _ZAxisWidth;
        //private uint _ZAxisHeight;

        //X
        public AxisType AxisName
        {
            get { return _AxisName; }
            set { _AxisName = value; OnPropertyChanged(nameof(AxisName)); }
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
            set { _X = value; OnPropertyChanged(nameof(X)); }
        }

        public double Y
        {
            get { return _Y; }
            set { _Y = value; OnPropertyChanged(nameof(Y)); }
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

        public Axis() { }


    }
}
