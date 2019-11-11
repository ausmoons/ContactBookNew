

using ContactBook.data.Migrations;
using ContactBook.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactBook.Data
{
    public class ContactBookContext : DbContext
    {
    
        static ContactBookContext() 
        {

            Database.SetInitializer<ContactBookContext>(null);

        }

        public ContactBookContext()
        : base("Data Source=DESKTOP-QF4NJ7V;Initial Catalog = ContactBookDB; user id = contactbook; password=contactbook;MultipleActiveResultSets=True")
        {
            Database.SetInitializer<ContactBookContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactBookContext, Configuration>());
        }


        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<PhoneNumbers> PhoneNumbers { get; set; }
        public DbSet<Emails> Emails { get; set; }

    }
}
