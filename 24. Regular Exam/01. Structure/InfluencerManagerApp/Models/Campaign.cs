using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    private readonly string _brand = null!;
    private readonly List<string> _contributors;

    protected Campaign(string brand, double budget)
    {
        Brand = brand;
        Budget = budget;
        _contributors = new();
    }

    public string Brand
    {
        get => _brand;
        private init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.BrandIsrequired);
            _brand = value;
        }
    }

    public double Budget { get; private set; }
    public IReadOnlyCollection<string> Contributors => _contributors.AsReadOnly();

    public override string ToString() => $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";

    public void Gain(double amount) => Budget += amount;

    public void Engage(IInfluencer influencer)
    {
        _contributors.Add(influencer.Username);
        Budget -= influencer.CalculateCampaignPrice();
    }
}