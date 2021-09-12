using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
               .HasOne<Category>(m => m.Category)
               .WithMany(m => m.NewsCategories)
               .HasForeignKey(m => m.CategoryId);

            builder
              .HasOne<News>(m => m.News)
              .WithMany(m => m.NewsCategories)
              .HasForeignKey(m => m.NewsId);

            builder.ToTable("NewsCategories");
        }
    }
}
