abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }
    
    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(name, description, points, bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(name, description, points);
            case "ChecklistGoal":
                return new ChecklistGoal(name, description, points, int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new Exception("Unknown goal type");
        }
    }
}