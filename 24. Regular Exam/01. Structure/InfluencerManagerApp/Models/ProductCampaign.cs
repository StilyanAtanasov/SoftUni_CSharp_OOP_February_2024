namespace InfluencerManagerApp.Models;

public class ProductCampaign : Campaign
{
    private const double ProductCampaignBudget = 60_000.0;

    public ProductCampaign(string brand) : base(brand, ProductCampaignBudget) { }
}