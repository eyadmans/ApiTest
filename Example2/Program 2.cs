using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2
{
    class Program2
    {
        static void Main(string[] args)
        {
            string a = "production";
            var word = a.GroupBy(c=> c).ToList();
            for(int i= 0; i<word.Count;i++)
            Console.WriteLine("The Character " + word[i].Key + ":" + word[i].Count() + " times");
            Console.ReadKey();
        }
    }
}
