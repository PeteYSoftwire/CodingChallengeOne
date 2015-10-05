using CodingChallengeOne.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOne.View
{
    class Printer
    {
        List<Solution> solutions;

        public Printer(List<Solution> solutions)
        {
            this.solutions = solutions;
        }

        public void print()
        {
            int i = 0;
            solutions.ForEach((item)=>
                {
                    System.Console.Write(i++ + " - ");
                    printPartialSolution(item);
                });
            System.Console.WriteLine(solutions.Count);
        }

        private void printPartialSolution(Solution item)
        {
            int lastValueChangedIndex = item.getLastValueChangedIndex();
            List<int> values = item.getValues();
            String output = "";
            for (int i = 0; i < values.Count; i++)
            {

                if (i == lastValueChangedIndex)
                {
                    output = output + "*" + values[i].ToString() + "*";
                }
                else
                {
                    output = output + values[i].ToString();
                }

            }
            System.Console.WriteLine(output);
        }
    }
}
