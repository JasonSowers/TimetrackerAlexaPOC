using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;

namespace TimeTrackerService.Controllers
{
    public class GetTotalHoursController : ApiController
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public GetTotalHoursController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);

            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }

        public int GetTotalHours()
        {
            return _TimeTrackerBusinessService.GetTotalHoursByUser("JASSOW");
        }
    }
}
