using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace 栈
{
    class Calculate
    {
        private string infix = null;
        private string suffix = null;
        LinkStack<String> buffer = new LinkStack<string>();

        public Calculate(string i)
        {
            infix = i.Trim();
        }

        public Calculate()
        {
            infix = "";
        }

        public string Formula
        {
            get {return infix; }
            set
            {
                suffix = null;infix = value.Trim(); }
        }

        public string GetTrans
        {
            get
            {
                suffix = null;return Transfrom(); }
        }
        /// <summary>
        /// 将中缀表达式转后缀表达式
        /// </summary>
        /// <returns></returns>
        public string Transfrom()  //测试数据  167÷(10+6+151)= 
        {
            if (suffix != null)
            {
                Console.WriteLine("已经运行过中缀转后缀");
            }
            string a = "";
            Console.WriteLine("要转化的数据是 " + infix );
            infix += " ";
            for (int i = 0; i < infix.Length; i++) //循环遍历所有字节
            {
                if (infix[i] == '.')
                {
                    a += ".";
                    continue;
                }
                    //  if(Regex.IsMatch(Convert.ToString(infix[i]),@"\d"))
                if (char.IsDigit(infix[i]))
                {
                    a = a + infix[i];
                    //if (point == false)
                    //{
                    //   // a = Convert.ToInt32(infix[i].ToString()) + a * 10;

                    //}
                    //else
                    //{
                    //    float c = Convert.ToInt32(infix[i].ToString());
                    //    for (int j = b; j < i; j++)
                    //    {
                    //        c = c / 10;
                    //    }

                    //    c = (float)Math.Round(c, i - b);
                    //    a += c;
                    //}   
                    //   Console.WriteLine(i +"是数字 " + infix[i].ToString());  如果不加ToString，默认转换为数字？
                }
                else
                {
                    if (a!="")
                    {
                        //if (infix[i] != '=')
                        //{
                        //    suffix += infix[i] + " ";
                        //}
                        suffix += a + " ";

                        //Console.WriteLine("给后缀添加数值：" + a);

                        //suffix += infix[i] + " ";
                        AddSign(infix[i].ToString());
                        a = "";
                    }
                    else AddSign(infix[i].ToString());
                }
            }

            //输出栈中剩下的全部
            //Console.WriteLine(buffer.ReadAll());
            suffix = suffix + buffer.ReadAll();

            //buffer = new LinkStack<string>();
            if (buffer.Count < 2)
            {
                Console.WriteLine("数据不正常，已切换成默认数据1+1=");
                suffix = "1 1 +";
            }
            return suffix;
        }

        /// <summary>
        /// 计算结果 
        /// </summary>
        /// <returns></returns>
        public float GetResult()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            float result = 0;
            string a = "";
            float top,topnext;
            LinkStack<float> numbers = new LinkStack<float>();
            foreach (char c in suffix)
            {
                if (char.IsDigit(c)||c == '.')
                {
                    a += c;
                }
                else if (c == ' '&& a != "")
                {
                    numbers.Push(float.Parse(a));
                    Console.WriteLine("传入了数" + a);
                    a = "";
                }
                if (c == '+')
                {
                    top = numbers.Pop();
                    topnext = numbers.Pop();
                    float temp = topnext + top;
                    Console.WriteLine("加法运算结果 " + temp);
                    numbers.Push(temp);
                }
                else if (c == '-')
                {
                    top = numbers.Pop();
                    topnext = numbers.Pop();
                    float temp = topnext - top;
                    Console.WriteLine("减法运算结果 " + temp);
                    numbers.Push(temp);
                }
                else if (c == '*')
                {
                    top = numbers.Pop();
                    topnext = numbers.Pop();
                    float temp = topnext * top;
                    Console.WriteLine("乘法运算结果 " + temp);
                    numbers.Push(temp);
                }
                else if (c == '/')
                {
                    top = numbers.Pop();
                    topnext = numbers.Pop();
                    float temp = topnext / top;
                    Console.WriteLine("除法运算结果 " + temp);
                    numbers.Push(temp);
                }
            }
            result = numbers.Pop();
            numbers.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            return (float)Math.Round(result,4);
        }

        /// <summary>
        /// 数学符号判断与检测
        /// </summary>
        /// <param name="item"></param>
        private void AddSign(String item)
        {
            item = item == "÷" ? "/" : item; //统一规定为 /  符号
            string top = item;
           string topnext = string.Empty;
           if (buffer.IsEmpty())
           {
               buffer.Push(item);
               return;
           }
           else
           { 
               topnext = buffer.GetByID(1);
            }
           if (top == "=")
           { return;}
           if (top == ")")
           {
               Console.WriteLine("触发事件！遇到 ) 符号");   // 测试数据   (111+222+333)+12345
               string sign = buffer.Pop();
               while (sign != "(")
               {
                   suffix += sign +" ";
                   sign = buffer.Pop();
               }
               return;
           }
           if (Regex.IsMatch(top,@"[+-]") && Regex.IsMatch(topnext, @"[/*]"))
           {
               Console.WriteLine("触发事件！top " + top + "  topnext " + topnext);
               while (!buffer.IsEmpty())
               {
                    string sign = buffer.Pop();
                    suffix += sign +" ";
               }
               buffer.Push(item);
           }
           else
           {
               buffer.Push(item);
            }
        }
    }
}
