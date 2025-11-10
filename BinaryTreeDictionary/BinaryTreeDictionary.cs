
using System;



public class BinaryTreeDictionary<TKey, TValue> : Common.IDictionary<TKey, TValue> where TKey : IComparable<TKey>
{
    //TODO #1: Add your implementation of BinaryTree to the project BinaryTreeDictionary and use it to declare the tree we will use for this
    //implementation of a tree:
    //public [USE BinaryTree HERE] Tree;
    

    public BinaryTreeDictionary()
    {
        //TODO #2: Initialize anything that needs initialization
        
    }

    public override string ToString()
    {
        //TODO #3: Use the implementation of BinaryTree
        
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
        //TODO #6: Remove the item with this key.
        
    }

    public TKey[] Keys()
    {
        //TODO #7: Return an array with all the keys in the dictionary. The length of the array needs to be equal
        //to the number of elements in the dictionary
        
        return null;
        
    }

    public TValue[] Values()
    {
        //TODO #8: Return an array with all the values in the dictionary. The length of the array needs to be equal
        //to the number of elements in the dictionary
        
        return null;
        
    }
}
