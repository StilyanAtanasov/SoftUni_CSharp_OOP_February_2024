Dictionary<int, double> accounts = new();

// Read the bank accounts
string[] accountsInput = Console.ReadLine()!.Split(',');
foreach (string account in accountsInput)
{
    double[] accountData = account.Split('-').Select(double.Parse).ToArray();
    int accountId = Convert.ToInt32(accountData[0]);
    double balance = accountData[1];
    accounts.Add(accountId, balance);
}

string command;
while ((command = Console.ReadLine()!) != "End")
{
    string[] operationData = command.Split();
    string operationKeyword = operationData[0];
    int accountNumber = int.Parse(operationData[1]);
    double sum = double.Parse(operationData[2]);

    try
    {
        switch (operationKeyword)
        {
            case "Deposit":
                accounts[accountNumber] += sum;
                break;
            case "Withdraw":
                if (accounts[accountNumber] - sum < 0) throw new ArgumentException("Insufficient balance!");
                accounts[accountNumber] -= sum;
                break;
            default: throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Invalid account!");
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}