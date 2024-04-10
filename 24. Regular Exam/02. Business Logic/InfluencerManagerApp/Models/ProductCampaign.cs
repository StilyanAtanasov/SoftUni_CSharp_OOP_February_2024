namespace InfluencerManagerApp.Models;

public class ProductCampaign : Campaign
{
    private const double ProductCampaignBudget = 60_000.0;
    private static readonly Type[] EligibleInfluencers = { typeof(BusinessInfluencer), typeof(FashionInfluencer) };

    public ProductCampaign(string brand) : base(brand, ProductCampaignBudget) { }

    public override IReadOnlyCollection<Type> EligibleInfluencersCollection => EligibleInfluencers.ToList().AsReadOnly();
}