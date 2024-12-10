using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace IMTIRED.Models;

public partial class TlS2302374webContext : DbContext
{
    public TlS2302374webContext()
    {
    }

    public TlS2302374webContext(DbContextOptions<TlS2302374webContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketbooking> Ticketbookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(
            "name=MySqlConnection",  // Ensure this is the same key in appsettings.json
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attraction");

            entity.Property(e => e.AttractionId).HasColumnName("attractionId");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.RoomNumber, "RoomNumber").IsUnique();

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.IsAvailable).HasDefaultValueSql("'1'");
            entity.Property(e => e.PricePerNight).HasPrecision(10, 2);
            entity.Property(e => e.RoomType).HasMaxLength(50);
        });

        modelBuilder.Entity<Roombooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("roombookings");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.RoomId, "RoomID");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingStatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Booked'");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.TotalPrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Customer).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_1");

            entity.HasOne(d => d.Room).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_2");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("tickets");

            entity.Property(e => e.TicketId).HasColumnName("ticketId");
            entity.Property(e => e.AttractionId).HasColumnName("attractionId");
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingId");
        });

        modelBuilder.Entity<Ticketbooking>(entity =>
        {
            entity.HasKey(e => e.TicketbookingId).HasName("PRIMARY");

            entity.ToTable("ticketbooking");

            entity.HasIndex(e => e.CustomerId, "ticketbooking_fk1_idx");

            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateBooked).HasColumnName("dateBooked");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ticketbookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticketbooking_fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
