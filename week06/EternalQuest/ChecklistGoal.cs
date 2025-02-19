class ChecklistGoal : Goal
{
    public int TargetCount { get; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount = 0, int bonusPoints = 0)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = currentCount;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => IsComplete ? $"[X] {Name} - {Description} (Completed {CurrentCount}/{TargetCount})" : $"[ ] {Name} - {Description} (Completed {CurrentCount}/{TargetCount})";
    public override string Serialize() => $"ChecklistGoal|{Name}|{Description}|{Points}|{TargetCount}|{CurrentCount}|{BonusPoints}";
}