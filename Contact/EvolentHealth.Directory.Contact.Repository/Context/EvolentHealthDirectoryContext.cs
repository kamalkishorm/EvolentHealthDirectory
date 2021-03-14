using Microsoft.EntityFrameworkCore;

namespace EvolentHealth.Directory.Contact.Repository.Context
{
    public partial class EvolentHealthDirectoryContext : DbContext
    {
        public EvolentHealthDirectoryContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Contact>(ConfigureContact);
        }
    }
}
