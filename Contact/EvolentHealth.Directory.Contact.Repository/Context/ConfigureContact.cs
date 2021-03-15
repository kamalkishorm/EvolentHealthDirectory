using EvolentHealth.Directory.Contact.Contract.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvolentHealth.Directory.Contact.Repository.Context
{
    public partial class EvolentHealthDirectoryContext
    {
        public DbSet<Models.Contact> Contacts { get; set; }

        private void ConfigureContact(EntityTypeBuilder<Models.Contact> entity)
        {
            entity.HasData(
                new Models.Contact()
                {
                    Id = 1,
                    FirstName = "Kamal",
                    LastName = "Mehra",
                    Email = "kkm7668@gmail.com",
                    PhoneNumber = "+91-8432862796",
                    Status = StatusValue.Active
                },
                new Models.Contact()
                {
                    Id = 2,
                    FirstName = "Sanjay",
                    Email = "sanjay007@gmail.com",
                    PhoneNumber = "+91-8989787670",
                    Status = StatusValue.InActive
                }
            );
        }
    }
}