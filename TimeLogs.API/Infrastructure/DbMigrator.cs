using Microsoft.EntityFrameworkCore;
using TimeLogs.DB;

namespace TimeLogs.API.Infrastructure;

public static class DbMigrator
{
    public static void MigrateDatabase(string connectionString)
    {
        var dbBuilder = new DbContextOptionsBuilder<TimeLogsDbContext>();
        dbBuilder.UseSqlServer(connectionString);
        var context = new TimeLogsDbContext(dbBuilder.Options);
        context.Database.Migrate();
    }
}
