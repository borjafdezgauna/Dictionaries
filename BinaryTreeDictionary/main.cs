using Common;
using System;

class MainClass
{
    public static void Main(string[] args)
    {
        BinaryTreeDictionary<int, string> dictionaryIntString = new BinaryTreeDictionary<int, string>();
        Console.WriteLine("Testing BinaryTreeDictionary<int,string>:\n");
        bool success = Common.Tests.TestDictionaryIntString(dictionaryIntString);
        if (!success)
            return;

        SpeedMeasure speedMeasure = Tests.MeasureSpeed(new BinaryTreeDictionary<int, int>());
        if (!speedMeasure.Success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }
        Console.WriteLine($"All tests passed. Time: {speedMeasure.Time}s");
    }
}