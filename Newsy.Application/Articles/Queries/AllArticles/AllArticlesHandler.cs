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

            var articles =
                await _context.AppUserArticles
                .AsNoTracking()
                .Include(i => i.Article).Where(a => !a.Article.Archived)
                .Include(a => a.AppUser)
                .Select(x => x.Map(new GetAllArticlesViewModel()))
                .ToListAsync(cancellationToken);
            res.Data.AddRange(articles);

            return res;
        }
    }
}
