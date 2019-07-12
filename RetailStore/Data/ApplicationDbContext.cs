using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailStore.Domain;
using RetailStore.Models;

namespace RetailStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict).IsRequired();

            builder.Entity<Product>().HasKey(x => x.Id);
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            base.OnModelCreating(builder);
        }

        public DbSet<RetailStore.Models.ProductViewModel> ProductViewModel { get; set; }
    }
}
