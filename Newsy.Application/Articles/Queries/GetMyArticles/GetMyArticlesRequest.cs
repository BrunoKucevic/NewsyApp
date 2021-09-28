using MediatR;
using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Articles.Queries.GetMyArticles
{
    public class GetMyArticlesRequest : IRequest<GetMyArticlesViewModel>, ICacheable
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string CacheKey => $"GetMyArticlesRequest{DateTime.Now.Hour}";
    }
}
