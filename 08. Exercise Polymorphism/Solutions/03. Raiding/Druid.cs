namespace _03._Raiding;

public class Druid : BaseHero
{
    private const int DruidPower = 80;

    public Druid(string name) : base(name, DruidPower) { }

    public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
}