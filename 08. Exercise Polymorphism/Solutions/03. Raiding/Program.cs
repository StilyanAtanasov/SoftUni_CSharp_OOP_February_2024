using _03._Raiding;

List<BaseHero> heroes = new();
int heroesCount = int.Parse(Console.ReadLine()!);
for (int i = 0; i < heroesCount; i++)
{
    string heroName = Console.ReadLine()!;
    string heroType = Console.ReadLine()!;
    if (heroType == "Paladin") heroes.Add(new Paladin(heroName));
    else if (heroType == "Warrior") heroes.Add(new Warrior(heroName));
    else if (heroType == "Druid") heroes.Add(new Druid(heroName));
    else if (heroType == "Rogue") heroes.Add(new Rogue(heroName));
    else
    {
        Console.WriteLine("Invalid hero!");
        i--;
    }
}

int bossPower = int.Parse(Console.ReadLine()!);

foreach (BaseHero baseHero in heroes) Console.WriteLine(baseHero.CastAbility());
Console.WriteLine(bossPower <= heroes.Sum(h => h.Power) ? "Victory!" : "Defeat...");