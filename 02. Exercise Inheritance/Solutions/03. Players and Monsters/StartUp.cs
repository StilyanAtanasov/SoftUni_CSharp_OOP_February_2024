namespace PlayersAndMonsters;
public class StartUp
{
    public static void Main(string[] args)
    {
        // Sample Usage
        MuseElf museElf = new("museElf", 1);
        DarkWizard darkWizard = new("darkWizard", 135);
        SoulMaster soulMaster = new("soulMaster", 270);
        DarkKnight darkKnight = new("darkKnight", 89);
        BladeKnight bladeKnight = new("bladeKnight", 112);

        Hero[] players = { museElf, darkWizard, soulMaster, darkKnight, bladeKnight};

        foreach (Hero player in players) Console.WriteLine(player);
    }
}