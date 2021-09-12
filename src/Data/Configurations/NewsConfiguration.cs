using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {

            builder
               .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
              .Property(m => m.Status)
              .IsRequired()
              .HasDefaultValue(true);

            builder
                .Property(m => m.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder
               .Property(m => m.Text)
               .HasMaxLength(1000)
               .IsRequired();

            builder.ToTable("News");
        }
    }
}
