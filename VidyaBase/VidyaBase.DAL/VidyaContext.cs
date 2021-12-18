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
        public static string LocalConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VidyaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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

            modelBuilder.Entity<Collection>()
                .HasKey(c => c.ID);
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<Achievement>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<OwnedGame>()
                .HasKey(og => og.ID);
            modelBuilder.Entity<Wishlist>()
                .HasKey(w => w.ID);
            modelBuilder.Entity<Game>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Publisher>()
                .HasKey(p => p.ID);
            modelBuilder.Entity<Category>()
                .HasKey(c => c.ID);

            #endregion

            #region UNIQUE KEYS

            modelBuilder.Entity<User>()
                    .HasIndex(u => u.Email)
                    .IsUnique();
            modelBuilder.Entity<Achievement>()
                .HasIndex(a => a.Name)
                .IsUnique();
            modelBuilder.Entity<Game>()
                .HasIndex(g => g.EAN)
                .IsUnique();
            modelBuilder.Entity<Publisher>()
                .HasIndex(p => p.Name)
                .IsUnique();
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
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

            //foreign key collection_User_UserID -> (one-to-one) one user has one collection
            modelBuilder.Entity<User>()
            .HasOne<Collection>(x => x.Collection)
            .WithOne(x => x.User)
            .HasForeignKey<Collection>(x => x.UserID);
            #endregion

            #region Collection

            modelBuilder.Entity<Collection>()
                         .Property(x => x.Name)
                         .IsRequired()
                         .HasMaxLength(75);
            ////Foreign key to User
            //modelBuilder.Entity<Collection>()
            //    .HasOne(x => x.User)
            //    .WithOne(x => x.Collection)
            //    .HasForeignKey<User>(x => x.CollectionID);


            #endregion

            #region Achievement
            modelBuilder.Entity<Achievement>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            #endregion

            #region Wishlists
            modelBuilder.Entity<Wishlist>()
                    .Property(w => w.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            modelBuilder.Entity<Wishlist>()
                .Property(w => w.Note)
                .HasDefaultValue("Your hopes and dreams go here");
            #endregion

            #region Game
            modelBuilder.Entity<Game>()
                    .Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(75);
            modelBuilder.Entity<Game>()
                    .Property(x => x.EAN)
                    .IsRequired();
            #endregion



            #region MANY TO MANY UserAchievement

            modelBuilder.Entity<UserAchievement>()
                    .HasKey(ua => new { ua.UserID, ua.AchievementID });

            modelBuilder.Entity<UserAchievement>()
                .HasOne(u => u.User)
                .WithMany(l => l.UserAchievements)
                .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<UserAchievement>()
                .HasOne(x => x.Achievement)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(l => l.AchievementID);

            #endregion

            #region MANY TO MANY CollectionOwnedGame

            modelBuilder.Entity<CollectionOwnedGame>()
                    .HasKey(x => new { x.CollectionID, x.OwnedGamesID });

            modelBuilder.Entity<CollectionOwnedGame>()
                .HasOne(c => c.Collection)
                .WithMany(x => x.OwnedGames)
                .HasForeignKey(x => x.CollectionID);

            modelBuilder.Entity<CollectionOwnedGame>()
                .HasOne(x => x.OwnedGame)
                .WithMany(x => x.OwnedGamesCollection)
                .HasForeignKey(x => x.OwnedGamesID);

            #endregion

            #region WishlistGame

            modelBuilder.Entity<WishlistGame>()
                    .HasKey(x => new { x.WishlistID, x.GameID });

            modelBuilder.Entity<WishlistGame>()
                .HasOne(x => x.Wishlist)
                .WithMany(x => x.WishlistGames)
                .HasForeignKey(x => x.WishlistID);

            modelBuilder.Entity<WishlistGame>()
                .HasOne(x => x.Game)
                .WithMany(x => x.WishlistGames)
                .HasForeignKey(x => x.GameID);

            #endregion

            #region GameCategory

            modelBuilder.Entity<GameCategory>()
                .HasKey(x => new { x.CategoryID, x.GameID });

            modelBuilder.Entity<GameCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.GameCategories)
                .HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<GameCategory>()
                .HasOne(x => x.GameCat)
                .WithMany(x => x.GameCategories)
                .HasForeignKey(x => x.GameID);

            #endregion

            #region GamePublisher

            modelBuilder.Entity<GamePublisher>()
                .HasKey(x => new { x.PublisherID, x.GameID });

            modelBuilder.Entity<GamePublisher>()
                .HasOne(x => x.Publisher)
                .WithMany(x => x.GamePublishers)
                .HasForeignKey(x => x.PublisherID);

            modelBuilder.Entity<GamePublisher>()
                .HasOne(x => x.Game)
                .WithMany(x => x.GamePublishers)
                .HasForeignKey(x => x.GameID);

            #endregion

            //#region GamePublisher

            //modelBuilder.Entity<GamePublisher>()
            //    .HasKey(x => new { x.PublisherID, x.GameID });

            //modelBuilder.Entity<GamePublisher>()
            //    .HasOne(x => x.Publisher)
            //    .WithMany(x => x.GamePublishers)
            //    .HasForeignKey(x => x.PublisherID);

            //modelBuilder.Entity<GamePublisher>()
            //    .HasOne(x => x.Game)
            //    .WithMany(x => x.GamePublishers)
            //    .HasForeignKey(x => x.GameID);

            //#endregion

            #region MANY TO MANY OwnedGame

            modelBuilder.Entity<OwnedGame>()
                    .HasKey(x => new { x.UserID, x.GameID });

            modelBuilder.Entity<OwnedGame>()
                .HasOne(u => u.User)
                .WithMany(x => x.OwnedGames)
                .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<OwnedGame>()
                .HasOne(x => x.Game)
                .WithMany(x => x.OwnedGames)
                .HasForeignKey(x => x.GameID);

            #endregion



        }
    }
}
