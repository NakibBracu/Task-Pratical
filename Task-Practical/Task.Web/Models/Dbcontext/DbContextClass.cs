using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Task.Web.Models.Dbcontext
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Customer> Customers { get; set; } // DbSet for Customer entity
        public DbSet<MeetingMaster> MeetingMasters { get; set; } // DbSet for MeetingMaster entity
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndividualCustomer>().ToTable("Individual_Customer_Tbl");
            modelBuilder.Entity<CorporateCustomer>().ToTable("Corporate_Customer_Tbl");
            modelBuilder.Entity<IndividualCustomer>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<CorporateCustomer>().Property(c => c.Name).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }

}
