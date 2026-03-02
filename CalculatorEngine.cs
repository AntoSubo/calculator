using System;

namespace calculator
{
    public class CalculatorEngine
    {
        private double _firstNumber;
        private char _operation;
        private bool _startNewNumber = true;
        private string _displayText = "0";

   
        public string GetDisplayText()
        {
            return _displayText;
        }

    
        public void ProcessDigit(string digit)
        {
            if (_startNewNumber)
            {
                _displayText = digit;
                _startNewNumber = false;
            }
            else
            {
                if (_displayText.Length < 15)
                    _displayText += digit;
            }
        }

      
        public void ProcessOperation(char op)
        {
            _firstNumber = double.Parse(_displayText);
            _operation = op;
            _startNewNumber = true;
        }

  
        public void ProcessEquals()
        {
            if (_operation == ' ') return;

            double secondNumber = double.Parse(_displayText);
            double result = 0;

            switch (_operation)
            {
                case '+':
                    result = _firstNumber + secondNumber;
                    break;
                case '-':
                    result = _firstNumber - secondNumber;
                    break;
                case '*':
                    result = _firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber != 0)
                        result = _firstNumber / secondNumber;
                    else
                    {
                        _displayText = "Ошибка";
                        _operation = ' ';
                        _startNewNumber = true;
                        return;
                    }
                    break;
            }

            _displayText = result.ToString();
            _operation = ' ';
            _startNewNumber = true;
        }

     
        public void Clear()
        {
            _displayText = "0";
            _firstNumber = 0;
            _operation = ' ';
            _startNewNumber = true;
        }
    }
}