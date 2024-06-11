namespace WorkTableSimulator
{
    public class ContentLabel : ChangeNotifier
    {
        private string? _Content;
        private double _X;
        private double _Y;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; OnPropertyChanged(nameof(Content)); }
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
    }
}
