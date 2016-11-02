using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {            
            int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int part = values.Length / 4;
            int[] row1 = values.Take(part).Reverse().Concat(values.Reverse().Take(part)).ToArray();
            int[] row2 = values.Skip(part).Take(2 * part).ToArray();
            int[] sum = row1.Select((x, index) => x + row2[index]).ToArray();
            Console.WriteLine("{0} +\n{1} =\n{2}", string.Join(" ", row1), string.Join(" ", row2), string.Join(" ", sum));
        }
    }
}
