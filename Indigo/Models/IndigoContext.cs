using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Indigo.Models
{
    public class IndigoContext : IdentityDbContext
    {
        public IndigoContext(DbContextOptions<IndigoContext> options):base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
