using MediatR;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Newsy.Application.Shared.Interfaces;

namespace Newsy.Application.Articles.Commands.UpdateMyArticle
{
    public class UpdateMyArticleHandler : IRequestHandler<UpdateMyArticleRequest, UpdateMyArticleViewModel>
    {
        private readonly INewsyDbContext _context;
        private readonly ICurrentUserAccessor _currentUserAccessor;
        public UpdateMyArticleHandler(INewsyDbContext context, ICurrentUserAccessor currentUserAccessor)
        {
            _context = context;
            _currentUserAccessor = currentUserAccessor;
        }
        public async Task<UpdateMyArticleViewModel> Handle(UpdateMyArticleRequest request, CancellationToken cancellationToken)
        {
            var myArticle =
                 _context.Articles
                .FirstOrDefault(x => x.Id == request.ArticleId);

            if (request.Archive.HasValue)
                myArticle.Archived = request.Archive.Value;
            myArticle.Content = request.Content;
            myArticle.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateMyArticleViewModel()
            {
                ArticleId = myArticle.Id
            };
        }
    }
}
