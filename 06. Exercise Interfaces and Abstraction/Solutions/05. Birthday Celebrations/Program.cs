using _05._Birthday_Celebrations;

List<IBirthable> birthableList = new();

string command;
while ((command = Console.ReadLine()!) != "End")
{
    string[] birthableInfo = command.Split();
    if (birthableInfo[0] == "Citizen") birthableList.Add(new Citizen(birthableInfo[1], int.Parse(birthableInfo[2]), birthableInfo[3], birthableInfo[4]));
    else if (birthableInfo[0] == "Pet") birthableList.Add(new Pet(birthableInfo[1], birthableInfo[2]));
}

string key = Console.ReadLine()!;
birthableList.Where(b => b.Birthdate.EndsWith(key)).ToList().ForEach(b => Console.WriteLine(b.Birthdate));