using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
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
        public void WeaponDurability()
        {
            _axe.Attack(_dummy);

            Assert.AreEqual(9, _axe.DurabilityPoints);
        }

        [Test]
        public void BrokenWeapon()
        {
            _axe = new Axe(1, 0);

            Assert.Throws<InvalidOperationException>(() => _axe.Attack(_dummy));
        }
    }
}