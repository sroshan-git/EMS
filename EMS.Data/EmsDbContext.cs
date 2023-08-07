
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace EMS.Data
{
    public class EmsDbContext : IdentityDbContext
    {
        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options)
        {
        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

         }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseLazyLoadingProxies();
         }
    }
}
