namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    private const double ServiceCampaignBudget = 60_000.0;

    public ServiceCampaign(string brand) : base(brand, ServiceCampaignBudget) { }
}