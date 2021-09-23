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
            "2de02010-b551-4362-adb3-a5bbcf25eebb"
        };
        public static void SeedInitialData(ModelBuilder builder)
        {
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Name = RolesConsts.Admin, NormalizedName = RolesConsts.Admin.ToUpper(), Id = new Guid(RolesGuids[0]) },
                new Role { Name = RolesConsts.Author, NormalizedName = RolesConsts.Author.ToUpper(), Id = new Guid(RolesGuids[1]) },
                new Role { Name = RolesConsts.RegularUser, NormalizedName = RolesConsts.RegularUser.ToUpper(), Id = new Guid(RolesGuids[2]) }
            );
        }
    }
}
