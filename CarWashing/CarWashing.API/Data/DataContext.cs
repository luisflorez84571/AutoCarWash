using CarWashing.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Reflection.Emit;
using static CarWashing.Shared.Entities.Service;

namespace CarWashing.API.Data
{
    public class DataContext : DbContext
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

        public class SomeService
        {
            private readonly DataContext _context;

            public SomeService(DataContext context)
            {
                _context = context;
            }

            public void AddClient(Client client)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Client>().HasIndex(c => c.FirstName).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Service>().HasIndex("ServiceId", "Servicio").IsUnique();
            modelBuilder.Entity<Bill>().HasIndex("BillId", "ClientId", "MontoTotal").IsUnique();
            modelBuilder.Entity<Scheduling>().HasIndex("SchedulingId", "ClientId", "VehicleId", "date").IsUnique();
            modelBuilder.Entity<History>().HasIndex("HistoryId", "Descripcion").IsUnique();            

        }
    }

}