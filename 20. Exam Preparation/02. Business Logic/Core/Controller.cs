using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    private readonly FishRepository _fishes;
    private readonly DiverRepository _divers;

    public Controller()
    {
        _fishes = new();
        _divers = new();
    }

    public string DiveIntoCompetition(string diverTypeName, string diverName)
    {
        // Validate Type
        Type diverType = typeof(Diver);
        Type[] driverDerivedTypes = diverType.Assembly.GetTypes().Where(t => t != diverType && diverType.IsAssignableFrom(t)).ToArray();
        if (driverDerivedTypes.Count(t => t.Name == diverTypeName) == 0)
            return string.Format(OutputMessages.DiverTypeNotPresented, diverTypeName);

        // Check if already registered
        if (_divers.GetModel(diverName) != null) return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));

        // Add new diver
        _divers.AddModel((IDiver)Activator.CreateInstance(driverDerivedTypes.First(t => t.Name == diverTypeName), diverName)!);
        return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
    }

    public string SwimIntoCompetition(string fishTypeName, string fishName, double points)
    {
        // Validate Type
        Type fishType = typeof(Fish);
        Type[] fishDerivedTypes = fishType.Assembly.GetTypes().Where(t => t != fishType && fishType.IsAssignableFrom(t)).ToArray();
        if (fishDerivedTypes.Count(t => t.Name == fishTypeName) == 0)
            return string.Format(OutputMessages.FishTypeNotPresented, fishTypeName);

        // Check if already registered
        if (_fishes.GetModel(fishName) != null) return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));

        // Add new diver
        _fishes.AddModel((IFish)Activator.CreateInstance(fishDerivedTypes.First(t => t.Name == fishTypeName), fishName, points)!);
        return string.Format(OutputMessages.FishCreated, fishName);
    }

    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {
        // Check if the diver is registered
        IDiver? diver = _divers.GetModel(diverName);
        if (diver == null) return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);

        // Check if the fish is registered
        IFish? fish = _fishes.GetModel(fishName);
        if (fish == null) return string.Format(OutputMessages.FishNotAllowed, fishName);

        // Check if the diver has health issues
        if (diver.HasHealthIssues) return string.Format(OutputMessages.DiverHealthCheck, diverName);

        // Check oxygen needed
        if (diver.OxygenLevel < fish.TimeToCatch)
        {
            diver.Miss(fish.TimeToCatch);
            if (diver.OxygenLevel <= 0) diver.UpdateHealthStatus();
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }

        if (diver.OxygenLevel == fish.TimeToCatch)
        {
            if (isLucky)
            {
                diver.Hit(fish);
                if (diver.OxygenLevel <= 0) diver.UpdateHealthStatus();
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }

            diver.Miss(fish.TimeToCatch);
            if (diver.OxygenLevel <= 0) diver.UpdateHealthStatus();
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }

        // Successful mission
        diver.Hit(fish);
        return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
    }

    public string HealthRecovery()
    {
        uint diversWthIssuesCount = (uint)_divers.Models.Count(m => m.HasHealthIssues);

        foreach (IDiver diver in _divers.Models.Where(m => m.HasHealthIssues))
        {
            diver.UpdateHealthStatus();
            diver.RenewOxy();
        }

        return string.Format(OutputMessages.DiversRecovered, diversWthIssuesCount);
    }

    public string DiverCatchReport(string diverName)
    {
        IDiver diver = _divers.GetModel(diverName)!;

        StringBuilder reportBuilder = new();
        reportBuilder.AppendLine(diver.ToString());
        reportBuilder.AppendLine("Catch Report:");

        foreach (string fish in diver.Catch) reportBuilder.AppendLine(_fishes.GetModel(fish)!.ToString());

        return reportBuilder.ToString().Trim();
    }

    public string CompetitionStatistics()
    {
        StringBuilder statisticsBuilder = new();
        statisticsBuilder.AppendLine("**Nautical-Catch-Challenge**");
        foreach (var diver in _divers.Models.Where(d => !d.HasHealthIssues).OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name))
            statisticsBuilder.AppendLine(diver.ToString());

        return statisticsBuilder.ToString().Trim();
    }
}