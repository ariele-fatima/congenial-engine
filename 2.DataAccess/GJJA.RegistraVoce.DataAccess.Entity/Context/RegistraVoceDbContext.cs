using GJJA.RegistraVoce.Domain;
using Microsoft.EntityFrameworkCore;

namespace GJJA.RegistraVoce.DataAccess.Entity.Context
{
    public class RegistraVoceDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public RegistraVoceDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("PEO_PEOPLE");
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .HasColumnName("PEO_ID")
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasColumnName("PEO_NAME")
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Gender)
                .HasColumnName("PEO_GENDER")
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.DocumentNumber)
                .HasColumnName("PEO_DOCUMETNNUMBER")
                .HasMaxLength(11)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Identification)
                .HasColumnName("PEO_IDENTIFICATION")
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.BirthDate)
                .HasColumnName("PEO_BIRTHDATE")
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.MaritalStatus)
                .HasColumnName("PEO_MARITAL_STATUS")
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.Address)
                .HasColumnName("PEO_ADDRESS")
                .HasMaxLength(100);
            modelBuilder.Entity<Person>()
                .Property(p => p.Phone)
                .HasColumnName("PEO_PHONE")
                .HasMaxLength(12);
            modelBuilder.Entity<Person>().HasKey(pk => pk.Id);
        }
    }
}