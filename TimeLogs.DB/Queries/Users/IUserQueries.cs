using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.Users;

public interface IUserQueries
{
    IEnumerable<User> GetUsers();

    IEnumerable<User> GetSortedUsersBetweenDates(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null);

    int GetUsersCount(DateTime? fromDate = null, DateTime? toDate = null);
}
