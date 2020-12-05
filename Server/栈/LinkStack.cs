using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 栈
{
    class LinkStack<T>:IstackDS<T>
    {
        private Node<T> top;
        private int count = 0;
        /// <summary>
        /// 将栈中的所有元素输出，并清除
        /// </summary>
        /// <returns></returns>
        public string ReadAll()
        {
            string temp = null;
            while (top!= null)
            {
                temp += top.Data + " ";
                top = top.Next;
            }
            Clear();
            return temp.Trim();
        }
        /// <summary>
        /// 逆序输出第i个元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetByID(int i)
        {
            int k = 1;
            Node<T> temp = top;  //这里出现NULL的原因是忘记了对K进行自增导致的死循环
            while (k < i)
            {
                temp = temp.Next;
                k++;
            }
            return temp.Data.ToString();
        }
        /// <summary>
        /// 取得栈中元素个数
        /// </summary>
        public int Count
        {
            get { return count; }
        }
        /// <summary>
        /// 取得栈中元素个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
        }
        /// <summary>
        /// 判断栈中是否有数据
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }
        /// <summary>
        /// 清空栈中数据
        /// </summary>
        public void Clear()
        {
            count = 0;
            top = null; //important
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
       Node<T> a = new Node<T>(item);
       a.Next = top;
       top = a;
       count++;
        }
/// <summary>
/// 取得栈顶元素然后删除
/// </summary>
/// <returns></returns>
public T Pop()
{
    T data = top.Data;
    top = top.Next;
    count--;
    return data;
}
/// <summary>
/// 取得栈顶的数据，不删除栈顶
/// </summary>
/// <returns></returns>
        public T Peek()
        {
            T data = top.Data;
            return data;
        }
    }
}
