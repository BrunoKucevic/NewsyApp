using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.EntityConfigurations
{
    public class AppUserRoleEntityConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder
                .HasOne(uc => uc.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(uc => uc.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //table
            builder.ToTable("AppUserRoles");
        }
    }
}
