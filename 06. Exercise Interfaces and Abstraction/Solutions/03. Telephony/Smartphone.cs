namespace _03._Telephony;

public class Smartphone : ICaller, IBrowser
{
    public void Call(string number) => Console.WriteLine($"Calling... {number}");
    public void Browse(string website) => Console.WriteLine($"Browsing: {website}!");
}