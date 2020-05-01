using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 3;
            LinearEquation a = new LinearEquation("5.2,6.89,5");
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("3.0, 2.0,-4.0, 3.0"));
            s.Add(new LinearEquation("2.0, 3.0, 3.0, 15.0"));
            s.Add(new LinearEquation("5.0, -3, 1.0, 14.0"));
            s.SteppingUp();
            double[] solve = s.SolveSystem();
            Console.WriteLine(s.ToString());
            for (int i=0;i<solve.Length;i++)
            {
                Console.WriteLine(@"x{0}={1}", i + 1, solve[i]);
            }
        }
    }
}
