using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.ViewModels.Articles
{
    public class GetAllArticlesViewModel
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
