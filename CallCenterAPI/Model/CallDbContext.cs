using Microsoft.EntityFrameworkCore;

namespace CallCenterAPI.Model
{
    public class CallDbContext : DbContext
    {

        public CallDbContext(DbContextOptions<CallDbContext> options)
            : base(options)
        {
        }

        public DbSet<CallRecord> CallRecords { get; set; }


    }

}

