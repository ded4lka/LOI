using System.Linq;
using System;
using System.Collections.Generic;

namespace LOI
{
    public class ExpressionValidator
    {
        private readonly string validVariables = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string validOperators = "&|^\\";

        public bool Validate(string expression)
        {
            expression = expression.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(expression))
            {
                Console.WriteLine("Expression is empty.");
                return false;
            }

            // Проверяем, содержит ли выражение только допустимые символы
            if (!expression.All(c => validVariables.Contains(c) || validOperators.Contains(c) || c == '(' || c == ')'))
            {
                Console.WriteLine("Expression contains invalid characters.");
                return false;
            }

            // Проверяем минимальное количество переменных (минимум 2)
            int variableCount = expression.Count(c => validVariables.Contains(c));
            if (variableCount < 2)
            {
                Console.WriteLine("Expression must contain at least two variables.");
                return false;
            }

            // Проверяем наличие хотя бы одного оператора
            int operatorCount = expression.Count(c => validOperators.Contains(c));
            if (operatorCount < 1)
            {
                Console.WriteLine("Expression must contain at least one operator.");
                return false;
            }

            // Проверяем парность скобок
            if (!AreParenthesesBalanced(expression))
            {
                Console.WriteLine("Parentheses are not balanced.");
                return false;
            }

            // Проверяем, что каждая переменная встречается только один раз
            if (!AreVariablesUnique(expression))
            {
                Console.WriteLine("Each variable must appear only once.");
                return false;
            }

            return true;
        }

        private bool AreParenthesesBalanced(string expression)
        {
            int balance = 0;
            foreach (char c in expression)
            {
                if (c == '(')
                {
                    balance++;
                }
                else if (c == ')')
                {
                    balance--;
                    if (balance < 0)
                    {
                        return false; // Закрывающая скобка без соответствующей открывающей
                    }
                }
            }
            return balance == 0; // Все открывающие скобки должны быть закрыты
        }

        private bool AreVariablesUnique(string expression)
        {
            HashSet<char> seenVariables = new HashSet<char>();
            foreach (char c in expression)
            {
                if (validVariables.Contains(c))
                {
                    if (!seenVariables.Add(c)) // Если добавление не удалось, переменная уже встречалась
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
