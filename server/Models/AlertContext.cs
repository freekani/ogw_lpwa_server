using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class AlertContext : DbContext
    {
        public AlertContext(DbContextOptions<AlertContext> options)
            : base(options)
        {
        }

        public DbSet<AlertModel> AlertModels { get; set; }
    }
}