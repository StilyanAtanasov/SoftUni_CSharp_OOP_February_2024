using _06._Food_Shortage;

List<IBuyer> buyerList = new();

uint buyersCount = uint.Parse(Console.ReadLine()!);
for (int i = 0; i < buyersCount; i++)
{
    string[] buyerInfo = Console.ReadLine()!.Split();
    if (buyerInfo.Length == 4) buyerList.Add(new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]));
    else buyerList.Add(new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2])); // buyerInfo.Length == 3
}

string command;
while ((command = Console.ReadLine()!) != "End")
{
    string name = command;
    IBuyer? buyer = buyerList.Find(b => b.Name == name);
    if (buyer != null) buyer.BuyFood();
}

Console.WriteLine(buyerList.Sum(b => b.Food));