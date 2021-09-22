using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public Role Role { get; set; }
    }
}
