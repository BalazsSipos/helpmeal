using helpmeal.Models;
using helpmeal.Models.Identity;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<ShoppingDaysOfWeek> ShoppingDaysOfWeeks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
        }
    }
}
