using System;
using System.Diagnostics;
using IntToIntDictionary = System.Collections.Generic.Dictionary<int,int>;

namespace Common
{
    public static class Tests
    {
        private static bool CompareDictionaries<TKey, TValue>(Common.IDictionary<TKey, TValue> dictionary1,
            Common.IDictionary<TKey, TValue> dictionary2, Action<string> onError)
        {
            if (dictionary1.Count() != dictionary2.Count())
            {
                onError($"The original dictionary and the one read from file have a different number of elements ({dictionary1.Count()} and {dictionary2?.Count()})");
                return false;
            }

            foreach (TKey key in dictionary1.Keys())
            {
                if (!dictionary1.Get(key).Equals(dictionary2.Get(key)))
                {
                    onError($"Different values found for the same key in original dictionary ({dictionary1.Get(key)} and {dictionary2.Get(key)})");
                    return false;
                }
            }
            return true;
        }


        public static bool TestReaderWriter<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            string filename,
            Func<TKey, string> keyToString, Func<TValue, string> valueToString,
            Func<string, TKey> stringToKey, Func<string, TValue> stringToValue,
            Action<string> onError)
        {
            DictionaryReaderWriter readerWriter = new DictionaryReaderWriter();
            bool success = readerWriter.Write(dictionary, filename, (key) => keyToString(key), (value) => valueToString(value));
            if (!success)
                onError("Something went wrong writing the dictionary to a file");

            IDictionary<TKey, TValue> readFromFile = (IDictionary<TKey, TValue>)Activator.CreateInstance(dictionary.GetType());

            success = readerWriter.Read(readFromFile, filename, (keyString) => stringToKey(keyString), (valueString) => stringToValue(valueString));
            if (!success)
                onError("Something went wrong reading from the file");

            return CompareDictionaries(dictionary, readFromFile, onError);
        }

        private static bool AddToDictionary(Common.IDictionary<int, string> dictionary,
            int[] keys, string[] values,
            Action<string> onProgress, Action<string> onError, bool isDuplicate = false)
        {
            int pos = 0;
            int count = dictionary.Count();
            foreach (int key in keys)
            {
                dictionary.Add(key, values[pos]);
                string check = dictionary.Get(key);
                if (check != values[pos])
                {
                    onError($"After doing Add({key},\"{values[pos]}\"), Get({key}) returned {check} instead of {values[pos]}");
                    return false;
                }

                int newCount = dictionary.Count();
                int expectedCount = isDuplicate ? count : count + 1;
                if (expectedCount != newCount)
                {
                    onError($"Count returned {newCount} instead of {expectedCount} after Add({key}, {values[pos]})");
                    return false;
                }
                if (!isDuplicate)
                    count++;
                pos++;
            }
            return true;
        }
        
        private static bool RemoveKeys(Common.IDictionary<int, string> dictionary,
            int[] keys,
            Action<string> onProgress, Action<string> onError)
        {
            int pos = 0;
            int count = dictionary.Count();
            foreach (int key in keys)
            {
                dictionary.Remove(key);

                int newCount = dictionary.Count();
                if (count - 1 != newCount)
                {
                    onError($"Count returned {newCount} instead of {count-1} after Remove({key}");
                    return false;
                }
                string check = dictionary.Get(key);
                if (check != null)
                {
                    onError($"Get({key}) returned {check} instead of null after Remove({key}");
                    return false;
                }
                count--;
                pos++;
            }
            return true;
        }

        public static bool Test1_AddGetCount(Common.IDictionary<int, string> dictionary,
         Action<string> onProgress, Action<string> onError)
        {
            //int -> string tests
            onProgress("Testing Add()/Get()/Count()...");

            int[] keys = new int[] { 3, 7, 11, 2, 1, 4, 15, 5, 13, 6, 8, 9, 10, 12, 14 };
            string[] values = new string[]
            {
                "hiru", "zazpi", "hamaika", "bi", "bat", "lau", "hamabost", "bost","hamairu",
                "sei", "zortzi", "bederatzi", "hamar", "hamabi", "hamalau"
            };

            bool success = AddToDictionary(dictionary, keys, values, onProgress, onError);
            if (!success)
                return false;

            onProgress("Ok");
            return true;
        }
        public static bool Test2_AddDuplicate(Common.IDictionary<int, string> dictionary,
         Action<string> onProgress, Action<string> onError)
        {
            onProgress("Testing Add() with duplicate keys...");

            int[] keys = new int[] { 3, 7, 11, 2, 1, 4, 15, 5, 13, 6, 8, 9, 10, 12, 14 };
            string[] values = new string[]
            {
                "hiru", "zazpi", "hamaika", "bi", "bat", "lau", "hamabost", "bost","hamairu",
                "sei", "zortzi", "bederatzi", "hamar", "hamabi", "hamalau"
            };

            bool success = AddToDictionary(dictionary, keys, values, onProgress, onError);
            if (!success)
                return false;

            string[] values2 = new string[]
            {
                "three", "seven", "eleven", "two", "one", "four", "fifteen", "five","thirteen",
                "six", "eight", "nine", "ten", "twelve", "fourteen"
            };

            AddToDictionary(dictionary, keys, values2, onProgress, onError, true);
            if (!success)
                return false;

            onProgress("Ok");
            return true;
        }

        public static bool Test3_Remove(Common.IDictionary<int, string> dictionary,
         Action<string> onProgress, Action<string> onError)
        {
            //int -> string tests
            onProgress("Testing Remove()...");

            int[] keys = new int[] { 3, 7, 11, 2, 1, 4, 15, 5, 13, 6, 8, 9, 10, 12, 14 };
            string[] values = new string[]
            {
                "hiru", "zazpi", "hamaika", "bi", "bat", "lau", "hamabost", "bost","hamairu",
                "sei", "zortzi", "bederatzi", "hamar", "hamabi", "hamalau"
            };

            bool success = AddToDictionary(dictionary, keys, values, onProgress, onError);
            if (!success)
                return false;

            success = RemoveKeys(dictionary, keys, onProgress, onError);
            if (!success)
                return false;

            onProgress("Ok");

            return true;
        }
        public static bool Test4_RemoveNonExistent(Common.IDictionary<int, string> dictionary,
         Action<string> onProgress, Action<string> onError)
        {
            //int -> string tests
            onProgress("Testing Remove()...");

            int[] keys = new int[] { 3, 7, 11, 2, 1, 15, 5, 13, 6, 8, 9, 12, 14 };
            string[] values = new string[]
            {
                "hiru", "zazpi", "hamaika", "bi", "bat", "hamabost", "bost","hamairu",
                "sei", "zortzi", "bederatzi", "hamabi", "hamalau"
            };

            bool success = AddToDictionary(dictionary, keys, values, onProgress, onError);
            if (!success)
                return false;

            Console.Write("Testing Remove() with non-existing key...");
            int count = dictionary.Count();
            foreach (int nonExistentKey in new int[] { 23, -32, 50, 32, 22, 10, 4 })
            {
                dictionary.Remove(nonExistentKey);

                int newCount = dictionary.Count();
                if (count != newCount)
                {
                    onError($"Count() returned {newCount} instead of {count} after deleting a key that wasn't in the dictionary");
                    return false;
                }
            }

            onProgress("Ok");

            return true;

        }
        
        public static bool TestPerformanceWithTimeout(IDictionary<int, int> dictionary,
            Action<string> onProgress, Action<string> onError)
        {
            return Common.TimeoutHandler.Test(TestPerformance, dictionary, 1, onProgress, onError);
        }
        private static bool TestPerformance(IDictionary<int, int> dictionary,
            Action<string> onProgress, Action<string> onError)
        {
            onProgress("Measuring speed");

            int numSamples = 100000;
            Random randomGenerator = new Random();
            IntToIntDictionary solutions = new IntToIntDictionary();

            onProgress($"Adding {numSamples} items");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numSamples; i++)
            {
                int number = randomGenerator.Next(0, 10000);
                dictionary.Add(number, number * number);
                solutions[number] = number * number;
            }

            onProgress($"Getting back and checking added items");

            foreach (int number in solutions.Keys)
            {
                if (dictionary.Get(number) != solutions[number])
                {
                    onError($"Get({number}) returned {dictionary.Get(number)} instead of {solutions[number]}");
                    return false;
                }

                dictionary.Remove(number);
            }

            onProgress($"Ok");
            return true;
        }

        public static bool TestReaderWriterStringInt<T>(T dictionary, string filename, Action<string> onProgress,
            Action<string> onError) where T : Common.IDictionary<string, int>
        {
            dictionary.Add("bat", 1);
            dictionary.Add("zortzi", 8);
            dictionary.Add("hamar", 10);
            dictionary.Add("bederatzi", 9);
            dictionary.Add("zero", 0);

            return Common.Tests.TestReaderWriter(dictionary, filename, (word) => word, (number) => number.ToString(),
                (wordString) => wordString, (numberString) => int.Parse(numberString),
                (message) => onError(message));

        }
        public static bool TestReaderWriterIntDouble<T>(T dictionary, string filename, Action<string> onProgress,
            Action<string> onError) where T : Common.IDictionary<int, double>
        {
            dictionary.Add(1234, 4.25);
            dictionary.Add(2133, 1.35);
            dictionary.Add(3312, 8.71);
            dictionary.Add(6544, 9.1);
            dictionary.Add(7092, 6.25);

            return Common.Tests.TestReaderWriter(dictionary, filename, (id) => id.ToString(), (grade) => grade.ToString(),
                (idString) => int.Parse(idString), (gradeString) => double.Parse(gradeString),
                (message) => onError(message));
        }
        public static bool TestReaderWriterSpecialCharacters<T>(T dictionary1, T dictionary2, string filename,
            Action<string> onError) where T : Common.IDictionary<string, string>
        {
            dictionary1.Add("Izen-a:\nJacinto", "Nombre:[Ja-cinto]");
            dictionary1.Add("Abi zena:\nRamírez", "Ape_llido:Ramírez");

            DictionaryReaderWriter readerWriter = new DictionaryReaderWriter();
            bool success = readerWriter.Write(dictionary1, filename, (word) => word, (word) => word);
            if (!success)
                return false;

            success = readerWriter.Read(dictionary2, filename, (word) => word, (word) => word);
            if (!success)
                return false;

            return Common.Tests.TestReaderWriter(dictionary2, filename, (word) => word, (word) => word,
                (word) => word, (word) => word,
                (message) => onError(message));
        }
    }
}