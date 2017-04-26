using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Mvc;
using BusinessServices;
using DataServices;
using IFactory = BusinessServices.IFactory;


namespace TimeTrackerService.Controllers
{
    public class TTWebAPIController : ApiController
    {

        private IFactory _Factory;
        private ITimeTrackerBusinessService _TimeTrackerBusinessService;

        public TTWebAPIController()
        {
            DataServices.IFactory dataServicesFactory = new DataServices.Factory();
            _Factory = new BusinessServices.Factory(dataServicesFactory);

            _TimeTrackerBusinessService = _Factory.CreateTimeTrackerBusinessService();
        }

        
        public List<string> getUsersFullName()
       {
            var query = (from each in _TimeTrackerBusinessService.GetAllUsers()
                select each.FName + " " + each.LName).ToList();

            return query;
        }
//        [HttpGet]
//        public string getUserFullName(string ID)
//        {
//            var query = (from each in _TimeTrackerBusinessService.GetAllUsers()
//                         where each.ID == ID
//                         select each.FName + " " + each.LName
//                         ).FirstOrDefault();
//
//            return query;
//        }
//
//        [HttpGet]
//        public IEnumerable<Users> getUsers()
//        {
//            return _TimeTrackerBusinessService.GetAllUsers();
//        }
    }
}
