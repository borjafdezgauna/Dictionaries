
using Common;
using System;

public class HashTableDictionaryItem<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public HashTableDictionaryItem(TKey key, TValue value)
    {
        //TODO #1: Initialize this object's member variables/attributes
    }

    public string AsString()
    {
        if (!Key.Equals(default(TKey)))
            return $"[{Key}->{Value}]\n";
        else
            return null;
    }
}

public class HashTableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
    int NumElements = 0;
    public HashTableDictionaryItem<TKey, TValue>[] Entries;

    public HashTableDictionary(int maxSize = 100000)
    {
        //TODO #2: Initialize Entries with an array of size maxSize
    }

    public string AsString()
    {
        string output = null;

        for (int i = 0; i < Entries.Length; i++)
        {
            if (Entries[i] != null)
                output += Entries[i].AsString();
        }

        return output;
    }

    public int Count()
    {
        //TODO #3: Return the number of elements (NumElements: make sure this member variable/attribute is updated when needed)
        return 0;
    }

    public int FindKey(TKey key)
    {
        //TODO #4:  Find where the key is in the array, or an empty place on the array where we can store this key
        //          First, we will use key.GetHashCode() to calculate the hash function and use to calculate the index
        //          If that position is not empty, we will look the next one until we find an empty place
        //          Notes:  a) GetHashCode() return very large integer numbers, but we need to map this value to the range [0, Entries.Length-1]
        //                  b) The key may already be in the array, so we have to check if an entry is empty AND is not equal to our key
        return -1;
    }

    public TValue Get(TKey key)
    {
        //TODO #5:  Using FindKey, find where this key is in the array, and return its value
        return default(TValue);
    }

    public void Add(TKey key, TValue value)
    {
        //TODO #5:  Using FindKey, find where this key should be stored in the array
        //          If the position returned by FindKey is empty, create a new entry there with the given key/value
        //          If it is not empty (it must be the same key), just update the value
    }

    public void Remove(TKey key)
    {
        //TODO #6: Using FindKey, find where this key is stored in the array. Remove the entry
    }
}
