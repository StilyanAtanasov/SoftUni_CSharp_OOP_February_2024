using _03._Telephony;

string[] phoneNumbers = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
string[] websites = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

ICaller stationaryPhoneCaller = new StationaryPhone();
ICaller smartphoneCaller = new Smartphone();
IBrowser smartphoneBrowser = new Smartphone();

foreach (string phoneNumber in phoneNumbers)
{
    if (!phoneNumber.All(char.IsDigit)) Console.WriteLine("Invalid number!");
    else if (phoneNumber.Length == 7) stationaryPhoneCaller.Call(phoneNumber);
    else smartphoneCaller.Call(phoneNumber); // phoneNumber.Length == 10
}

foreach (string website in websites)
{
    if (website.Any(char.IsDigit)) Console.WriteLine("Invalid URL!");
    else smartphoneBrowser.Browse(website);
}