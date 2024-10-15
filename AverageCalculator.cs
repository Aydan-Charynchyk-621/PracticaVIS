using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();
        string input;

        Console.WriteLine("Введите числа для расчета среднего арифметического.");
        Console.WriteLine("Введите 'стоп' для завершения ввода.");

        while (true)
        {
            Console.Write("Введите число: ");
            input = Console.ReadLine();

            if (input.ToLower() == "стоп")
            {
                break;
            }

            try
            {
                double number = Convert.ToDouble(input);
                numbers.Add(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Пожалуйста, введите корректное число.");
            }
        }

        if (numbers.Count > 0)
        {
            double average = 0;
            foreach (var num in numbers)
            {
                average += num;
            }
            average /= numbers.Count;
            Console.WriteLine($"Среднее арифметическое: {average:F2}");
        }
        else
        {
            Console.WriteLine("Вы не ввели ни одного числа.");
        }
    }
}
