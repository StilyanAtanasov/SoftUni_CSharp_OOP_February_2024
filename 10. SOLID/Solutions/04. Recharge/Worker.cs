namespace _04._Recharge;

public abstract class Worker
{
    public string Id { get; }
    public int WorkingHours { get; protected set; }

    protected Worker(string id) => Id = id;

    public virtual void Work(int hours) => WorkingHours += hours;
}