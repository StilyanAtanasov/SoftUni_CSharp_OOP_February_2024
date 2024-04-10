namespace InfluencerManagerApp.Models;

public class BloggerInfluencer : Influencer
{
    private const double BloggerInfluencerEngagementRate = 2.0;
    private const double Factor = 0.2;

    public BloggerInfluencer(string username, int followers) : base(username, followers, BloggerInfluencerEngagementRate) { }

    public override int CalculateCampaignPrice() => (int)Math.Floor(Followers * EngagementRate * Factor);
}