using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOne.Solver
{
    class Head
    {
        List<int> sequence;
        List<Solution> partialSolutions; 
        int direction = 1;
        int index = 0;

        public Head(List <int> sequence){
            this.sequence = sequence;
            this.partialSolutions = new List<Solution>();
            //add the initial sequence to the list of partial solutions
            this.partialSolutions.Add(producePartialSolution(-1));
        }

        public List<Solution> solve()
        {
            bool isFinished = false;
            while(!isFinished){
                isFinished = readOne();
            }
            return partialSolutions;
        }

        private bool readOne()
        {
            int instruction = sequence[index];
            partialSolutions.Add(generatePartialSolution(sequence, instruction));
            return instruction == 0;

        }

        private Solution generatePartialSolution(List<int> sequence, int instruction)
        {
            int indexChanged = -1;
            switch (instruction)
            {
                case 0:
                    break;
                case 1:
                    updateIndex();
                    break;
                case 2:
                    indexChanged = adjustPreviousInstruction(1);
                    updateIndex();
                    break;
                case 3:
                    indexChanged = adjustPreviousInstruction(-1);
                    updateIndex();
                    break;
                case 4:
                    direction = direction * -1;
                    updateIndex();
                    break;
                default:
                    System.Console.WriteLine("invalid instruction!");
                    break;
            }
            return producePartialSolution(indexChanged);
        }

        private void updateIndex()
        {
            index = (index + direction) % sequence.Count;
            if (index < 0)
            {
                index = sequence.Count - 1;
            }
        }

        private int adjustPreviousInstruction(int amount)
        {
            int targetIndex = (index + (-1)*direction) % sequence.Count;
            if (targetIndex < 0)
            {
                targetIndex = sequence.Count - 1;
            }
            int newVal = (sequence[targetIndex] + amount) % 5;
            if (newVal < 0)
            {
                newVal = 4;
            }
            sequence[targetIndex] = newVal;
            
            return targetIndex;
        }

        private Solution producePartialSolution(int indexChanged)
        {
            List<int> newSequence = new List<int>();
            sequence.ForEach((x)=>
                {
                    newSequence.Add(x);
                });
            return new Solution(newSequence, indexChanged);
        }


    }
}
