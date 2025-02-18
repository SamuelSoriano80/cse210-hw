class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity helps you relax by guiding you through deep breathing.") { }

    protected override void RunActivity()
    {
        int timeRemaining = Duration;
        while (timeRemaining > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(5);
            timeRemaining -= 5;
            Console.WriteLine("Breathe out...");
            ShowCountdown(5);
            timeRemaining -= 5;
        }
    }
}