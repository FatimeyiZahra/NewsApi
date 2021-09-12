using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
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
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();


            builder.ToTable("Categories");
        }
    }
}
