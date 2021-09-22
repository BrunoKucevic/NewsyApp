using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Entities
{
    public partial class Role : IdentityRole<Guid>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
