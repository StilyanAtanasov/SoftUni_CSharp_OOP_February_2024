namespace NauticalCatchChallenge.Models;

internal class ScubaDiver : Diver
{
    private const int MaxOxygenLevel = 540;

    public ScubaDiver(string name) : base(name, MaxOxygenLevel) { }

    public override void Miss(int timeToCatch) =>
        OxygenLevel -= (int)Math.Round(timeToCatch * 0.3, MidpointRounding.AwayFromZero);

    public override void RenewOxy() => OxygenLevel = MaxOxygenLevel;
}