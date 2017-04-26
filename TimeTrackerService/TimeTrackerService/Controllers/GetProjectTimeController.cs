using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;

namespace TimeTrackerService.Controllers
{
    public class GetProjectTimeController : ApiController
    {
        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public GetProjectTimeController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new Factory(dataServicesFactory);

            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }

        public int getProjectTime()
        {
            return _TimeTrackerBusinessService.GetProjectTime();
        }
    }
}
