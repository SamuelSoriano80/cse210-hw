class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity helps you reflect on the good things in your life by listing as many as you can.") { }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowCountdown(5);
        
        int count = 0;
        int timeRemaining = Duration;
        
        while (timeRemaining > 0)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
            timeRemaining -= 2;
        }

        Console.WriteLine($"You listed {count} items!");
    }
}