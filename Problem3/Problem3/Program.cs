using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            double value = 600851475143;
            int limit = (int) Math.Sqrt(value);
            int maxFactor = 0;

            Console.WriteLine($"sqrt({value}) = {maxFactor}");

            for (int f = 2; f <= limit; )
            {
                double d = value / f;
                if (d == Math.Floor(d))
                {
                    value = d;
                    maxFactor = f;
                    Console.WriteLine("Factor = " + f);
                }
                else
                {
                    f++;
                }
            }

            Console.WriteLine("Max Factor = " + maxFactor);
            Console.WriteLine("Done");
        }
    }
}
