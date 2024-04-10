using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories;

public class FishRepository : IRepository<IFish>
{
    private readonly List<IFish> _fishes;

    public FishRepository() => _fishes = new();

    public IReadOnlyCollection<IFish> Models => _fishes.AsReadOnly();

    public void AddModel(IFish model) => _fishes.Add(model);

    public IFish? GetModel(string name)
    {
        IFish? diver = Models.FirstOrDefault(d => d.Name == name);
        return diver;
    }
}