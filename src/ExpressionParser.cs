using System;

namespace LOI
{
    public class ExpressionParser
    {
        private readonly string input;
        private int position = 0;

        public ExpressionParser(string input)
        {
            this.input = input;
        }

        public Expression Parse()
        {
            return ParseExpression();
        }

        private Expression ParseExpression()
        {
            var left = ParseTerm();
            while (Current == '|')
            {
                Eat('|');
                var right = ParseTerm();
                left = new OrExpression(left, right);
            }
            return left;
        }

        private Expression ParseTerm()
        {
            var left = ParseFactor();
            while (Current == '&' || Current == '^' || Current == '\\')  // Добавлена обработка символа '\'
            {
                if (Current == '&')
                {
                    Eat('&');
                    var right = ParseFactor();
                    left = new AndExpression(left, right);
                }
                else if (Current == '^')
                {
                    Eat('^');
                    var right = ParseFactor();
                    left = new XorExpression(left, right);
                }
                else if (Current == '\\')  // Обработка операции логического вычитания
                {
                    Eat('\\');
                    var right = ParseFactor();
                    left = new DifferenceExpression(left, right);
                }
            }
            return left;
        }

        private Expression ParseFactor()
        {
            if (char.IsLetter(Current))
            {
                string name = ParseVariableName();
                return new VariableExpression(name);
            }
            else if (Current == '(')
            {
                Eat('(');
                var expression = ParseExpression();
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
