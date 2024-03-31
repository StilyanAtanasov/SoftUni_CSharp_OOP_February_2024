using NUnit.Framework;
// ReSharper disable RedundantUsingDirective - The test system compiler requires these usings
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FightingArena.Tests;

[TestFixture]
public class ArenaTests
{
    private Arena _arena = null!;
    private readonly Warrior _attacker = new("Attacker", 10, 100);
    private readonly Warrior _defender = new("Defender", 10, 100);

    [SetUp]
    public void SetUp() => _arena = new();

    [Test]
    public void Constructor() => Assert.That(_arena.Warriors, !Is.Null);

    [Test]
    public void EnrollMethod()
    {
        // Assert normal flow
        _arena.Enroll(_attacker);
        Assert.That(_arena.Warriors.Contains(_attacker), "Warriors are not being saved as enrolled!");

        // Assert a warrior cannot enroll twice
        Assert.Throws<InvalidOperationException>(() => _arena.Enroll(_attacker), "A warrior should not be able to enroll twice!");
    }

    [Test]
    public void Count()
    {
        _arena.Enroll(_attacker);
        Assert.That(_arena.Count == 1, "Count does not return actual value!");
    }

    [Test]
    public void FightMethod()
    {
        // Assert that not enrolled attacker the fight cannot start
        Assert.Throws<InvalidOperationException>(() =>
        {
            _arena.Enroll(_defender);
            _arena.Fight(_attacker.Name, _defender.Name);
        }, "Fighting without the attacker being enrolled should not be possible!");

        // Assert that not enrolled defender the fight cannot start
        Assert.Throws<InvalidOperationException>(() =>
        {
            _arena = new();
            _arena.Enroll(_attacker);
            _arena.Fight(_attacker.Name, _defender.Name);
        }, "Fighting without the defender being enrolled should not be possible!");

        // Assert normal flow
        Assert.That(() =>
        {
            _arena = new();
            _arena.Enroll(_attacker);
            _arena.Enroll(_defender);

            _arena.Fight(_attacker.Name, _defender.Name);

            return _attacker.HP != 100;
        }, "Fighting with the attacker and the defender being enrolled should be possible!");
    }
}