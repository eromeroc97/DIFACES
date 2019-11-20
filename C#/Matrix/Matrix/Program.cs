
using System;
using System.Collections.Generic;
using System.Threading;

namespace Matrix
{
    class Program
    {
        public static int MAX_CHARACTERS = 200;
        public static int WORLD_SIZE = 5;
        public static int SIMULATION_TIME = 20;
        public static Queue<Character> qCharacters;
        public static Character[,] MATRIX_WORLD;
        static void Main(string[] args)
        {
            //Generate random characters
            qCharacters = new Queue<Character>();
            for (int i = 0; i < MAX_CHARACTERS; i++)
                qCharacters.Enqueue(new Character());
            
            //Building the Real World
            MATRIX_WORLD = new Character[WORLD_SIZE, WORLD_SIZE];

            Neo neo = new Neo();
            Smith smith = new Smith();

            //We put neo and smith randomly on the matrix
            neo.generate(MATRIX_WORLD);
            smith.generate(MATRIX_WORLD);

            printMatrix(neo, smith);

            //Then we fill the matrix with the rest characters
            for(int i = 0; i < (WORLD_SIZE*WORLD_SIZE)-2; i++) 
            {
                qCharacters.Dequeue().generate(MATRIX_WORLD);
            }
            Console.WriteLine();
            printMatrix(neo, smith);

            int time = 0;
            bool endSimulation = false;
            do
            {
                if (time % 1 == 0) //Every 1 second
                {
                    checkCharacters(neo, smith);
                    
                    endSimulation = isGameOver();
                    printMatrix(neo, smith);
                }

                if (time % 2 == 0) //Every 2 seconds
                {
                    smith.infect(MATRIX_WORLD, neo);
                    

                    endSimulation = isGameOver();
                    smith.print();
                    printMatrix(neo, smith);
                }

                if (time % 5 == 0) //Every 5 seconds
                {
                    neo.isChoosenOne(MATRIX_WORLD, qCharacters);

                    endSimulation = isGameOver();
                    neo.print();
                    printMatrix(neo, smith);
                    
                }


                Thread.Sleep(1000);
                time += 1;


            } while (time <= SIMULATION_TIME && !endSimulation);

            if (endSimulation)
                Console.WriteLine("Smith is the winner");
            else
                Console.WriteLine("Neo is the winner");

            Console.ReadKey();
        }

        public static bool isGameOver()
        {
            int i = 0, j = 0, counter = 0;
            while (i < MATRIX_WORLD.GetLength(0))
            {
                if (MATRIX_WORLD[i,j] is null)
                    counter++;
                if (j == MATRIX_WORLD.GetLength(0) - 1)
                {
                    i++;
                    j = 0;
                }
                else
                    j++;
            }

            return counter == (WORLD_SIZE * WORLD_SIZE) - 2;
        }

        public static void checkCharacters(Neo neo, Smith smith)
        {
            int i = 0, j = 0, deadCounter = 0, replaced = 0;
            while (i < MATRIX_WORLD.GetLength(0))
            {
                if (MATRIX_WORLD[i, j] != null && MATRIX_WORLD[i, j] != neo && MATRIX_WORLD[i, j] != smith) //if there is a character
                {
                    if (MATRIX_WORLD[i, j].isDead()) //check if charater has to die
                    { 
                        MATRIX_WORLD[i, j] = null;
                        deadCounter++;
                        if (qCharacters.Count > 0) //if character probability is over 70 and dies
                        {
                            qCharacters.Dequeue().generate(MATRIX_WORLD); //character must be substituted
                            replaced++;
                        }
                    }
                }
                
                
                if (j == MATRIX_WORLD.GetLength(0) - 1)
                {
                    i++;
                    j = 0;
                }
                else
                    j++;
            }
            Console.WriteLine("Natural Deaths: " + deadCounter);
            Console.WriteLine("Replaced: " + replaced);
        }

        public static void printMatrix(Neo neo, Smith smith)
        {
            int i = 0, j = 0;
            while (i < MATRIX_WORLD.GetLength(0))
            {
                if (MATRIX_WORLD[i,j] != null) //if there is a character
                {
                    if (MATRIX_WORLD[i,j] == neo)
                    {
                        Console.Write("N ");
                    }
                    else if (MATRIX_WORLD[i,j] == smith)
                    {
                        Console.Write("S ");
                    }
                    else
                    {
                        Console.Write("C ");
                    }
                }
                else //if character is null
                    Console.Write("- ");

                if (j == MATRIX_WORLD.GetLength(0) - 1)
                {
                    i++;
                    j = 0;
                    Console.WriteLine();
                }
                else
                    j++;
            }
            Console.WriteLine();
        }
    }
}
