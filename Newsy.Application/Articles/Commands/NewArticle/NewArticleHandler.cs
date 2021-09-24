using MediatR;
using Newsy.Application.Shared.Interfaces;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Articles.Commands.NewArticle
{
    public class NewArticleHandler : IRequestHandler<NewArticleRequest, NewArticleViewModel>
    {
        private readonly INewsyDbContext _context;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public NewArticleHandler(INewsyDbContext context, ICurrentUserAccessor currentUserAccessor)
        {
            _context = context;
            _currentUserAccessor = currentUserAccessor;
        }

        public async Task<NewArticleViewModel> Handle(NewArticleRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid articleId = Guid.NewGuid();
                    Article article = new Article()
                    {
                        Id = articleId,
                        Title = request.Title,
                        Content = request.Content
                    };

                    _context.Articles.Add(article);
                    _context.AppUserArticles.Add(new AppUserArticle() { ArticleId = articleId, AppUserId = _currentUserAccessor.GetUserId() });

                    await _context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);

                    return new NewArticleViewModel()
                    {
                        ArticleId = articleId
                    };
                }
                catch 
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }
    }
}
