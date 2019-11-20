using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Neo : Character
    {
        private bool isChoosen;
        public Neo() : base() 
        {
            this.isChoosen = false;
        }

        public void isChoosenOne(Character[,] MATRIX, Queue<Character> listofCharacters)
        {
            int isTheChoosenOne = random.Next(2);
            this.isChoosen = isTheChoosenOne == 1;

            if(isChoosen)
            {
                //Check adjacent positions and re-generate characters
                List<int[]> adjacentsPositions = getAdjacents(MATRIX, this.getLatitude(), this.getLongitude());
                for(int pos = 0; pos < adjacentsPositions.Count(); pos++)
                {
                    int[] position = adjacentsPositions.ElementAt(pos);
                    if(MATRIX[position[0],position[1]] == null && listofCharacters.Count() > 0) //Checking if this cell is null
                    {
                        listofCharacters.Dequeue().generate(MATRIX);
                    }
                }
            }

            this.move(MATRIX);

        }

        private List<int[]> getAdjacents(object[,] M, int x, int y)
        {
            List<int[]> adjacents = new List<int[]>();

            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if(x+i < 0 || y+j < 0 || x+i >= M.GetLength(0) || y+j >= M.GetLength(0) || (i == 0 && j == 0)) 
                    {/*Out of bounds or origin position */}
                    else { adjacents.Add(new int[] { x + i, y + j }); }
                }
            }

            return adjacents;
        }

        private void move(Character[,] Matrix)
        {
            int x = random.Next(Matrix.GetLength(0));
            int y = random.Next(Matrix.GetLength(0));
            
            if(Matrix[x,y] != null) //If there is another character in the cell
            {
                Character toChange = Matrix[x,y];
                toChange.setLatitude(this.getLatitude());
                toChange.setLongitude(this.getLongitude());
                Matrix[this.getLatitude(),this.getLongitude()] = toChange;
            }
            else
            {
                Matrix[this.getLatitude(), this.getLongitude()] = null;
            }

            //Moving neo
            Matrix[x,y] = this;
            this.setLatitude(x);
            this.setLongitude(y);
        }


        new public void print()
        {
            if (isChoosen)
            {
                Console.WriteLine("Neo: I don't like the idea of not being me who control my own life!");
            }
            else
            {
                Console.WriteLine("Neo: The problem is the election.");
            }
        }

    }
}
