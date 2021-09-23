using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Newsy.Domain.Entities
{
    [NotMapped]
    public class AppUserToken : IdentityUserToken<Guid>
    {
        public virtual AppUser User { get; set; }
    }
}
