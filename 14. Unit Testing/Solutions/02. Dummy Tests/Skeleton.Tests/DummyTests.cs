using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe _axe;
        private Dummy _dummy;

        [SetUp]
        public void StartUp()
        {
            _axe = new(10, 10);
            _dummy = new(100, 1);
        }

        [Test]
        public void HealthLoss()
        {
            _axe.Attack(_dummy);

            Assert.AreEqual(90, _dummy.Health, "The health loss is not handled!");
        }

        [Test]
        public void AttackDeadDummy()
        {
            _dummy = new(0, 0);

            Assert.Throws<InvalidOperationException>(() => _axe.Attack(_dummy), "The flow allows attack to already dead Dummy!");
        }

        [Test]
        public void ExperienceReleaseWhenAlive() => Assert.Throws<InvalidOperationException>(() => _dummy.GiveExperience(), "Alive Dummy gives experience !!!");

        [Test]
        public void ExperienceReleaseWhenDead()
        {
            _dummy = new(8, 1);
            _axe.Attack(_dummy);

            Assert.AreEqual(1, _dummy.GiveExperience(), "Dummy does not release experience points even when dead!");
        }
    }
}