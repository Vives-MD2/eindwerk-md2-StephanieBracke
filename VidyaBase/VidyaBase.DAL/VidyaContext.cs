using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VidyaBase.DOMAIN;

namespace VidyaBase.DAL
{
    class VidyaContext : DbContext
    {
        //<MoetNogIngevuldWorden>
        public static string LocalConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=<MoetNogIngevuldWorden>;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string OnlineConnectionString { get; set; } = @"";

        public VidyaContext()
        {
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocalConnectionString);
            //optionsBuilder.UseSqlServer(OnlineConnectionString);
            //optionsBuilder.EnableSensitiveDataLogging(true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/generated-properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region IGNORE
            modelBuilder.Ignore<GObject>();
            modelBuilder.Ignore<VidyaException>();
            modelBuilder.Ignore<Exception>();
            #endregion

            #region PRIMARY KEYS
            modelBuilder.Entity<User>()
                    .HasKey(x => x.ID);
            modelBuilder.Entity<Game>()
                    .HasKey(x => x.ID);
            #endregion

            #region UNIQUE KEYS
            modelBuilder.Entity<User>()
                    .HasIndex(x => x.Email)
                    .IsUnique();
            #endregion

            #region User

            modelBuilder.Entity<User>()
                    .Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
            modelBuilder.Entity<User>()
                    .Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            modelBuilder.Entity<User>()
                    .Property(x => x.DateOfBirth)
                    .HasColumnType("datetime")
                    .IsRequired();
            #endregion

            #region Game
            modelBuilder.Entity<Game>()
                    .Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(75);
            //definitely needs to be double checked
            modelBuilder.Entity<Game>()
                    .Property(x => x.EAN)
                    .IsRequired();
            #endregion

            #region Achievements
            modelBuilder.Entity<Achievement>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            #endregion

            #region Collections
            modelBuilder.Entity<Collection>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            #endregion

            #region Wishlists
            modelBuilder.Entity<Wishlist>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            #endregion

            #region MANY-TO-MANY
            modelBuilder.Entity<Collection>()
                    .HasKey(x => new { x.ID, x.UserID});

            modelBuilder.Entity<Achievement>()
                    .HasKey(x => new { x.ID, x.UserID });

            modelBuilder.Entity<Wishlist>()
                    .HasKey(x => new { x.ID, x.UserID });

            modelBuilder.Entity<UserGameCollection>()
                .HasOne(x => x.CollectionID)
                .WithMany(c => .)
                .HasForeignKey();

            modelBuilder.Entity<OwnedGame>()
                .HasOne(x => x.GameID)
                .WithMany()
                .HasForeignKey();
            #endregion
        }
    }
}
