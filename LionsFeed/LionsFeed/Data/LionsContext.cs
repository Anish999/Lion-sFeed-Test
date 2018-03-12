using LionsFeed.Models;
using Microsoft.EntityFrameworkCore;

namespace LionsFeed.Data
{
    public class LionsContext : DbContext
    {
        public LionsContext(DbContextOptions<LionsContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
