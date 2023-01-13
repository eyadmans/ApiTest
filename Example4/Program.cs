using System;
using System.Collections.Generic;
using System.Linq;


namespace Example4
{
    class Program4
    {
        static void Main(string[] args)
        {
            string[] arr1 = new string[] { "Rome" , "Damascus" , "Paris" , "Amsterdam" , "Berlin" };
            foreach (string word in arr1)
                if (word.StartsWith('A')==true & word.EndsWith('m')==true)
                Console.WriteLine(word);
            Console.ReadKey();
        }
    }
    }

