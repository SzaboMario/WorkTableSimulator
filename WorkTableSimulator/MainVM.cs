using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;


namespace WorkTableSimulator
{
    internal class MainVM : ChangeNotifier
    {
        #region Fields
        private Axis _Axis;
        private Plate _Plate;
        private Motor _Motor;

        private uint _XAxisX;
        private uint _XAxisY;
        private uint _XAxisWidth;
        private uint _XAxisHeight;
        private uint _YAxisX;
        private uint _YAxisY;
        private uint _YAxisWidth;
        private uint _YAxisHeight;
        private uint _ZAxisX;
        private uint _ZAxisY;
        private uint _ZAxisWidth;
        private uint _ZAxisHeight;
        private uint _PlateX;
        private uint _PlateY;
        private uint _PlateWidth;
        private uint _PlateHeight;

        private ObservableCollection<Axis> _Axes;
        private ObservableCollection<Plate> _Plates;
        private ObservableCollection<Motor> _Motors;
        #endregion Fields

        #region Properties
        public Axis Axis
        {
            get { return _Axis; }
            set { _Axis = value; OnPropertyChanged(nameof(Axis)); }
        }
        public Plate Plate
        {
            get { return _Plate; }
            set { _Plate = value; OnPropertyChanged(nameof(Plate)); }
        }
        public Motor Motor
        {
            get { return _Motor; }
            set { _Motor = value; OnPropertyChanged(nameof(Motor)); }
        }

        public uint XAxisX
        {
            get { return _XAxisX; }
            set { _XAxisX = value; OnPropertyChanged(nameof(XAxisX)); }
        }
        public uint XAxisY
        {
            get { return _XAxisY; }
            set { _XAxisY = value; OnPropertyChanged(nameof(XAxisY)); }
        }
        public uint XAxisWidth
        {
            get { return _XAxisWidth; }
            set { _XAxisWidth = value; OnPropertyChanged(nameof(XAxisWidth)); }
        }
        public uint XAxisHeight
        {
            get { return _XAxisHeight; }
            set { _XAxisHeight = value; OnPropertyChanged(nameof(XAxisHeight)); }
        }

        public uint YAxisX
        {
            get { return _YAxisX; }
            set { _YAxisX = value; OnPropertyChanged(nameof(YAxisX)); }
        }
        public uint YAxisY
        {
            get { return _YAxisY; }
            set { _YAxisY = value; OnPropertyChanged(nameof(YAxisY)); }
        }
        public uint YAxisWidth
        {
            get { return _YAxisWidth; }
            set { _YAxisWidth = value; OnPropertyChanged(nameof(YAxisWidth)); }
        }
        public uint YAxisHeight
        {
            get { return _YAxisHeight; }
            set { _YAxisHeight = value; OnPropertyChanged(nameof(YAxisHeight)); }
        }

        public uint ZAxisX
        {
            get { return _ZAxisX; }
            set { _ZAxisX = value; OnPropertyChanged(nameof(ZAxisX)); }
        }
        public uint ZAxisY
        {
            get { return _ZAxisY; }
            set { _ZAxisY = value; OnPropertyChanged(nameof(ZAxisY)); }
        }
        public uint ZAxisWidth
        {
            get { return _YAxisWidth; }
            set { _ZAxisWidth = value; OnPropertyChanged(nameof(ZAxisWidth)); }
        }
        public uint ZAxisHeight
        {
            get { return _ZAxisHeight; }
            set { _ZAxisHeight = value; OnPropertyChanged(nameof(ZAxisHeight)); }
        }

        public uint PlateX
        {
            get { return _PlateX; }
            set { _PlateX = value; OnPropertyChanged(nameof(PlateX)); }
        }
        public uint PlateY
        {
            get { return _PlateY; }
            set { _PlateY = value; OnPropertyChanged(nameof(PlateY)); }
        }
        public uint PlateWidth
        {
            get { return _PlateWidth; }
            set { _PlateWidth = value; OnPropertyChanged(nameof(PlateWidth)); }
        }
        public uint PlateHeight
        {
            get { return _PlateHeight; }
            set { _PlateHeight = value; OnPropertyChanged(nameof(PlateHeight)); }
        }

        

        public ObservableCollection<Axis> Axes { get => _Axes; set => _Axes = value; }       
        public ObservableCollection<Plate> Plates { get => _Plates; set => _Plates = value; }    
        public ObservableCollection<Motor> Motors { get => _Motors; set => _Motors = value; }
        #endregion Properties

        #region Constructor
        public MainVM()
        {
            _InitAxes();
            _InitPlates();
            _InitMotors();
            _InitdrawableObjects();
            MouseDownCommand = new RelayCommand(ExecuteMouseDown);
        }
        #endregion Constructor

        #region Public Methods
        public void AddAxis()
        {
            Axes.Add(Axis);
        }

        public void AddPlate()
        {
            Plates.Add(Plate);
        }

        public void AddMotor()
        {
            Motors.Add(Motor);
        }
        #endregion Public Methods

        #region Private Methods
        private void _InitAxes()
        {
            Axes = [];
            Axis = new Axis
            {
                XRectangle = new Rectangle(),
                XMinPose = 0,
                XMaxPose = 100,
                XCurrPose = 0
            };
            AddAxis();

            Axis = new Axis
            {
                YRectangle = new Rectangle(),
                YMinPose = 0,
                YMaxPose = 100,
                YCurrPose = 0
            };
            AddAxis();

            Axis = new Axis
            {
                ZRectangle = new Rectangle(),
                ZMinPose = 0,
                ZMaxPose = 100,
                ZCurrPose = 0
            };
            AddAxis();
        }
        private void _InitPlates()
        {
            Plates = new ObservableCollection<Plate>();
            Plate= new Plate();
            for (int i = 0; i < 1; i++)
            {
                Plate.CurrentPose = 0;
                AddPlate();
            }
        }

        private void _InitMotors()
        {
            Motors = new ObservableCollection<Motor>();
            Motor = new Motor();
            for (int i = 0; i < 3; i++)
            {
                Motor.Speed = 2;
                AddMotor();
            }
        }

        private void _InitdrawableObjects()
        {
            XAxisX = 200;
            XAxisY = 350;
            XAxisWidth = 500;
            XAxisHeight = 10;

            YAxisX = 200;
            YAxisY = 100;
            YAxisWidth = 10;
            YAxisHeight = 500;

            ZAxisX = 200;
            ZAxisY = 100;
            ZAxisWidth = 10;
            ZAxisHeight = 10;

            PlateWidth = 100;
            PlateHeight = 100;
            PlateX = 200 - PlateWidth / 2 + ZAxisWidth / 2;
            PlateY = 100 - PlateHeight / 2 + ZAxisHeight / 2;
        }

        #endregion Private Methods

        public ICommand MouseDownCommand { get;  set; }

        private void ExecuteMouseDown(object obj)
        {
            if(obj != null && obj is Canvas canvas)
            {
                System.Windows.Point clickPoint = Mouse.GetPosition(canvas);
            }
        }

    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
