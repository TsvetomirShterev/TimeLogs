using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.Users;

public interface IUserQueries
{
    IEnumerable<User> GetUsers();
}
