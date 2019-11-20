using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfSpockYoda
{
    /// <summary>
    /// Class that define the different types of players
    /// </summary>
    class Player
    {
        private enum ePlayer { Gandalf, Spock, Yoda }
        private enum ePower { magical, logical, force}

        private int typePlayer;
        private int[] typePower = new int[2];
        private Queue<Task> queueTask;
        private Stack<Task> stackTask;
        private int totalScore;

        /// <summary>
        /// Builder of the class
        /// </summary>
        /// <param name="typePlayer">integer that defines the player type</param>
        public Player(int typePlayer)
        {
            if (typePlayer == 0)
            {
                this.typePlayer = (int)ePlayer.Gandalf;
                this.typePower[0] = (int)ePower.magical;
                this.typePower[1] = (int)ePower.force;
            }
            else if (typePlayer == 1)
            {
                this.typePlayer = (int)ePlayer.Spock;
                this.typePower[0] = (int)ePower.logical;
                this.typePower[1] = (int)ePower.magical;
            }
            else
            {
                this.typePlayer = (int)ePlayer.Yoda;
                this.typePower[0] = (int)ePower.logical;
                this.typePower[1] = (int)ePower.force;
            }

            queueTask = new Queue<Task>();
            stackTask = new Stack<Task>();
        }

        /// <summary>
        /// Function that queues a task assigned by the task's code to a player
        /// </summary>
        /// <param name="task">task to enqueue</param>
        public void addTask(Task task)
        {
            if (task.getCode() % 2 == 0 && this.typePlayer == (int) ePlayer.Spock)
                queueTask.Enqueue(task);
            if (task.getCode() % 3 == 0 && this.typePlayer == (int) ePlayer.Gandalf)
                queueTask.Enqueue(task);
            if (task.getCode() % 5 == 0 && this.typePlayer == (int) ePlayer.Yoda)
                queueTask.Enqueue(task);
        }

        /// <summary>
        /// Function that resolves the task or push it into the stack if its impossible to be complete
        /// </summary>
        public void doTask()
        {
            if (queueTask.Count > 0) { 
                Task task = queueTask.Dequeue();
                if (task.getType() == 0 && (this.typePower[0] == 0 || this.typePower[1] == 0))
                    totalScore += task.getScore();
                else if (task.getType() == 1 && (this.typePower[0] == 1 || this.typePower[1] == 1))
                    queueTask.Enqueue(task);
                else if (task.getType() == 2 && (this.typePower[0] == 2 || this.typePower[1] == 2))
                    queueTask.Enqueue(task);
                else
                    this.stackTask.Push(task);
            }
        }

        /// <summary>
        /// get the score of the player
        /// </summary>
        /// <returns>total score of the player as integer</returns>
        public int getTotalScore()
        {
            return this.totalScore;
        }

        /// <summary>
        /// get the amount of unfinished task of the player
        /// </summary>
        /// <returns>size of the stack as integer</returns>
        public int getStackSize()
        {
            return this.stackTask.Count;
        }

        /// <summary>
        /// Gives the player a name depending on the player type
        /// </summary>
        /// <returns>name as string</returns>
        public String getPlayerName()
        {
            String name = null;
            if (this.typePlayer == (int)ePlayer.Gandalf)
                name = "Gandalf";
            else if (this.typePlayer == (int)ePlayer.Spock)
                name = "Spock";
            else if (this.typePlayer == (int)ePlayer.Yoda)
                name = "Yoda";

            return name;
        }
    }
}
