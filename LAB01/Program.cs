using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static LAB01.DelegateClass;

namespace LAB01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Q1:
            Q1 q1 = new Q1();
            //Nhap vao 2 so a va b
            System.Console.WriteLine("Vui long lan luot nhap vao 2 so a va b: ");
            var input = q1.InPut2Number();
            Double a = input.Item1;
            Double b = input.Item2;
            //Nhap vao phep tinh:
            System.Console.WriteLine("Vui long nhap vao phep tinh: ");
            string ort = q1.InputOperator(); //Phep tinh
            switch (ort)
            {
                case "+":
                    System.Console.WriteLine($"Ket qua phep tinh {a} {ort} {b} = {q1.Plus(a, b)}");
                    break;
                case "-":
                    System.Console.WriteLine($"Ket qua phep tinh {a} {ort} {b} = {q1.Sub(a, b)}");
                    break;
                case "*":
                    System.Console.WriteLine($"Ket qua phep tinh {a} {ort} {b} = {q1.Mul(a, b)}");
                    break;
                case "/":
                    System.Console.WriteLine($"Ket qua phep tinh {a} {ort} {b} = {q1.Div(a, b)}");
                    break;
                default:
                    Console.WriteLine("Invalid Operator!");
                    break;
            }
            //Q2:Delegate in C#
            //Way1:
            DelegateClass deleC = new DelegateClass();
            PrintDelegate printdele = new PrintDelegate(deleC.PrintMessage);
            printdele("alo");
            //Way2:
            DelegateClass.PrintDelegate printdele2 = delegate (string msg)
            {
                Console.WriteLine("Way2 - Anonymous Method: " + msg);
            };
            printdele2("Alo - Way2!");
            // Way 3: Sử dụng biểu thức Lambda
            DelegateClass.PrintDelegate printdele3 = (msg) => Console.WriteLine("Way3 - Lambda Expression: " + msg);
            printdele3("Alo - Way3!");

        }
    }
}
