using NUnit.Framework;
// ReSharper disable RedundantUsingDirective - The test system compiler requires these usings
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CarManager.Tests;

[TestFixture]
public class CarManagerTests
{
    private Car _car = null!;
    private readonly string _make = "BMW";
    private readonly string _model = "X6";
    private readonly double _fuelConsumption = 10;
    private readonly double _fuelCapacity = 70;

    [Test]
    public void Constructors()
    {
        _car = new(_make, _model, _fuelConsumption, _fuelCapacity);

        // Assert that the constructor passes to the appropriate setters their normal flow
        Assert.That(_car.Make, Is.EqualTo(_make), "Make is not being set!");
        Assert.That(_car.Model, Is.EqualTo(_model), "Model is not being set!");
        Assert.That(_car.FuelConsumption, Is.EqualTo(_fuelConsumption), "FuelConsumption is not being set!");
        Assert.That(_car.FuelCapacity, Is.EqualTo(_fuelCapacity), "FuelCapacity is not being set!");
        Assert.That(_car.FuelAmount, Is.EqualTo(0), "FuelAmount is not being set!");
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void MakeInvalidCases(string invalidMake)
    {
        Assert.Throws<ArgumentException>(() => _car = new(invalidMake, _model, _fuelConsumption, _fuelCapacity),
            "The flow allows setting a null or empty value to the Make!");
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void ModelInvalidCases(string invalidModel)
    {
        Assert.Throws<ArgumentException>(() => _car = new(_make, invalidModel, _fuelConsumption, _fuelCapacity),
            "The flow allows setting a null or empty value to the Model!");
    }

    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void FuelConsumptionInvalidCases(double invalidFuelConsumption)
    {
        Assert.Throws<ArgumentException>(() => _car = new(_make, _model, invalidFuelConsumption, _fuelCapacity),
            "The flow allows setting a zero or less value to the FuelConsumption!");
    }

    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void FuelCapacityInvalidCases(double invalidFuelCapacity)
    {
        Assert.Throws<ArgumentException>(() => _car = new(_make, _model, _fuelConsumption, invalidFuelCapacity),
            "The flow allows setting a zero or less value to the FuelCapacity!");
    }

    [Test]
    public void RefuelMethod()
    {
        _car = new(_make, _model, _fuelConsumption, _fuelCapacity);

        // Assert refueling with 0 or less is not possible
        Assert.Throws<ArgumentException>(() => _car.Refuel(0),
            "Refueling with 0 or less should not be possible!");

        // Assert normal flow
        Assert.That(() =>
        {
            _car.Refuel(10);
            return _car.FuelAmount;
        }, Is.EqualTo(10),
            "FuelAmount is not being updated!");

        // Refueling with more than needed fuel
        // Assert normal flow
        Assert.That(() =>
            {
                _car.Refuel(_fuelCapacity + 1);
                return _car.FuelAmount;
            }, Is.EqualTo(_fuelCapacity),
            "FuelAmount should not be greater than the FuelCapacity!");
    }

    [Test]
    public void DriveMethod()
    {
        _car = new(_make, _model, _fuelConsumption, _fuelCapacity);

        // Assert refueling with 0 or less is not possible
        Assert.Throws<InvalidOperationException>(() => _car.Drive(1),
            "Driving without enough fuel should not be possible!");

        // Assert normal flow
        Assert.That(() =>
            {
                _car.Refuel(10);
                _car.Drive(100);
                return _car.FuelAmount;
            }, Is.EqualTo(0),
            "FuelAmount is not being reduced!");
    }
}