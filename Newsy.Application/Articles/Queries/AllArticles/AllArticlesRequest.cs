using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Articles.Queries.AllArticles
{
    public class AllArticlesRequest : IRequest<AllArticlesViewModel>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
