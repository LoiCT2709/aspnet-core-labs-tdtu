using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01
{
    public class DelegateClass
    {
        public delegate void PrintDelegate(string msg);
        //BASIC delegate
        public void PrintMessage(string msg)
        {
            Console.WriteLine("Way1 - Basic Delegate: "+ msg);
        }


    }
}
