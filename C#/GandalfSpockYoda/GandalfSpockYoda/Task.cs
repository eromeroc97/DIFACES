using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfSpockYoda
{
    /// <summary>
    /// Class that defines the different types of tasks that players will complete
    /// </summary>
    class Task
    {
        private int type;
        private int code;
        private int score;

        /// <summary>
        /// Builder of the class, creates random values
        /// </summary>
        public Task()
        {
            Random randomNum = new Random();
            this.type = randomNum.Next(3);
            this.code = randomNum.Next(1, 101);
            this.score = randomNum.Next(1, 5);
        }

        /// <summary>
        /// This function returns the value of the task's type
        /// </summary>
        /// <returns>task's type as integer</returns>
        public int getType()
        {
            return this.type;
        }

        /// <summary>
        /// This function returns the value of the task's code
        /// </summary>
        /// <returns>task's code as integer</returns>
        public int getCode()
        {
            return this.code;
        }

        /// <summary>
        /// This function get the value of the task's score
        /// </summary>
        /// <returns>Task's score as integer</returns>
        public int getScore()
        {
            return this.score;
        }
    }
}
