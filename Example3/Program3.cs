using System;
using System.Collections.Generic;
using System.Linq;

namespace Example3
{
    class Program3
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 6, 8, 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, };
            var numbers = arr1.GroupBy(n => n).ToList();
            for (int i = 0; i < numbers.Count; i++)
                Console.WriteLine( numbers[i].Key + " " + numbers[i].Count()* numbers[i].Key + " " + numbers[i].Count());
            Console.ReadKey();
        }
    }
}