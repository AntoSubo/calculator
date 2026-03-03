namespace calculator.models
{
    public class CalculatorEngine
    {
        public double FirstNumber { get; set; }
        public char Operation { get; set; }
        public bool StartNewNumber { get; set; } = true;

        public double Calculate(double secondNumber)
        {
            switch (Operation)
            {
                case '+':
                    return FirstNumber + secondNumber;
                case '-':
                    return FirstNumber - secondNumber;
                case '*':
                    return FirstNumber * secondNumber;
                case '/':
                    if (secondNumber > 0)
                        return FirstNumber / secondNumber;
                    else
                        return 0;
                default:
                    return 0;
            }
        }
    }
}

//Model – она содержит бизнес-данные и методы их обработки, независимые от пользовательского интерфейса.