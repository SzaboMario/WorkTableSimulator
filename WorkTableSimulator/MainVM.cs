using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Xps;


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
        public OperationMode OpMode
        {
            get { return _OpMode; }
            set { _OpMode = value; OnPropertyChanged(nameof(OpMode)); }
        }
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
        public ICommand ExecuteMoveCommand { get; set; }


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
            ExecuteMoveCommand = new RelayCommand(ExecuteMove);
            OpMode = OperationMode.Idle;
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

        private void ExecuteMouseDown(object obj)   
        {
            if (obj != null && obj is Canvas canvas && OpMode == OperationMode.Idle)
            {
                System.Windows.Point clickPoint = Mouse.GetPosition(canvas);
                var (_x,_y) = TargetPointValidation(clickPoint);
                var (xDist, yDist) = CalculateDistance(MainPlate, _x, _y);
                MoveAxis(xDist, yDist);
            }
        }

        private void ExecuteMove( object obj)
        {
            if (OpMode == OperationMode.Idle && obj != null && obj is string param)
            {
                switch (param)
                {
                    case "XP":
                        if (ZAxis.X + ZAxis.Width < XAxis.X + XAxis.Width)
                        {
                            ZAxis.X += 1;
                            YAxis.X += 1;
                            MainPlate.X += 1;
                            XAxis.CurrPose = (int)AxisPoseScale(XAxis);
                        }
                        break;
                    case "XM":
                        if (ZAxis.X > XAxis.X)
                        {
                            ZAxis.X -= 1;
                            YAxis.X -= 1;
                            MainPlate.X -= 1;
                            XAxis.CurrPose = (int)AxisPoseScale(XAxis);
                        }
                        break;
                    case "YP":
                        if (ZAxis.Y + ZAxis.Height < YAxis.Y + YAxis.Height)
                        {
                            ZAxis.Y += 1;
                            MainPlate.Y += 1;
                            YAxis.CurrPose = (int)AxisPoseScale(ZAxis);
                        }
                        break;
                    case "YM":
                        if (ZAxis.Y > YAxis.Y)
                        {
                            ZAxis.Y -= 1;
                            MainPlate.Y -= 1;
                            YAxis.CurrPose = (int)AxisPoseScale(ZAxis);
                        }       
                        break;
                    case "ZP":
                       //TODO: plate terület csökkentéssel/nőveléssel érzékeltessem a távolságot?
                        break;
                    case "ZM":
                        
                        break;

                }
            }
        }


        public double AxisPoseScale(Axis axis)
        {
            double retDistance = 0;
            switch (axis.AxisName)
            {
                case AxisType.X:
                    retDistance = axis.X - YAxis.X;
                    break;
                case AxisType.Z:
                    retDistance = axis.Y - YAxis.Y;
                    break;
            }
            if (retDistance < 0) retDistance *= -1;
            return retDistance;
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
                OpMode = OperationMode.Running;
                if(distanceX < 0)
                {
                    for (double i = distanceX; i < 0; i++)
                    {
                        MainPlate.X -= 1;
                        YAxis.X -= 1;
                        ZAxis.X -= 1;
                        XAxis.CurrPose = (int)AxisPoseScale(XAxis);
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
                        XAxis.CurrPose = (int)AxisPoseScale(XAxis);
                        Thread.Sleep(XMotor.Speed);
                    }
                }

                if (distanceY < 0)
                {
                    for (double i = distanceY; i < 0; i++)
                    {
                        MainPlate.Y -= 1;
                        ZAxis.Y -= 1;
                        YAxis.CurrPose = (int)AxisPoseScale(ZAxis);
                        Thread.Sleep(YMotor.Speed);
                    }
                }
                else
                {
                    for (int i = 0; i < distanceY; i++)
                    {
                        MainPlate.Y += 1;
                        ZAxis.Y += 1;
                        YAxis.CurrPose = (int)AxisPoseScale(ZAxis);
                        Thread.Sleep(YMotor.Speed);
                    }
                }
                OpMode = OperationMode.Idle;
            });          
        }
        #endregion Private Methods
    }
}
