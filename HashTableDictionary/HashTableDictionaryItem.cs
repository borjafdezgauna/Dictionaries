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
