using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public static class TimeoutHandler
    {
        public static bool Test<T>(Func<T, Action<string>, Action<string>, bool> test, T parameter,
         int timeoutSecs, Action<string> onProgress, Action<string> onError)
        {
            Task timeoutTask = Task.Delay(timeoutSecs * 1000);
            Task<bool> testTask = Task.Factory.StartNew(() => test(parameter, onProgress, onError));

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

        public static bool Test<T1,T2>(Func<T1, T2, Action<string>, Action<string>, bool> test, T1 parameter1, T2 parameter2,
         int timeoutSecs, Action<string> onProgress, Action<string> onError)
        {
            Task timeoutTask = Task.Delay(timeoutSecs * 1000);
            Task<bool> testTask = Task.Factory.StartNew(() => test(parameter1, parameter2, onProgress, onError));

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
}