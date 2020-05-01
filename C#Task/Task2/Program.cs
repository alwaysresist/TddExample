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
            SysOfLinearEquation s = new SysOfLinearEquation(n);

            s.Add(new LinearEquation("5, 4, 1, -2"));
            s.Add(new LinearEquation("3, 3, 3, 12"));
            s.Add(new LinearEquation("1, 5, 1, 1"));
            s.StepUp();

            double[] solve = s.Solve();
            Console.WriteLine(s.ToString());
            Console.WriteLine("Ответ:\n");
            for (int i=0;i<solve.Length;i++)
            {
                Console.WriteLine(@"x{0}={1}", i + 1, solve[i]);
            }
        }
    }
}
