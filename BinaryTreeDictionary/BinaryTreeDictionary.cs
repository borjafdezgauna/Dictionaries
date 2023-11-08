
using System;



public class BinaryTreeDictionary<TKey, TValue> : Common.IDictionary<TKey, TValue> where TKey : IComparable<TKey> 
{
    //TODO #1: Add your implementation of GenericBinaryTree to the project BinaryTreeDictionary and use it to declare the tree we will use for this
    //implementation of a tree:

    //public [USE GenericBinaryTree HERE] Tree;

    public BinaryTreeDictionary()
    {
        //TODO #2: Initialize anything that needs initialization
    }

    public string AsString()
    {
        //TODO #3: Use the implementation of GenericBinaryTree
        return null;
    }

    public int Count()
    {
        //TODO #4
        return 0;
    }

    public TValue Get(TKey key)
    {
        //TODO #5
        return default(TValue);
    }

    public void Add(TKey key, TValue value)
    {
        //TODO #6
    }

    public void Remove(TKey key)
    {
        //TODO #7
    }
}
