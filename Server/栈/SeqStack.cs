using System;
using System.Collections.Generic;
using System.Text;

namespace 栈
{
    class SeqStack<T> : IstackDS<T>
    {
        private T[] data;
        private int top = -1;

        public SeqStack()
        {
            data = new T[10];
        }

        public SeqStack(int size)
        {
            data = new T[size];
        }

        public int Count
        {
            get
            { 
                return top+1;
            }
        }

        public int GetLength()
        {
            return top + 1;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            top = -1;
        }

        public void Push(T item)
        {
            data[top + 1] = item;
            top++;
        }

        public T Pop()
        {
            T temp = data[top];
            top--;
            return temp;
        }

        public T Peek()
        {
            T temp = data[top];
            return temp;
        }
    }
}
