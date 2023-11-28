using BeierholmWPF.Model.EIncome;
using BeierholmWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeierholmWPF
{
    /// <summary>
    /// Interaction logic for DetailedWindow.xaml
    /// </summary>
    public partial class DetailedWindow : Window
    {
        public DetailedViewModel dvm;
        public DetailedWindow(DetailedViewModel dvm)
        {
            this.dvm = dvm;

            InitializeComponent();

            this.DataContext = dvm;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
