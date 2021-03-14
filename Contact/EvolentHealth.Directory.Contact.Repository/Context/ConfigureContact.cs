using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvolentHealth.Directory.Contact.Repository.Context
{
    public partial class EvolentHealthDirectoryContext
    {
        private DbSet<Models.Contact> Contacts { get; set; }

        private void ConfigureContact(EntityTypeBuilder<Models.Contact> entity)
        {
            
        }
    }
}