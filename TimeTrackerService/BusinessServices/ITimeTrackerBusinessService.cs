using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServices;

namespace BusinessServices
{
    public interface ITimeTrackerBusinessService
    {
        string HelloFriends();
        
        List<Users> GetAllUsers();

        int GetProjectTime();

        bool UpdateProjectHours(string projID, int hours);

        int GetTotalHoursByUser(string userId);

        List<string> GetActivitySummaryByUser(string userId);
    }
}
