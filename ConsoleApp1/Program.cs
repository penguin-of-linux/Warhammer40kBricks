using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new IntVector2(1, 1);
            var b = new IntVector2(1, 1);

            var set = new HashSet<IntVector2>();
            set.Add(a);

            Console.WriteLine(set.Contains(b));
        }
    }
}
