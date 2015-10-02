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
            int value = sequence[index];
            partialSolutions.Add(generatePartialSolution(sequence, value));
            return value == 0;

        }

        private Solution generatePartialSolution(List<int> sequence, int value)
        {
            int indexChanged = -1;
            switch (value)
            {
                case 0:
                    break;
                case 1:
                    updateIndex();
                    break;
                case 2:
                    indexChanged = adjustPrevious(1);
                    updateIndex();
                    break;
                case 3:
                    indexChanged = adjustPrevious(-1);
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
            return producePartial(indexChanged);
        }

        private void updateIndex()
        {
            index = (index + direction) % sequence.Count;
            if (index < 0)
            {
                index = sequence.Count - 1;
            }
        }

        private int adjustPrevious(int amount)
        {
            int targetIndex = index + (-1)*direction;
            int newVal = sequence[targetIndex] + amount % 5;
            if (newVal < 0)
            {
                newVal = 4;
            }
            sequence[targetIndex] = newVal;
            
            return targetIndex;
        }

        private Solution producePartial(int indexChanged)
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
