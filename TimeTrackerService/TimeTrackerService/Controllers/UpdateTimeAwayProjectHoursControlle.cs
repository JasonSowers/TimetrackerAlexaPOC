using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;

namespace TimeTrackerService.Controllers
{
    public class UpdateTimeAwayProjectHoursController : ApiController
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public UpdateTimeAwayProjectHoursController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);
            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public bool UpdateTimeAwayProjectHours()
        {
            return _TimeTrackerBusinessService.UpdateProjectHours("3", 8);
        }
    }
}
