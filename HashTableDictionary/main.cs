using Common;
using System;

class MainClass
{
    public static void Main(string[] args)
    {
        StatsUpdater statsUpdater = new StatsUpdater();
        statsUpdater.CheckGitUsername();

        if (statsUpdater.GitUsername == null)
        {
            Console.WriteLine("Error getting Git info. You need to add this project to Git (clone from my repo, delete the .git directory and create a new repo on GitHub)");
            Console.WriteLine("If you have already done that, run Visual Studio Installer and check you have installed \"Git for Windows\"");
            return;
        }

        HashTableDictionary<int, string> dictionaryIntString = new HashTableDictionary<int, string>();
        Console.WriteLine("Testing BinaryTreeDictionary<int,string>:\n");
        bool success = Common.Tests.TestDictionaryIntString(dictionaryIntString);
        if (!success)
            return;

        SpeedMeasure speedMeasure = Tests.MeasureSpeed(new HashTableDictionary<int, int>());
        if (!speedMeasure.Success)
        {
            Console.WriteLine("An error was detected during the speed measurement. Probably something wrong with Add/Get");
            return;
        }

        success = statsUpdater.AddResult(speedMeasure);
        if (success)
            Console.WriteLine("Your time was saved on the server");
        else
            Console.WriteLine("Something failed saving your time on the server");
    }
}