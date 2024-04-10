using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories;

// ReSharper disable InconsistentNaming
public class DiverRepository : IRepository<IDiver>
{
    private readonly List<IDiver> _divers;

    public DiverRepository() => _divers = new();

    public IReadOnlyCollection<IDiver> Models => _divers.AsReadOnly();

    public void AddModel(IDiver model) => _divers.Add(model);

    public IDiver? GetModel(string name)
    {
        IDiver? diver = Models.FirstOrDefault(d => d.Name == name);
        return diver;
    }
}