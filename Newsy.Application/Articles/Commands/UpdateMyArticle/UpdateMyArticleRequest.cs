using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Articles.Commands.UpdateMyArticle
{
    public class UpdateMyArticleRequest : IRequest<UpdateMyArticleViewModel>
    {
        public Guid ArticleId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public bool? Archive { get; set; }
    }
}
