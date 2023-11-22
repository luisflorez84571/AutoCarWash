using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarWashing.Shared.Entities;

namespace CarWashing.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Service> Services { get; set; }

        public DbSet<Scheduling> Schedulings { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Entity<Employee>().HasIndex(e => e.Nombre).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(s => s.Servicio).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.NumeroPlaca).IsUnique();
            modelBuilder.Entity<Scheduling>().HasIndex(c => c.date).IsUnique();
            modelBuilder.Entity<Bill>().HasIndex("ServiceId", "UserId", "MontoTotal").IsUnique();
            modelBuilder.Entity<History>().HasIndex("UserId", "Descripcion").IsUnique();
           
        }
    }
}