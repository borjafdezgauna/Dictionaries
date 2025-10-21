using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;

public static class TimeoutHandler
{
    public static bool Test(Func<Action<string>,Action<string>, bool> test, int timeoutSecs, Action<string> onProgress, Action<string> onError)
    {
        Task timeoutTask = Task.Delay(timeoutSecs * 1000);
        Task<bool> testTask = Task.Factory.StartNew(() => test(onProgress, onError));

        var winner = Task.WhenAny(testTask, timeoutTask).Result;


        if (testTask.IsCompleted && testTask.Result)
        {
            onProgress("Success");
            return true;
        }
        else if (testTask.IsCompleted)
        {
            onError("The test failed");
            return false;
        }

        //This test timed out
        onError($"The test took too long and it timed out (>{timeoutSecs}s)");
        return false;
    }
}
