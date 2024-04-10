using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository _influencerRepository = null!;
        private readonly Influencer _influencer = new("valid", 1);
        private readonly Influencer _influencer2 = new("valid2", 2);

        [SetUp]
        public void Setup() => _influencerRepository = new();

        [Test]
        public void Constructor() => Assert.That(_influencerRepository.Influencers != null);

        [Test]
        public void RegisterInfluencerMethod()
        {
            Assert.Throws<ArgumentNullException>(() => _influencerRepository.RegisterInfluencer(null!));

            Assert.That(() =>
            {
                _influencerRepository.RegisterInfluencer(_influencer);
                return _influencerRepository.Influencers.Count == 1;
            });

            Assert.Throws<InvalidOperationException>(() => _influencerRepository.RegisterInfluencer(_influencer));
        }

        [Test]
        public void RemoveInfluencerMethod()
        {
            Assert.Throws<ArgumentNullException>(() => _influencerRepository.RemoveInfluencer(null!));

            Assert.That(() =>
            {
                _influencerRepository.RegisterInfluencer(_influencer);
                return _influencerRepository.RemoveInfluencer(_influencer.Username);
            });
        }

        [Test]
        public void GetInfluencerWithMostFollowersMethod()
        {
            _influencerRepository.RegisterInfluencer(_influencer);
            _influencerRepository.RegisterInfluencer(_influencer2);

            Assert.That(_influencerRepository.GetInfluencerWithMostFollowers() == _influencer2);
        }

        [Test]
        public void GetInfluencerMethod()
        {
            _influencerRepository.RegisterInfluencer(_influencer);
            Assert.That(_influencerRepository.GetInfluencer(_influencer.Username) == _influencer);
        }
    }
}