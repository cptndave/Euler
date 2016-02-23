using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// Project Euler problem 18 and problem 67 solution
// by Dave Brennan (davebrennan at gmail.com)
namespace Problem18
{
    public class Base
    {
        public Node next;
    }

    public class Node : Base
    {
        public Node(int _) { value = _; }
        public int value;
        public int max;
        public Node left;
        public Node right;
        public Node path;
    }

    public class Level : Base
    {
        public Level(Level last)
        {
            up = last;
            if (last != null)
            {
                last.down = this;
            }
        }
        public Level up, down;
    }

    class Program
    {
        static void Dump(Level top)
        {
            for (Level l = top; l != null; l = l.down)
            {
                for (Node n = l.next; n != null; n = n.next)
                {
                    Console.Write(n.value);
                    Console.Write(' ');
                }
                Console.Write('\n');
            }
        }

        static void PrintPath(Level top)
        {
            Console.WriteLine($"Max = {top.next.max}");
            for (Node n = top.next; n != null; n = n.path)
            {
                Console.Write(n.value);
                if (n.path != null)
                {
                    Console.Write(" + ");
                }
            }
            Console.Write('\n');
        }

        // Compute max path from bottom up
        static void Compute(Level level)
        {
            for (Level l = level; l != null; l = l.up)
            {
                int leftMax, rightMax;
                for (Node n = l.next; n != null; n = n.next)
                {
                    leftMax = n.left?.max ?? 0;
                    rightMax = n.right?.max ?? 0;
                    if (leftMax >= rightMax)
                    {
                        n.max = n.value + leftMax;
                        n.path = n.left;
                    }
                    else
                    {
                        n.max = n.value + rightMax;
                        n.path = n.right;
                    }
                }
            }
        }
  
        static void Main(string[] args)
        {
            Level topLevel = null;
            Level prevLevel = null;
            Level currentLevel = null;
            Node leftParent, rightParent;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                prevLevel = currentLevel;
                leftParent = prevLevel?.next;
                rightParent = null;
                currentLevel = new Level(prevLevel);
                if (topLevel == null)
                {
                    topLevel = currentLevel;
                }
                Base prevNode = currentLevel;
                string[] values = line.Split(' ');
                foreach (string value in values)
                {
                    int ivalue = int.Parse(value);
                    Node node = new Node(ivalue);
                    prevNode.next = node;
                    if (rightParent != null)
                    {
                        rightParent.right = node;
                        rightParent = rightParent.next;
                    }
                    if (leftParent != null)
                    {
                        leftParent.left = node;
                        if (rightParent == null)
                        {
                            rightParent = leftParent;
                        }
                        leftParent = leftParent.next;
                    }
                    prevNode = node;
                }
            }

            // Dump(topLevel);
            Compute(currentLevel);
            Stopwatch timer = Stopwatch.StartNew();
            Compute(currentLevel);
            timer.Stop();
            PrintPath(topLevel);
            double ms = (double) timer.ElapsedTicks / (double) Stopwatch.Frequency * 1000.0;
            Console.WriteLine($"Done in {ms:0.0000} ms!");
        }
    }
}
