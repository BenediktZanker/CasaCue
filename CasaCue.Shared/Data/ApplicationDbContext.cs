using CasaCue.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaCue.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}



