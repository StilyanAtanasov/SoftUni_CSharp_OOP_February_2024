using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    private readonly string _username = null!;
    private readonly int _followers;
    private readonly List<string> _participations;

    protected Influencer(string username, int followers, double engagementRate)
    {
        Username = username;
        Followers = followers;
        EngagementRate = engagementRate;
        _participations = new();
    }

    public string Username
    {
        get => _username;
        private init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(ExceptionMessages.UsernameIsRequired);
            _username = value;
        }
    }

    public int Followers
    {
        get => _followers;
        private init
        {
            if (value < 0) throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            _followers = value;
        }
    }

    public double EngagementRate { get; private set; }
    public double Income { get; private set; }
    public IReadOnlyCollection<string> Participations => _participations.AsReadOnly();

    public override string ToString() => $"{Username} - Followers: {Followers}, Total Income: {Income}";

    public void EarnFee(double amount) => Income += amount;

    public void EnrollCampaign(string brand) => _participations.Add(brand);

    public void EndParticipation(string brand) => _participations.Remove(brand);

    public abstract int CalculateCampaignPrice();
}