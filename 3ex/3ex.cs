using System;
using System.Collections.Generic;

namespace Exercises
{


    class Program
    {
        static void FindWord(ref string v, ref string temp)
        {
            string b = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == ' ')
                {
                    v = v.Remove(i, 1);
                    break;
                }
                else
                {
                    b += v[i];
                    v = v.Remove(i, 1);
                    i--;
                }
            }
            temp += b;
        }

        delegate int BinaryOperator(int i1, int i2);

        class Calculator
        {
            event BinaryOperator oper = null;
            static private char strategy;


            static public void ChangeStrategy(char smth)
            {
                strategy = smth;
            }


            public static int PerformCalculation(int firstOperand, int secondOperand)
            {
                if (strategy == '+')
                {
                    return firstOperand + secondOperand;
                }
                else if (strategy == '-')
                {
                    return firstOperand - secondOperand;
                }
                else if (strategy == '*')
                {
                    return firstOperand * secondOperand;
                }
                else if (strategy == '/')
                {
                    return firstOperand / secondOperand;
                }
                return 0;
            }

            public void start()
            {
                oper += PerformCalculation;

                while (true)
                {
                    string all = Console.ReadLine();
                    if(all==" " || all == "")
                    {
                        break;
                    }
                    else
                    {
                        string temp = "";
                        FindWord(ref all, ref temp);
                        if (temp == "mode")
                        {
                            char ch = all[all.Length - 1];
                            ChangeStrategy(ch);
                        }
                        else
                        {
                            int i1, i2;
                            i1 = int.Parse(temp);
                            i2=int.Parse(all);
                            Console.WriteLine(oper(i1, i2));
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Calculator a = new Calculator();
            a.start();
        }
    }
}
