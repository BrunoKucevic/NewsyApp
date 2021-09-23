using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.EntityConfigurations
{
    public class AppUserArticleConfiguration : IEntityTypeConfiguration<AppUserArticle>
    {
        public void Configure(EntityTypeBuilder<AppUserArticle> builder)
        {
            builder.HasKey(k => new { k.AppUserId, k.ArticleId });

            builder
                .HasOne(x => x.AppUser)
                .WithMany(y => y.Articles)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Article)
                .WithMany(y => y.AppUsers)
                .HasForeignKey(x => x.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("AppUserArticles");
        }
    }
}
