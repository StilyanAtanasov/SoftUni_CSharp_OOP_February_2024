namespace _03._Raiding;

public abstract class BaseHero
{
    protected string Name;

    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public int Power { get; protected set; }

    public abstract string CastAbility();
}