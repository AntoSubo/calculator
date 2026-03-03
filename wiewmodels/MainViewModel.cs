using calculator.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace calculator.wiewmodels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private CalculatorEngine _engine = new CalculatorEngine();
        private string _displayText = "0";           // то, что видит пользователь
        public MainViewModel()
        {
            _engine = new CalculatorEngine();
        }
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged(); // уведомление об изменении
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

        }
        public void ProcessNumber(string digit)
        {
            if (_engine.StartNewNumber)
            {
                DisplayText = digit;
                _engine.StartNewNumber = false;
            }
            else
            {
                if (DisplayText.Length < 15)
                    DisplayText += digit;
            }
        }
        public void ProcessOperation(char op)
        {
            _engine.FirstNumber = double.Parse(DisplayText);
            _engine.Operation = op;
            _engine.StartNewNumber = true;
        }

        public void Clear()
        {
            DisplayText = "0";
            _engine.FirstNumber = 0;
            _engine.Operation = ' ';
            _engine.StartNewNumber = true;
        }

        public void Calculate()
        {
        }
    }
}