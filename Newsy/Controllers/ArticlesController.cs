using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Application.Articles.Commands.NewArticle;
using Newsy.Application.Articles.Queries.AllArticles;
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

        [HttpGet("allArticles")]
        public async Task<ActionResult<AllArticlesViewModel>> GetAllArticles()
        {
            AllArticlesRequest request = new AllArticlesRequest();
            AllArticlesViewModel res = await Mediator.Send(request);

            return Ok(res);
        }

        //articles by id and my articles

        //update artice

        //archive article
    }
}
