using Groceries.Models;
using Microsoft.EntityFrameworkCore;

namespace Groceries.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {}
        //creating the db sets 
        public DbSet<Grocerie> GroceriesTable { get; set; }
        public DbSet<User> UsersTable { get; set; } 
    }
}
