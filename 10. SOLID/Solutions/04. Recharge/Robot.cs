namespace _04._Recharge;

public class Robot : Worker, IRechargeable
{
    private readonly int _capacity;
    private int _currentPower = 10;

    public Robot(string id, int capacity) : base(id) => _capacity = capacity;

    public int Capacity => _capacity;

    public override void Work(int hours)
    {
        if (hours > _currentPower) hours = _currentPower;

        base.Work(hours);
        _currentPower -= hours;
    }

    public void Recharge() => _currentPower = _capacity;
}