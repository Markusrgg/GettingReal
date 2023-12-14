using BeierholmWPF.ViewModel;
using System.Windows;

namespace BeierholmWPF
{
    /// <summary>
    /// Interaction logic for DetailedWindow.xaml
    /// </summary>
    public partial class DetailedWindow : Window
    {
        public DetailedWindow(DetailedViewModel dvm)
        {
            InitializeComponent();

            DataContext = dvm;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
