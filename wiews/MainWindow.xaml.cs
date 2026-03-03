using calculator.wiewmodels;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {
            MainViewModel ViewModel = new MainViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;

            // Получаем цифру из нажатой кнопки
            string digit = ((Button)sender).Content.ToString();

            // Вызываем метод ViewModel для обработки цифры
            viewModel.ProcessNumber(digit);
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;

            // Получаем знак операции из кнопки (первый символ)
            char operation = ((Button)sender).Content.ToString()[0];

            viewModel.ProcessOperation(operation);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            viewModel.Clear();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            viewModel.Calculate();
        }
    }
}