using NUnit.Framework;

// ReSharper disable RedundantUsingDirective - The test system compiler requires these usings
using System;
using System.Linq;

namespace FightingArena.Tests;

[TestFixture]
public class WarriorTests
{
    private Warrior _warrior;
    private readonly string _name = "W1";
    private readonly int _damage = 10;
    private readonly int _hp = 100;

    [Test]
    public void Constructor()
    {
        _warrior = new(_name, _damage, _hp);
        Assert.That(_warrior.Name, Is.EqualTo(_name), "Name is not being set properly!");
        Assert.That(_warrior.Damage, Is.EqualTo(_damage), "Name is not being set properly!");
        Assert.That(_warrior.HP, Is.EqualTo(_hp), "Name is not being set properly!");
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("     ")]
    public void NameInvalidCases(string invalidName)
    {
        Assert.Throws<ArgumentException>(() => _warrior = new(invalidName, _damage, _hp),
            "Warrior should not be able to have null or whitespace only name!");
    }

    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void DamageInvalidCases(int invalidDamage)
    {
        Assert.Throws<ArgumentException>(() => _warrior = new(_name, invalidDamage, _hp),
            "Warrior should not be able to have zero or negative damage!");
    }

    [Test]
    [TestCase(-1)]
    public void HpInvalidCases(int invalidHealth)
    {
        Assert.Throws<ArgumentException>(() => _warrior = new(_name, _damage, invalidHealth),
            "Warrior should not be able to have negative HP!");
    }

    [Test]
    public void AttackMethod()
    {
        const int hpUnderAttackMin = 10;

        _warrior = new(_name, _damage, hpUnderAttackMin);
        Warrior warriorUnderAttack = new(_name, _damage, hpUnderAttackMin);

        // Assert a warrior cannot attack while their HP is <= 30
        Assert.Throws<InvalidOperationException>(() => _warrior.Attack(warriorUnderAttack),
            "Warrior should not be able to attack while their HP is <= 30!");

        // Assert a warrior cannot attack while opponent HP is <= 30
        _warrior = new(_name, _damage, _hp);
        Assert.Throws<InvalidOperationException>(() => _warrior.Attack(warriorUnderAttack),
            "Warrior should not be able to attack while opponent HP is <= 30!");

        // Assert a warrior cannot attack stronger enemies
        warriorUnderAttack = new(_name, 1000, _hp);
        Assert.Throws<InvalidOperationException>(() => _warrior.Attack(warriorUnderAttack),
            "Warrior should not be able to stronger enemies!");

        // -- Normal flow

        // Assert killing an enemy sets their health to 0
        _warrior = new(_name, 1000, _hp);
        warriorUnderAttack = new(_name, _damage, _hp);
        Assert.That(() =>
        {
            _warrior.Attack(warriorUnderAttack);
            return warriorUnderAttack.HP;
        }, Is.EqualTo(0),
            "If an enemy is killed their health should be 0");

        // Assert normal attack without dead warriors
        _warrior = new(_name, _damage, _hp);
        warriorUnderAttack = new(_name, _damage, _hp);
        int attackedStartingHp = warriorUnderAttack.HP;
        _warrior.Attack(warriorUnderAttack);
        Assert.That(warriorUnderAttack.HP, Is.EqualTo(attackedStartingHp - _warrior.Damage),
            "HP is not reduced for the opponent!");
        Assert.That(_warrior.HP, Is.EqualTo(_hp - warriorUnderAttack.Damage),
            "HP is not reduced for the attacker!");
    }
}