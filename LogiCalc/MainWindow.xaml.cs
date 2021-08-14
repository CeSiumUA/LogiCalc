using LogiCalc.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogiCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.viewModel;
        }

        private void ParsingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var senderBox = sender as TextBox;
            this.viewModel.ChangeDispoplan(senderBox?.Text);
        }
    }
}
