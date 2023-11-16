using CarWashing.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWashing.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Entity<Client>().HasIndex(c => c.FirstName).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Service>().HasIndex("ServiceId", "Servicio").IsUnique();
            modelBuilder.Entity<Bill>().HasIndex("BillId", "ClientId", "MontoTotal").IsUnique();
            modelBuilder.Entity<Scheduling>().HasIndex("SchedulingId", "ClientId", "VehicleId", "date").IsUnique();
            modelBuilder.Entity<History>().HasIndex("HistoryId", "Descripcion").IsUnique();
            DisableCascadingDelete(modelBuilder);
        }
        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}