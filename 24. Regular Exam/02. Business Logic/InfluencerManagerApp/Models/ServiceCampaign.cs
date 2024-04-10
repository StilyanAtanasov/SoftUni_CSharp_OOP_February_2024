namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    private const double ServiceCampaignBudget = 30_000.0;
    private static readonly Type[] EligibleInfluencers = { typeof(BusinessInfluencer), typeof(BloggerInfluencer) };

    public ServiceCampaign(string brand) : base(brand, ServiceCampaignBudget) { }
    public override IReadOnlyCollection<Type> EligibleInfluencersCollection => EligibleInfluencers.ToList().AsReadOnly();
}