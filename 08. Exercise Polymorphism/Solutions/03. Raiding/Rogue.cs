namespace _03._Raiding;

public class Rogue : BaseHero
{
    private const int RoguePower = 80;

    public Rogue(string name) : base(name, RoguePower) { }

    public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";
}