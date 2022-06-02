using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncProg
{
    class Program
    {
        static Action<string> printing = message => Console.WriteLine(message); // 1 - 1
        static void Printing() // 1 - 1
        {
            var input = Console.ReadLine().Split(" ");
            foreach (var item in input) printing(item.Trim());
        }

        static Action<string> paper = message => Console.WriteLine($"{message} (нет в наличии)"); // 1 - 2
        static void Paper() // 1 - 2
        {
            var input = Console.ReadLine().Split(" ");
            foreach (var item in input) paper(item.Trim());
        }

        static Func<List<int>, int> minimum = message => message.OrderBy(s => s).ToList()[0]; // 1 - 3
        static void Minimum() // 1 - 3
        {
            var input = Console.ReadLine()
                            .Split(" ")
                            .Select(Int32.Parse)
                            .ToList();

            Console.WriteLine(minimum(input));
        }

        static List<int> sort(List<int> input, Func<List<int>, List<int>> operation) // 1 - 4
        {
            return operation(input);
        }
        static void Sort() // 1 - 4
        {
            var input = Console.ReadLine()
                            .Split(" ")
                            .Select(Int32.Parse)
                            .ToList();

            List<int> numbers = new List<int>();

            for (int i = input[0]; i <= input[1]; i++) numbers.Add(i);

            var parity = Console.ReadLine();

            if (parity == "odd") numbers = sort(numbers, x => x.Where(s => s % 2 != 0).ToList());
            else numbers = sort(numbers, x => x.Where(s => s % 2 == 0).ToList());

            foreach (var item in numbers) Console.Write(item + " ");
        }

        static Func<int, int> add = x => x + 1;
        static Func<int, int> multiply = x => x * 2;
        static Func<int, int> subtract = x => x - 1;
        static Action<int> print = x => Console.Write(x + " ");
        static void Arithmetic() // 2 - 1
        {
            var numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(Int32.Parse)
                            .ToList();

            var command = Console.ReadLine().Trim();

            while (command != "end")
            {
                if (command == "add")
                    for (int i = 0; i < numbers.Count; i++) numbers[i] = add(numbers[i]);
                if (command == "multiply")
                    for (int i = 0; i < numbers.Count; i++) numbers[i] = multiply(numbers[i]);
                if (command == "subtract")
                    for (int i = 0; i < numbers.Count; i++) numbers[i] = subtract(numbers[i]);
                if (command == "print")
                    numbers.ForEach(n => Console.Write(n + " "));
                command = Console.ReadLine().Trim();
            }
        }

        static Func<List<int>, int, List<int>> reversal = (x, y) => x.Where(e => e % y != 0).Reverse().ToList(); // 2 - 2
        static void Reversal() // 2 - 2
        {
            var numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(Int32.Parse)
                            .ToList();

            var num = Int32.Parse(Console.ReadLine().Trim());

            numbers = reversal(numbers, num);

            numbers.ForEach(n => Console.Write(n + " "));
        }

        static Func<int, List<string>, List<string>> filtering = (n, name) => name.Where(e => e.Length <= n).ToList(); // 2 - 3
        static void Filtering() // 2 - 3
        {
            var n = Int32.Parse(Console.ReadLine().Trim());

            var names = Console.ReadLine()
                            .Split(" ")
                            .ToList();

            names = filtering(n, names);

            names.ForEach(e => Console.Write(e + " "));
        }

        static Func<int, int, int> comparator = (x, y) => // 2 - 4
        {
            if (x % 2 == 0 && y % 2 == 0 && x > y)
            {
                return 1;
            }

            if (x % 2 != 0 && y % 2 != 0 && x < y)
            {
                return -1;
            }

            if (x % 2 != 0)
                return 1;

            return -1;
        };

        static int Compare(int x, int y) // 2 - 4
        {
            return comparator(x, y);
        }

        static void Comparator() // 2 - 4
        {
            var numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(Int32.Parse)
                            .ToList();

            numbers.Sort(Compare);

            numbers.ForEach(n => Console.Write(n + " "));
        }

        static void Main(string[] args)
        {
            //Printing();
            //Paper();
            //Minimum();
            //Sort();
            //Arithmetic();
            //Reversal();
            //Filtering();
            //Comparator();
        }
    }
}
