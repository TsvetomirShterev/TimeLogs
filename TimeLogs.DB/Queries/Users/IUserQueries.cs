using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.Users;

public interface IUserQueries
{
    IEnumerable<User> GetUsers();

    IEnumerable<User> GetSortedUsers(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null);
}
