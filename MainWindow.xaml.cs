using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private CalculatorEngine _engine;

        public MainWindow()
        {
            InitializeComponent();
            _engine = new CalculatorEngine();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _engine.ProcessDigit(button.Content.ToString());
            Display.Text = _engine.GetDisplayText();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _engine.ProcessOperation(button.Content.ToString()[0]);
            Display.Text = _engine.GetDisplayText();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            _engine.ProcessEquals();
            Display.Text = _engine.GetDisplayText();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _engine.Clear();
            Display.Text = _engine.GetDisplayText();
        }
    }
}