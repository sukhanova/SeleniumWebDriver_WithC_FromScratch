using System;
using CSharpFundamentals;
namespace CSharpFundamentals
{
    public class Program2
    {
        public Program2()
        {
            Console.WriteLine("Runnig a second program");

            Program p = new Program();
            p.getData();
        }
    }
}
