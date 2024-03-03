// ReSharper disable UnusedMember.Global
namespace _05._Birthday_Celebrations;

public class Robot : IIdentifiable
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; }
    public string Id { get; }
}