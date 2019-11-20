using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Character : IfaceCharacter
    {
        enum eCities { New_York, Boston, Baltimore, Atlanta, Detroit, Dallas, Denver }
        enum eNames { Michelle, Alexander, James, Caroline, Claire, Jessica, Erik, Mike }

        protected Random random = new Random();

        private int cName;
        private int cCity;
        private int cDeathProbability;
        private int cAge;

        protected int cLatitude;
        protected int cLongitude;

        public Character()
        {
            Array vNames = Enum.GetValues(typeof(eNames));
            Array vCities = Enum.GetValues(typeof(eCities));
            this.cName = (int) vNames.GetValue(random.Next(vNames.Length));
            this.cCity = (int) vCities.GetValue(random.Next(vCities.Length));
            this.cDeathProbability = random.Next(101);
            this.cAge = random.Next(16, 81);
        }

        public void generate(Character[,] world)
        {
            //we check every free position in the world
            List<int[]> freePositions = new List<int[]>();
            int i = 0, j = 0;
            while (i < world.GetLength(0))
            {
                if (world[i,j] == null)
                    freePositions.Add(new int[] { i, j });
                if (j == world.GetLength(0) - 1)
                {
                    i++;
                    j = 0;
                }
                else
                    j++;
            }

            if(freePositions.Count != 0)
            {
                //We get a random free position
                int[] position = freePositions.ElementAt(random.Next(freePositions.Count));

                this.cLatitude = position[0];
                this.cLongitude = position[1];

                world[cLatitude,cLongitude] = this;
            }

        }

        public bool isDead()
        {
            bool kill = false;
            if (cDeathProbability > 70)
                kill = true;
            else
                cDeathProbability += 10;

            return kill;
        }

        public void print() { }

        public void prompt() { }

        public int getDeathProbability() { return this.cDeathProbability; }
        public int getLatitude() { return this.cLatitude; }
        public int getLongitude() { return this.cLongitude; }

        public void setLatitude(int value) { this.cLatitude = value; }
        public void setLongitude(int value) { this.cLongitude = value; }

    }
}
