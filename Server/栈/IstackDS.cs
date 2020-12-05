using System;
using System.Collections.Generic;
using System.Text;

namespace 栈
{
    interface IstackDS<T>
    {
        int Count { get; }
        int GetLength();
        bool IsEmpty();
        void Clear();
        void Push(T item);
        T Pop();
        T Peek();
    }
}
