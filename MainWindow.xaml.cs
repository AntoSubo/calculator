using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNumber = 0; // хранит число, которое было до нажатия операции (например, нажали 5 +, сохраняем 5)

        char operation = ' '; //хранит знак операции(например, пользователь нажал "+")

        bool StartNewNumber = true; //флаг: true = следующая цифра начнет новое число, false = добавляем цифру к текущему
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (StartNewNumber)
            {
                Display.Text = button.Content.ToString();
                StartNewNumber = false;
            }
            else
            {
                if (Display.Text.Length < 15)
                {
                    Display.Text += button.Content.ToString();
                }

            }

        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            firstNumber = Convert.ToDouble(Display.Text);
            operation = button.Content.ToString()[0];
            StartNewNumber = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = ' ';
            StartNewNumber = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (operation == ' ') return;

            double secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;

            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber; break;
                case '-':
                    result = firstNumber - secondNumber; break;
                case '*':
                    result = firstNumber * secondNumber; break;
                case '/':
                    if (secondNumber > 0)
                    {
                        result = firstNumber / secondNumber; 
                    }
                    else
                    {
                        Display.Text = "Ошибка";
                        return;
                    }
                    break;
            }
            Display.Text = result.ToString();
            StartNewNumber = true;
            operation = ' ';
        }
    }
}