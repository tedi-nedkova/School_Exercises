using Microsoft.EntityFrameworkCore;
using NationalPark.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Data
{
    public class NationalParkDbContext : DbContext
    {
        public NationalParkDbContext()
        {

        }

        public NationalParkDbContext(DbContextOptions<NationalParkDbContext> options)
                : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT19;Database=NationalPark;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>(entity =>
            {
                entity.Property(z => z.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(z => z.AreaHa)
                      .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<PlantSpecies>(entity =>
            {
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasIndex(p => p.LatinName).IsUnique();
            });

            modelBuilder.Entity<ZonePlant>(entity =>
            {
                entity.HasOne(zp => zp.Zone)
                      .WithMany(z => z.ZonePlants)
                      .HasForeignKey(zp => zp.ZoneId);

                entity.HasOne(zp => zp.PlantSpecies)
                      .WithMany(p => p.ZonePlants)
                      .HasForeignKey(zp => zp.PlantId);

                entity.HasIndex(zp => new { zp.ZoneId, zp.PlantId }).IsUnique();

                entity.Property(zp => zp.Density)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.HasCheckConstraint("CK_ZonePlant_Density",
                    "[density] IN ('rare', 'medium', 'common')");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(f => f.Type).IsRequired();
                entity.Property(f => f.Condition)
                      .IsRequired()
                      .HasDefaultValue("good");

                entity.HasOne(f => f.Zone)
                      .WithMany(z => z.Facilities)
                      .HasForeignKey(f => f.ZoneId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }
            }

        }
    }
}
