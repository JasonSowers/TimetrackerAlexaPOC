using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;

namespace TimeTrackerService.Controllers
{
    public class GetActivitySummaryController : ApiController
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public GetActivitySummaryController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);

            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }

        public List<string> GetActivitySummary()
        {
            return _TimeTrackerBusinessService.GetActivitySummaryByUser("jassow");
        }
    }
}
