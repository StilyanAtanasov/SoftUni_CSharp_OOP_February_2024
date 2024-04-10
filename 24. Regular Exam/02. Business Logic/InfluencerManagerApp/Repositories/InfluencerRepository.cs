using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class InfluencerRepository : IRepository<IInfluencer>
{
    private readonly List<IInfluencer> _influencers;

    public InfluencerRepository() => _influencers = new();

    public IReadOnlyCollection<IInfluencer> Models => _influencers.AsReadOnly();

    public void AddModel(IInfluencer model) => _influencers.Add(model);

    public bool RemoveModel(IInfluencer model) => _influencers.Remove(model);

    public IInfluencer? FindByName(string name) => _influencers.FirstOrDefault(i => i.Username == name);
}