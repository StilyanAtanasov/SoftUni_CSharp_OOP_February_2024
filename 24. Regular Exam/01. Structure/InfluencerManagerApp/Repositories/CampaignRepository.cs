using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private readonly List<ICampaign> _campaigns;

    public CampaignRepository() => _campaigns = new();

    public IReadOnlyCollection<ICampaign> Models => _campaigns.AsReadOnly();

    public void AddModel(ICampaign campaign) => _campaigns.Add(campaign);

    public bool RemoveModel(ICampaign campaign) => _campaigns.Remove(campaign);

    public ICampaign? FindByName(string brand) => _campaigns.FirstOrDefault(i => i.Brand == brand);
}