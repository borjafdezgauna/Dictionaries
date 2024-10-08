using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IDictionary<TKey,TValue>
    {
        int Count();
        TValue Get(TKey key);
        void Add(TKey key, TValue value);
        void Remove(TKey key);
    }
}
