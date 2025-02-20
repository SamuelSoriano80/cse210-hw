class Swimming : Activity
{
    private int _laps;
    private const double LapLengthKm = 50.0 / 1000;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthKm;
    public override double GetSpeed() => GetDistance() / _minutes * 60;
    public override double GetPace() => _minutes / GetDistance();

    public override string GetSummary()
    {
        return $"{_date:dd MMM yyyy} Swimming ({_minutes} min, {_laps} laps): Distance {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}