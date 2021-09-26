using ExpressMapper;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newsy.Domain.ViewModels.Articles
{
    public class GetAllArticlesViewModelMapper : IMapperRegistrator
    {
        public void RegisterMappings()
        {
            Mapper.Register<AppUserArticle, GetAllArticlesViewModel>()
                    .Member(dest => dest.ArticleId, src => src.ArticleId)
                    .Member(dest => dest.Title, src => src.Article.Title)
                    .Member(dest => dest.Content, src => src.Article.Content)
                    .Member(dest => dest.AuthorName, src => src.AppUser.LastName);
            ;
        }
    }
}
