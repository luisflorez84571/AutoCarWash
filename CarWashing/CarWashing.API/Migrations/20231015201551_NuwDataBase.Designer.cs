﻿// <auto-generated />
using System;
using CarWashing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarWashing.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231015201551_NuwDataBase")]
    partial class NuwDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarWashing.Shared.Entities.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("ClientId");

                    b.HasIndex("BillId", "ClientId", "MontoTotal")
                        .IsUnique();

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Celphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientId");

                    b.HasIndex("FirstName")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HorarioTrabajo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryId"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServicioVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VehículoId")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.HasIndex("ServicioVehicleId");

                    b.HasIndex("HistoryId", "Descripcion")
                        .IsUnique()
                        .HasFilter("[Descripcion] IS NOT NULL");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Scheduling", b =>
                {
                    b.Property<int>("SchedulingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchedulingId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Hour")
                        .HasMaxLength(50)
                        .HasColumnType("time");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.HasKey("SchedulingId");

                    b.HasIndex("SchedulingId", "ClientId", "VehicleId", "date")
                        .IsUnique();

                    b.ToTable("Schedulings");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Servicio")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<string>("Vehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.HasIndex("ServiceId", "Servicio")
                        .IsUnique()
                        .HasFilter("[Servicio] IS NOT NULL");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NúmeroPlaca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("ClientId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Bill", b =>
                {
                    b.HasOne("CarWashing.Shared.Entities.Client", null)
                        .WithMany("Bills")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.History", b =>
                {
                    b.HasOne("CarWashing.Shared.Entities.Vehicle", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioVehicleId");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Vehicle", b =>
                {
                    b.HasOne("CarWashing.Shared.Entities.Client", "Client")
                        .WithMany("Vehicles")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarWashing.Shared.Entities.Client", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
