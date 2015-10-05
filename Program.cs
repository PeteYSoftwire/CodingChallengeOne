using CodingChallengeOne.Solver;
using CodingChallengeOne.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(1);
            Head head = new Head(sequence);
            Printer printer = new Printer(head.solve());
            printer.print();
        }
    }
}
