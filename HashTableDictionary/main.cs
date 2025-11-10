using Common;
using System;
using System.Diagnostics;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testing HashTableDictionary<int,string>:\n");
        bool success = Common.Tests.Test1_AddGetCount(new HashTableDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test2_AddDuplicate(new HashTableDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test3_Remove(new HashTableDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test4_RemoveNonExistent(new HashTableDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test5_KeysValues(new HashTableDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.TestPerformanceWithTimeout(new HashTableDictionary<int, int>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        HashTableDictionary<string, int> numbers = new HashTableDictionary<string, int>();
        success = Common.Tests.TestReaderWriterStringInt(numbers, "numbers-dictionary-hash-map.txt", Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        HashTableDictionary<int, double> grades = new HashTableDictionary<int, double>();
        success = Common.Tests.TestReaderWriterIntDouble(grades, "grades-dictionary-hash-map.txt", Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        Console.WriteLine($"All tests passed.");
    }
}