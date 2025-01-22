using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Groupwork.Models;

public partial class ParkmanContext : DbContext
{
    public ParkmanContext()
    {
    }

    public ParkmanContext(DbContextOptions<ParkmanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ParkingLot> ParkingLots { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NEMOSENSEI\\SQLEXPRESS;Database=parkman;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingLot>(entity =>
        {
            entity.HasKey(e => e.LotId).HasName("PK__ParkingL__4160EF4DFCCCB1F1");

            entity.ToTable("ParkingLot");

            entity.Property(e => e.LotId).HasColumnName("LotID");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F0414FF306D");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.LotId).HasColumnName("LotID");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

            entity.HasOne(d => d.Lot).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.LotId)
                .HasConstraintName("FK__Reservati__LotID__4F7CD00D");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Reservati__Vehic__4E88ABD4");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__476B54B2968BA29D");

            entity.ToTable("Vehicle");

            entity.HasIndex(e => e.LicensePlate, "UQ__Vehicle__026BC15CA3FB59DC").IsUnique();

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OwnerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
