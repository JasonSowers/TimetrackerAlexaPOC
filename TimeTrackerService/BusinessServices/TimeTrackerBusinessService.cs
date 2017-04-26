using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServices;

namespace BusinessServices
{
    public class TimeTrackerBusinessService : ITimeTrackerBusinessService
    {
        private IFactory _Factory;
        private DataServices.IUsersDataService _UsersDataService;
        public TimeTrackerBusinessService(IFactory factory)
        {
            _Factory = factory;
            _UsersDataService = _Factory.DataServicesFactory.CreateUsersDataService();
        }

        public string HelloFriends()
        {
            return "Hello Friends";
        }

        public List<Users> GetAllUsers()
        {
            return _UsersDataService.GetAllUsers();
        }

        public int GetProjectTime()
        {
            return _UsersDataService.GetProjectTime();
        }

        public bool UpdateProjectHours(string projID, int hours)
        {
            return _UsersDataService.UpdateProjectTime(projID, hours);
        }

        public int GetTotalHoursByUser(string userId)
        {
            return _UsersDataService.GetTotalHoursByUser(userId);
        }

        public List<string> GetActivitySummaryByUser(string userId)
        {
            return _UsersDataService.GetActivitySummaryByUser(userId);
        }
    }
}
