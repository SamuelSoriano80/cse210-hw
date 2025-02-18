public class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>();

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"{Name} Activity\n");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        
        RunActivity();
        
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"You completed {Name} for {Duration} seconds.");
        ShowSpinner(5);

        if (activityLog.ContainsKey(Name))
            activityLog[Name]++;
        else
            activityLog[Name] = 1;
        
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    protected virtual void RunActivity() { }

    protected void ShowSpinner(int seconds)
    {
        char[] spinner = { '-', '/', '|', '\\' };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write($"{spinner[i % 4]}");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public static void ShowActivityLog()
    {
        Console.WriteLine("\nActivity Usage Log:");
        foreach (var entry in activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}