using Data.Configurations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new NewsCategoryConfiguration());
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new NewsPhotoConfiguration());

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsPhoto> NewsPhotos { get; set; }


    }
}
