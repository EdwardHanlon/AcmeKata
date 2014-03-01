using System;
using AcmeKata.Models;
using NUnit.Framework;

namespace AcmeKata.Tests
{
    [TestFixture]
    public class NewspaperTests
    {
        [Test]
        public void CreateNewspaper_GivenNewspaperWithNoIssueDate_DefaultToTodaysDate()
        {
            var newsPaper = new Newspaper();

            Assert.AreEqual(DateTime.Now.Date, newsPaper.IssueDate);
        }

        [Test]
        public void CreateNewspaper_GivenNewspaperWithTestDate_IssueDateAndTestDateMatch()
        {
            var newsPaper = new Newspaper(new DateTime(2012, 2, 28), 1);

            Assert.AreEqual(new DateTime(2012, 2, 28), newsPaper.IssueDate);
        }

        [Test]
        public void PlaceAd_GivenANewNewspaperAndNewAd_CanAddAdToNewsPaper()
        {
            var newsPaper = new Newspaper();
            var testAd = new Ad();

            newsPaper.PlaceAd(testAd);

            Assert.AreEqual(1, newsPaper.AdList.Count);
        }

        [Test]
        public void PlaceAd_GivenThreeAds_NewspaperAdListCountIsThree()
        {
            var newsPaper = new Newspaper();
            var testAd1 = new Ad();
            var testAd2 = new Ad();
            var testAd3 = new Ad();

            newsPaper.PlaceAd(testAd1);
            newsPaper.PlaceAd(testAd2);
            newsPaper.PlaceAd(testAd3);

            Assert.AreEqual(3, newsPaper.AdList.Count);
        }
    }
}
