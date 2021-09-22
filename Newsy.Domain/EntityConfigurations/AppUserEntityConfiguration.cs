using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.EntityConfigurations
{
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);

            //define fields
            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");


            builder
                .Property(u => u.ArchivingDate)
                .HasColumnType("datetime");

            builder
                .Property(u => u.Archived)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(0);

            builder
                .Property(u => u.Enabled)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(1);


            builder
                .Property(u => u.LastPasswordChangeDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CAST(GETDATE() AS Date)");



            //table
            builder.ToTable("AppUsers");
        }
    }
}
