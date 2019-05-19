using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GraphDesignApp
{
    public class GraphicDesignContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<GraphicDesign> GraphicDesigns { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GraphicDesign19;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity
                    .HasKey(e => e.EmailAddress)
                    .HasName("PK_UserAccounts");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .IsRequired();
            });

            modelBuilder.Entity<GraphicDesign>(entity =>
            {
                entity.HasKey(e => e.GraphicDesignId)
                    .HasName("PK_GraphicDesigns");

                entity.Property(e => e.GraphicDesignId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UnitPrice)
                    .IsRequired();

                entity.Property(e => e.ShippingType)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.EmailAddress);
            });
        }
    }
}
