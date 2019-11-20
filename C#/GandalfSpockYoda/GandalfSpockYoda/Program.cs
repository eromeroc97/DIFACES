using System;
using System.Threading;

namespace GandalfSpockYoda
{
    class Program
    {
        static void Main(string[] args)
        {
            int max_time = 30;
            int time = 1;

            Player Gandalf = new Player(0);
            Player Spock = new Player(1);
            Player Yoda = new Player(2);

            do
            {
                if (time % 1 == 0) //Every second
                {
                    Task t = new Task();
                    Gandalf.addTask(t);
                    Spock.addTask(t);
                    Yoda.addTask(t);
                    Console.WriteLine("Created Task:");
                    Console.WriteLine("[Task Code]: "+t.getCode() + " [Task Type]: "+ t.getType() + " [Task Score]: "+ t.getScore());
                }

                if (time % 2 == 0) //Every 2 seconds
                {
                    Gandalf.doTask();
                    Spock.doTask();
                    Yoda.doTask();
                }


                Thread.Sleep(1000);
                time += 1;


            } while (time <= max_time);

            getWinner(Gandalf, Spock, Yoda);

            Console.ReadKey();
        }

        public static void getWinner(Player p1, Player p2, Player p3)
        {
            Console.WriteLine("###########################################");
            Console.WriteLine(p1.getPlayerName() + " -> " + p1.getTotalScore() + " points");
            Console.WriteLine(p2.getPlayerName() + " -> " + p2.getTotalScore() + " points");
            Console.WriteLine(p3.getPlayerName() + " -> " + p3.getTotalScore() + " points");
            Console.WriteLine();

            Player win = maxScore(p1, p2, p3);

            if (win is null) //There is a draw for the winner position
                win = minStackSize(p1, p2 ,p3);

            if (win is null) //There isn't winner
                Console.WriteLine("No winner this time.");
            else
                Console.WriteLine("Winner is: " + win.getPlayerName() + " With score: " + win.getTotalScore());

        }

        public static Player maxScore(Player p1, Player p2, Player p3)
        {
            Player Winner = null;
            if (p1.getTotalScore() > p2.getTotalScore() && p1.getTotalScore() > p3.getTotalScore())
                Winner = p1;
            else if (p2.getTotalScore() > p1.getTotalScore() && p2.getTotalScore() > p3.getTotalScore())
                Winner = p2;
            else if (p3.getTotalScore() > p2.getTotalScore() && p3.getTotalScore() > p1.getTotalScore())
                Winner = p3;

            return Winner;
        }

        public static Player minStackSize(Player p1, Player p2, Player p3)
        {
            Player Winner = null;
            if (p1.getStackSize() < p2.getStackSize() && p1.getStackSize() < p3.getStackSize())
                Winner = p1;
            else if (p2.getStackSize() < p1.getStackSize() && p2.getStackSize() < p3.getStackSize())
                Winner = p2;
            else if (p3.getStackSize() < p2.getStackSize() && p3.getStackSize() < p1.getStackSize())
                Winner = p3;

            return Winner;
        }




    }
}
