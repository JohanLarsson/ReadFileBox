namespace ReadFileBox
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private async void OnReadClick(object sender, RoutedEventArgs e)
        {
            await _vm.Read().ConfigureAwait(true);
        }

        private async void OnSaveClick(object sender, RoutedEventArgs e)
        {
            await _vm.Save().ConfigureAwait(true);
        }
    }
}
