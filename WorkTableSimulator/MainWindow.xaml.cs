using System.Windows;

namespace WorkTableSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
            
        }

        private void workZone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}