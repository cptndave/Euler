using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static bool isPalindrome(string s)
        {
            for (int i = 0, j = s.Length-1; i < s.Length / 2; i++, j--)
            {
                if (s[i] != s[j])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int f1 = 0, f2 = 0;
            int p, maxp = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    p = i * j;
                    if (isPalindrome(p.ToString()) && (p > maxp))
                    {
                        f1 = i; f2 = j;
                        maxp = p;
                        // Console.WriteLine($"Found {i} x {j} = {p}");
                    }
                }
            }

            Console.WriteLine($"{f1} x {f2} = {maxp}");
        }
    }
}
