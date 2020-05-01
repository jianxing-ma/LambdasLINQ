using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdasLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> Greet = () => "Hello World";
            Func<int, int> AddOne = i => i + 1;
            Func<int, int, int> ToPower = (a, b) => (int)Math.Pow(a, b);
            Func<int, int, int> AddInts = (a, b) => a + b;
            Func<string, string, string> ConcatStrings = (a, b) => b + a;

            var nums = Enumerable.Range(1, 10).ToList();
            List<string> sl = Enumerable.Range(65, 26).ToList().ConvertAll(i => ((char)i).ToString());

            nums.ForEach(i => Console.Write($"{AddOne(i)} "));
            Console.WriteLine(); // Alternative
            nums.Select(x => x + 1).ToList().ForEach(i => Console.Write($"{i} "));
            Console.WriteLine();

            nums.ForEach(i => Console.Write($"{ToPower(i, 2)} "));
            Console.WriteLine(); // Alternative
            nums.Select(x => ToPower(x, 2)).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            int sum = 0;
            nums.ForEach(i => sum = AddInts(sum, i)); 
            Console.WriteLine(sum);
            // Alternative
            int sum1 = nums.Aggregate((result, next) => result + next);
            Console.WriteLine(sum1);

            Console.WriteLine(String.Join("", sl.ToArray()));
            string s = "";
            sl.ForEach(i => s = ConcatStrings(i, s));
            Console.WriteLine(s);
            //Alternative
            Console.WriteLine(sl.Aggregate((result, next) => result + next));

            Func<int, int, int> Tetration = null;
            Tetration = (a, b) => b == 1 ? a: ToPower(a, Tetration(a, b - 1));
            Console.WriteLine(Tetration(2,4));
        }
    }
}
