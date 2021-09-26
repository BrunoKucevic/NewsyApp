using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newsy.Application.Shared.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> PaginateQuery<T>(this IQueryable<T> query, int pageSize, int currentPage, IListedViewModel result) where T : class
        {
            CalculateRowsAndPages(query, ref currentPage, ref pageSize, result);

            return query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private static void CalculateRowsAndPages<TEntity>(IQueryable<TEntity> query, ref int page, ref int pageSize, IListedViewModel result) where TEntity : class
        {
            if (page == 0 || pageSize == 0)
            {
                page = 1;
                pageSize = 50;
            }

            result.PageSize = pageSize;
            result.CurrentPage = page;
            result.TotalRows = query.Count();
            result.TotalPages = (int)Math.Ceiling((double)result.TotalRows / pageSize);
        }
    }
}
