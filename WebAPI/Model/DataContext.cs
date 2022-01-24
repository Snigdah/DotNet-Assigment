using Microsoft.EntityFrameworkCore;

namespace WebAPI.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<OfficeManagement> OfficeManagements { get; set; }
    }
}
