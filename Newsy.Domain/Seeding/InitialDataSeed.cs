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

        private static readonly List<string> UserGuids = new List<string>
        {
            "8D113B3C-54E5-4614-98FB-41BFB8596F51",//author
            "3172FDF5-9F76-40CA-8331-DBD94963F9EF",//admin
            "FB2F4E2B-8C69-490F-A65D-E4921491260A"//regular
        };

        public static void SeedInitialData(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedRoleClaims(builder);
            SeedUserRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Name = RolesConsts.Admin, NormalizedName = RolesConsts.Admin.ToUpper(), Id = new Guid(RolesGuids[0]) },
                new Role { Name = RolesConsts.Author, NormalizedName = RolesConsts.Author.ToUpper(), Id = new Guid(RolesGuids[1]) },
                new Role { Name = RolesConsts.RegularUser, NormalizedName = RolesConsts.RegularUser.ToUpper(), Id = new Guid(RolesGuids[2]) }
            );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<AppUserRole>()
                .HasData(
                new AppUserRole
                {
                    RoleId = new Guid(RolesGuids[0]),
                    UserId = new Guid(UserGuids[1])
                },
                new AppUserRole
                {
                    RoleId = new Guid(RolesGuids[1]),
                    UserId = new Guid(UserGuids[0])
                }, new AppUserRole
                {
                    RoleId = new Guid(RolesGuids[2]),
                    UserId = new Guid(UserGuids[2])
                }
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
                        },
                        new RoleClaim
                        {
                            Id = 3,
                            ClaimType = "RegularUser",
                            ClaimValue = "true",
                            RoleId = new Guid(RolesGuids[2])
                        }
            );
        }
    }
}
