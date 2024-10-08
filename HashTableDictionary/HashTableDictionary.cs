
using Common;
using System;

public class HashTableDictionaryItem<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public HashTableDictionaryItem(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public override string ToString()
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
    //TODO #1: Copy your implementation of GenericList to the project HashTableDictionary and use it to declare Entries: an array of lists of HashTableDictionaryItem<TKey,TValue>
    //[USE GenericList and HashTableDictionaryItem HERE] [] Entries;

    public HashTableDictionary(int maxSize = 100000)
    {
        //TODO #2: Initialize Entries with an array of size maxSize
    }

    public override string ToString()
    {
        string output = null;

        //TODO #3: Uncomment this

        //for (int i = 0; i < Entries.Length; i++)
        //{
        //    if (Entries[i] != null)
        //    {
        //        for (int j = 0; j < Entries[i].Count(); j++)
        //        {
        //            HashTableDictionaryItem<TKey, TValue> entry = Entries[i].Get(j);
        //            output += entry.ToString();
        //        }
        //    }
        //}

        return output;
    }

    public int Count()
    {
        //TODO #4: Return the number of elements (NumElements: make sure this member variable/attribute is updated when the number of elements changes)
        return 0;
    }

    public int FindKey(TKey key)
    {
        //TODO #4:  Calculate in which entry should this key be stored and return it (use key.GetHashCode() to calculate the hash function of the key)
        //          Note:  GetHashCode() returns very large integer numbers, but we need to map this value to the range [0, Entries.Length-1]
        return -1;
    }

    public TValue Get(TKey key)
    {
        //TODO #5:  Using FindKey, calculate where this key should be in the array of entries. Then, find the item with this key on the list, and return its value
        return default(TValue);
    }

    public void Add(TKey key, TValue value)
    {
        //TODO #5:  Using FindKey, calculate where this key should be in the array of entries. Then, look for the item on the list.
        //          If the item is not found, add a new item to the list with the given key/value
        //          If the item is found, just update its value
    }

    public void Remove(TKey key)
    {
        //TODO #6: Using FindKey, calculate where this key should be in the array of entries. Then, look for the item on the list.
        //          If the item is not found, do nothing
        //          If the item is found, remove it from the list and return
    }
}
