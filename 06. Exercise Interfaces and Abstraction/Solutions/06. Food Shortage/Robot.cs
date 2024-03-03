// ReSharper disable UnusedMember.Global
namespace _06._Food_Shortage;

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