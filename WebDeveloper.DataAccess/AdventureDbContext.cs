using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class AdventureDbContext : DbContext
    {
        public AdventureDbContext() : base("name=AdventureWorks")
        {
            //En este constructor llamaremos al metodo que rellena data
            //Database.SetInitializer(new WebDeveloperInitializer());
        }

        
        public DbSet<Person> Person { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>()
            //   .HasOptional(j => j.BusinessEntityAddress)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
