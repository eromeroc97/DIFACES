using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Smith : Character
    {
        private int maxInfect;
        private int infected;

        public Smith() : base()
        {
            this.maxInfect = 4;
            this.infected = 0;
        }

        public int getInfect(){ return random.Next(1, maxInfect+1); }

        public void infect(Character[,] MATRIX, Neo neo)
        {
            //We get all infectable characters
            List<Character> toInfect = new List<Character>();
            int i = 0, j = 0;
            while (i < MATRIX.GetLength(0))
            {
                if (MATRIX[i,j] != null && MATRIX[i,j] != neo && MATRIX[i,j] != this) //neo and smith are not infectable
                    toInfect.Add(MATRIX[i,j]);

                if (j == MATRIX.GetLength(0) - 1)
                {
                    i++;
                    j = 0;
                }
                else
                    j++;
            }

            //Now we sort the list ascending
            List<Character> infectedSortedList = toInfect.OrderByDescending(o => o.getDeathProbability()).ToList();

            //We infect a random number of characters
            this.infected = getInfect();
            for (int index = 0; index < infected && index < infectedSortedList.Count() && infectedSortedList.Count() > 0; index++)
            {
                Character infected = infectedSortedList.ElementAt(index);
                MATRIX[infected.getLatitude(),infected.getLongitude()] = null; //Kill = null
            }
        }

        new public void print()
        {
            if(infected > maxInfect/2)
                Console.WriteLine("Smith: Do you hear that mr. Anderson? It's the sound of the inevitable! (" + this.infected + " infections)");
            else
                Console.WriteLine("Smith: Mr. Anderson, did you received my package? (" + this.infected+ " infections)");
        }

    }
}
