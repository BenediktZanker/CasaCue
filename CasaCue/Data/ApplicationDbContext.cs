using CasaCue.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaCue.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}



