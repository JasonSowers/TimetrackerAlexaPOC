using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IUsersDataService
    {
        List<Users> GetAllUsers();

        int GetProjectTime();

        bool UpdateProjectTime(string projID, int hours);

        int GetTotalHoursByUser(string userId);

        List<string> GetActivitySummaryByUser(string userid);
    }
}
