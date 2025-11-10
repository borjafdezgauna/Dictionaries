using System;
using System.IO;
using System.Text;

namespace Common
{
    public class DictionaryReaderWriter
    {
        private string EncodeString(string str) => str.Replace("\n", "[NEW_LINE]");
        private string DecodeString(string str) => str.Replace("[NEW_LINE]", "\n");
        public bool Write<TKey,TValue>(IDictionary<TKey,TValue> dictionary, string filename,
            Func<TKey, string> keyToString, Func<TValue, string> valueToString)
        {
            try
            {
                TextWriter writer = File.CreateText(filename);

                //TODO #1: Write in the file the keys and values, one by one: a key in a line, its value on the following line
                //Example: If the dictionary has the key/value pairs 1234->4.25 and 2133->1.35, then the content of the file will be:
                //1234
                //4.25
                //2133
                //1.35
                //Because we don't know what type keys and values are, we need to call keyToString(key) to convert the key to string and
                //valueToString(value) to convert the value to string
                

                writer.Close();

                return true;
            }
            catch { return false; }
        }
   
        public bool Read<TKey, TValue>(IDictionary<TKey, TValue> dictionary, string filename,
            Func<string,TKey> stringToKey, Func<string,TValue> valueToKey)
        {
            try
            {
                TextReader reader = File.OpenText(filename);

                //TODO #2: Read the keys and values one by one and add them to the given dictionary. Use the same format as the Write() above
                //Once a key is read from the file, it needs to be converted to string using stringToKey(line). For the value, valueToKey(line)
                

                reader.Close();

                return true;
            }
            catch { return false; }
        }
    }
}
