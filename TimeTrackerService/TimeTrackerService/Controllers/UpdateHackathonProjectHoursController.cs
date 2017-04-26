using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;

namespace TimeTrackerService.Controllers
{
    public class UpdateHackathonProjectHoursController : ApiController
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public UpdateHackathonProjectHoursController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);
            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public bool UpdateHackathonProjectHours()
        {
            return _TimeTrackerBusinessService.UpdateProjectHours("8", 2);
        }
    }
}
