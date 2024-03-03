using _03._Telephony;

string[] phoneNumbers = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
string[] websites = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

foreach (string phoneNumber in phoneNumbers)
{
    if (!phoneNumber.All(char.IsDigit)) Console.WriteLine("Invalid number!");
    else if (phoneNumber.Length == 7) new StationaryPhone().Call(phoneNumber);
    else new Smartphone().Call(phoneNumber); // phoneNumber.Length == 10
}

foreach (string website in websites)
{
    if (website.Any(char.IsDigit)) Console.WriteLine("Invalid URL!");
    else new Smartphone().Browse(website);
}