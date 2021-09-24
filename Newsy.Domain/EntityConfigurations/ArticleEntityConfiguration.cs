using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.EntityConfigurations
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.Title)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder
                .Property(prop => prop.Content)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.ToTable("Articles");
        }
    }
}
