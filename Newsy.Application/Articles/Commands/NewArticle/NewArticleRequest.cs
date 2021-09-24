using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Articles.Commands.NewArticle
{
    public class NewArticleRequest : IRequest<NewArticleViewModel>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
