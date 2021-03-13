using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Models
{
    public class SatioDbContext : DbContext
    {
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Warning> Warning { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<BlockedWord> BlockedWord { get; set; }
        public DbSet<RegisteredUserRecipe> RegisteredUserRecipe { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<RecipeWarning> RecipeWarning { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisteredUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.LastName)
               .HasMaxLength(15)
               .IsUnicode(false)
               .IsRequired();

                entity.Property(e => e.ProfilePicture)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();


                entity.Property(e => e.Email)
              .HasMaxLength(100)
              .IsUnicode(false)
              .IsRequired();

            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Steps)
               .HasMaxLength(255)
               .IsUnicode(false)
               .IsRequired();

                entity.Property(e => e.PrepTime)
              .IsRequired();

                entity.Property(e => e.Difficulty)
             .IsRequired(); 
                
                entity.Property(e => e.Rating)
              .IsRequired();

            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.YouTube)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Instagram)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Twitter)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();

                entity.Property(e => e.Facebok)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();

                 entity.Property(e => e.WebPage)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantity)
            .IsRequired();

            });

            modelBuilder.Entity<Warning>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ThreatLevel)
            .IsRequired();

                entity.Property(e => e.Description)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
              .HasMaxLength(255)
              .IsUnicode(false)
              .IsRequired();
            });

            modelBuilder.Entity<RegisteredUserRecipe>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdRecipe)
            .IsRequired();

                entity.Property(e => e.IdRegisteredUser)
            .IsRequired();

                entity.HasOne(e => e.RegisteredUser)
                .WithMany(y => y.RegisteredUserRecipe);

            });


            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdRecipe)
            .IsRequired();

                entity.Property(e => e.IdIngredient)
            .IsRequired();

            });


            modelBuilder.Entity<RecipeWarning>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IdRecipe)
            .IsRequired();

                entity.Property(e => e.IdWarning)
            .IsRequired();

            });




        }
    }
}
}
