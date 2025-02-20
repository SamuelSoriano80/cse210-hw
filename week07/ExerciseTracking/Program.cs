using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 19), 30, 4.8),
            new Cycling(new DateTime(2025, 02, 19), 45, 20),
            new Swimming(new DateTime(2025, 02, 19), 25, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}