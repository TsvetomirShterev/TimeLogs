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
        SeedProjectsTable(timeLogsDbContext);
        SeedTimeLogsTable(timeLogsDbContext);
    }

    private static void ClearTables(TimeLogsDbContext timeLogsDbContext)
    {
        timeLogsDbContext.Users.RemoveRange(timeLogsDbContext.Users);
        timeLogsDbContext.Projects.RemoveRange(timeLogsDbContext.Projects);
        timeLogsDbContext.TimeLogs.RemoveRange(timeLogsDbContext.TimeLogs);

        timeLogsDbContext.SaveChanges();
    }

    private static void SeedUsersTable(TimeLogsDbContext timeLogsDbContext)
    {
        var random = new Random();
        var firstNames = new[] { "John", "Gringo", "Mark", "Lisa", "Maria", "Sonya", "Philip", "Jose", "Lorenzo", "George", "Justin" };
        var lastNames = new[] { "Johnson", "Lamas", "Jackson", "Brown", "Mason", "Rodriguez", "Roberts", "Thomas", "Rose", "McDonalds" };
        var domains = new[] { "hotmail.com", "gmail.com", "live.com" };

        var users = Enumerable.Range(0, 100)
            .Select(u =>
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var domain = domains[random.Next(domains.Length)];

                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain}";

                return new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };
            })
            .ToList();

        timeLogsDbContext.Users.AddRange(users);
        timeLogsDbContext.SaveChanges();
    }


    private static void SeedProjectsTable(TimeLogsDbContext timeLogsDbContext)
    {
        var projects = new List<Project>()
            {
                new Project { Name = "My own" },
                new Project { Name = "Free Time" },
                new Project { Name = "Work" }
            };

        timeLogsDbContext.Projects.AddRange(projects);
        timeLogsDbContext.SaveChanges();
    }

    private static void SeedTimeLogsTable(TimeLogsDbContext timeLogsDbContext)
    {
        var random = new Random();

        var users = timeLogsDbContext.Users.ToList();
        var projects = timeLogsDbContext.Projects.ToList();

        var timeLogs = users.SelectMany(user =>
            Enumerable.Range(0, random.Next(1, 21))
                      .Select(_ => new TimeLog
                      {
                          UserId = user.Id,
                          ProjectId = projects[random.Next(projects.Count)].Id,
                          LogDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                          HoursWorked = (float)(random.NextDouble() * (8.00 - 0.25) + 0.25)
                      }));

        timeLogsDbContext.TimeLogs.AddRange(timeLogs);
        timeLogsDbContext.SaveChanges();
    }
}
