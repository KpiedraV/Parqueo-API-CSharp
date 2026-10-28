using Microsoft.EntityFrameworkCore;
using ParqueoApi.Models;

namespace ParqueoApi.Data;

public class ParqueoDbContext(DbContextOptions<ParqueoDbContext> options) : DbContext(options)
{
    public DbSet<Automovil> Automoviles => Set<Automovil>();
    public DbSet<Parqueo> Parqueos => Set<Parqueo>();
    public DbSet<Ingreso> Ingresos => Set<Ingreso>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automovil>(entity =>
        {
            entity.ToTable("PRQ_Automovil");
            entity.HasKey(automovil => automovil.Id);
            entity.Property(automovil => automovil.Color).IsRequired();
            entity.Property(automovil => automovil.Fabricante).IsRequired();
            entity.Property(automovil => automovil.Tipo).IsRequired();
            entity.HasData(
                new Automovil { Id = 1, Color = "Rojo", Anio = 2020, Fabricante = "Toyota", Tipo = "sedán" },
                new Automovil { Id = 2, Color = "Azul", Anio = 2022, Fabricante = "Honda", Tipo = "sedán" },
                new Automovil { Id = 3, Color = "Negro", Anio = 2019, Fabricante = "Toyota", Tipo = "4x4" },
                new Automovil { Id = 4, Color = "Blanco", Anio = 2023, Fabricante = "Hyundai", Tipo = "sedán" },
                new Automovil { Id = 5, Color = "Gris", Anio = 2021, Fabricante = "Suzuki", Tipo = "moto" },
                new Automovil { Id = 6, Color = "Verde", Anio = 2018, Fabricante = "Nissan", Tipo = "4x4" },
                new Automovil { Id = 7, Color = "Plateado", Anio = 2024, Fabricante = "Kia", Tipo = "sedán" },
                new Automovil { Id = 8, Color = "Amarillo", Anio = 2022, Fabricante = "Yamaha", Tipo = "moto" });
        });

        modelBuilder.Entity<Parqueo>(entity =>
        {
            entity.ToTable("PRQ_Parqueo");
            entity.HasKey(parqueo => parqueo.Id);
            entity.Property(parqueo => parqueo.NombreProvincia).IsRequired();
            entity.Property(parqueo => parqueo.Nombre).IsRequired();
            entity.Property(parqueo => parqueo.PrecioPorHora).HasPrecision(10, 2);
            entity.HasData(
                new Parqueo { Id = 1, NombreProvincia = "San José", Nombre = "Parqueo Central", PrecioPorHora = 1200m },
                new Parqueo { Id = 2, NombreProvincia = "Alajuela", Nombre = "Parqueo Aeropuerto", PrecioPorHora = 1500m },
                new Parqueo { Id = 3, NombreProvincia = "Cartago", Nombre = "Parqueo Basílica", PrecioPorHora = 1000m },
                new Parqueo { Id = 4, NombreProvincia = "Heredia", Nombre = "Parqueo del Café", PrecioPorHora = 1100m },
                new Parqueo { Id = 5, NombreProvincia = "Guanacaste", Nombre = "Parqueo Tamarindo", PrecioPorHora = 1800m },
                new Parqueo { Id = 6, NombreProvincia = "Puntarenas", Nombre = "Parqueo del Puerto", PrecioPorHora = 1300m },
                new Parqueo { Id = 7, NombreProvincia = "Limón", Nombre = "Parqueo Caribe", PrecioPorHora = 1250m },
                new Parqueo { Id = 8, NombreProvincia = "San José", Nombre = "Parqueo Escazú", PrecioPorHora = 1600m });
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.ToTable("PRQ_Ingreso");
            entity.HasKey(ingreso => ingreso.Consecutivo);
            entity.HasOne(ingreso => ingreso.Parqueo)
                .WithMany(parqueo => parqueo.Ingresos)
                .HasForeignKey(ingreso => ingreso.ParqueoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(ingreso => ingreso.Automovil)
                .WithMany(automovil => automovil.Ingresos)
                .HasForeignKey(ingreso => ingreso.AutomovilId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasData(
                new Ingreso { Consecutivo = 1, ParqueoId = 1, AutomovilId = 1, FechaHoraEntrada = new DateTime(2026, 10, 20, 8, 0, 0), FechaHoraSalida = new DateTime(2026, 10, 20, 10, 0, 0) },
                new Ingreso { Consecutivo = 2, ParqueoId = 2, AutomovilId = 2, FechaHoraEntrada = new DateTime(2026, 10, 20, 9, 15, 0), FechaHoraSalida = new DateTime(2026, 10, 20, 11, 0, 0) },
                new Ingreso { Consecutivo = 3, ParqueoId = 3, AutomovilId = 3, FechaHoraEntrada = new DateTime(2026, 10, 21, 7, 30, 0), FechaHoraSalida = new DateTime(2026, 10, 21, 9, 0, 0) },
                new Ingreso { Consecutivo = 4, ParqueoId = 4, AutomovilId = 4, FechaHoraEntrada = new DateTime(2026, 10, 21, 12, 0, 0), FechaHoraSalida = new DateTime(2026, 10, 21, 13, 30, 0) },
                new Ingreso { Consecutivo = 5, ParqueoId = 5, AutomovilId = 5, FechaHoraEntrada = new DateTime(2026, 10, 22, 10, 0, 0), FechaHoraSalida = null },
                new Ingreso { Consecutivo = 6, ParqueoId = 6, AutomovilId = 6, FechaHoraEntrada = new DateTime(2026, 10, 22, 14, 45, 0), FechaHoraSalida = null },
                new Ingreso { Consecutivo = 7, ParqueoId = 7, AutomovilId = 7, FechaHoraEntrada = new DateTime(2026, 10, 23, 8, 20, 0), FechaHoraSalida = null },
                new Ingreso { Consecutivo = 8, ParqueoId = 8, AutomovilId = 8, FechaHoraEntrada = new DateTime(2026, 10, 23, 16, 10, 0), FechaHoraSalida = null });
        });
    }
}
