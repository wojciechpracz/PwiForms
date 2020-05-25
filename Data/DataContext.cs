using Microsoft.EntityFrameworkCore;
using pwiforms2.Models;

namespace pwiforms2.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}