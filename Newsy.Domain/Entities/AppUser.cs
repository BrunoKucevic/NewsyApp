using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public DateTime? ArchivingDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool Archived { get; set; }
        public DateTime LastPasswordChangeDateTime { get; set; }

        public virtual ICollection<AppUserClaim> Claims { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<AppUserLogin> Logins { get; set; }
        public virtual ICollection<AppUserToken> Tokens { get; set; }
    }
}
