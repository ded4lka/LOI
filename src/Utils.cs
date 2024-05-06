using System.Collections.Generic;

namespace LOI
{
     public class Utils
    {
        public HashSet<string> StringToHashSet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new HashSet<string>();
            }

            // Разбиение строки на массив элементов, удаление пробелов в начале и в конце каждого элемента
            string[] elements = input.Split(',');
            HashSet<string> hashSet = new HashSet<string>();

            foreach (string element in elements)
            {
                // Trim используется для удаления пробелов в начале и конце строки
                string trimmedElement = element.Trim();
                if (!string.IsNullOrEmpty(trimmedElement))
                {
                    hashSet.Add(trimmedElement);
                }
            }

            return hashSet;
        }
        public string HashSetToString(HashSet<string> hashSet)
        {
            // Возвращаем пустую строку, если HashSet пустой или null
            if (hashSet == null || hashSet.Count == 0)
                return string.Empty;

            // Соединяем элементы HashSet через запятую
            return string.Join(", ", hashSet);
        }
        public string ListToString(List<string> list)
        {
            // Возвращаем пустую строку, если список пустой или null
            if (list == null || list.Count == 0)
                return string.Empty;

            // Соединяем элементы списка через запятую
            return string.Join(", ", list);
        }
        public void SortStringNumbers(List<string> numbers)
        {
            // Проверяем, не пустой ли список
            if (numbers == null || numbers.Count == 0)
                return;

            List<string> numericStrings = new List<string>();
            List<string> nonNumericStrings = new List<string>();

            // Разделение строк на числовые и нечисловые
            foreach (var number in numbers)
            {
                if (int.TryParse(number, out int parsedNumber))
                {
                    numericStrings.Add(number);
                }
                else
                {
                    nonNumericStrings.Add(number);
                }
            }

            // Сортировка числовых строк
            numericStrings.Sort((x, y) => int.Parse(x).CompareTo(int.Parse(y)));

            // Объединение списков: сначала числовые строки, затем нечисловые
            numbers.Clear();
            numbers.AddRange(numericStrings);
            numbers.AddRange(nonNumericStrings);
        }
    }
}