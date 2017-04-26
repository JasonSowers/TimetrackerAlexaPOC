using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class Factory : IFactory
    {
        private DataServices.IFactory _DataServicesFactory;

        public Factory(DataServices.IFactory dataServicesFactory)
        {
            _DataServicesFactory = dataServicesFactory;
        }

        public DataServices.IFactory DataServicesFactory
        {
            get
            {
                return _DataServicesFactory;
            }
        }

        public ITimeTrackerBusinessService CreateTimeTrackerBusinessService()
        {
            return new TimeTrackerBusinessService(this);
        }
    }
}
