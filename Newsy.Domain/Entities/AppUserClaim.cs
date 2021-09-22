using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
        public virtual AppUser User { get; set; }
    }
}
