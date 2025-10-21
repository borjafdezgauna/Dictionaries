using Common;
using System;
using System.Diagnostics;

class MainClass
{
    public static void Main(string[] args)
    {
        BinaryTreeDictionary<int, string> dictionaryIntString = new BinaryTreeDictionary<int, string>();
        Console.WriteLine("Testing BinaryTreeDictionary<int,string>:\n");
        bool success = Common.Tests.TestDictionaryIntString(dictionaryIntString);
        if (!success)
            return;

        Stopwatch stopwatch = Stopwatch.StartNew();
        success = Tests.TestPerformance(new BinaryTreeDictionary<int, int>());
        if (!success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }
        else
            Console.WriteLine($"Performance minimum passed. Time: {stopwatch.Elapsed.TotalSeconds}s\n\n");

        Console.WriteLine("Testing DictionaryReaderWriter...");
        BinaryTreeDictionary<string, int> numbers = new BinaryTreeDictionary<string, int>();
        numbers.Add("bat", 1);
        numbers.Add("zortzi", 8);
        numbers.Add("hamar", 10);
        numbers.Add("bederatzi", 9);
        numbers.Add("zero", 0);

        success = Common.Tests.TestReaderWriter(numbers, "string-to-int-btree.txt", (word) => word, (number) => number.ToString(),
            (wordString) => wordString, (numberString) => int.Parse(numberString),
            (message) => { Console.WriteLine(message); });
        if (!success)
            return;

        BinaryTreeDictionary<int, double> grades = new BinaryTreeDictionary<int, double>();
        grades.Add(1234, 4.25);
        grades.Add(2133, 1.35);
        grades.Add(3312, 8.71);
        grades.Add(6544, 9.1);
        grades.Add(7092, 6.25);

        Common.Tests.TestReaderWriter(grades, "int-to-double-btree.txt", (id) => id.ToString(), (grade) => grade.ToString(),
            (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString),
            (message) => { Console.WriteLine(message); });
        if (!success)
            return;

        Console.WriteLine($"All tests passed.");
    }
}