﻿// <auto-generated />
using System;
using CookSupp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookSupp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookSupp.Models.Fridge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("CookSupp.Models.FridgeProduct", b =>
                {
                    b.Property<int>("FridgeId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("FridgeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProducts");
                });

            modelBuilder.Entity("CookSupp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Flour"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bread"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rice"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sugar"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Salt"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Oats"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cornmeal"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Barley"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Quinoa"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Buckwheat"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Millet"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Semolina"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Breadcrumbs"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Cornstarch"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Whole Wheat Flour"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Brown Rice"
                        },
                        new
                        {
                            Id = 18,
                            Name = "White Bread"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Yeast"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Couscous"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Polenta"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Rye Flour"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Spaghetti"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Macaroni"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Baguette"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Pita Bread"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Focaccia"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Tortilla"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Bagels"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Rolls"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Sourdough Bread"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Biscuits"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Croissants"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Doughnuts"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Muffins"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Cornbread"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Crackers"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Pretzels"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Naan"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Ciabatta"
                        },
                        new
                        {
                            Id = 41,
                            Name = "English Muffins"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Flatbread"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Bran Flakes"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Rice Cakes"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Multigrain Bread"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Pumpernickel"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Brioche"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Kaiser Rolls"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Challah"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Soda Bread"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Wheat Bran"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Rye Bread"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Corn Tortilla"
                        },
                        new
                        {
                            Id = 54,
                            Name = "Graham Crackers"
                        },
                        new
                        {
                            Id = 55,
                            Name = "Wonton Wrappers"
                        },
                        new
                        {
                            Id = 56,
                            Name = "Panko"
                        },
                        new
                        {
                            Id = 57,
                            Name = "Potato Bread"
                        },
                        new
                        {
                            Id = 58,
                            Name = "Sushi Rice"
                        },
                        new
                        {
                            Id = 59,
                            Name = "Basmati Rice"
                        },
                        new
                        {
                            Id = 60,
                            Name = "Jasmine Rice"
                        },
                        new
                        {
                            Id = 61,
                            Name = "Arborio Rice"
                        },
                        new
                        {
                            Id = 62,
                            Name = "Glutinous Rice"
                        },
                        new
                        {
                            Id = 63,
                            Name = "Instant Rice"
                        },
                        new
                        {
                            Id = 64,
                            Name = "Wild Rice"
                        },
                        new
                        {
                            Id = 65,
                            Name = "Brown Bread"
                        },
                        new
                        {
                            Id = 66,
                            Name = "Oatmeal"
                        },
                        new
                        {
                            Id = 67,
                            Name = "Steel-Cut Oats"
                        },
                        new
                        {
                            Id = 68,
                            Name = "Quick Oats"
                        },
                        new
                        {
                            Id = 69,
                            Name = "Rolled Oats"
                        },
                        new
                        {
                            Id = 70,
                            Name = "Granola"
                        },
                        new
                        {
                            Id = 71,
                            Name = "Muesli"
                        },
                        new
                        {
                            Id = 72,
                            Name = "Grits"
                        },
                        new
                        {
                            Id = 73,
                            Name = "Ramen Noodles"
                        },
                        new
                        {
                            Id = 74,
                            Name = "Udon Noodles"
                        },
                        new
                        {
                            Id = 75,
                            Name = "Rice Noodles"
                        },
                        new
                        {
                            Id = 76,
                            Name = "Soba Noodles"
                        },
                        new
                        {
                            Id = 77,
                            Name = "Linguine"
                        },
                        new
                        {
                            Id = 78,
                            Name = "Fettuccine"
                        },
                        new
                        {
                            Id = 79,
                            Name = "Rigatoni"
                        },
                        new
                        {
                            Id = 80,
                            Name = "Orzo"
                        },
                        new
                        {
                            Id = 81,
                            Name = "Shells"
                        },
                        new
                        {
                            Id = 82,
                            Name = "Rotini"
                        },
                        new
                        {
                            Id = 83,
                            Name = "Tortellini"
                        },
                        new
                        {
                            Id = 84,
                            Name = "Gnocchi"
                        },
                        new
                        {
                            Id = 85,
                            Name = "Cannelloni"
                        },
                        new
                        {
                            Id = 86,
                            Name = "Ziti"
                        },
                        new
                        {
                            Id = 87,
                            Name = "Manicotti"
                        },
                        new
                        {
                            Id = 88,
                            Name = "Angel Hair Pasta"
                        },
                        new
                        {
                            Id = 89,
                            Name = "Lasagna Noodles"
                        },
                        new
                        {
                            Id = 90,
                            Name = "Farfalle"
                        },
                        new
                        {
                            Id = 91,
                            Name = "Gemelli"
                        },
                        new
                        {
                            Id = 92,
                            Name = "Capellini"
                        },
                        new
                        {
                            Id = 93,
                            Name = "Bucatini"
                        },
                        new
                        {
                            Id = 94,
                            Name = "Radiatori"
                        },
                        new
                        {
                            Id = 95,
                            Name = "Ditalini"
                        },
                        new
                        {
                            Id = 96,
                            Name = "Acini di Pepe"
                        },
                        new
                        {
                            Id = 97,
                            Name = "Cavatappi"
                        },
                        new
                        {
                            Id = 98,
                            Name = "Campanelle"
                        },
                        new
                        {
                            Id = 99,
                            Name = "Anelli"
                        },
                        new
                        {
                            Id = 100,
                            Name = "Strozzapreti"
                        });
                });

            modelBuilder.Entity("CookSupp.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CookSupp.Models.RecipeProduct", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int?>("RecipeStepId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeStepId");

                    b.ToTable("RecipeProduct");
                });

            modelBuilder.Entity("CookSupp.Models.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CookSupp.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CookSupp.Models.Fridge", b =>
                {
                    b.HasOne("CookSupp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CookSupp.Models.FridgeProduct", b =>
                {
                    b.HasOne("CookSupp.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookSupp.Models.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CookSupp.Models.Recipe", b =>
                {
                    b.HasOne("CookSupp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CookSupp.Models.RecipeProduct", b =>
                {
                    b.HasOne("CookSupp.Models.Product", "Product")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookSupp.Models.Recipe", "Recipe")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CookSupp.Models.RecipeStep", null)
                        .WithMany("RecipeProducts")
                        .HasForeignKey("RecipeStepId");

                    b.Navigation("Product");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CookSupp.Models.RecipeStep", b =>
                {
                    b.HasOne("CookSupp.Models.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CookSupp.Models.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("CookSupp.Models.Product", b =>
                {
                    b.Navigation("FridgeProducts");

                    b.Navigation("RecipeProducts");
                });

            modelBuilder.Entity("CookSupp.Models.Recipe", b =>
                {
                    b.Navigation("RecipeProducts");

                    b.Navigation("RecipeSteps");
                });

            modelBuilder.Entity("CookSupp.Models.RecipeStep", b =>
                {
                    b.Navigation("RecipeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
