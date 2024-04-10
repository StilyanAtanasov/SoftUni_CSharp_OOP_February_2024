namespace InfluencerManagerApp.Models;

public class FashionInfluencer : Influencer
{
    private const double FashionInfluencerEngagementRate = 4.0;
    private const double Factor = 0.1;

    public FashionInfluencer(string username, int followers) : base(username, followers, FashionInfluencerEngagementRate) { }

    public override int CalculateCampaignPrice() => (int)Math.Floor(Followers * EngagementRate * Factor);
}