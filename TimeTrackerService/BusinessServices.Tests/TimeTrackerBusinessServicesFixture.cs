using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BusinessServices.Tests
{
    [TestFixture]
    public class TimeTrackerBusinessServicesFixture
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        [SetUp]
        public void SetUp()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);

            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }

        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(_TimeTrackerBusinessService);
        }

        [Explicit]
        public void HelloFriendsReturnsCorrectText()
        {
            string returnText = _TimeTrackerBusinessService.HelloFriends();

            Assert.AreEqual("Hello Friends", returnText);
        }
    }
}
