using EvolentHealth.Directory.Contact.Repository.Context;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvolentHealth.Directory.Contact.RunMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run Migration!");
            var optionsBuilder = new DbContextOptionsBuilder<EvolentHealthDirectoryContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7168J1M\\MSSQLSERVER01;Initial Catalog=EvolentHealthDirectory;Integrated Security=True;");
            var context = new EvolentHealthDirectoryContext(optionsBuilder.Options);
            context.SaveChanges();
            
        }


    }

}
