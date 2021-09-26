using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application
{
    public class ListedViewModel<T> : IListedViewModel
    {
        public ListedViewModel()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
