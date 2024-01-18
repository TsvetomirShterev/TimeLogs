using TimeLogs.DB;
using TimeLogs.DB.Entities;

namespace TimeLogs.API.Infrastructure;

public static class DataSeeder
{
    public static void InitializeDatabase(this WebApplication app)
    {
        var appServices = app.Services;
        using var scopedService = appServices.CreateScope();
        var service = scopedService.ServiceProvider;
        var timeLogsDbContext = service.GetService<TimeLogsDbContext>();

        ClearTables(timeLogsDbContext);
        SeedUsersTable(timeLogsDbContext);
    }

    private static void ClearTables(TimeLogsDbContext timeLogsDbContext)
    {
        timeLogsDbContext.Users.RemoveRange(timeLogsDbContext.Users);
        //timeLogsDbContext.Projects.RemoveRange(timeLogsDbContext.Projects);
        //timeLogsDbContext.TimeLogs.RemoveRange(timeLogsDbContext.TimeLogs);

        timeLogsDbContext.SaveChanges();
    }

    private static void SeedUsersTable(TimeLogsDbContext timeLogsDbContext)
    {
        var random = new Random();
        var firstNames = new[] { "John", "Gringo", "Mark", "Lisa", "Maria", "Sonya", "Philip", "Jose", "Lorenzo", "George", "Justin" };
        var lastNames = new[] { "Johnson", "Lamas", "Jackson", "Brown", "Mason", "Rodriguez", "Roberts", "Thomas", "Rose", "McDonalds" };
        var domains = new[] { "hotmail.com", "gmail.com", "live.com" };

        var users = new List<User>();

        for (int i = 0; i < 100; i++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            var domain = domains[random.Next(domains.Length)];

            var email = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain}";

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            users.Add(user);
        }

        timeLogsDbContext.Users.AddRange(users);
        timeLogsDbContext.SaveChanges();
    }
}
