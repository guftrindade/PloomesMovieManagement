using Microsoft.EntityFrameworkCore;
using Movie.Management.Infra.Data;

namespace Movie.Management.Api.Configuration
{
    public static class DataBaseManagement
    {
        public static void MigrationInitialization (this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                _db.Database.Migrate();
            }
        }
    }
}
