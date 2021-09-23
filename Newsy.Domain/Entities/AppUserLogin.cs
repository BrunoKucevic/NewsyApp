using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
        public virtual AppUser User { get; set; }
    }
}
