using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<AppUserArticle> AppUsers { get; set; }
    }
}
