using System;

namespace 栈
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkStack<string> stack = new LinkStack<string>();
            //stack.Push("A");
            //stack.Push("B");
            //stack.Push("C");
            //stack.Push("D");
            //Console.WriteLine(stack.Count);
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.GetLength());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.GetLength());
            //Console.WriteLine(stack.ReadAll());  //为什么子类传递给了父类，子类的方法就没有了
            //Console.WriteLine(stack.GetByID(2));

            //string formula = Console.ReadLine();
            //string formula = "9+(6.6-1.3)*3+10÷2=";
            //Calculate arithmetic = new Calculate(formula);
            //Console.WriteLine("后缀表达式：" +arithmetic.Transfrom() + "\n" );
            //Console.WriteLine("最终结果： " +arithmetic.GetResult()+"\n");
            //arithmetic.Formula = "8÷((49+5)÷27)=  ";
            //Console.WriteLine("后缀表达式：" + arithmetic.GetTrans + "\n");
            //Console.WriteLine("最终结果： " + arithmetic.GetResult() + "\n");
            //arithmetic.Formula = " (187+1)÷94-1=";
            //Console.WriteLine("后缀表达式：" +arithmetic.GetTrans + "\n");
            //Console.WriteLine("最终结果： " + arithmetic.GetResult() + "\n");
            //float a = 6;
            //a = a / 100;
            ////a = a / 10;
            //Console.WriteLine(a);
            //Console.ReadKey();

            Communication c = new Communication();
            Console.ReadKey();
        }
    }
}
