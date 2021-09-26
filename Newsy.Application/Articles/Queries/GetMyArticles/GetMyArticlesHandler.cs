using ExpressMapper.Extensions;
using MediatR;
using Newsy.Application.Shared.Extensions;
using Newsy.Application.Shared.Interfaces;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Articles;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Articles.Queries.GetMyArticles
{
    public class GetMyArticlesHandler : IRequestHandler<GetMyArticlesRequest, GetMyArticlesViewModel>
    {
        private readonly INewsyDbContext _context;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public GetMyArticlesHandler(INewsyDbContext context, ICurrentUserAccessor currentUserAccessor)
        {
            _context = context;
            _currentUserAccessor = currentUserAccessor;
        }
        public async Task<GetMyArticlesViewModel> Handle(GetMyArticlesRequest request, CancellationToken cancellationToken)
        {

            var res = new GetMyArticlesViewModel();

            var query =
                _context.AppUserArticles
                .AsNoTracking()
                .Include(i => i.Article)
                .Include(a => a.AppUser)
                .Where(x => x.AppUserId == _currentUserAccessor.GetUserId());

            query = query.PaginateQuery(request.PageSize, request.CurrentPage, res);

            var myArticles = await query.Select(x => x.Map(new GetAllArticlesViewModel()))
                .ToListAsync(cancellationToken);

            res.Data.AddRange(myArticles);

            return res;
        }
    }
}
