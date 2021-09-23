using Microsoft.EntityFrameworkCore;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Seeding
{
    public class InitialDataSeed
    {
        private static readonly List<string> RolesGuids = new List<string>
        {
            "d83b41a7-1f4a-47ac-9834-ad18473c872a",
            "49ec873f-76a1-4ba4-87cd-63ba1316438f",
            "2de02010-b551-4362-adb3-a5bbcf25eebb",
            "1e969ee3-395c-4d71-8100-a1dd955431e7",
            "8c037fe7-7633-4e2f-b3e0-00a313e7d2e1",
            "f650d784-4673-4d82-8826-bc17078dfd8a",
            "a9dd386e-4cab-4082-9b89-cae8d53db863",
            "931a9d29-eee2-45bd-8fdd-b3b140b2c7b4",


        };
        public static void SeedInitialData(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedRoleClaims(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Name = RolesConsts.Admin, NormalizedName = RolesConsts.Admin.ToUpper(), Id = new Guid(RolesGuids[0]) },
                new Role { Name = RolesConsts.Author, NormalizedName = RolesConsts.Author.ToUpper(), Id = new Guid(RolesGuids[1]) },
                new Role { Name = RolesConsts.RegularUser, NormalizedName = RolesConsts.RegularUser.ToUpper(), Id = new Guid(RolesGuids[2]) }
            );
        }

        private static void SeedRoleClaims(ModelBuilder builder)
        {
            builder.Entity<RoleClaim>()
                .HasData(
                new RoleClaim
                {
                    Id = 1,
                    ClaimType = "Admin",
                    ClaimValue = "true",
                    RoleId = new Guid(RolesGuids[0])
                },
                new RoleClaim
                {
                    Id = 2,
                    ClaimType = "Author",
                    ClaimValue = "true",
                    RoleId = new Guid(RolesGuids[1])
                }
            );
        }
    }
}
