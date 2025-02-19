class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private string _title = "Novice";

    public void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Select goal type: \n1.Simple \n2.Eternal \n3.Checklist\n");
        string type = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": _goals.Add(new SimpleGoal(name, description, points)); break;
            case "2": _goals.Add(new EternalGoal(name, description, points)); break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, targetCount, 0, bonus));
                break;
            default: Console.WriteLine("Invalid type."); break;
        }
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        File.WriteAllLines(filename, _goals.ConvertAll(g => g.Serialize()).Append($"Score|{_score}"));
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            var lines = File.ReadAllLines(filename).ToList();
            _goals = lines.Where(line => !line.StartsWith("Score|"))
            .Select(line => Goal.Deserialize(line)).ToList();
            _score = int.Parse(lines.FirstOrDefault(line => line.StartsWith("Score|"))?.Split('|')[1] ?? "0");
            UpdateLevel();
            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            _score += _goals[index].RecordEvent();
            UpdateLevel();
            Console.WriteLine("Event recorded!");
        }
    }

    private void UpdateLevel()
    {
        _level = _score / 1000 + 1;
        _title = _level switch
        {
            1 => "Novice Procrastinator",
            2 => "Outstanding Planner",
            3 => "Master Goal Completionist",
            _ => "Ultimate Task Achiever"
        };
    }

    public string GetStatus() => $"You have {_score} points. Level {_level} {_title}.";
}