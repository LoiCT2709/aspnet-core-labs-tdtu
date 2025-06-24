using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01
{
    public class Q1
    {
        //Viết phương thức nhập vào 2 số
        public Tuple<Double,Double> InPut2Number()
        {
            string a_text = System.Console.ReadLine();
            string b_text = System.Console.ReadLine();
            //Chuyen doi sang kieu Double
            double a = Convert.ToDouble(a_text);
            double b = Convert.ToDouble(b_text);                  
            return Tuple.Create(a, b);
        }
        public string InputOperator()
        {
            string a_text = System.Console.ReadLine();
            return a_text;
        }
        public double Plus(double a, double b)
        {
            return a + b;
        }
        public double Mul(double a, double b)
        {
            return a * b;
        }
        public double Div(double a, double b)
        {

            return a / b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }

    }
}
