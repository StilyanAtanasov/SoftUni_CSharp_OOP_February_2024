using NUnit.Framework;

// ReSharper disable RedundantUsingDirective - The test system compiler requires these usings
using System;
using System.Linq;

namespace Database.Tests;

[TestFixture]
public class DatabaseTests
{
    private Database _database = null!;

    [SetUp]
    public void SetUp()
    {
        _database = new(Enumerable.Range(1, 16).ToArray());
    }

    [Test]
    public void Constructor()
    {
        // Invalid parameters
        Assert.Throws<InvalidOperationException>(() =>
        {
            _database = new(Enumerable.Range(1, 20).ToArray());
        }, "When longer array that 16 elements is passed, there should be an error thrown!");

        // Check if stores the input
        Assert.That(_database.Count, Is.EqualTo(16), "The input when valid is not being stored!");
    }

    [Test]
    public void DataLength()
    {
        // Assert the max length is 16
        Assert.That(_database.Count, Is.EqualTo(16), "The data should accept 16 integers!");
        Assert.Throws<InvalidOperationException>(() => _database = new(Enumerable.Range(1, 17).ToArray()),
            "The data should not accept more than 16 integers!");
    }

    [Test]
    public void AddMethod()
    {
        // Assert it cannot add more than 16 elements
        Assert.Throws<InvalidOperationException>(() => _database.Add(0),
            "The Add method should not add more if there are already 16 integers!");

        // Assert normal flow
        Assert.That(() =>
        {
            _database = new(1);
            _database.Add(2);
            return _database.Count;
        }, Is.EqualTo(2));
    }

    [Test]
    public void RemoveMethod()
    {
        // Assert normal flow
        _database.Remove();
        Assert.That(_database.Count, Is.EqualTo(15), "The length of the data is not being reduced!");

        // Assert it cannot remove from empty array
        Assert.Throws<InvalidOperationException>(() =>
            {
                _database = new();
                _database.Remove();
            },
            "The Remove method should not remove if there are no integers!");
    }

    [Test]
    public void FetchMethod()
    {
        // Assert this method works
        Assert.That(_database.Fetch(), Is.EqualTo(Enumerable.Range(1, 16).ToArray()));
    }
}