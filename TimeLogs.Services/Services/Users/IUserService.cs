using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.Users;

public interface IUserService
{
    User CreateUser(CreateUserModel createUserModel);

    int GetUsersCount(DateTime? fromDate = null, DateTime? toDate = null);

    IEnumerable<ReadUserModel> GetUsers(int page, int itemsPerPage);

    IEnumerable<ReadUserModel> GetSortedUsersBetweenDates(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null);
}
