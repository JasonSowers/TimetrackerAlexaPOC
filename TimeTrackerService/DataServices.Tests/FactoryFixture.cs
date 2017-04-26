using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataServices.Tests
{
    [TestFixture]
    public class FactoryFixture
    {
        private IFactory _Factory;

        [SetUp]
        public void SetUp()
        {
            _Factory = new Factory();
        }

        [Test]
        public void CanCreateUsersDataService()
        {
            IUsersDataService dataService = _Factory.CreateUsersDataService();

            Assert.IsNotNull(dataService);
        }
    }
}
