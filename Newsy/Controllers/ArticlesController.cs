using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Application.Articles.Commands.NewArticle;
using Newsy.Application.Articles.Queries.AllArticles;
using Newsy.Application.Articles.Queries.GetMyArticles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        [HttpPost("newArticle")]
        [Authorize(Roles = "Author")]
        public async Task<ActionResult<NewArticleViewModel>> NewArticle ([FromBody] NewArticleRequest request)
        {
            NewArticleViewModel res = await Mediator.Send(request);


            return Ok(res);
        }

        [HttpPost("allArticles")]
        public async Task<ActionResult<AllArticlesViewModel>> GetAllArticles([FromBody] AllArticlesRequest request)
        {
            AllArticlesViewModel res = await Mediator.Send(request);

            return Ok(res);
        }

        //articles by id and my articles
        [HttpPost("myArticles")]
        [Authorize(Roles = "Author")]
        public async Task<ActionResult<GetMyArticlesViewModel>> GetMyArticles([FromBody] GetMyArticlesRequest request)
        {
            GetMyArticlesViewModel res = await Mediator.Send(request);

            return Ok(res);
        }

        //update artice

        //archive article
    }
}
