using System.Drawing;
using System.Windows;


namespace WorkTableSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VisualContents plate;
        private VisualContents xAxis;
        private VisualContents yAxis;
        private VisualContents zAxis;

        public MainWindow()
        {
            InitializeComponent();

            xAxis = new VisualContents(new System.Drawing.Point(100, 100), AxisType.X);
            yAxis = new VisualContents(new System.Drawing.Point(300, 100), AxisType.Y);
            zAxis = new VisualContents(new System.Drawing.Point(500, 100), AxisType.Z);
            plate = new VisualContents(new System.Drawing.Point(700, 100), new System.Drawing.Size(100, 100));
            workZone.Children.Add(xAxis.);
            workZone.Children.Add(yAxis);
            workZone.Children.Add(zAxis);
            workZone.Children.Add(plate);

        }

    }
}