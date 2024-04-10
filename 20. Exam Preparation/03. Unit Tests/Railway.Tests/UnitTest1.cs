namespace Railway.Tests;

// ReSharper disable RedundantUsingDirective
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Tests
{
    private RailwayStation _railwayStation = null!;
    private const string ValidName = "ValidName";
    private const string TrainName = "Train";

    [SetUp]
    public void SetUp() => _railwayStation = new(ValidName);

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public void ConstructorIncorrectName(string incorrectName) =>
        Assert.Throws<ArgumentException>(() => _railwayStation = new RailwayStation(incorrectName));

    [Test]
    public void ConstructorNormalFlow()
    {
        Assert.That(_railwayStation.Name == ValidName, "Name is not being set correctly");
        Assert.That(_railwayStation.DepartureTrains != null, "DepartureTrains is not being set correctly");
        Assert.That(_railwayStation.ArrivalTrains != null, "ArrivalTrains is not being set correctly");
    }

    [Test]
    public void NewArrivalOnBoardMethod()
    {
        _railwayStation.NewArrivalOnBoard("Train");
        Assert.That(_railwayStation.ArrivalTrains.Count == 1, "Arrival trains count is not being updated!");
    }

    [Test]
    public void TrainHasArrivedMethod()
    {
        _railwayStation.NewArrivalOnBoard(TrainName);

        Assert.That(_railwayStation.TrainHasArrived(TrainName) == $"{TrainName} is on the platform and will leave in 5 minutes.");

        _railwayStation.NewArrivalOnBoard("Train2");
        Assert.That(_railwayStation.TrainHasArrived(TrainName) == $"There are other trains to arrive before {TrainName}.");
    }

    [Test]
    public void TrainHasLeftMethod()
    {
        _railwayStation.NewArrivalOnBoard(TrainName);
        _railwayStation.TrainHasArrived(TrainName);

        Assert.That(_railwayStation.TrainHasLeft("Train2") == false);
        Assert.That(_railwayStation.TrainHasLeft(TrainName));
    }
}