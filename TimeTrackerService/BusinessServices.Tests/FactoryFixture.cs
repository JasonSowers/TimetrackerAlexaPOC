using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BusinessServices.Tests
{
    [TestFixture]
    public class FactoryFixture
    {
        private IFactory _Factory;
        

        [SetUp]
        public void SetUp()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);
        }

        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(_Factory);
        }

        [Test]
        public void CanCreateTimeTrackerBusinessService()
        {
            ITimeTrackerBusinessService businessService = _Factory.CreateTimeTrackerBusinessService();

            Assert.IsNotNull(businessService);
        }
    }
}
