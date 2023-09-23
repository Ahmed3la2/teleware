
using Microsoft.EntityFrameworkCore;
using TeleWareAssessment.Entities;

namespace TeleWareAssessment.Data
{
    public class TeleWareContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public TeleWareContext(DbContextOptions<TeleWareContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Age)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Address>()
                .Property(a => a.Description)
                .HasMaxLength(100)
                .IsRequired();
        }
    }


}
