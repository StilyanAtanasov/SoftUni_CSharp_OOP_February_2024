using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private readonly InfluencerRepository _influencers;
    private readonly CampaignRepository _campaigns;

    public Controller()
    {
        _influencers = new();
        _campaigns = new();
    }

    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        // Check typeName
        Type influencerType = typeof(Influencer);
        Type? derivedType = influencerType.Assembly.GetTypes()
            .FirstOrDefault(t => t != influencerType && t.IsAssignableTo(influencerType) && t.Name == typeName);
        if (derivedType == null) return string.Format(OutputMessages.InfluencerInvalidType, typeName);

        // Check if already registered
        if (_influencers.FindByName(username) != null)
            return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));

        // Register the influencer
        _influencers.AddModel((IInfluencer)Activator.CreateInstance(derivedType, username, followers)!);
        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        // Check typeName
        Type campaignType = typeof(Campaign);
        Type? derivedType = campaignType.Assembly.GetTypes()
            .FirstOrDefault(t => t != campaignType && t.IsAssignableTo(campaignType) && t.Name == typeName);
        if (derivedType == null) return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);

        // Check if already added
        if (_campaigns.FindByName(brand) != null)
            return string.Format(OutputMessages.CampaignDuplicated, brand);

        // Register the influencer
        _campaigns.AddModel((ICampaign)Activator.CreateInstance(derivedType, brand)!);
        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
    }

    public string AttractInfluencer(string brand, string username)
    {
        // Check if the influencer is enrolled
        IInfluencer? influencer = _influencers.FindByName(username);
        if (influencer == null)
            return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);

        // Check if the brand runs campaign
        ICampaign? campaign = _campaigns.FindByName(brand);
        if (campaign == null)
            return string.Format(OutputMessages.CampaignNotFound, brand);

        // Check if the username is already engaged
        if (influencer.Participations.Contains(brand))
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);

        // Check if eligible
        if (!campaign.EligibleInfluencersCollection.Contains(influencer.GetType()))
            return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);

        // Check campaign budged
        if (campaign.Budget < influencer.CalculateCampaignPrice())
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);

        // Successful join
        influencer.EnrollCampaign(brand);
        influencer.EarnFee(influencer.CalculateCampaignPrice());
        campaign.Engage(influencer);

        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
    }

    public string FundCampaign(string brand, double amount)
    {
        // Check if the campaign exists
        ICampaign? campaign = _campaigns.FindByName(brand);
        if (campaign == null)
            return string.Format(OutputMessages.InvalidCampaignToFund);

        // Assert the amount is positive
        if (amount <= 0)
            return string.Format(OutputMessages.NotPositiveFundingAmount);

        // Fund
        campaign.Gain(amount);
        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
    }

    public string CloseCampaign(string brand)
    {
        // Validate campaign
        ICampaign? campaign = _campaigns.FindByName(brand);
        if (campaign == null)
            return string.Format(OutputMessages.InvalidCampaignToClose);

        // Check campaign budget
        if (campaign.Budget <= 10_000)
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);

        // Close campaign
        foreach (IInfluencer influencer in _influencers.Models.Where(i => i.Participations.Contains(brand)))
        {
            influencer.EarnFee(2_000);
            influencer.EndParticipation(brand);
        }

        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
    }

    public string ConcludeAppContract(string username)
    {
        // Validate influencer
        IInfluencer? influencer = _influencers.FindByName(username);
        if (influencer == null)
            return string.Format(OutputMessages.InfluencerNotSigned, username);

        // Check if enrolled in active campaigns
        if (influencer.Participations.Count != 0)
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);

        // Conclude contract
        _influencers.RemoveModel(influencer);
        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
    }

    public string ApplicationReport()
    {
        StringBuilder reportBuilder = new();

        foreach (IInfluencer influencer in _influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers))
        {
            reportBuilder.AppendLine(influencer.ToString());
            if (influencer.Participations.Count != 0)
            {
                reportBuilder.AppendLine("Active Campaigns:");
                foreach (string participation in influencer.Participations.OrderBy(n => n))
                    reportBuilder.AppendLine(_campaigns.FindByName(participation)!.ToString());
            }
        }

        return reportBuilder.ToString().Trim();
    }
}