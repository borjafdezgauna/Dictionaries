using Common;
using System;
using System.Diagnostics;
using System.Reflection;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testing BinaryTreeDictionary<int,string>:\n");
        
        bool success = Common.Tests.Test1_AddGetCount(new BinaryTreeDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test2_AddDuplicate(new BinaryTreeDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test3_Remove(new BinaryTreeDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test4_RemoveNonExistent(new BinaryTreeDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Common.Tests.Test5_KeysValues(new BinaryTreeDictionary<int, string>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        success = Tests.TestPerformanceWithTimeout(new BinaryTreeDictionary<int,int>(), Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        BinaryTreeDictionary<string, int> numbers = new BinaryTreeDictionary<string, int>();
        success = Common.Tests.TestReaderWriterStringInt(numbers, "numbers-dictionary-bin-tree.txt", Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        BinaryTreeDictionary<int, double> grades = new BinaryTreeDictionary<int, double>();
        success = Common.Tests.TestReaderWriterIntDouble(grades, "grades-dictionary-bin-tree.txt", Console.WriteLine, Console.WriteLine);
        if (!success)
            return;

        Console.WriteLine($"All tests passed.");
    }
}