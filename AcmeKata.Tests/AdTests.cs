using System;
using AcmeKata.Models;
using NUnit.Framework;

namespace AcmeKata.Tests
{
    [TestFixture]
    public class AdTests
    {
        [Test]
        public void CreateAd_GivenAdWithNoName_NameDefaultsToEmptyString()
        {
            var testAd = new Ad();

            Assert.AreEqual(String.Empty, testAd.Name);
        }

        [Test]
        public void CreateAd_GivenAnAdWithTestName_NameMatchesTestName()
        {
            string testName = "TEST NAME FOR AD";

            var testAd = new Ad(testName);

            Assert.AreEqual("TEST NAME FOR AD", testAd.Name);
        }

        [Test]
        public void CreateAd_GivenAnAdWithNullName_NameDefaultsToEmptyString()
        {
            string testName = null;

            var testAd = new Ad(testName);

            Assert.AreEqual(String.Empty, testAd.Name);
        }
    }
}
