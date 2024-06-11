using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace WorkTableSimulator
{
    internal class MainVM : ChangeNotifier
    {
        #region Fields
        private Axis _XAxis;
        private Axis _YAxis;
        private Axis _ZAxis;
        private Motor _XMotor;
        private Motor _YMotor;
        private Motor _ZMotor;
        private Plate _MainPlate;
        private OperationMode _OpMode;

        private ObservableCollection<Axis> _Axes;
        private ObservableCollection<Plate> _Plates;
        private ObservableCollection<Motor> _Motors;
        #endregion Fields

        #region Properties
        public Axis XAxis
        {
            get { return _XAxis; }
            set { _XAxis = value; OnPropertyChanged(nameof(XAxis)); }
        }
        public Axis YAxis
        {
            get { return _YAxis; }
            set { _YAxis = value; OnPropertyChanged(nameof(YAxis)); }
        }
        public Axis ZAxis
        {
            get { return _ZAxis; }
            set { _ZAxis = value; OnPropertyChanged(nameof(ZAxis)); }
        }
        public Motor XMotor
        {
            get { return _XMotor; }
            set { _XMotor = value; OnPropertyChanged(nameof(XMotor)); }
        }
        public Motor YMotor
        {
            get { return _YMotor; }
            set { _YMotor = value; OnPropertyChanged(nameof(YMotor)); }
        }
        public Motor ZMotor
        {
            get { return _ZMotor; }
            set { _ZMotor = value; OnPropertyChanged(nameof(ZMotor)); }
        }
        public Plate MainPlate
        {
            get { return _MainPlate; }
            set { _MainPlate = value; OnPropertyChanged(nameof(MainPlate)); }
        }

        public ICommand MouseDownCommand { get; set; }

        public ObservableCollection<Axis> Axes { get => _Axes; set => _Axes = value; }       
        public ObservableCollection<Plate> Plates { get => _Plates; set => _Plates = value; }    
        public ObservableCollection<Motor> Motors { get => _Motors; set => _Motors = value; }
        #endregion Properties

        #region Constructor
        public MainVM()
        {
            InitAxes();
            InitPlates();
            InitMotors();
            MouseDownCommand = new RelayCommand(ExecuteMouseDown);
            _OpMode = OperationMode.Idle;
        }
        #endregion Constructor

        #region Public Methods

        #endregion Public Methods

        #region Private Methods
        private void AddAxis(Axis axis)
        {
            Axes.Add(axis);
        }

        private void AddPlate(Plate plate)
        {
            Plates.Add(plate);
        }

        private void AddMotor(Motor motor)
        {
            Motors.Add(motor);
        }

        private void InitAxes()
        {
            Axes = [];
            XAxis = new Axis
            {
                AxisName = AxisType.X,             
                X = 200,
                Y = 350,
                Width = 500,
                Height = 10,
                MinPose = 0,
                MaxPose = 100,
                CurrPose = 0,
            };

            AddAxis(XAxis);

            YAxis = new Axis
            {
                AxisName = AxisType.Y,
                X = 200,
                Y = 100,
                Width = 10,
                Height = 500,
                MinPose = 0,
                MaxPose = 100,
                CurrPose = 0,
            };

            AddAxis(YAxis);

            ZAxis = new Axis
            {
                AxisName = AxisType.Z,
                X = 200,
                Y = 100,
                Width = 10,
                Height = 10,
                MinPose = 0,
                MaxPose = 100,
                CurrPose = 0,
            };

            AddAxis(ZAxis);
        }

        private void InitPlates()
        {
            Plates = [];
            MainPlate = new Plate();
            MainPlate.PlateName = AxisType.Plate;
            MainPlate.Width = MainPlate.Height = 100;
            MainPlate.X = (ZAxis.X - (MainPlate.Width / 2)) + ZAxis.Width / 2;
            MainPlate.Y = (ZAxis.Y - (MainPlate.Height / 2)) + ZAxis.Height / 2;

            AddPlate(MainPlate);
        }

        private void InitMotors()
        {
            Motors = [];
            XMotor = new Motor
            {
                Speed = 10
            };

            AddMotor(XMotor);
            YMotor = new Motor
            {
                Speed = 10
            };

            AddMotor(YMotor);
            ZMotor = new Motor
            {
                Speed = 10
            };
            AddMotor(ZMotor);
        }

        #endregion Private Methods

        #region ICommand Methods
        private void ExecuteMouseDown(object obj)
        {
            if (obj != null && obj is Canvas canvas && _OpMode == OperationMode.Idle)
            {
                System.Windows.Point clickPoint = Mouse.GetPosition(canvas);
                var (_x,_y) = TargetPointValidation(clickPoint);
                var (xDist, yDist) = CalculateDistance(MainPlate, _x, _y);
                //MainPlate.TargetPose = $"{xDist},{yDist}";
                //TODO: TargetPose-t kitalálni hogyan kell kiszámolni.
                //pl. van egy click x és y, x=124, de nekem csak 0-100 ig skálázhatom fel
                double normalizaltX = (_x - 100) / 4;
                double normalizaltY = (_y - 100) / 4;
                //normalizaltX = Math.Max(0, Math.Min(normalizaltX, 100));
                //normalizaltY = Math.Max(0, Math.Min(normalizaltY, 100));
                MainPlate.TargetPose = $"{normalizaltX},{normalizaltY}";
                MoveAxis(xDist, yDist);
            }
        }
        public double NormalizeTargetPoint(double value, double minVal, double maxVal)
        {
            // Az érték normalizálása 0 és 100 közé
            return (100 * (value - minVal)) / (maxVal - minVal);
        }

        private (double x, double y) GetMaxSize(object obj)
        {
            if (obj != null)
            {
                if (obj is Axis axis)
                {
                    return ((axis.X + axis.Width)-ZAxis.Width / 2, (axis.Y + axis.Height) - ZAxis.Height / 2);
                }
                else if (obj is Plate plate)
                {
                    return ((plate.X + plate.Width) - ZAxis.Width / 2, (plate.Y + plate.Height) - ZAxis.Height / 2);
                }
            }
            return (0, 0);
        }

        private (double X, double Y) TargetPointValidation(System.Windows.Point clickPoint)
        {
            double clickX = clickPoint.X;
            double clickY = clickPoint.Y;

            if (clickX < XAxis.X + ZAxis.Width / 2)
            {
                clickX = XAxis.X + ZAxis.Width / 2;
            }
            else if(clickX > XAxis.X + XAxis.Width - (ZAxis.Width / 2))
            {
                clickX = XAxis.X + XAxis.Width - (ZAxis.Width / 2);
            }

            if (clickY < YAxis.Y + ZAxis.Height / 2)
            {
                clickY = YAxis.Y + ZAxis.Height / 2;
            }
            else if (clickY > YAxis.Y + YAxis.Height - (ZAxis.Height / 2))
            {
                clickY = YAxis.Y + YAxis.Height - (ZAxis.Height / 2);
            }

            return (clickX, clickY);
        }

        private (double X, double Y) CalculateDistance(Plate plate, double targX, double targY)
        {
            double _x = targX - plate.X - plate.Width / 2;
            double _y = targY - plate.Y - plate.Height / 2;
            return (_x, _y);
        }

        private void MoveAxis(double distanceX, double distanceY)
        {
            Task task = Task.Run(() =>
            {
                _OpMode = OperationMode.Running;
                if(distanceX < 0)
                {
                    for (double i = distanceX; i < 0; i++)
                    {
                        MainPlate.X -= 1;
                        YAxis.X -= 1;
                        ZAxis.X -= 1;
                        Thread.Sleep(XMotor.Speed);
                    }
                }
                else
                {
                    for (int i = 0; i < distanceX; i++)
                    {
                        MainPlate.X += 1;
                        YAxis.X += 1;
                        ZAxis.X += 1;
                        Thread.Sleep(XMotor.Speed);
                    }
                }

                if (distanceY < 0)
                {
                    for (double i = distanceY; i < 0; i++)
                    {
                        MainPlate.Y -= 1;
                        ZAxis.Y -= 1;
                        Thread.Sleep(XMotor.Speed);
                    }
                }
                else
                {
                    for (int i = 0; i < distanceY; i++)
                    {
                        MainPlate.Y += 1;
                        ZAxis.Y += 1;
                        Thread.Sleep(XMotor.Speed);
                    }
                }
                _OpMode = OperationMode.Idle;
            });          
        }
        #endregion ICommand Methods
    }
}
