using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Common
{
    public static class Tests
    {
        public static bool TestDictionaryIntString(Common.IDictionary<int, string> dictionary)
        {
            //int -> string tests
            Console.Write("Testing Add()...");
            dictionary.Add(3, "hiru");
            dictionary.Add(7, "zazpi");
            dictionary.Add(11, "hamaika");
            dictionary.Add(2, "bi");
            dictionary.Add(1, "bat");
            dictionary.Add(4, "lau");
            dictionary.Add(15, "hamabost");
            dictionary.Add(5, "bost");
            dictionary.Add(13, "hamairu");
            dictionary.Add(6, "sei");
            dictionary.Add(8, "zortzi");
            dictionary.Add(9, "bederatzi");
            dictionary.Add(10, "hamar");
            dictionary.Add(12, "hamabi");
            dictionary.Add(14, "hamalau");

            string asString = dictionary.AsString();
            if (asString == null)
            {
                Console.WriteLine($"AsString() is not yet implemented");
                return false;
            }    
            for (int i = 1; i < 16; i++)
            {
                if (!asString.Contains($"[{i}-"))
                {
                    Console.WriteLine($"Error. Value {i} wasn't added to the dictionary:");
                    Console.WriteLine(asString);
                    return false;
                }
            }
            Console.WriteLine("Ok");

            Console.WriteLine($"Initial dictionary:\n{dictionary.AsString()}");

            Console.Write("Testing Count()...");
            int count = dictionary.Count();
            if (count != 15)
            {
                Console.WriteLine($"Error. Count() returned {count} instead of 15");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Get()...");
            string value = dictionary.Get(12);
            if (value != "hamabi")
            {
                Console.WriteLine($"Error. Get(12) returned {value} instead of \"hamabi\"");
                return false;
            }
            value = dictionary.Get(14);
            if (value != "hamalau")
            {
                Console.WriteLine($"Error. Get(14) returned {value} instead of \"hamalau\"");
                return false;
            }
            value = dictionary.Get(4);
            if (value != "lau")
            {
                Console.WriteLine($"Error. Get(4) returned {value} instead of \"lau\"");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Add() with already existing key...");
            dictionary.Add(6, "six");
            count = dictionary.Count();
            if (count != 15 || dictionary.Get(6) != "six")
            {
                Console.WriteLine($"Error. Get(6) after Add(6,\"six\") returned \"{dictionary.Get(6)}\" instead of \"six\"");
                return false;
            }
            Console.WriteLine("Ok");


            Console.Write("Testing Remove()...");
            dictionary.Remove(6);
            int newCount = dictionary.Count();
            if (count != newCount + 1)
            {
                Console.WriteLine($"Error. Remove failed to remove leaf node");
                return false;
            }
            Console.WriteLine("Ok");

            Console.Write("Testing Remove() with non-existing key...");
            dictionary.Remove(6);
            newCount = dictionary.Count();
            int expectedNodeCount = count - 1;
            if (expectedNodeCount != newCount)
            {
                Console.WriteLine($"Error. {newCount} instead of {expectedNodeCount} nodes");
                return false;
            }
            Console.WriteLine("Ok");


            Console.WriteLine();
            Console.WriteLine();
            return true;

        }
        public static SpeedMeasure MeasureSpeed(IDictionary<int, int> dictionary)
        {
            Console.WriteLine("Measuring speed");

            int numSamples = 1000000;
            Random randomGenerator = new Random();
            Dictionary<int, int> solutions = new Dictionary<int, int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numSamples; i++)
            {
                int number = randomGenerator.Next(0, 10000);
                dictionary.Add(number, number * number);
                solutions[number] = number * number;
            }

            foreach (int number in solutions.Keys)
            {
                if (dictionary.Get(number) != solutions[number])
                    return new SpeedMeasure() { Success = false };

                dictionary.Remove(number);
            }

            return new SpeedMeasure() { Success = true, Time = stopwatch.Elapsed.TotalSeconds };
        }
    }
}