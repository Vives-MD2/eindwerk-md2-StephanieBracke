// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VidyaBase.DAL;

namespace VidyaBase.DAL.Migrations
{
    [DbContext(typeof(VidyaContext))]
    partial class VidyaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VidyaBase.DOMAIN.Achievement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Collection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.CollectionOwnedGame", b =>
                {
                    b.Property<int>("CollectionID")
                        .HasColumnType("int");

                    b.Property<int>("OwnedGamesID")
                        .HasColumnType("int");

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.HasKey("CollectionID", "OwnedGamesID");

                    b.HasIndex("GameID");

                    b.HasIndex("OwnedGamesID");

                    b.ToTable("CollectionOwnedGame");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.HasKey("ID");

                    b.HasIndex("EAN")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.GameCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.GamePublisher", b =>
                {
                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("PublisherID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("GamePublisher");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.OwnedGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("UserID");

                    b.ToTable("OwnedGame");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.UserAchievement", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("AchievementID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "AchievementID");

                    b.HasIndex("AchievementID");

                    b.ToTable("UserAchievement");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Wishlist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("Note")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Your hopes and dreams go here");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.WishlistGame", b =>
                {
                    b.Property<int>("WishlistID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("WishlistID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("WishlistGame");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Achievement", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.User", null)
                        .WithMany("Achievements")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Collection", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.CollectionOwnedGame", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Collection", "Collection")
                        .WithMany("CollectionOwnedGames")
                        .HasForeignKey("CollectionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.Game", null)
                        .WithMany("OwnedGamesCollection")
                        .HasForeignKey("GameID");

                    b.HasOne("VidyaBase.DOMAIN.OwnedGame", "OwnedGame")
                        .WithMany("CollectionOwnedGames")
                        .HasForeignKey("OwnedGamesID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.GameCategory", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Category", "Category")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.Game", "GameCat")
                        .WithMany("GameCategories")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.GamePublisher", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Game", "Game")
                        .WithMany("GamePublishers")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.Publisher", "Publisher")
                        .WithMany("GamePublishers")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.OwnedGame", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Game", "Game")
                        .WithMany("OwnedGames")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.User", "User")
                        .WithMany("OwnedGames")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.UserAchievement", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Achievement", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.User", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.Wishlist", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.User", null)
                        .WithMany("Wishlists")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VidyaBase.DOMAIN.WishlistGame", b =>
                {
                    b.HasOne("VidyaBase.DOMAIN.Game", "Game")
                        .WithMany("WishlistGames")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VidyaBase.DOMAIN.Wishlist", "Wishlist")
                        .WithMany("WishlistGames")
                        .HasForeignKey("WishlistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
