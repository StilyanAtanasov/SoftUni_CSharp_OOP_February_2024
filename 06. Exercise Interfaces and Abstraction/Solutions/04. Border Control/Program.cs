using _04._Border_Control;

List<IIdentifiable> identifiableList = new();

string command;
while ((command = Console.ReadLine()!) != "End")
{
    string[] identifiableInfo = command.Split();
    if (identifiableInfo.Length == 2) identifiableList.Add(new Robot(identifiableInfo[0], identifiableInfo[1]));
    else identifiableList.Add(new Citizen(identifiableInfo[0], int.Parse(identifiableInfo[1]), identifiableInfo[2]));
}

string key = Console.ReadLine()!;
identifiableList.Where(i => i.Id.EndsWith(key)).ToList().ForEach(i => Console.WriteLine(i.Id));