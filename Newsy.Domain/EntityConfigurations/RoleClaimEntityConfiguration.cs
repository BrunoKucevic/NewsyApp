using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.EntityConfigurations
{
    public class RoleClaimEntityConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder
                .HasOne(rc => rc.Role)
                .WithMany(r => r.RoleClaims)
                .HasForeignKey(rc => rc.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            //table
            builder.ToTable("RoleClaims");
        }
    }
}
