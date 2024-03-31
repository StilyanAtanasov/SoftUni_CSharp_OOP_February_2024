using ExtendedDatabase;
using NUnit.Framework;

// ReSharper disable RedundantUsingDirective - The test system compiler requires these usings
using System;
using System.Linq;

namespace DatabaseExtended.Tests;

[TestFixture]
public class ExtendedDatabaseTests
{
    private Database _database = null!;

    private static readonly Person[] Array16Persons = {
        new(1, "P1"),
        new(2, "P2"),
        new(3, "P3"),
        new(4, "P4"),
        new(5, "P5"),
        new(6, "P6"),
        new(7, "P7"),
        new(8, "P8"),
        new(9, "P9"),
        new(10, "P10"),
        new(11, "P11"),
        new(12, "P12"),
        new(13, "P13"),
        new(14, "P14"),
        new(15, "P15"),
        new(16, "P16")
    };

    private static readonly Person ExtraPerson = new(17, "P17");
    private static readonly Person[] Array17Persons = Array16Persons.Concat(new[] { ExtraPerson }).ToArray();

    [Test]
    public void Constructor()
    {
        // Invalid parameters
        Assert.Throws<ArgumentException>(() =>
        {
            _database = new(Array17Persons);
        }, "When longer array that 16 elements is passed, there should be an error thrown!");

        // Check if stores the input
        Assert.That((_database = new(Array16Persons)).Count, Is.EqualTo(16), "The input when valid is not being stored!");
    }

    [Test]
    public void DataLength()
    {
        _database = new(Array16Persons);

        // Assert the max length is 16
        Assert.That(_database.Count, Is.EqualTo(16), "The data should accept 16 persons!");
        Assert.Throws<ArgumentException>(() => _database = new(Array17Persons),
            "The data should not accept more than 16 persons!");
    }

    [Test]
    public void AddMethod()
    {
        _database = new(Array16Persons);

        // Assert it cannot add more than 16 elements
        Assert.Throws<InvalidOperationException>(() => _database.Add(ExtraPerson),
            "The Add method should not add more if there are already 16 persons!");

        _database = new(new Person(1, "P1"));

        // Assert it cannot add a person with the same name
        Assert.Throws<InvalidOperationException>(() => _database.Add(new(0, "P1")),
            "The Add method should not add if there is already a person with that name!");

        // Assert it cannot add a person with the same Id
        Assert.Throws<InvalidOperationException>(() => _database.Add(new(1, "PWithExistingID")),
            "The Add method should not add if there is already a person with that Id!");

        // Assert normal flow
        Assert.That(() =>
        {
            _database = new();
            _database.Add(ExtraPerson);
            return _database.Count;
        }, Is.EqualTo(1));
    }

    [Test]
    public void RemoveMethod()
    {
        _database = new(Array16Persons);

        // Assert normal flow
        _database.Remove();
        Assert.That(_database.Count, Is.EqualTo(15), "The length of the data is not being reduced!");

        // Assert it cannot remove from empty array
        Assert.Throws<InvalidOperationException>(() =>
            {
                _database = new();
                _database.Remove();
            },
            "The Remove method should not remove if there are no people!");
    }

    [Test]
    public void FindByUsernameMethod()
    {
        _database = new(ExtraPerson);

        // Assert response for searching for person with null or empty string!
        Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(""),
            "Searching for empty username should throw an error!");
        Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(null!),
            "Searching for null username should throw an error!");

        // Assert response for finding no matching person
        Assert.Throws<InvalidOperationException>(() => _database.FindByUsername("RandomString"),
            "Searching for not an existing person should throw an error!");


        // Assert normal response
        Assert.That(_database.FindByUsername("P17"), Is.EqualTo(ExtraPerson),
            "Searching for existing person does not return the needed value!");
    }

    [Test]
    public void FindByIdMethod()
    {
        _database = new(ExtraPerson);

        // Assert response for searching for Id less than 0!
        Assert.Throws<ArgumentOutOfRangeException>(() => _database.FindById(-1),
            "Searching for id less than 0 should throw an error!");

        // Assert response for finding no matching person
        Assert.Throws<InvalidOperationException>(() => _database.FindById(100),
            "Searching for not an existing person should throw an error!");

        // Assert normal response
        Assert.That(_database.FindById(17), Is.EqualTo(ExtraPerson),
            "Searching for existing person does not return the needed value!");
    }
}