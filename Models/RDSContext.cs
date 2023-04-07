using Microsoft.EntityFrameworkCore;

namespace winter_intex_2_5.Models
{
    public class RDSContext : DbContext
    {
        public DbSet<TestTable> tests {get; set;}
        public RDSContext(DbContextOptions<RDSContext> options) : base(options) 
        {
            
        }
    }
}
