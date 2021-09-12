using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class NewsPhotoConfiguration : IEntityTypeConfiguration<NewsPhoto>
    {
        public void Configure(EntityTypeBuilder<NewsPhoto> builder)
        {
            builder
                  .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(m => m.News)
                .WithMany(m => m.NewsPhotos)
                .HasForeignKey(m => m.NewsId);

            builder
                .Property(m => m.Photo)
                .HasMaxLength(100)
                .IsRequired();

            builder.ToTable("NewsPhotos");
        }
    }
}
