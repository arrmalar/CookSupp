using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CookSupp.Models;

namespace CookSupp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FridgeProduct>()
            .HasKey(fp => new { fp.FridgeId, fp.ProductId });

            modelBuilder.Entity<FridgeProduct>()
                .HasOne(fp => fp.Fridge)
                .WithMany(f => f.FridgeProducts)
                .HasForeignKey(fp => fp.FridgeId);

            modelBuilder.Entity<FridgeProduct>()
                .HasOne(fp => fp.Product)
                .WithMany(p => p.FridgeProducts)
                .HasForeignKey(fp => fp.ProductId);

            modelBuilder.Entity<RecipeProduct>()
            .HasKey(fp => new { fp.RecipeId, fp.ProductId });

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(fp => fp.Recipe)
                .WithMany(f => f.RecipeProducts)
                .HasForeignKey(fp => fp.RecipeId);

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(fp => fp.Product)
                .WithMany(p => p.RecipeProducts)
                .HasForeignKey(fp => fp.ProductId);

            modelBuilder.Entity<RecipeStep>().HasData();

            modelBuilder.Entity<Recipe>().HasData();

            modelBuilder.Entity<Fridge>().HasData();

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Flour" },
                new Product { Id = 2, Name = "Pasta" },
                new Product { Id = 3, Name = "Bread" },
                new Product { Id = 4, Name = "Rice" },
                new Product { Id = 5, Name = "Sugar" },
                new Product { Id = 6, Name = "Salt" },
                new Product { Id = 7, Name = "Oats" },
                new Product { Id = 8, Name = "Cornmeal" },
                new Product { Id = 9, Name = "Barley" },
                new Product { Id = 10, Name = "Quinoa" },
                new Product { Id = 11, Name = "Buckwheat" },
                new Product { Id = 12, Name = "Millet" },
                new Product { Id = 13, Name = "Semolina" },
                new Product { Id = 14, Name = "Breadcrumbs" },
                new Product { Id = 15, Name = "Cornstarch" },
                new Product { Id = 16, Name = "Whole Wheat Flour" },
                new Product { Id = 17, Name = "Brown Rice" },
                new Product { Id = 18, Name = "White Bread" },
                new Product { Id = 19, Name = "Yeast" },
                new Product { Id = 20, Name = "Couscous" },
                new Product { Id = 21, Name = "Polenta" },
                new Product { Id = 22, Name = "Rye Flour" },
                new Product { Id = 23, Name = "Spaghetti" },
                new Product { Id = 24, Name = "Macaroni" },
                new Product { Id = 25, Name = "Baguette" },
                new Product { Id = 26, Name = "Pita Bread" },
                new Product { Id = 27, Name = "Focaccia" },
                new Product { Id = 28, Name = "Tortilla" },
                new Product { Id = 29, Name = "Bagels" },
                new Product { Id = 30, Name = "Rolls" },
                new Product { Id = 31, Name = "Sourdough Bread" },
                new Product { Id = 32, Name = "Biscuits" },
                new Product { Id = 33, Name = "Croissants" },
                new Product { Id = 34, Name = "Doughnuts" },
                new Product { Id = 35, Name = "Muffins" },
                new Product { Id = 36, Name = "Cornbread" },
                new Product { Id = 37, Name = "Crackers" },
                new Product { Id = 38, Name = "Pretzels" },
                new Product { Id = 39, Name = "Naan" },
                new Product { Id = 40, Name = "Ciabatta" },
                new Product { Id = 41, Name = "English Muffins" },
                new Product { Id = 42, Name = "Flatbread" },
                new Product { Id = 43, Name = "Bran Flakes" },
                new Product { Id = 44, Name = "Rice Cakes" },
                new Product { Id = 45, Name = "Multigrain Bread" },
                new Product { Id = 46, Name = "Pumpernickel" },
                new Product { Id = 47, Name = "Brioche" },
                new Product { Id = 48, Name = "Kaiser Rolls" },
                new Product { Id = 49, Name = "Challah" },
                new Product { Id = 50, Name = "Soda Bread" },
                new Product { Id = 51, Name = "Wheat Bran" },
                new Product { Id = 52, Name = "Rye Bread" },
                new Product { Id = 53, Name = "Corn Tortilla" },
                new Product { Id = 54, Name = "Graham Crackers" },
                new Product { Id = 55, Name = "Wonton Wrappers" },
                new Product { Id = 56, Name = "Panko" },
                new Product { Id = 57, Name = "Potato Bread" },
                new Product { Id = 58, Name = "Sushi Rice" },
                new Product { Id = 59, Name = "Basmati Rice" },
                new Product { Id = 60, Name = "Jasmine Rice" },
                new Product { Id = 61, Name = "Arborio Rice" },
                new Product { Id = 62, Name = "Glutinous Rice" },
                new Product { Id = 63, Name = "Instant Rice" },
                new Product { Id = 64, Name = "Wild Rice" },
                new Product { Id = 65, Name = "Brown Bread" },
                new Product { Id = 66, Name = "Oatmeal" },
                new Product { Id = 67, Name = "Steel-Cut Oats" },
                new Product { Id = 68, Name = "Quick Oats" },
                new Product { Id = 69, Name = "Rolled Oats" },
                new Product { Id = 70, Name = "Granola" },
                new Product { Id = 71, Name = "Muesli" },
                new Product { Id = 72, Name = "Grits" },
                new Product { Id = 73, Name = "Ramen Noodles" },
                new Product { Id = 74, Name = "Udon Noodles" },
                new Product { Id = 75, Name = "Rice Noodles" },
                new Product { Id = 76, Name = "Soba Noodles" },
                new Product { Id = 77, Name = "Linguine" },
                new Product { Id = 78, Name = "Fettuccine" },
                new Product { Id = 79, Name = "Rigatoni" },
                new Product { Id = 80, Name = "Orzo" },
                new Product { Id = 81, Name = "Shells" },
                new Product { Id = 82, Name = "Rotini" },
                new Product { Id = 83, Name = "Tortellini" },
                new Product { Id = 84, Name = "Gnocchi" },
                new Product { Id = 85, Name = "Cannelloni" },
                new Product { Id = 86, Name = "Ziti" },
                new Product { Id = 87, Name = "Manicotti" },
                new Product { Id = 88, Name = "Angel Hair Pasta" },
                new Product { Id = 89, Name = "Lasagna Noodles" },
                new Product { Id = 90, Name = "Farfalle" },
                new Product { Id = 91, Name = "Gemelli" },
                new Product { Id = 92, Name = "Capellini" },
                new Product { Id = 93, Name = "Bucatini" },
                new Product { Id = 94, Name = "Radiatori" },
                new Product { Id = 95, Name = "Ditalini" },
                new Product { Id = 96, Name = "Acini di Pepe" },
                new Product { Id = 97, Name = "Cavatappi" },
                new Product { Id = 98, Name = "Campanelle" },
                new Product { Id = 99, Name = "Anelli" },
                new Product { Id = 100, Name = "Strozzapreti" }
            );
        }
    }
}
