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
        public DbSet<ProductorService> productorServices { get; set; } // DbSet for ProductorService entity

        public DbSet<MeetingProductorService> MeetingProductorServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingProductorService>().ToTable("Meeting_Minutes_Details_Tbl");
            modelBuilder.Entity<ProductorService>().ToTable("Products_Service_Tbl");
            modelBuilder.Entity<MeetingMaster>().ToTable("Meeting_Minutes_Master_Tbl"); // Renaming MeetingMasters table
            modelBuilder.Entity<IndividualCustomer>().ToTable("Individual_Customer_Tbl");
            modelBuilder.Entity<CorporateCustomer>().ToTable("Corporate_Customer_Tbl");
            modelBuilder.Entity<IndividualCustomer>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<CorporateCustomer>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<MeetingMaster>().HasMany(x => x.meetingProductorServices).WithOne(y => y.MeetingMaster)
                .HasForeignKey(x => x.MeetingId);


            modelBuilder.Entity<Customer>().HasMany(x => x.meetingMasters).WithOne(y => y.Customer)
               .HasForeignKey(x => x.CustomerId);


            base.OnModelCreating(modelBuilder);
        }
    }

}
