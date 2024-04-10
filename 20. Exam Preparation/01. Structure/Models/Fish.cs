using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models;

public abstract class Fish : IFish
{
    private readonly string _name = null!;
    private readonly double _points;

    protected Fish(string name, double points, int timeToCatch)
    {
        Name = name;
        Points = points;
        TimeToCatch = timeToCatch;
    }

    public string Name
    {
        get => _name;
        private init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.FishNameNull);
            _name = value;
        }
    }

    public double Points
    {
        get => _points;
        private init
        {
            if (value < 1 || value > 10) throw new ArgumentException(ExceptionMessages.PointsNotInRange);
            _points = value;
        }
    }

    public int TimeToCatch { get; }

    public override string ToString() => $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
}