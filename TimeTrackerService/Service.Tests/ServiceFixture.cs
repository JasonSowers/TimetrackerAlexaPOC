using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Service.Tests.TTService;

namespace Service.Tests
{
    [TestFixture]
    public class ServiceFixture
    {
        private TTServiceHTTPS.TimeTrackerServiceClient _Client;

        [SetUp]
        public void SetUp()
        {
            _Client = new TTServiceHTTPS.TimeTrackerServiceClient();
        }

        [TearDown]
        public void TearDown()
        {
            _Client.Close();
        }

        [Explicit]
        [Test]
        public void HelloFriends()
        {
            string returnValue = _Client.HelloFriends();

            Assert.AreEqual("Hello Friends", returnValue);
        }

        [Explicit]
        [Test]
        public void GetAllUsers()
        {
            TTServiceHTTPS.Users[] users = _Client.GetAllUsers();

            Assert.AreEqual(4, users.Length);
        }
    }
}
