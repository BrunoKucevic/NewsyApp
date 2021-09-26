using ExpressMapper.Extensions;
using MediatR;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Articles;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newsy.Application.Shared.Extensions;
using Newsy.Application.Shared.Interfaces;

namespace Newsy.Application.Articles.Queries.AllArticles
{
    public class AllArticlesHandler : IRequestHandler<AllArticlesRequest, AllArticlesViewModel>
    {
        private readonly INewsyDbContext _context;

        public AllArticlesHandler(INewsyDbContext context)
        {
            _context = context;
        }

        public async Task<AllArticlesViewModel> Handle(AllArticlesRequest request, CancellationToken cancellationToken)
        {
            var res = new AllArticlesViewModel();

            var query =
                _context.AppUserArticles
                .AsNoTracking()
                .Include(i => i.Article)
                .Include(a => a.AppUser)
                .Where(a => !a.Article.Archived);

            query = query.PaginateQuery(request.PageSize, request.CurrentPage, res);

            var articles = await query.Select(x => x.Map(new GetAllArticlesViewModel()))
                .ToListAsync(cancellationToken);

            res.Data.AddRange(articles);

            return res;
        }
    }
}
