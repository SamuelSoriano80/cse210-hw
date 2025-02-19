//  Added a basic leveling system so that points matter
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        while (true)
        {
            Console.WriteLine(manager.GetStatus());
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": manager.CreateGoal(); break;
                case "2": manager.ListGoals(); break;
                case "3": manager.SaveGoals(); break;
                case "4": manager.LoadGoals(); break;
                case "5": manager.RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }
}