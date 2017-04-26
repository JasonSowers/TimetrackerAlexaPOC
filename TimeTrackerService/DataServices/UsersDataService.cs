using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class UsersDataService : IUsersDataService
    {
        private IFactory _Factory;

        public UsersDataService(IFactory factory)
        {
            _Factory = factory;
        }

        public List<Users> GetAllUsers()
        {
            using (var databaseContext = new TimeTrackerEntities1())
            {
                var entities = from each in databaseContext.Users
                    select each;


                return entities.ToList();
            }
        }

        public int GetProjectTime()
        {
            decimal query;
            using (var databaseContext = new TimeTrackerEntities1())
            {
                query = (decimal)(from each in databaseContext.Hours
                    where each.ActivityID == "8"
                    where each.UserID == "JASSOW"
                    select each.Hours1).FirstOrDefault();
            }
            return Convert.ToInt32(query);
        }

        public bool UpdateProjectTime(string projID, int hours)
        {
            bool success;
            try
            {
                using (var databaseContext = new TimeTrackerEntities1())
                {
                    var value = (from each in databaseContext.Hours
                        where each.UserID == "JASSOW"
                                 where each.ActivityID == projID
                        select each).FirstOrDefault();

                    value.Hours1 = value.Hours1 + hours;
                    databaseContext.SaveChanges();
                }
                success = true;
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public int GetTotalHoursByUser(string userId)
        {
            decimal? sumDecimal;

            using (var databaseContext = new TimeTrackerEntities1())
            {
                sumDecimal = (from t in databaseContext.Hours
                              where t.UserID == userId.ToUpper()
                              select t.Hours1).Sum();
            }

            return Convert.ToInt32(sumDecimal);
        }

        public List<string> GetActivitySummaryByUser(string userid)
        {
            List<string> activitySummaries = new List<string>();

            using (var databaseContext = new TimeTrackerEntities1())
            {
                var activityQueryResults = (from hours in databaseContext.Hours
                                  join activities in databaseContext.Activities on hours.ActivityID equals activities.ID
                                  where hours.UserID == userid.ToUpper()
                                  select new
                                  {
                                      ActivityName = activities.Name,
                                      Hours = hours.Hours1
                                  });

                foreach (var item in activityQueryResults)
                {
                    activitySummaries.Add(string.Format("{0} {1} hours", item.ActivityName, Convert.ToInt32(item.Hours)));
                }
            }

            return activitySummaries;
        }
    }
}
