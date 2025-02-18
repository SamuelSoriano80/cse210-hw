//  Added the possibility to display how many times each activity has been used in the current session.

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit\n");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            
            Activity activity = null;
            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": Activity.ShowActivityLog(); continue;
                case "5": return;
                default: Console.WriteLine("Invalid choice. Try again."); Thread.Sleep(2000); continue;
            }
            
            activity.Start();
        }
    }
}