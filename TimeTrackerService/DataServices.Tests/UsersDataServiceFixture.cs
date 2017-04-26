using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataServices.Tests
{
    [TestFixture]
    public class UsersDataServiceFixture
    {
        private IFactory _Factory;
        private IUsersDataService _UsersDataService;

        [SetUp]
        public void SetUp()
        {
            _Factory = new Factory();
            _UsersDataService = _Factory.CreateUsersDataService();
        }

        [Explicit]
        [Test]
        public void GetAllUsers()
        {
            List<Users> users = _UsersDataService.GetAllUsers();

            Assert.AreEqual(4, users.Count);
        }

        [Explicit]
        [Test]
        public void GetTotalHoursByUser()
        {
            int hours = _UsersDataService.GetTotalHoursByUser("chriwi");

            Assert.AreEqual(0, hours);
        }

        [Explicit]
        [Test]
        public void GetActivitySummaryByUser()
        {
            List<string> activitySummaries = _UsersDataService.GetActivitySummaryByUser("jassow");

            Assert.AreEqual(5, activitySummaries.Count);
            Assert.AreEqual("Training 0 hours", activitySummaries[0]);
            Assert.AreEqual("Time Away 0 hours", activitySummaries[1]);
            Assert.AreEqual("Hackathon Project 28 hours", activitySummaries[2]);
            Assert.AreEqual("N B A Enhancements 0 hours", activitySummaries[3]);
            Assert.AreEqual("Sleep 0 hours", activitySummaries[4]);
        }
    }
}
