using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models;

public abstract class Diver : IDiver
{
    private readonly string _name = null!;
    private int _oxygenLevel;
    private readonly List<string> _fishList;

    protected Diver(string name, int oxygenLevel)
    {
        Name = name;
        OxygenLevel = oxygenLevel;
        _fishList = new List<string>();
        CompetitionPoints = 0;
        HasHealthIssues = false;
    }

    public string Name
    {
        get => _name;
        private init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(ExceptionMessages.DiversNameNull);
            _name = value;
        }
    }

    public int OxygenLevel
    {
        get => _oxygenLevel;
        protected set
        {
            if (value < 0) _oxygenLevel = 0;
            _oxygenLevel = value;
        }
    }

    public IReadOnlyCollection<string> Catch => _fishList.AsReadOnly();

    public double CompetitionPoints { get; private set; }
    public bool HasHealthIssues { get; private set; }


    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        _fishList.Add(fish.Name);
        CompetitionPoints += fish.Points;
    }

    public abstract void Miss(int timeToCatch);

    public void UpdateHealthStatus() => HasHealthIssues = !HasHealthIssues;

    public abstract void RenewOxy();

    public override string ToString() =>
        $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
}