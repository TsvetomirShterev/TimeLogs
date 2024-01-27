using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.Users;

public interface IUserService
{
    User CreateUser(CreateUserModel createUserModel);

    int GetUsersCount(DateTime? fromDate = null, DateTime? toDate = null);

    IEnumerable<ReadUserModel> GetUsers(int page, int itemsPerPage, DateTime? fromDate = null, DateTime? toDate = null);

}
