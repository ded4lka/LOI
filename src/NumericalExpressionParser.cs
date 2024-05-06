using System;

namespace LOI
{
    public class NumericalExpressionParser
    {
        private readonly string input;
        private int position = 0;

        public NumericalExpressionParser(string input)
        {
            this.input = input.Trim(); // Удаляем пробелы в начале и в конце строки
        }

        public NumericalExpression Parse()
        {
            var result = ParseNumericalExpression();
            if (position != input.Length) // Проверяем, что весь ввод был обработан
                throw new Exception("Unexpected characters at end of expression.");
            return result;
        }

        private NumericalExpression ParseNumericalExpression()
        {
            var left = ParseTerm();
            while (Current == '|')
            {
                Eat('|');
                var right = ParseTerm();
                left = new NumericalOrExpression(left, right);
            }
            return left;
        }

        private NumericalExpression ParseTerm()
        {
            var left = ParseFactor();
            while (Current == '&' || Current == '^' || Current == '\\')
            {
                if (Current == '&')
                {
                    Eat('&');
                    var right = ParseFactor();
                    left = new NumericalAndExpression(left, right);
                }
                else if (Current == '^')
                {
                    Eat('^');
                    var right = ParseFactor();
                    left = new NumericalXorExpression(left, right);
                }
                else if (Current == '\\')
                {
                    Eat('\\');
                    var right = ParseFactor();
                    left = new NumericalDifferenceExpression(left, right);
                }
            }
            return left;
        }

        private NumericalExpression ParseFactor()
        {
            if (char.IsLetter(Current))
            {
                string name = ParseVariableName();
                return new NumericalVariableExpression(name);
            }
            else if (Current == '(')
            {
                Eat('(');
                var expression = ParseNumericalExpression();
                Eat(')');
                return expression;
            }
            throw new Exception($"Unexpected character: {Current}");
        }

        private string ParseVariableName()
        {
            int start = position;
            while (char.IsLetterOrDigit(Current) || Current == '_')
            {
                position++;
            }
            return input.Substring(start, position - start);
        }

        private void Eat(char expected)
        {
            if (Current == expected)
            {
                position++;
            }
            else
            {
                throw new Exception($"Expected '{expected}' but found '{Current}'");
            }
        }

        private char Current => position < input.Length ? input[position] : '\0';
    }
}
