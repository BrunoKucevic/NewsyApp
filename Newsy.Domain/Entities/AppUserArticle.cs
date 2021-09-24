using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class AppUserArticle
    {
        [ForeignKey("AppUserId")]
        public Guid AppUserId { get; set; }
        public Guid ArticleId { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual Article Article { get; set; }
    }
}
